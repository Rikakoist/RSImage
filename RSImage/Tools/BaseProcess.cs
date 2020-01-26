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
    /// 基础操作。
    /// </summary>
    class BaseProcess
    {

        #region 直方图匹配
        /// <summary>
        /// 影像直方图匹配。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="MatchDS">要匹配到的数据集。</param>
        /// <param name="InputCumu">输入的数据集的累积概率表。</param>
        /// <param name="MatchingCumu">要匹配到的数据集的累积概率表。</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <param name="OutPath">输出栅格数据集的位置。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool HistogramMatching(OSGeo.GDAL.Dataset InputDS, OSGeo.GDAL.Dataset MatchDS, double[][] InputCumu, double[][] MatchingCumu, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (InputDS.RasterCount != MatchDS.RasterCount)
                    throw new ArgumentException("数据集波段数不一致。");

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行影像直方图匹配...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                int[][] LUT = new int[InputDS.RasterCount][];
                FP.Output("正在计算查找表...");
                for (int i = 0; i < InputDS.RasterCount; i++)
                {
                    LUT[i] = HistogramMatching(InputCumu[i], MatchingCumu[i]);
                }

                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, InputDS.RasterCount, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(InputDS, DS);

                for (int bandcount = 0; bandcount < InputDS.RasterCount; bandcount++)
                {
                    FP.SetProgress2("正在处理", bandcount + 1, InputDS.RasterCount, "波段");
                    Tools.Common.GetMinimum(InputDS.GetRasterBand(bandcount + 1), out double inputDSBandMin);
                    Tools.Common.GetMinimum(MatchDS.GetRasterBand(bandcount + 1), out double matchDSBandMin);
                    for (int Row = 0; Row < ySize; Row++)
                    {
                        FP.SetProgress1("正在处理", Row + 1, ySize, "行");
                        double[] Values = new double[xSize];
                        //读取DN到数组
                        InputDS.GetRasterBand(bandcount + 1).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                        for (int Col = 0; Col < xSize; Col++)
                        {
                            //防止GDAL自带方法算出的统计数据越界。
                            if ((Values[Col] - inputDSBandMin) <= 0)
                            {
                                Values[Col] = matchDSBandMin + LUT[bandcount][0];
                                continue;
                            }
                            if ((Values[Col] - inputDSBandMin) >= LUT[bandcount].Length - 1)
                            {
                                Values[Col] = matchDSBandMin + LUT[bandcount][LUT[bandcount].Length - 1];
                                continue;
                            }
                            Values[Col] = matchDSBandMin + LUT[bandcount][(int)(Values[Col] - inputDSBandMin)];
                        }
                        //写结果到新栅格
                        DS.GetRasterBand(bandcount + 1).WriteRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                        DS.FlushCache();
                        Thread.Sleep(1);
                        if (FP.Canceled)
                        {
                            Thread.Sleep(500);

                            FP.Finish();
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }
                }

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
        /// 波段直方图匹配。
        /// </summary>
        /// <param name="InputBand">输入的波段。</param>
        /// <param name="MatchBand">要匹配到的波段。</param>
        /// <param name="InputCumu">输入的数据集的累积概率表。</param>
        /// <param name="MatchingCumu">要匹配到的数据集的累积概率表。</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <returns>操作成功或失败。</returns>
        public static OSGeo.GDAL.Band HistogramMatching(OSGeo.GDAL.Band InputBand, OSGeo.GDAL.Band MatchBand, double[] InputCumu, double[] MatchingCumu, OSGeo.GDAL.DataType OutDataType)
        {
            try
            {
                int[] LUT = HistogramMatching(InputCumu, MatchingCumu); //进行波段直方图匹配。
                int xSize = InputBand.XSize;
                int ySize = InputBand.YSize;

                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                string tmpFileName = Tools.Common.GetTempFileName();

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行波段直方图匹配...",
                    CanCancel = false,
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(tmpFileName, xSize, ySize, 1, OutDataType, null);
                FP.Output("已创建临时输出数据集\"" + tmpFileName + "\"");

                Tools.Common.GetMinimum(InputBand, out double inputBandMin);
                Tools.Common.GetMinimum(MatchBand, out double matchBandMin);

                for (int Row = 0; Row < ySize; Row++)
                {
                    FP.SetProgress1("正在处理：", Row + 1, ySize, "行");
                    double[] Values = new double[xSize];
                    //读取DN到数组
                    InputBand.ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    for (int Col = 0; Col < xSize; Col++)
                    {
                        //防止GDAL自带方法算出的统计数据越界。
                        if ((Values[Col] - inputBandMin) <= 0)
                        {
                            Values[Col] = matchBandMin + LUT[0];
                            continue;
                        }
                        if ((Values[Col] - inputBandMin) >= LUT.Length - 1)
                        {
                            Values[Col] = matchBandMin + LUT[LUT.Length - 1];
                            continue;
                        }
                        Values[Col] = matchBandMin + LUT[(int)(Values[Col] - inputBandMin)];
                    }
                    //写结果到新栅格
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
                return DS.GetRasterBand(1);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return null;
            }
        }

        /// <summary>
        /// 累积概率表匹配映射。
        /// </summary>
        /// <param name="InputCumuProba">输入的累积概率表。</param>
        /// <param name="MatchingCumuProba">要匹配到的累积概率表。</param>
        /// <returns>匹配结果。长度与输入的累积概率表相同，内容为输入概率表索引映射到要匹配的概率表的索引。</returns>
        public static int[] HistogramMatching(double[] InputCumuProba, double[] MatchingCumuProba)
        {
            int[] lut = new int[InputCumuProba.Length];
            for (int i = 0; i < InputCumuProba.Length; i++)
            {
                double[] minus = new double[MatchingCumuProba.Length];
                //计算匹配到的概率表各项与输入概率表一项的差。
                for (int j = 0; j < MatchingCumuProba.Length; j++)
                {
                    minus[j] = Math.Abs(InputCumuProba[i] - MatchingCumuProba[j]);
                }
                double min = 32767;
                int minIndex = 0;
                //计算差值最小的作为对应项。
                for (int j = 0; j < MatchingCumuProba.Length; j++)
                {
                    if (minus[j] < min)
                    {
                        min = minus[j];
                        minIndex = j;
                    }
                }
                lut[i] = minIndex;
            }
            return lut;
        }
        #endregion

        #region 重采样
        /// <summary>
        /// 距离倒数权重插值。
        /// </summary>
        /// <param name="ds">要重采样到的数据集。</param>
        /// <param name="band">要重采样到数据集的波段。</param>
        /// <param name="x">被插值的像元在数据集中的x坐标。</param>
        /// <param name="y">被插值的像元在数据集中的y坐标。</param>
        /// <returns>插值结果</returns>
        public double IDW(OSGeo.GDAL.Dataset ds, int band, double x, double y)
        {
            int Width = ds.RasterXSize;
            int Height = ds.RasterYSize;
            if (x < 0 || x > Width - 1 || y < 0 || y > Height - 1)
            {
                throw new IndexOutOfRangeException("待计算像元的行列号超出影像边界。期望的参数为：0<=x<=" + (Width - 1).ToString() + "，0<=y<=" + (Height - 1).ToString() + "，输入的参数为：x=" + x.ToString() + "，y=" + y.ToString());
            }
            double tmpDistance = 0.0, sumPiZi = 0.0, sumPi = 0.0;
            tmpDistance = Distanse(x, y, Math.Ceiling(x), Math.Ceiling(y));
            sumPi += 1.0 / tmpDistance;
            sumPiZi += GetDN(ds, band, (int)Math.Ceiling(x), (int)Math.Ceiling(y)) / tmpDistance;

            tmpDistance = Distanse(x, y, Math.Ceiling(x), Math.Floor(y));
            sumPi += 1.0 / tmpDistance;
            sumPiZi += GetDN(ds, band, (int)Math.Ceiling(x), (int)Math.Floor(y)) / tmpDistance;

            tmpDistance = Distanse(x, y, Math.Floor(x), Math.Ceiling(y));
            sumPi += 1.0 / tmpDistance;
            sumPiZi += GetDN(ds, band, (int)Math.Floor(x), (int)Math.Ceiling(y)) / tmpDistance;

            tmpDistance = Distanse(x, y, Math.Floor(x), Math.Floor(y));
            sumPi += 1.0 / tmpDistance;
            sumPiZi += GetDN(ds, band, (int)Math.Floor(x), (int)Math.Floor(y)) / tmpDistance;

            return sumPiZi / sumPi;
        }

        /// <summary>
        /// 求两点间距离。
        /// </summary>
        /// <param name="x1">x1。</param>
        /// <param name="y1">y1。</param>
        /// <param name="x2">x2。</param>
        /// <param name="y2">y2。</param>
        /// <returns>距离计算结果。</returns>
        public double Distanse(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
        }

        /// <summary>
        /// 获取指定行列号的像元值。
        /// </summary>
        /// <param name="x">列号。</param>
        /// <param name="y">行号。</param>
        /// <returns></returns>
        public double GetDN(OSGeo.GDAL.Dataset ds, int band, int x, int y)
        {
            double[] buf = new double[1];
            ds.GetRasterBand(band).ReadRaster(x, y, 1, 1, buf, 1, 1, 0, 0);
            return buf[0];
        }
        #endregion

        #region 数据集运算
        /// <summary>
        /// 数据集相减。
        /// </summary>
        /// <param name="D1">被减数据集。</param>
        /// <param name="D2">减数据集。</param>
        /// <param name="OutDataType">输出数据集的数据类型。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool Minus(OSGeo.GDAL.Dataset D1, OSGeo.GDAL.Dataset D2, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (D1 == null || D2 == null)
                    throw new ArgumentNullException("输入的数据集不可为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                //取输入的宽、高、波段最小值创建输出数据集。
                int Width = Math.Min(D1.RasterXSize, D2.RasterXSize);
                int Height = Math.Min(D1.RasterYSize, D2.RasterYSize);
                int band = Math.Min(D1.RasterCount, D2.RasterCount);

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行数据集减法运算...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, Width, Height, band, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(D1, DS);

                for (int bandcount = 1; bandcount <= band; bandcount++)
                {
                    FP.SetProgress2("正在处理", bandcount, band, "波段");
                    for (int row = 0; row < Height; row++)
                    {
                        FP.SetProgress1("正在处理：", row + 1, Height, "行");
                        double[] d1Tmp = new double[Width];
                        double[] d2Tmp = new double[Width];
                        double[] dsTmp = new double[Width];
                        D1.GetRasterBand(bandcount).ReadRaster(0, row, Width, 1, d1Tmp, Width, 1, 0, 0);
                        D2.GetRasterBand(bandcount).ReadRaster(0, row, Width, 1, d2Tmp, Width, 1, 0, 0);
                        for (long i = 0; i < Width; i++)
                        {
                            dsTmp[i] = d1Tmp[i] - d2Tmp[i];
                        }

                        DS.GetRasterBand(bandcount).WriteRaster(0, row, Width, 1, dsTmp, Width, 1, 0, 0);
                        DS.FlushCache();
                        Thread.Sleep(1);
                        if (FP.Canceled)
                        {
                            Thread.Sleep(500);

                            FP.Finish();
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }
                }

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
        /// 数据集相除。
        /// </summary>
        /// <param name="D1">被除数据集。</param>
        /// <param name="D2">除数据集。</param>
        /// <param name="OutDataType">输出数据集的数据类型。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool Divide(OSGeo.GDAL.Dataset D1, OSGeo.GDAL.Dataset D2, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (D1 == null || D2 == null)
                    throw new ArgumentNullException("输入的数据集不可为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                //取输入的宽、高、波段最小值创建输出数据集。
                int Width = Math.Min(D1.RasterXSize, D2.RasterXSize);
                int Height = Math.Min(D1.RasterYSize, D2.RasterYSize);
                int band = Math.Min(D1.RasterCount, D2.RasterCount);

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行数据集除法运算...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, Width, Height, band, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(D1, DS);

                for (int bandcount = 1; bandcount <= band; bandcount++)
                {
                    FP.SetProgress2("正在处理", bandcount, band, "波段");
                    for (int row = 0; row < Height; row++)
                    {
                        FP.SetProgress1("正在处理：", row + 1, Height, "行");
                        double[] d1Tmp = new double[Width];
                        double[] d2Tmp = new double[Width];
                        double[] dsTmp = new double[Width];
                        D1.GetRasterBand(bandcount).ReadRaster(0, row, Width, 1, d1Tmp, Width, 1, 0, 0);
                        D2.GetRasterBand(bandcount).ReadRaster(0, row, Width, 1, d2Tmp, Width, 1, 0, 0);
                        for (long i = 0; i < Width; i++)
                        {
                            if (d2Tmp[i] == 0)
                            {
                                dsTmp[i] = 0;
                            }
                            else
                            {
                                dsTmp[i] = d1Tmp[i] / d2Tmp[i];
                            }
                        }

                        DS.GetRasterBand(bandcount).WriteRaster(0, row, Width, 1, dsTmp, Width, 1, 0, 0);
                        DS.FlushCache();
                        Thread.Sleep(1);
                        if (FP.Canceled)
                        {
                            Thread.Sleep(500);

                            FP.Finish();
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }
                }

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
        #endregion

        #region 影像裁剪
        public static bool CutImage(OSGeo.GDAL.Dataset InputDS, int CutWidth, int CutHeight, OSGeo.GDAL.DataType OutDataType, string OutFolder)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入的数据集不可为空。");
                if (String.IsNullOrWhiteSpace(OutFolder))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                //取输入的宽、高、波段最小值创建输出数据集。
                int Width = InputDS.RasterXSize;
                int Height = InputDS.RasterYSize;

                int Rows = Height / CutHeight;
                int Cols = Width / CutWidth;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行影像裁剪...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                FP.Output("输出的目录为：" + OutFolder);
                FP.Output("输出的数据类型为：" + OutDataType.ToString());

                for (int row = 0; row < Rows; row++)
                {
                    FP.SetProgress2("总进度：", row + 1, Rows, "");
                    string ParentPath = row.ToString();
                    Directory.CreateDirectory(Path.Combine(OutFolder, ParentPath));
                    for (int col = 0; col < Cols; col++)
                    {
                        FP.SetProgress1("当前行进度：", col + 1, Cols, "");
                        string OutName = row.ToString() + "_" + col.ToString() + ".tif";
                        OSGeo.GDAL.Dataset DS = Dri.Create(Path.Combine(OutFolder, ParentPath, OutName), CutWidth, CutHeight, InputDS.RasterCount, OutDataType, null);
                        for (int band = 1; band <= InputDS.RasterCount; band++)
                        {
                            double[] buf = new double[CutWidth * CutHeight];
                            InputDS.GetRasterBand(band).ReadRaster(col * CutWidth, row * CutHeight, CutWidth, CutHeight, buf, CutWidth, CutHeight, 0, 0);
                            DS.GetRasterBand(band).WriteRaster(0, 0, CutWidth, CutHeight, buf, CutWidth, CutHeight, 0, 0);
                        }
                        ////单行读取写入，防止爆内存。
                        //for (int cRow = 0; cRow < CutHeight; cRow++)
                        //{
                        //    double[] buf = new double[CutWidth];
                        //    InputDS.GetRasterBand(band).ReadRaster(col * CutWidth, row * CutHeight + cRow, CutWidth, 1, buf, CutWidth, 1, 0, 0);
                        //    DS.GetRasterBand(band).WriteRaster(0, cRow, CutWidth, 1, buf, CutWidth, 1, 0, 0);
                        //    DS.FlushCache();
                        //    Thread.Sleep(1);
                        //}

                        DS.FlushCache();
                        DS.Dispose();
                        Thread.Sleep(1);
                        if (FP.Canceled)
                        {
                            Thread.Sleep(500);

                            FP.Finish();
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }
                }

                FP.Finish();
                InputDS.Dispose();
                Dri.Dispose();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }
        #endregion

        #region 重分类
        /// <summary>
        /// 重分类。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="ReplaceList">用于对照值替换的表。</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <param name="OutPath">输出数据集的路径。</param>
        /// <param name="DefaultValue">若值不在ReplaceList中，则该像元的值设为。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool Reclassify(OSGeo.GDAL.Dataset InputDS, List<double[]> ReplaceList, OSGeo.GDAL.DataType OutDataType, string OutPath, double DefaultValue = 0.03)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                if (InputDS.RasterCount != 1)
                    throw new ArgumentOutOfRangeException("重分类的影像不是灰度影像。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行重分类...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                double NoDataValue = -9999;
                int HasNoDataValue = -1;
                InputDS.GetRasterBand(1).GetNoDataValue(out NoDataValue, out HasNoDataValue);
                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, 1, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                if (HasNoDataValue == 1)
                    DS.GetRasterBand(1).SetNoDataValue(NoDataValue);

                Tools.Common.CopyMetadata(InputDS, DS);

                for (int Row = 0; Row < ySize; Row++)
                {
                    FP.SetProgress1("正在处理：", Row + 1, ySize, "行");
                    double[] Values = new double[xSize];
                    InputDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    for (int Col = 0; Col < xSize; Col++)
                    {
                        //值为NoData
                        if (Math.Abs(Values[Col] - NoDataValue) < 1e-7)
                        {
                            continue;
                        }
                        int i = -1;
                        //对照表进行值替换
                        for (i = 0; i < ReplaceList.Count; i++)
                        {
                            if (Values[Col] == ReplaceList[i][0])
                            {
                                Values[Col] = ReplaceList[i][1];
                                break;
                            }
                        }
                        if (i == ReplaceList.Count)
                        {
                            Values[Col] = 0.03;
                        }
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
                DS.Dispose();
                FP.Finish();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        /// <summary>
        /// NoData值替换。将非NoData值替换为指定值。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="NoDataValue">NoData值。</param>
        /// <param name="ReplaceValue">非NoData值替换为的值。</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <param name="OutPath">输出数据集的路径。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool ReplaceNoData(OSGeo.GDAL.Dataset InputDS, double NoDataValue, double ReplaceValue, OSGeo.GDAL.DataType OutDataType, string OutPath, double NewNoDataValue = -9999)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                if (InputDS.RasterCount != 1)
                    throw new ArgumentOutOfRangeException("替换值的影像不是灰度影像。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行非NoData值替换...",
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
                DS.GetRasterBand(1).SetNoDataValue(NoDataValue);

                for (int Row = 0; Row < ySize; Row++)
                {
                    FP.SetProgress1("正在处理：", Row + 1, ySize, "行");
                    double[] Values = new double[xSize];
                    InputDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    for (int Col = 0; Col < xSize; Col++)
                    {
                        if (Math.Abs(Values[Col] - NoDataValue) > 1e-7)
                        {
                            Values[Col] = ReplaceValue;
                        }
                        else
                        {
                            Values[Col] = NewNoDataValue;
                        }
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
                DS.Dispose();
                FP.Finish();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }
        #endregion

        #region 格式转换
        public static bool ConvertToAAIGrid(OSGeo.GDAL.Dataset InputDS, string ConvertTo, string OutPath)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                if (InputDS.RasterCount != 1)
                    throw new ArgumentOutOfRangeException("重分类的影像不是灰度影像。");

                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName(ConvertTo);
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行格式转换...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                double NoDataValue = -9999;
                int HasNoDataValue = -1;
                InputDS.GetRasterBand(1).GetNoDataValue(out NoDataValue, out HasNoDataValue);
                OSGeo.GDAL.Dataset DS = Dri.CreateCopy(OutPath, InputDS, 0, null, null, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + DS.GetRasterBand(1).DataType.ToString() + "。");
                if (HasNoDataValue == 1)
                    DS.GetRasterBand(1).SetNoDataValue(NoDataValue);

                for (int Row = 0; Row < ySize; Row++)
                {
                    FP.SetProgress1("正在处理：", Row + 1, ySize, "行");
                    double[] Values = new double[xSize];
                    InputDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    DS.GetRasterBand(1).WriteRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                    //DS.FlushCache();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);
                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                DS.Dispose();
                FP.Finish();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }

        }
        #endregion
    }
}
