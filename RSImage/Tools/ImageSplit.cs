using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace RSImage.Tools
{
    /// <summary>
    /// 影像分割。
    /// </summary>
    class ImageSplit
    {
        /// <summary>
        /// 二值化。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="Threshold">分割阈值。</param>
        /// <param name="ZeroValue">小于阈值的像元值被设为...</param>
        /// <param name="OneValue">大于阈值的像元值被设为...</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <param name="OutPath">输出栅格数据集的位置。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool Binarize(OSGeo.GDAL.Dataset InputDS, double Threshold, double ZeroValue, double OneValue, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (InputDS.RasterCount != 1)
                    throw new ArgumentException("输入的数据集波段大于1。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行二值化操作...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, 1, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(InputDS, DS);

                for (int Row = 0; Row < ySize; Row++)
                {
                    FP.SetProgress1("正在处理：", Row + 1, ySize, "行");
                    double[] Values = new double[xSize];
                    InputDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    for (int Col = 0; Col < xSize; Col++)
                    {
                        //阈值应用
                        if (Values[Col] < Threshold)
                            Values[Col] = ZeroValue;
                        else
                            Values[Col] = OneValue;
                    }
                    DS.GetRasterBand(1).WriteRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    DS.FlushCache();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                
                FP.Finish();
                Dri.Dispose();
                DS.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        /// <summary>
        /// Otsu（最大类间方差法）寻找分割阈值。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="Divide">将最大最小值区间内分割为的份数。</param>
        /// <returns>最优阈值。</returns>
        public static double Otsu(OSGeo.GDAL.Dataset InputDS, int Divide = 256)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (InputDS.RasterCount != 1)
                    throw new ArgumentException("输入的数据集波段大于1。");

                double[] g = new double[Divide];
                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在使用Otsu法寻找分割阈值...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                FP.Output("正在计算影像统计数据...");
                Tools.Common.ComputeRasterMinMax(InputDS.GetRasterBand(1), out double Min, out double Max);
                FP.Output("最小值：" + Min.ToString() + "\r\n最大值：" + Max.ToString() + "\r\n分割段数：" + Divide.ToString());

                for (int i = 1; i <= Divide; i++)
                {
                    FP.SetProgress2("正在计算：", i, Divide, "区间");
                    double foregroundRatio = 0.0, foregroundAvg = 0.0, backgroundRatio = 0.0, backgroundAvg = 0.0;
                    int foregroundCount = 0, backgroundCount = 0;
                    double tmpThreshold = Min + (Max - Min) * ((double)i / Divide);
                    for (int row = 0; row < InputDS.RasterYSize; row++)
                    {
                        FP.SetProgress1("正在处理：", row + 1, InputDS.RasterYSize, "行");
                        double[] tmp = new double[InputDS.RasterXSize];
                        InputDS.GetRasterBand(1).ReadRaster(0, row, InputDS.RasterXSize, 1, tmp, InputDS.RasterXSize, 1, 0, 0);
                        for (int col = 0; col < InputDS.RasterXSize; col++)
                        {
                            //逐像元累加前、背景计数和总和。
                            if (ThresholdCheck(tmp[col], tmpThreshold))
                            {
                                foregroundCount++;
                                foregroundAvg += tmp[col];
                            }
                            else
                            {
                                backgroundCount++;
                                backgroundAvg += tmp[col];
                            }
                        }
                    }
                    foregroundRatio = (double)foregroundCount / (foregroundCount + backgroundCount);
                    foregroundAvg /= foregroundCount;
                    backgroundRatio = (double)backgroundCount / (foregroundCount + backgroundCount);
                    backgroundAvg /= backgroundCount;
                    double totalGrayAvg = foregroundRatio * foregroundAvg + backgroundRatio * backgroundAvg;
                    g[i - 1] = foregroundRatio * backgroundRatio * Math.Pow(foregroundAvg - backgroundAvg, 2);
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }

                //找一个最小值
                int index = 0;
                double max = -100000000;
                for (int i = 0; i < Divide; i++)
                {
                    if (g[i] > max)
                    {
                        max = g[i];
                        index = i;
                    }
                }
                
                FP.Finish();
                return Min + (Max - Min) * ((double)index / (Divide - 1));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return 0;
            }
        }

        /// <summary>
        /// 迭代阈值法寻找分割阈值。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="ThresholdDiff">前后阈值之差的变化限值，小于此值则终止循环。</param>
        /// <returns>最优阈值。</returns>
        public static double IterateThreshold(OSGeo.GDAL.Dataset InputDS, double ThresholdDiff = 1)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (InputDS.RasterCount != 1)
                    throw new ArgumentException("输入的数据集波段大于1。");

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在使用迭代阈值法寻找分割阈值...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                FP.Output("正在计算影像统计数据...");
                Tools.Common.ComputeRasterMinMax(InputDS.GetRasterBand(1), out double Min, out double Max);

                //初始阈值及新阈值。
                double tmpThreshold = (Min + Max) / 2.0;
                double newThreshold = 1000000;
                double Diff = 1000000;  //迭代T值之差。

                FP.Output("最小值：" + Min.ToString() + "\r\n最大值：" + Max.ToString() + "\r\n变化阈值：" + ThresholdDiff.ToString());

                while (Diff >= ThresholdDiff)
                {
                    FP.SetProgress1("阈值变化", ThresholdDiff, Diff, "");
                    //前景、背景像元平均值及计数。
                    double foregroundAvg = 0.0, backgroundAvg = 0.0;
                    int foregroundCount = 0, backgroundCount = 0;

                    for (int row = 0; row < InputDS.RasterYSize; row++)
                    {
                        FP.SetProgress2("迭代已处理", row + 1, InputDS.RasterYSize, "行");
                        double[] tmp = new double[InputDS.RasterXSize];
                        InputDS.GetRasterBand(1).ReadRaster(0, row, InputDS.RasterXSize, 1, tmp, InputDS.RasterXSize, 1, 0, 0);
                        for (int col = 0; col < InputDS.RasterXSize; col++)
                        {
                            //逐像元累加前、背景计数和总和。
                            if (ThresholdCheck(tmp[col], tmpThreshold))
                            {
                                foregroundCount++;
                                foregroundAvg += tmp[col];
                            }
                            else
                            {
                                backgroundCount++;
                                backgroundAvg += tmp[col];
                            }
                        }
                    }
                    foregroundAvg /= foregroundCount;
                    backgroundAvg /= backgroundCount;
                    newThreshold = (foregroundAvg + backgroundAvg) / 2.0;
                    Diff = Math.Abs(newThreshold - tmpThreshold); //阈值差
                    tmpThreshold = newThreshold;
                    FP.Output("新的阈值：" + newThreshold.ToString());
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                
                FP.Finish();
                return newThreshold;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return 0;
            }
        }

        /// <summary>
        /// 阈值判断。
        /// </summary>
        /// <param name="DN">像元值。</param>
        /// <param name="Threshold">分割阈值。</param>
        /// <param name="Equal">等于时是否返回true，默认为真。</param>
        /// <returns>像元是否大于（等于）阈值。</returns>
        public static bool ThresholdCheck(double DN, double Threshold, bool Equal = true)
        {
            if (Equal)
            {
                if (DN >= Threshold)
                    return true;
                return false;
            }
            else
            {
                if (DN > Threshold)
                    return true;
                return false;
            }
        }
    }
}
