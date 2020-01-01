using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage.Tools
{
    /// <summary>
    /// 影像分类
    /// </summary>
    class ImageClassification
    {
        /// <summary>
        /// 聚类中心
        /// </summary>
        public class ClusterCenter
        {
            public int BandNum;
            public double[] OldCenter = null;
            public double[] NewCenter = null;
            public double[] CenterTotal = null;
            public double[] CenterMean = null;
            public double[] CenterStddev = null;
            public double MaxStddev = 0.0;
            public List<double[]> CenterList = null;

            public double PixelCount = 0;

            public ClusterCenter(int BandNum)
            {
                this.BandNum = BandNum;
                OldCenter = new double[BandNum];
                NewCenter = new double[BandNum];
                CenterTotal = new double[BandNum];
                CenterList = new List<double[]>();
            }

            /// <summary>
            /// 由两个聚类中心合并产生一个新的聚类中心。
            /// </summary>
            /// <param name="C1">聚类中心1。</param>
            /// <param name="C2">聚类中心2。</param>
            public ClusterCenter(ClusterCenter C1, ClusterCenter C2)
            {
                if (C1.BandNum != C2.BandNum)
                    throw new RankException("需要进行合并的两类中心拥有不相等的波段数。");
                this.BandNum = C1.BandNum;
                OldCenter = new double[BandNum];
                NewCenter = new double[BandNum];
                for (int band = 0; band < BandNum; band++)
                {
                    OldCenter[band] = NewCenter[band] = (C1.NewCenter[band] + C2.NewCenter[band]) / 2;
                }
                CenterTotal = new double[BandNum];
                CenterList = new List<double[]>();
            }

            public void ResetAll()
            {
                ResetCenterList();
                ResetTotal();
                ResetMean();
                ResetStddev();
            }

            public void ResetCenterList()
            {
                CenterList.Clear();
            }

            public void ResetTotal()
            {
                CenterTotal = new double[BandNum];
                Array.Clear(CenterTotal, 0, CenterTotal.Length);
            }

            public void ResetMean()
            {
                CenterMean = new double[BandNum];
                Array.Clear(CenterMean, 0, CenterMean.Length);
            }

            public void ResetStddev()
            {
                CenterStddev = new double[BandNum];
                Array.Clear(CenterStddev, 0, CenterStddev.Length);
            }

            /// <summary>
            /// 获取该类下所有像元（分波段）的和。
            /// </summary>
            public void GetTotal()
            {
                ResetTotal();
                foreach (double[] pix in CenterList)
                {
                    for(int band=0;band<BandNum;band++)
                    {
                        CenterTotal[band] += pix[band];
                    }
                }
            }

            /// <summary>
            /// 获取该类下所有像元（分波段）的平均值。
            /// </summary>
            public void GetMean()
            {
                ResetMean();
                for (int band = 0; band < BandNum; band++)
                {
                    CenterMean[band] = CenterTotal[band] / PixelCount;
                }
            }

            /// <summary>
            /// 获取该类下所有像元（分波段）的标准差。
            /// </summary>
            public void GetStddev()
            {
                GetTotal();
                GetMean();
                ResetStddev();
                foreach(double[] pix in CenterList)
                {
                    for (int band = 0; band < BandNum; band++)
                    {
                        CenterStddev[band] += Math.Pow(pix[band]-CenterMean[band], 2);
                    }
                }
                for (int band = 0; band < BandNum; band++)
                {
                    CenterStddev[band] = Math.Sqrt(CenterStddev[band] / PixelCount);
                }
                GetMaxStddev();
            }

            /// <summary>
            /// 获取最大类内方差。
            /// </summary>
            public void GetMaxStddev()
            {
                MaxStddev = CenterStddev[0];
                for(int band=1;band<BandNum;band++)
                {
                    if (CenterStddev[band] > MaxStddev)
                        MaxStddev = CenterStddev[band];
                }
            }
        }

        /// <summary>
        /// K-Means算法。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="Kind">分类数。</param>
        /// <param name="MaxItera">最大迭代次数。</param>
        /// <param name="CenterDiff">聚类中心变化率阈值。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool KMeans(OSGeo.GDAL.Dataset InputDS, int Kind, int MaxItera, double CenterDiff, string OutPath)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int bandNum = InputDS.RasterCount;
                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行K-Means分类...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, 1, OSGeo.GDAL.DataType.GDT_Byte, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为GDT_Byte。");
                Tools.Common.CopyMetadata(InputDS, DS);

                int tmpItera = 0;
                bool tmpContinue = true;

                double[] min = new double[bandNum];
                double[] max = new double[bandNum];
                double[] mean = new double[bandNum];
                double[] stddev = new double[bandNum];
                ClusterCenter[] KCenter = new ClusterCenter[Kind];

                //计算数据集各波段统计数据
                for (int i = 0; i < bandNum; i++)
                {
                    Tools.Common.GetStatistics(InputDS.GetRasterBand(i + 1), out min[i], out max[i], out mean[i], out stddev[i]);
                }

                //初始化聚类中心
                for (int i = 0; i < Kind; i++)
                {
                    KCenter[i] = new ClusterCenter(bandNum);
                    for (int band = 0; band < bandNum; band++)
                    {
                        KCenter[i].NewCenter[band] = KCenter[i].OldCenter[band] = mean[band] + stddev[band] - 2 * i * stddev[band] / Kind;
                    }
                }

                //循环体
                while (tmpContinue)
                {
                    FP.Output("正在迭代第" + (tmpItera+1).ToString() + "次...");
                    FP.SetProgress2("正在迭代：", tmpItera + 1, MaxItera, "次");
                    //重置所有类的像元计数为1
                    for (int i = 0; i < Kind; i++)
                        KCenter[i].PixelCount = 1;

                    for (int i = 0; i < Kind; i++)
                    {
                        string tmpCenter = "第" + (i + 1).ToString() + "类中心：\r\n";
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpCenter += "\t第" + (band + 1).ToString() + "波段中心：" + KCenter[i].OldCenter[band] + "\r\n";
                        }
                        FP.Output(tmpCenter);
                    }

                    //遍历数据集每一行
                    for (int row = 0; row < ySize; row++)
                    {
                        FP.SetProgress1("正在处理：", row + 1, ySize, "行");
                        double[][] tmpInput = new double[bandNum][];    //用于存储输入像元的交错数组

                        //将一行的所有波段像元值读取入交错数组
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpInput[band] = new double[xSize];
                            InputDS.GetRasterBand(band + 1).ReadRaster(0, row, xSize, 1, tmpInput[band], xSize, 1, 0, 0);
                        }

                        byte[] tmpOut = new byte[xSize];    //用于存储输出像元的数组

                        //遍历一行的每一列，对像元分类
                        for (int col = 0; col < xSize; col++)
                        {
                            double[] tmpPix = new double[bandNum];  //临时存储单个像元所有波段的数组

                            //将指定行列的所有波段像元转储到数组
                            for (int band = 0; band < bandNum; band++)
                            {
                                tmpPix[band] = tmpInput[band][col];
                            }

                            double[] tmpDis = new double[Kind]; //单个像元到不同聚类中心的距离数组

                            //计算像元到不同聚类中心的距离
                            for (int i = 0; i < Kind; i++)
                            {
                                tmpDis[i] = Distance(tmpPix, KCenter[i].OldCenter);
                            }

                            double tmpMinDis = tmpDis[0];   //最小距离
                            int tmpClass = 0; //分类

                            //计算最小值及分类
                            for (int i = 1; i < Kind; i++)
                            {
                                if (tmpDis[i] < tmpMinDis)
                                {
                                    tmpMinDis = tmpDis[i];
                                    tmpClass = i;
                                }
                            }

                            //更新聚类中心
                            for (int band = 0; band < bandNum; band++)
                            {
                                KCenter[tmpClass].NewCenter[band] = (KCenter[tmpClass].NewCenter[band] * KCenter[tmpClass].PixelCount + tmpPix[band]) / (KCenter[tmpClass].PixelCount + 1);
                            }

                            //写入分类并增加对应类的像元计数
                            tmpOut[col] = (byte)(tmpClass + 1);
                            KCenter[tmpClass].PixelCount += 1;
                        }
                        DS.GetRasterBand(1).WriteRaster(0, row, xSize, 1, tmpOut, xSize, 1, 0, 0);
                        DS.FlushCache();
                        Thread.Sleep(1);
                        if (FP.Canceled)
                        {
                            Thread.Sleep(500);
                            
                            FP.Finish();
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }

                    for (int i = 0; i < Kind; i++)
                    {
                        string tmpCenter = "聚类后第" + (i + 1).ToString() + "类：\r\n\t新中心：";
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpCenter += KCenter[i].NewCenter[band] + ", ";
                        }
                        FP.Output(tmpCenter);
                    }

                    double[] tmpCenterChange = new double[Kind];
                    //计算聚类中心变化率
                    for (int i = 0; i < Kind; i++)
                    {
                        for (int band = 0; band < bandNum; band++)
                        {
                            if (Math.Abs(KCenter[i].OldCenter[band]) <= 1e-7)   //分母为0
                            {
                                tmpCenterChange[i] += Math.Abs(KCenter[i].NewCenter[band] - KCenter[i].OldCenter[band]) / 0.0001;
                            }
                            else
                            {
                                tmpCenterChange[i] += Math.Abs(KCenter[i].NewCenter[band] - KCenter[i].OldCenter[band]) / KCenter[i].OldCenter[band];
                            }
                        }
                        tmpCenterChange[i] /= bandNum;
                    }

                    //计算最大变化率
                    double tmpCenterChangeMax = tmpCenterChange[0];
                    for (int i = 1; i < Kind; i++)
                    {
                        if (tmpCenterChange[i] > tmpCenterChangeMax)
                        {
                            tmpCenterChangeMax = tmpCenterChange[i];
                        }
                    }

                    FP.Output("中心变化率：" + tmpCenterChangeMax+"，阈值："+ CenterDiff);
                    FP.SetProgress1("最大中心变化率：", CenterDiff, tmpCenterChangeMax, "");

                    //将新的中心变为旧的中心，准备开始新一轮迭代
                    for (int i = 0; i < Kind; i++)
                    {
                        for (int band = 0; band < bandNum; band++)
                        {
                            KCenter[i].OldCenter[band] = KCenter[i].NewCenter[band];
                        }
                    }

                    tmpItera++;

                    //判断是否继续循环
                    if (((MaxItera > 1) && (tmpItera > MaxItera)) || (tmpCenterChangeMax < CenterDiff) || (tmpItera > 10000))
                    {
                        tmpContinue = false;
                    }
                }
                
                FP.Finish();
                DS.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        /// <summary>
        /// ISO Data分类算法。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="MinKind">最小分类数。</param>
        /// <param name="MaxKind">最大分类数。</param>
        /// <param name="MaxItera">最大迭代次数。</param>
        /// <param name="CenterDiff">最大中心变化率</param>
        /// <param name="MinPixelNumInClass">类内最小像元数。</param>
        /// <param name="MaxClassStddev">最大类内标准差</param>
        /// <param name="MinClassDist">最小类间距离。</param>
        /// <param name="OutPath">结果数据集输出路径。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool IsoData(OSGeo.GDAL.Dataset InputDS, int MinKind, int MaxKind, int MaxItera, double CenterDiff, int MinPixelNumInClass, double MaxClassStddev, double MinClassDist, string OutPath)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int bandNum = InputDS.RasterCount;
                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行ISO Data分类...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, 1, OSGeo.GDAL.DataType.GDT_Byte, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为GDT_Byte。");
                Tools.Common.CopyMetadata(InputDS, DS);

                int tmpItera = 1;
                bool tmpContinue = true;

                double[] min = new double[bandNum];
                double[] max = new double[bandNum];
                double[] mean = new double[bandNum];
                double[] stddev = new double[bandNum];
                int InitKind = (MinKind + MaxKind) / 2;
                List<ClusterCenter> ICenter = new List<ClusterCenter>();

                //计算数据集各波段统计数据
                for (int i = 0; i < bandNum; i++)
                {
                    Tools.Common.GetStatistics(InputDS.GetRasterBand(i + 1), out min[i], out max[i], out mean[i], out stddev[i]);
                }

                //初始化聚类中心
                for (int i = 0; i < InitKind; i++)
                {
                    ICenter.Add(new ClusterCenter(bandNum));
                    for (int band = 0; band < bandNum; band++)
                    {
                        ICenter[i].NewCenter[band] = ICenter[i].OldCenter[band] = mean[band] + stddev[band] - 2 * i * stddev[band] / InitKind;
                    }
                }

                //循环体
                while (tmpContinue)
                {
                    FP.Output("正在迭代第" + tmpItera.ToString() + "次...");
                    FP.SetProgress2("正在迭代：", tmpItera, MaxItera, "次");
                    //清空所有聚类中心的和、平均值、标准差、像元列表
                    foreach (ClusterCenter C in ICenter)
                    {
                        C.ResetAll();
                    }

                    //重置所有类的像元计数为0
                    for (int i = 0; i < ICenter.Count; i++)
                        ICenter[i].PixelCount = 0;

                    for (int i = 0; i < ICenter.Count; i++)
                    {
                        string tmpCenter = "第" + (i + 1).ToString() + "类中心：";
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpCenter += ICenter[i].OldCenter[band] + ", ";
                        }
                        FP.Output(tmpCenter);
                    }

                    //遍历数据集每一行
                    for (int row = 0; row < ySize; row++)
                    {
                        FP.SetProgress1("正在处理：", row + 1, ySize, "行");
                        double[][] tmpInput = new double[bandNum][];    //用于存储输入像元的交错数组

                        //将一行的所有波段像元值读取入交错数组
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpInput[band] = new double[xSize];
                            InputDS.GetRasterBand(band + 1).ReadRaster(0, row, xSize, 1, tmpInput[band], xSize, 1, 0, 0);
                        }

                        byte[] tmpOut = new byte[xSize];    //用于存储输出像元的数组

                        //遍历一行的每一列，对像元分类
                        for (int col = 0; col < xSize; col++)
                        {
                            double[] tmpPix = new double[bandNum];  //临时存储单个像元所有波段的数组

                            //将指定行列的所有波段像元转储到数组
                            for (int band = 0; band < bandNum; band++)
                            {
                                tmpPix[band] = tmpInput[band][col];
                            }

                            double[] tmpDis = new double[ICenter.Count]; //单个像元到不同聚类中心的距离数组

                            //计算像元到不同聚类中心的距离
                            for (int i = 0; i < ICenter.Count; i++)
                            {
                                tmpDis[i] = Distance(tmpPix, ICenter[i].OldCenter);
                            }

                            double tmpMinDis = tmpDis[0];   //最小距离
                            int tmpClass = 0; //分类

                            //计算最小值及分类
                            for (int i = 1; i < ICenter.Count; i++)
                            {
                                if (tmpDis[i] < tmpMinDis)
                                {
                                    tmpMinDis = tmpDis[i];
                                    tmpClass = i;
                                }
                            }

                            //将该像元添加到对应聚类的列表中
                             ICenter[tmpClass].CenterList.Add(tmpPix);

                            //写入分类并增加对应类的像元计数
                            tmpOut[col] = (byte)(tmpClass + 1);
                            ICenter[tmpClass].PixelCount+=1;
                        }
                        DS.GetRasterBand(1).WriteRaster(0, row, xSize, 1, tmpOut, xSize, 1, 0, 0);
                        DS.FlushCache();
                        Thread.Sleep(1);
                        if (FP.Canceled)
                        {
                            Thread.Sleep(500);

                            FP.Finish();
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }

                    //重新计算每个集群的均值和方差
                    foreach (ClusterCenter c in ICenter)
                    {
                        c.GetStddev();  //计算方差之前会自动求和和平均值

                        //将聚类中所有像元的平均值作为聚类的新中心？
                        for (int band = 0; band < bandNum; band++)
                        {
                            c.NewCenter[band] = c.CenterMean[band];
                        }
                    }

                    for (int i = 0; i < ICenter.Count; i++)
                    {
                        string tmpCenter = "聚类后第" + (i + 1).ToString() + "类：";
                        tmpCenter += "\r\n\t像元数："+ ICenter[i].PixelCount + ", ";
                        tmpCenter += "\r\n\t和：";
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpCenter += ICenter[i].CenterTotal[band] + ", ";
                        }
                        tmpCenter += "\r\n\t平均中心：";
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpCenter += ICenter[i].CenterMean[band] + ", ";
                        }
                        tmpCenter += "\r\n\t标准差：";
                        for (int band = 0; band < bandNum; band++)
                        {
                            tmpCenter += ICenter[i].CenterStddev[band] + ", ";
                        }
                        FP.Output(tmpCenter);
                    }

                    bool tmpCenterModified = false; //判断是否有聚类中心数量的变动

                Delete:
                    //删除像元数在阈值以下的聚类
                    for (int i = 0; i < ICenter.Count; i++)
                    {
                        if (ICenter[i].PixelCount < MinPixelNumInClass)
                        {                   
                            FP.Output("第" + (i + 1).ToString() + "类像元数只有" + ICenter[i].PixelCount.ToString() + "个，将被删除。");
                            if (ICenter.Count - 1 >= MinKind)
                            {
                                tmpCenterModified = true;
                                ICenter.RemoveAt(i);
                                goto Delete;
                            }
                            else
                            {
                                FP.Output("第" + (i + 1).ToString() + "类删除失败，已达到最小分类数。");
                                goto EndDelete;
                            }
                        }
                    }
                EndDelete:;

                    //合并与分裂
                    List<ClusterCenter> tmpChangeCenter = new List<ClusterCenter>();    //用于暂存对全局列表的更改
                    //偶次合并
                    if (tmpItera % 2 == 0)
                    {
                    Combine:
                        for (int i = 0; i < ICenter.Count; i++)
                        {
                            for (int j = 0; j < ICenter.Count; j++)
                            {
                                //不与自身比较
                                if (i == j)
                                    continue;
                                //类间距离小于设定阈值，进行合并
                                if (Distance(ICenter[i].CenterMean, ICenter[j].CenterMean) < MinClassDist)
                                {
                                    FP.Output("第" + (i + 1).ToString() + "类和第" + (j + 1).ToString() + "类的距离过小，为" + Distance(ICenter[i].CenterMean, ICenter[j].CenterMean) + "，将被合并。");
                                    if (ICenter.Count - 1 >= MinKind)
                                    {
                                        tmpCenterModified = true;
                                        tmpChangeCenter.Add(new ClusterCenter(ICenter[i], ICenter[j])); //合并两类并在临时列表中新建中心。
                                                                                                        //考虑i、j的大小，依次删除全局列表中对应索引处的中心（从大的开始删除）。
                                        if (i > j)
                                        {
                                            ICenter.RemoveAt(i);
                                            ICenter.RemoveAt(j);
                                        }
                                        else
                                        {
                                            ICenter.RemoveAt(j);
                                            ICenter.RemoveAt(i);
                                        }
                                        //每次迭代是只合并一次嘛？如果是的话就不需要goto
                                        goto Combine;
                                    }
                                    else
                                    {
                                        FP.Output("第" + (i + 1).ToString() + "类和第" + (j + 1).ToString() + "类合并失败，已达到最小分类数。");
                                        goto EndCombine;
                                    }
                                }
                            }
                        }
                    EndCombine:;
                    }
                    else   //奇次分裂
                    {
                    Split:
                        for (int i = 0; i < ICenter.Count; i++)
                        {
                            if (ICenter[i].MaxStddev > MaxClassStddev)
                            {
                                FP.Output("第" + (i + 1).ToString() + "类的类内最大方差为" + ICenter[i].MaxStddev.ToString() + "，将被分裂。");
                                if (ICenter.Count + 1 <= MaxKind)
                                {
                                    tmpCenterModified = true;
                                    ClusterCenter C1 = new ClusterCenter(bandNum);
                                    ClusterCenter C2 = new ClusterCenter(bandNum);
                                    //新建两聚类，中心为旧中心加减方差的一半
                                    //分裂后中心的参数怎么算？
                                    for (int band = 0; band < bandNum; band++)
                                    {
                                        //只改变大于标准差的中心值，若不大于则保持不变。
                                        if (ICenter[i].CenterStddev[band]>MaxClassStddev)
                                        {
                                            C1.OldCenter[band] = C1.NewCenter[band] = ICenter[i].NewCenter[band] + ICenter[i].CenterStddev[band] / 2;
                                            C2.OldCenter[band] = C2.NewCenter[band] = ICenter[i].NewCenter[band] - ICenter[i].CenterStddev[band] / 2;
                                        }
                                        else
                                        {
                                            C1.OldCenter[band] = C1.NewCenter[band] = ICenter[i].NewCenter[band];
                                            C2.OldCenter[band] = C2.NewCenter[band] = ICenter[i].NewCenter[band];
                                        }
                                        //C1.OldCenter[band] = C1.NewCenter[band] = ICenter[i].NewCenter[band] + MaxClassStddev / 2;
                                        //C2.OldCenter[band] = C2.NewCenter[band] = ICenter[i].NewCenter[band] - MaxClassStddev / 2;
                                    }
                                    tmpChangeCenter.Add(C1);
                                    tmpChangeCenter.Add(C2);
                                    ICenter.RemoveAt(i);
                                    goto Split;
                                }
                                else
                                {
                                    FP.Output("第" + (i + 1).ToString() + "类分裂失败，已达到最大分类数。");
                                    goto EndSplit;
                                }
                            }
                        }
                    EndSplit:;
                    }

                    double tmpCenterChangeMax = 100000000;
                    //仅在聚类中心数量没有变化的时候才计算中心变化率
                    if (!tmpCenterModified)
                    {
                        double[] tmpCenterChange = new double[ICenter.Count];
                        //计算聚类中心变化率
                        for (int i = 0; i < ICenter.Count; i++)
                        {
                            for (int band = 0; band < bandNum; band++)
                            {
                                if (Math.Abs(ICenter[i].OldCenter[band]) <= 1e-7)   //分母为0
                                {
                                    tmpCenterChange[i] += Math.Abs(ICenter[i].NewCenter[band] - ICenter[i].OldCenter[band]) / 0.0001;
                                }
                                else
                                {
                                    tmpCenterChange[i] += Math.Abs(ICenter[i].NewCenter[band] - ICenter[i].OldCenter[band]) / ICenter[i].OldCenter[band];
                                }
                            }
                            tmpCenterChange[i] /= bandNum;
                        }

                        //计算最大变化率
                        tmpCenterChangeMax = tmpCenterChange[0];
                        for (int i = 1; i < ICenter.Count; i++)
                        {
                            if (tmpCenterChange[i] > tmpCenterChangeMax)
                            {
                                tmpCenterChangeMax = tmpCenterChange[i];
                            }
                        }
                        FP.Output("中心变化率：" + tmpCenterChangeMax + "，阈值：" + CenterDiff);
                        FP.SetProgress1("最大中心变化率：", CenterDiff, tmpCenterChangeMax, "");
                    }
                    else
                    {
                        FP.Output("第" + tmpItera.ToString() + "次迭代出现聚类中心的合并或分裂，不计算中心变化率...");
                    }

                    //将新的中心变为旧的中心，准备开始新一轮迭代
                    for (int i = 0; i < ICenter.Count; i++)
                    {
                        for (int band = 0; band < bandNum; band++)
                        {
                            ICenter[i].OldCenter[band] = ICenter[i].NewCenter[band];
                        }
                    }

                    //将临时新建的聚类中心添加到全局聚类中心的末尾，并清空临时聚类中心
                    ICenter.AddRange(tmpChangeCenter);
                    tmpChangeCenter.Clear();

                    tmpItera++;
                    //判断是否继续循环。
                    if (tmpItera % 2 == 0)
                    {
                        if (((MaxItera > 1) && (tmpItera > MaxItera)) || (!tmpCenterModified && tmpCenterChangeMax < CenterDiff) || (tmpItera > 10000))
                        {
                            tmpContinue = false;
                        }
                    }
                }
                FP.Finish();
                DS.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        /// <summary>
        /// 计算两向量距离。
        /// </summary>
        /// <param name="V1">向量1。</param>
        /// <param name="V2">向量2。</param>
        /// <returns>向量间距离。</returns>
        public static double Distance(double[] V1, double[] V2)
        {
            if (V1.Length != V2.Length)
                throw new ArgumentException("两向量维数不相等。");
            double dis = 0.0;
            for (int i = 0; i < V1.Length; i++)
            {
                dis += Math.Pow(V2[i] - V1[i], 2);
            }
            return Math.Sqrt(dis);
        }
    }
}
