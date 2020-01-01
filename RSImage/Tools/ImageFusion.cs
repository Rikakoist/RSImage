using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using OSGeo.GDAL;

namespace RSImage.Tools
{
    /// <summary>
    /// 影像融合。
    /// </summary>
    class ImageFusion
    {
        /// <summary>
        /// Brovey变换融合。融合前会将多光谱数据集的每一波段与全色数据集做直方图匹配。
        /// </summary>
        /// <param name="PanDS">全色数据集。</param>
        /// <param name="MSDS">多光谱数据集</param>
        /// <param name="PanCumu">全色数据集的累积概率表。</param>
        /// <param name="MSCumu">多光谱数据集的累积概率表。</param>
        /// <param name="MSBandList">多光谱数据集的波段组合。</param>
        /// <param name="OutDataType">输出数据类型。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool Brovey(OSGeo.GDAL.Dataset PanDS, OSGeo.GDAL.Dataset MSDS, double[][] PanCumu, double[][] MSCumu, int[] MSBandList, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (PanDS == null)
                    throw new ArgumentNullException("输入的全色数据集为空。");
                if (PanDS.RasterCount > 1)
                    throw new RankException("全色数据集波段大于1。");
                if (MSDS == null)
                    throw new ArgumentNullException("输入的多光谱数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int panWidth = PanDS.RasterXSize;
                int panHeight = PanDS.RasterYSize;
                int msWidth = MSDS.RasterXSize;
                int msHeight = MSDS.RasterYSize;
                //int rat = (int)Math.Ceiling((double)panHeight / msHeight);

                if (panWidth < msWidth)
                    throw new RankException("全色数据集宽度小于多光谱数据集宽度。");
                if (panHeight < msHeight)
                    throw new RankException("全色数据集高度小于多光谱数据集高度。");
                //if (rat <= 0)
                //    throw new ArgumentOutOfRangeException("全色高度：多光谱高度小于1。");

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行Brovey融合...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                #region 预处理
                //创建临时文件，进行直方图匹配。
                string HisMatFileName = Tools.Common.GetTempFileName();
                OSGeo.GDAL.Dataset MatchingDS = Dri.CreateCopy(HisMatFileName, MSDS, 0, null, null, null);
                FP.Output("已创建直方图匹配临时文件\"" + HisMatFileName + "\"");
                for (int band = 1; band <= MSDS.RasterCount; band++)
                {
                    FP.Output("正在进行直方图匹配(" + band.ToString() + "/" + MSDS.RasterCount.ToString() + ")...");
                    Band b = Tools.BaseProcess.HistogramMatching(MSDS.GetRasterBand(band), PanDS.GetRasterBand(1), MSCumu[band - 1], PanCumu[0], OutDataType);
                    if (b == null)
                        throw new ArgumentNullException("直方图匹配返回波段为空。");
                    for (int row = 0; row < b.YSize; row++)
                    {
                        double[] tmp = new double[b.XSize];
                        b.ReadRaster(0, row, b.XSize, 1, tmp, b.XSize, 1, 0, 0);
                        MatchingDS.GetRasterBand(band).WriteRaster(0, row, MatchingDS.GetRasterBand(band).XSize, 1, tmp, MatchingDS.GetRasterBand(band).XSize, 1, 0, 0);
                        MatchingDS.FlushCache();
                        Thread.Sleep(1);
                    }
                }

                //创建临时文件，进行重采样。
                double[] resamptmp;
                string ResampFileName = Tools.Common.GetTempFileName();
                OSGeo.GDAL.Dataset ResampDS = Dri.Create(ResampFileName, panWidth, panHeight, 3, MSDS.GetRasterBand(1).DataType, null);
                FP.Output("已创建重采样临时文件\"" + ResampFileName + "\"");
                //Tools.Common.CopyMetadata(PanDS, tmpDS);
                //Gdal.ReprojectImage(MSDS, tmpDS, null, null, 0, 0, 0, null, null);

                //将直方图匹配后的图像重采样。
                for (int i = 0; i < 3; i++)
                {
                    FP.Output("正在对直方图匹配后影像进行重采样(" + (i + 1).ToString() + "/" + "3)...");
                    resamptmp = new double[panWidth * panHeight];
                    MatchingDS.GetRasterBand(MSBandList[i]).ReadRaster(0, 0, msWidth, msHeight, resamptmp, panWidth, panHeight, 0, 0);
                    ResampDS.GetRasterBand(i + 1).WriteRaster(0, 0, panWidth, panHeight, resamptmp, panWidth, panHeight, 0, 0);
                    ResampDS.FlushCache();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                //释放直方图匹配图像资源。
                MatchingDS.Dispose();
                if (File.Exists(HisMatFileName))
                    File.Delete(HisMatFileName);
                FP.Output("已删除直方图匹配临时文件");
                #endregion

                //创建输出数据集。
                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, panWidth, panHeight, 3, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(PanDS, DS);

                double[] p;
                double[][] ms;
                double[] ds;

                for (int row = 0; row < panHeight; row++)
                {
                    FP.SetProgress2("正在处理", row + 1, panHeight, "行");
                    //将全色波段行读取进数组。
                    p = new double[panWidth];
                    PanDS.GetRasterBand(1).ReadRaster(0, row, panWidth, 1, p, panWidth, 1, 0, 0);

                    //将重采样后的多光谱行读取进数组。
                    ms = new double[3][];
                    ms[0] = new double[panWidth];
                    ms[1] = new double[panWidth];
                    ms[2] = new double[panWidth];
                    ResampDS.GetRasterBand(1).ReadRaster(0, row, panWidth, 1, ms[0], panWidth, 1, 0, 0);
                    ResampDS.GetRasterBand(2).ReadRaster(0, row, panWidth, 1, ms[1], panWidth, 1, 0, 0);
                    ResampDS.GetRasterBand(3).ReadRaster(0, row, panWidth, 1, ms[2], panWidth, 1, 0, 0);

                    //遍历三波段
                    for (int bandcount = 0; bandcount < 3; bandcount++)
                    {
                        FP.SetProgress1("正在处理", bandcount + 1, 3, "波段");
                        ds = new double[panWidth];  //临时数组
                        for (long i = 0; i < panWidth; i++)
                        {
                            ds[i] = p[i] * ms[bandcount][i] / (ms[0][i] + ms[1][i] + ms[2][i]); //Brovey公式
                        }
                        DS.GetRasterBand(bandcount + 1).WriteRaster(0, row, panWidth, 1, ds, panWidth, 1, 0, 0);    //计算完后的数据写入
                        DS.FlushCache();
                    }
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                //释放重采样图像资源。
                ResampDS.Dispose();
                if (File.Exists(ResampFileName))
                    File.Delete(ResampFileName);
                FP.Output("已删除重采样临时文件");

                /*一次性读取一时爽，遇到大文件爆内存。
                  一次性读取一时爽，遇到大文件爆内存。
                  一次性读取一时爽，遇到大文件爆内存。*/
                //p = new double[panWidth * panHeight];
                //ms = new double[3][];
                //ms[0] = new double[panWidth * panHeight];
                //ms[1] = new double[panWidth * panHeight];
                //ms[2] = new double[panWidth * panHeight];

                //PanDS.GetRasterBand(1).ReadRaster(0, 0, panWidth, panHeight, p, panWidth, panHeight, 0, 0);
                //MSDS.GetRasterBand(MSBandList[0]).ReadRaster(0, 0, msWidth, msHeight, ms[0], panWidth, panHeight, 0, 0);
                //MSDS.GetRasterBand(MSBandList[1]).ReadRaster(0, 0, msWidth, msHeight, ms[1], panWidth, panHeight, 0, 0);
                //MSDS.GetRasterBand(MSBandList[2]).ReadRaster(0, 0, msWidth, msHeight, ms[2], panWidth, panHeight, 0, 0);

                //for (int bandcount = 0; bandcount < 3; bandcount++)
                //{
                //    ds = new double[panWidth * panHeight];
                //    for (int row = 0; row < panHeight; row++)
                //    {
                //        for (int col = 0; col < panWidth; col++)
                //        {
                //            ds[row * panWidth + col] = p[row * panWidth + col] * ms[bandcount][row * panWidth + col] / (ms[0][row * panWidth + col] + ms[1][row * panWidth + col] + ms[2][row * panWidth + col]);
                //        }
                //    }
                //    DS.GetRasterBand(bandcount + 1).WriteRaster(0, 0, panWidth, panHeight, ds, panWidth, panHeight, 0, 0);
                //    DS.FlushCache();
                //}
                
                FP.Finish();
                Dri.Dispose();
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
        /// IHS融合。融合前会将全色数据集与多光谱数据集转换到IHS空间下的I波段做直方图匹配。
        /// </summary>
        /// <param name="PanDS">全色数据集。</param>
        /// <param name="MSDS">多光谱数据集</param>
        /// <param name="PanCumu">全色数据集的累积概率表。</param>
        /// <param name="MSCumu">多光谱数据集的累积概率表。</param>
        /// <param name="MSBandList">多光谱数据集的波段组合。</param>
        /// <param name="OutDataType">输出数据类型。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool IHSFusion(OSGeo.GDAL.Dataset PanDS, OSGeo.GDAL.Dataset MSDS, double[][] PanCumu, double[][] MSCumu, int[] MSBandList, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (PanDS == null)
                    throw new ArgumentNullException("输入的全色数据集为空。");
                if (PanDS.RasterCount > 1)
                    throw new RankException("全色数据集波段大于1。");
                if (MSDS == null)
                    throw new ArgumentNullException("输入的多光谱数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int panWidth = PanDS.RasterXSize;
                int panHeight = PanDS.RasterYSize;
                int msWidth = MSDS.RasterXSize;
                int msHeight = MSDS.RasterYSize;

                if (panWidth < msWidth)
                    throw new RankException("全色数据集宽度小于多光谱数据集宽度。");
                if (panHeight < msHeight)
                    throw new RankException("全色数据集高度小于多光谱数据集高度。");

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行IHS融合...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                #region 预处理
                //创建临时文件，进行重采样。
                double[] resamptmp;
                string ResampFileName = Tools.Common.GetTempFileName();
                OSGeo.GDAL.Dataset ResampDS = Dri.Create(ResampFileName, panWidth, panHeight, MSDS.RasterCount, MSDS.GetRasterBand(1).DataType, null);
                FP.Output("已创建重采样临时文件\"" + ResampFileName + "\"");

                //将多光谱影像重采样。
                for (int i = 0; i < 3; i++)
                {
                    FP.Output("正在进行重采样(" + (i + 1).ToString() + "/" + "3)...");
                    resamptmp = new double[panWidth * panHeight];
                    MSDS.GetRasterBand(MSBandList[i]).ReadRaster(0, 0, msWidth, msHeight, resamptmp, panWidth, panHeight, 0, 0);
                    ResampDS.GetRasterBand(i + 1).WriteRaster(0, 0, panWidth, panHeight, resamptmp, panWidth, panHeight, 0, 0);
                    ResampDS.FlushCache();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }

                double[] BandMax = new double[3];
                double[] BandMin = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    FP.Output("正在计算重采样影像统计数据(" + (i + 1).ToString() + "/" + "3)...");
                    Common.ComputeRasterMinMax(ResampDS.GetRasterBand(i + 1), out BandMin[i], out BandMax[i]);
                }
                #endregion

                //多光谱RGB转IHS。
                string MSIHSFileName = Tools.Common.GetTempFileName();
                OSGeo.GDAL.Dataset MSIHSDS = Dri.Create(MSIHSFileName, panWidth, panHeight, 3, OSGeo.GDAL.DataType.GDT_Float32, null);
                FP.Output("已创建IHS临时文件\"" + MSIHSFileName + "\"");

                //按行读入，进行拉伸后再IHS转换，写入。
                for (int row = 0; row < panHeight; row++)
                {
                    FP.SetProgress1("正在处理IHS临时文件(", row + 1, panHeight, ")");
                    double[] iArr = new double[panWidth];
                    double[] hArr = new double[panWidth];
                    double[] sArr = new double[panWidth];
                    double[][] MSRGBArr = new double[3][];
                    MSRGBArr[0] = new double[panWidth];
                    MSRGBArr[1] = new double[panWidth];
                    MSRGBArr[2] = new double[panWidth];
                    //读。
                    ResampDS.GetRasterBand(1).ReadRaster(0, row, panWidth, 1, MSRGBArr[0], panWidth, 1, 0, 0);
                    ResampDS.GetRasterBand(2).ReadRaster(0, row, panWidth, 1, MSRGBArr[1], panWidth, 1, 0, 0);
                    ResampDS.GetRasterBand(3).ReadRaster(0, row, panWidth, 1, MSRGBArr[2], panWidth, 1, 0, 0);
                    //按行逐像元转IHS。
                    for (long i = 0; i < panWidth; i++)
                    {
                        double[] tmp = Common.RGB2IHS(
                            new double[3] {
                             Common.LinearStretchDouble(MSRGBArr[0][i], BandMin[0], BandMax[0]),
                             Common.LinearStretchDouble(MSRGBArr[1][i], BandMin[1], BandMax[1]),
                             Common.LinearStretchDouble(MSRGBArr[2][i], BandMin[2], BandMax[2])
                        });
                        iArr[i] = tmp[0]; hArr[i] = tmp[1]; sArr[i] = tmp[2];
                    }
                    //写。
                    MSIHSDS.GetRasterBand(1).WriteRaster(0, row, panWidth, 1, iArr, panWidth, 1, 0, 0);
                    MSIHSDS.GetRasterBand(2).WriteRaster(0, row, panWidth, 1, hArr, panWidth, 1, 0, 0);
                    MSIHSDS.GetRasterBand(3).WriteRaster(0, row, panWidth, 1, sArr, panWidth, 1, 0, 0);
                    MSIHSDS.FlushCache();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                //释放重采样数据集资源。
                ResampDS.Dispose();
                if (File.Exists(ResampFileName))
                    File.Delete(ResampFileName);
                FP.Output("已删除重采样临时文件");

                //全色匹配多光谱I
                FP.Output("正在计算IHS统计数据...");
                Common.GetStatistics(MSIHSDS.GetRasterBand(1), out double Imin, out double Imax, out double Imean, out double Istddev);   //多光谱统计信息。
                int[] IHis = new int[(int)(Imax - Imin) + 1];
                MSIHSDS.GetRasterBand(1).GetHistogram(Imin, Imax, (int)(Imax - Imin) + 1, IHis, 1, 0, null, null);
                double[] ICumu = new double[IHis.Length];
                for (int i = 0; i < IHis.Length; i++)
                {
                    ICumu[i] = (double)IHis[i] / (MSIHSDS.RasterXSize * MSIHSDS.RasterYSize);
                    if (i > 0)
                    {
                        ICumu[i] += ICumu[i - 1];   //累积概率
                    }
                }
                FP.Output("正在进行I波段直方图匹配...");
                Band PanMatIBand = Tools.BaseProcess.HistogramMatching(PanDS.GetRasterBand(1), MSIHSDS.GetRasterBand(1), PanCumu[0], ICumu, OSGeo.GDAL.DataType.GDT_Float32);
                if (PanMatIBand == null)
                    throw new ArgumentNullException("直方图匹配返回波段为空。");
                //全色融合。
                //创建输出数据集。
                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, panWidth, panHeight, 3, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(PanDS, DS);
                for (int row = 0; row < panHeight; row++)
                {
                    FP.SetProgress1("正在融合(", row + 1, panHeight, ")");
                    //读取匹配多光谱I后的全色波段。
                    double[] Itmp = new double[panWidth];
                    PanMatIBand.ReadRaster(0, row, panWidth, 1, Itmp, panWidth, 1, 0, 0);

                    //读入IHS变换后的多光谱影像的H、S波段。
                    double[] Htmp = new double[panWidth];
                    double[] Stmp = new double[panWidth];
                    MSIHSDS.GetRasterBand(2).ReadRaster(0, row, panWidth, 1, Htmp, panWidth, 1, 0, 0);
                    MSIHSDS.GetRasterBand(3).ReadRaster(0, row, panWidth, 1, Stmp, panWidth, 1, 0, 0);

                    double[] Rtmp = new double[panWidth];
                    double[] Gtmp = new double[panWidth];
                    double[] Btmp = new double[panWidth];
                    for (long i = 0; i < panWidth; i++)
                    {
                        double[] tmp = Common.IHS2RGB(new double[3] { Itmp[i], Htmp[i], Stmp[i] });
                        Rtmp[i] = tmp[0]; Gtmp[i] = tmp[1]; Btmp[i] = tmp[2];
                    }
                    DS.GetRasterBand(1).WriteRaster(0, row, panWidth, 1, Rtmp, panWidth, 1, 0, 0);
                    DS.GetRasterBand(2).WriteRaster(0, row, panWidth, 1, Gtmp, panWidth, 1, 0, 0);
                    DS.GetRasterBand(3).WriteRaster(0, row, panWidth, 1, Btmp, panWidth, 1, 0, 0);
                    DS.FlushCache();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                //释放IHS图像资源。
                MSIHSDS.Dispose();
                PanMatIBand.Dispose();
                if (File.Exists(MSIHSFileName))
                    File.Delete(MSIHSFileName);
                FP.Output("已删除IHS临时文件");
                
                FP.Finish();
                Dri.Dispose();
                DS.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }
    }
}
