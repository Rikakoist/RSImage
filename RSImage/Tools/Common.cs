using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using OSGeo.GDAL;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace RSImage.Tools
{
    /// <summary>
    /// 公共方法。
    /// </summary>
    class Common
    {
        #region 影像显示
        /// <summary>
        /// 线性拉伸。
        /// </summary>
        /// <param name="PixelValue">像元值。</param>
        /// <param name="BlackPoint">拉伸前最小值。</param>
        /// <param name="WhitePoint">拉伸前最大值。</param>
        /// <param name="TargetMin">拉伸后最小值。默认为0。</param>
        /// <param name="TargetMax">拉伸后最大值。默认为255。</param>
        /// <returns>返回拉伸后的像元值。</returns>
        public static int LinearStretch(double PixelValue, double BlackPoint, double WhitePoint, int TargetMin = 0, int TargetMax = 255)
        {
            if (PixelValue <= BlackPoint)
                return TargetMin;
            if (PixelValue >= WhitePoint)
                return TargetMax;
            return (int)((PixelValue - BlackPoint) * (TargetMax - TargetMin) / (WhitePoint - BlackPoint));
        }

        /// <summary>
        /// 线性拉伸（浮点）。
        /// </summary>
        /// <param name="PixelValue">像元值。</param>
        /// <param name="BlackPoint">拉伸前最小值。</param>
        /// <param name="WhitePoint">拉伸前最大值。</param>
        /// <param name="TargetMin">拉伸后最小值。默认为0。</param>
        /// <param name="TargetMax">拉伸后最大值。默认为255。</param>
        /// <returns>返回拉伸后的像元值。</returns>
        public static double LinearStretchDouble(double PixelValue, double BlackPoint, double WhitePoint, double TargetMin = 0, double TargetMax = 255)
        {
            if (PixelValue <= BlackPoint)
                return TargetMin;
            if (PixelValue >= WhitePoint)
                return TargetMax;
            return (PixelValue - BlackPoint) * (TargetMax - TargetMin) / (WhitePoint - BlackPoint);
        }

        /// <summary>
        /// 直方图均衡化。
        /// </summary>        
        /// <param name="PixelValue">像元值。</param>
        /// <param name="CumuProba">累积概率表。</param>
        /// <param name="BlackPoint">拉伸前最小值。</param>
        /// <param name="WhitePoint">拉伸前最大值。</param>
        /// <param name="TargetMin">拉伸后最小值。默认为0。</param>
        /// <param name="TargetMax">拉伸后最大值。默认为255。</param>
        /// <returns>返回均衡化后的像元值。</returns>
        public static int EqualizationStretch(double PixelValue, double[] CumuProba, double BlackPoint, double WhitePoint, int TargetMin = 0, int TargetMax = 255)
        {
            if (PixelValue <= BlackPoint)
                return TargetMin;
            if (PixelValue >= WhitePoint)
                return TargetMax;
            return (int)(CumuProba[(int)(PixelValue - BlackPoint)] * TargetMax);
        }

        /// <summary>
        /// 对数拉伸。
        /// </summary>
        /// <param name="PixelValue">像元值。</param>
        /// <param name="BlackPoint">拉伸前最小值。</param>
        /// <param name="WhitePoint">拉伸前最大值。</param>
        /// <returns>返回拉伸后的像元值。</returns>
        public static double LogarithmicStretch(double PixelValue, double BlackPoint, double WhitePoint)
        {
            if (PixelValue <= BlackPoint)
                return BlackPoint;
            if (PixelValue >= WhitePoint)
                return WhitePoint;
            return (WhitePoint / Math.Log(WhitePoint + 1) * Math.Log(PixelValue + 1));
            //return (int)(WhitePoint * Math.Log(BlackPoint * PixelValue + 1));
        }

        /// <summary>
        /// 平方根拉伸。
        /// </summary>
        /// <param name="PixelValue">像元值。</param>
        /// <param name="BlackPoint">拉伸前最小值。</param>
        /// <param name="WhitePoint">拉伸前最大值。</param>
        /// <param name="TargetMin">拉伸后最小值。默认为0。</param>
        /// <param name="TargetMax">拉伸后最大值。默认为255。</param>
        /// <returns>返回拉伸后的像元值。</returns>
        public static int SquarerootStretch(double PixelValue, double BlackPoint, double WhitePoint, int TargetMin = 0, int TargetMax = 255)
        {
            if (PixelValue <= BlackPoint)
                return TargetMin;
            if (PixelValue >= WhitePoint)
                return TargetMax;
            return (int)(Math.Sqrt((PixelValue - BlackPoint) / (WhitePoint - BlackPoint)) * TargetMax);
        }

        /// <summary>
        /// 高斯拉伸。
        /// </summary>
        /// <param name="PixelValue"></param>
        /// <param name="CumuProba"></param>
        /// <param name="BandMin"></param>
        /// <param name="BandMean"></param>
        /// <param name="BandStddev"></param>
        /// <returns></returns>
        public static int GaussianStretch(double PixelValue, double[] CumuProba, double BandMin, double BandMean, double BandStddev)
        {
            return 0;
            if (PixelValue <= BandMean - 3 * BandStddev)
                return 0;
            if (PixelValue >= BandMean + 3 * BandStddev)
                return 255;

            double[] GaussProba = new double[256];
            double[] GaussCumuProba = new double[256];
            double Total = 0.0;
            for (int i = 0; i < 256; i++)
            {
                GaussProba[i] = 100 * Math.Pow(Math.E, -Math.Pow(i - 127, 2) / (2 * 42));
                Total += GaussProba[i];
            }
            for (int i = 0; i < 256; i++)
            {
                if (i == 0)
                {
                    GaussCumuProba[i] = GaussProba[i] / Total;
                }
                else
                {
                    GaussCumuProba[i] = GaussCumuProba[i - 1] + GaussProba[i] / Total;
                }
            }
            /*ENVI performs the following steps:
            Sets the data mean value to a screen value of 127.
            Sets the data value that is three standard deviations below the mean value to a screen value of 0.
            Sets the data value that is three standard deviations above the mean value to a screen value of 255.
            Intermediate values are assigned screen values using a Gaussian curve.*/
            int j = 0;
            for (j = 0; j < 256; j++)
            {
                if (CumuProba[(int)(PixelValue - BandMin)] >= GaussCumuProba[j])
                    break;
            }

            return j;
        }

        /// <summary>
        /// 根据拉伸模式重设拉伸参数。
        /// </summary>
        /// <param name="InputImg">影像对象。</param>
        public static void ResetStretchInfo(Img InputImg)
        {
            switch ((StretchModes)InputImg.StretchMode)
            {
                case StretchModes.No_stretch:
                case StretchModes.Linear:
                case StretchModes.Equalization:
                case StretchModes.Gaussion:
                case StretchModes.SquareRoot:
                case StretchModes.Logarithmic:
                    {
                        //线性拉伸。
                        for (int i = 0; i < InputImg.BandNum; i++)
                            InputImg.SetStretchInfo(i, InputImg.Min[i], InputImg.Max[i]);
                        break;
                    }
                case StretchModes.Linear_1:
                    {
                        //线性1%
                        for (int i = 0; i < InputImg.BandNum; i++)
                            InputImg.SetStretchInfo(i, InputImg.GetPercentageValue(i, 1), InputImg.GetPercentageValue(i, 99));
                        break;
                    }
                case StretchModes.Linear_2:
                    {
                        //线性2%
                        for (int i = 0; i < InputImg.BandNum; i++)
                            InputImg.SetStretchInfo(i, InputImg.GetPercentageValue(i, 2), InputImg.GetPercentageValue(i, 98));
                        break;
                    }
                case StretchModes.Linear_5:
                    {
                        //线性5%
                        for (int i = 0; i < InputImg.BandNum; i++)
                            InputImg.SetStretchInfo(i, InputImg.GetPercentageValue(i, 5), InputImg.GetPercentageValue(i, 95));
                        break;
                    }
                case StretchModes.CustomLinear:
                    {
                        //自定义，在这里打开窗口
                        break;
                    }
                default:
                    {
                        //不是0-9还能是啥？
                        break;
                    }
            }
        }

        /// <summary>
        /// 重构指定影像的Bitmap缓存。
        /// </summary>
        /// <param name="InputImg">影像对象。</param>
        /// <param name="RectWidth">显示宽度。</param>
        /// <param name="RectHeight">显示高度。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool RebuildBitmap(Img InputImg, int RectWidth, int RectHeight)
        {
            //万一呢？
            if (RectWidth <= 0 || RectHeight <= 0)
                return false;

            //确定Bitmap大小。
            int Width = 0, Height = 0;
            //影像宽高均分别小于矩形宽高，此时按影像原分辨率显示。
            if (InputImg.Width <= RectWidth && InputImg.Height <= RectHeight)
            {
                Width = InputImg.Width;
                Height = InputImg.Height;
            }
            else
            {
                //其他情况缩放显示，减少性能开销。
                float ImgRatio = InputImg.Width / (float)InputImg.Height;
                float BoxRatio = RectWidth / (float)RectHeight;
                if (BoxRatio >= ImgRatio)
                {
                    Height = RectHeight;
                    Width = (int)(RectHeight * ImgRatio);
                }
                else
                {
                    Width = RectWidth;
                    Height = (int)(RectWidth / ImgRatio);
                }
            }
            InputImg.BitmapCache = GetBitmap(InputImg, Width, Height, (StretchModes)InputImg.StretchMode);
            return true;
        }

        /// <summary>
        /// 获取当前显示的影像原始尺寸的Bitmap。
        /// </summary>
        /// <param name="InputImg">影像对象。</param>
        /// <returns>完整的Bitmap。</returns>
        public static Bitmap Img2Bitmap(Img InputImg)
        {
            int Width = InputImg.Width;
            int Height = InputImg.Height;
            return GetBitmap(InputImg, Width, Height);
        }

        /// <summary>
        /// 按指定宽高和拉伸方法重采样数据集至Bitmap。
        /// </summary>
        /// <param name="InputImg">影像对象。</param>
        /// <param name="Width">重采样宽度。</param>
        /// <param name="Height">重采样高度。</param>
        /// <param name="StretchMode">拉伸模式。</param>
        /// <returns></returns>
        public static Bitmap GetBitmap(Img InputImg, int Width, int Height, StretchModes StretchMode = StretchModes.No_stretch)
        {
            if (StretchMode < 0 || (int)StretchMode > 10)
                throw new ArgumentOutOfRangeException("拉伸模式取值超出范围。");
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppRgb);
            ResetStretchInfo(InputImg); //或许需要重设一下拉伸端点。

            #region 灰度图
            if (InputImg.IsGrayscale)
            {
                double BandMin = InputImg.Min[0];
                double BandMax = InputImg.Max[0];
                Band band = InputImg.GDALDataset.GetRasterBand(1);

                double[] r = new double[Width * Height];
                band.ReadRaster(0, 0, InputImg.Width, InputImg.Height, r, Width, Height, 0, 0);

                switch (StretchMode)
                {
                    case StretchModes.No_stretch:
                        {
                            //无拉伸
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    if (r[i + j * Width] < 0)
                                    {
                                        bitmap.SetPixel(i, j, InputImg.Colortable[0]);
                                        continue;
                                    }
                                    if (r[i + j * Width] > 255)
                                    {
                                        bitmap.SetPixel(i, j, InputImg.Colortable[255]);
                                        continue;
                                    }
                                    bitmap.SetPixel(i, j, InputImg.Colortable[(byte)r[i + j * Width]]);
                                }
                            }
                            break;
                        }
                    case StretchModes.Linear:
                    case StretchModes.Linear_1:
                    case StretchModes.Linear_2:
                    case StretchModes.Linear_5:
                    case StretchModes.CustomLinear:
                        {
                            //线性
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    bitmap.SetPixel(i, j, InputImg.Colortable[LinearStretch(r[i + j * Width], InputImg.StretchInfo[0].Item1, InputImg.StretchInfo[0].Item2)]);
                                }
                            }
                            break;
                        }
                    case StretchModes.Equalization:
                        {
                            //直方图均衡
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    bitmap.SetPixel(i, j, InputImg.Colortable[EqualizationStretch(r[i + j * Width], InputImg.CumulativeProbability[0], InputImg.Min[0], InputImg.Max[0])]);
                                }
                            }
                            break;
                        }
                    case StretchModes.Gaussion:
                        {
                            //高斯
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    bitmap.SetPixel(i, j, InputImg.Colortable[GaussianStretch(r[i + j * Width], InputImg.CumulativeProbability[0], BandMin, InputImg.Mean[0], InputImg.Stddev[0])]);
                                }
                            }
                            break;
                        }
                    case StretchModes.SquareRoot:
                        {
                            //平方根
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    bitmap.SetPixel(i, j, InputImg.Colortable[SquarerootStretch(r[i + j * Width], InputImg.StretchInfo[0].Item1, InputImg.StretchInfo[0].Item2)]);
                                }
                            }
                            break;
                        }
                    case StretchModes.Logarithmic:
                        {
                            //对数
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    bitmap.SetPixel(i, j, InputImg.Colortable[LinearStretch(LogarithmicStretch(r[i + j * Width], InputImg.StretchInfo[0].Item1, InputImg.StretchInfo[0].Item2), InputImg.StretchInfo[0].Item1, InputImg.StretchInfo[0].Item2)]);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            //不是0-9还能是啥？
                            throw new Exception("拉伸模式未知。");
                        }
                }
            }
            #endregion

            #region 彩色图
            else   //三波段组合
            {
                Band redBand = InputImg.GDALDataset.GetRasterBand(InputImg.BandList[0]);
                Band greenBand = InputImg.GDALDataset.GetRasterBand(InputImg.BandList[1]);
                Band blueBand = InputImg.GDALDataset.GetRasterBand(InputImg.BandList[2]);

                double[] r = new double[Width * Height];
                double[] g = new double[Width * Height];
                double[] b = new double[Width * Height];

                redBand.ReadRaster(0, 0, InputImg.Width, InputImg.Height, r, Width, Height, 0, 0);
                greenBand.ReadRaster(0, 0, InputImg.Width, InputImg.Height, g, Width, Height, 0, 0);
                blueBand.ReadRaster(0, 0, InputImg.Width, InputImg.Height, b, Width, Height, 0, 0);

                //红、绿、蓝波段对应的波段索引。
                int Red = InputImg.BandList[0] - 1;
                int Green = InputImg.BandList[1] - 1;
                int Blue = InputImg.BandList[2] - 1;
                //红、绿、蓝波段的统计最小值（Item2）、最大值（Item3）。
                double RedMin = InputImg.Min[Red];
                double RedMax = InputImg.Max[Red];
                double GreenMin = InputImg.Min[Green];
                double GreenMax = InputImg.Max[Green];
                double BlueMin = InputImg.Min[Blue];
                double BlueMax = InputImg.Max[Blue];

                switch (StretchMode)
                {
                    case StretchModes.No_stretch:
                        {
                            //无拉伸
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                            try
                            {
                                int stride = bitmapData.Stride;
                                IntPtr buf = bitmapData.Scan0;

                                blueBand.ReadRaster(0, 0, InputImg.Width, InputImg.Height, buf, Width, Height, DataType.GDT_Byte, 4, stride);
                                greenBand.ReadRaster(0, 0, InputImg.Width, InputImg.Height, new IntPtr(buf.ToInt32() + 1), Width, Height, DataType.GDT_Byte, 4, stride);
                                redBand.ReadRaster(0, 0, InputImg.Width, InputImg.Height, new IntPtr(buf.ToInt32() + 2), Width, Height, DataType.GDT_Byte, 4, stride);
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }
                            break;
                        }
                    case StretchModes.Linear:
                    case StretchModes.Linear_1:
                    case StretchModes.Linear_2:
                    case StretchModes.Linear_5:
                    case StretchModes.CustomLinear:
                        {
                            //线性
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    Color newColor = Color.FromArgb(
                                         LinearStretch(r[i + j * Width], InputImg.StretchInfo[Red].Item1, InputImg.StretchInfo[Red].Item2),
                                         LinearStretch(g[i + j * Width], InputImg.StretchInfo[Green].Item1, InputImg.StretchInfo[Green].Item2),
                                         LinearStretch(b[i + j * Width], InputImg.StretchInfo[Blue].Item1, InputImg.StretchInfo[Blue].Item2));
                                    bitmap.SetPixel(i, j, newColor);
                                }
                            }
                            break;
                        }
                    case StretchModes.Equalization:
                        {
                            //直方图均衡
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    Color newColor = Color.FromArgb(
                                        EqualizationStretch(r[i + j * Width], InputImg.CumulativeProbability[Red], RedMin, RedMax),
                                        EqualizationStretch(g[i + j * Width], InputImg.CumulativeProbability[Green], GreenMin, GreenMax),
                                        EqualizationStretch(b[i + j * Width], InputImg.CumulativeProbability[Blue], BlueMin, BlueMax));
                                    bitmap.SetPixel(i, j, newColor);
                                }
                            }
                            break;
                        }
                    case StretchModes.Gaussion:
                        {
                            //高斯
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    Color newColor = Color.FromArgb(
                                         GaussianStretch(r[i + j * Width], InputImg.CumulativeProbability[Red], RedMin, InputImg.Mean[Red], InputImg.Stddev[Red]),
                                         GaussianStretch(g[i + j * Width], InputImg.CumulativeProbability[Green], GreenMin, InputImg.Mean[Green], InputImg.Stddev[Green]),
                                         GaussianStretch(b[i + j * Width], InputImg.CumulativeProbability[Blue], BlueMin, InputImg.Mean[Blue], InputImg.Stddev[Blue]));
                                    bitmap.SetPixel(i, j, newColor);
                                }
                            }
                            break;
                        }
                    case StretchModes.SquareRoot:
                        {
                            //平方根
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    Color newColor = Color.FromArgb(
                                         SquarerootStretch(r[i + j * Width], RedMin, RedMax),
                                         SquarerootStretch(g[i + j * Width], GreenMin, GreenMax),
                                         SquarerootStretch(b[i + j * Width], BlueMin, BlueMax));
                                    bitmap.SetPixel(i, j, newColor);
                                }
                            }
                            break;
                        }
                    case StretchModes.Logarithmic:
                        {
                            //对数
                            for (int i = 0; i < Width; i++)
                            {
                                for (int j = 0; j < Height; j++)
                                {
                                    Color newColor = Color.FromArgb(
                                        LinearStretch(LogarithmicStretch(r[i + j * Width], RedMin, RedMax), RedMin, RedMax),
                                        LinearStretch(LogarithmicStretch(g[i + j * Width], GreenMin, GreenMax), GreenMin, GreenMax),
                                        LinearStretch(LogarithmicStretch(b[i + j * Width], BlueMin, BlueMax), BlueMin, BlueMax));
                                    bitmap.SetPixel(i, j, newColor);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            //不是0-9还能是啥？
                            break;
                        }
                }
            }
            #endregion

            return bitmap;
        }

        /// <summary>
        /// 导出当前视图。
        /// </summary>
        /// <param name="InputImg">影像对象。</param>
        /// <param name="OutDataType">输出数据类型。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool ExportView(Img InputImg, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (OutPath == InputImg.Path)
                    throw new Exception("输出路径与源文件相同。");
                if (InputImg.GDALDataset == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputImg.Width;
                int ySize = InputImg.Height;
                int Bandnum = 3;
                if (InputImg.IsGrayscale)
                    Bandnum = 1;
                else
                    Bandnum = 3;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在导出影像...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, Bandnum, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(InputImg.GDALDataset, DS);

                for (int i = 0; i < Bandnum; i++) //遍历每个波段
                {
                    FP.SetProgress2("正在处理", i + 1, Bandnum, "波段");
                    for (int Row = 0; Row < ySize; Row++)   //遍历每一行(y)
                    {
                        FP.SetProgress1("正在处理", Row + 1, ySize, "行");
                        double[] Values = new double[xSize];

                        //读取DN到数组
                        InputImg.GDALDataset.GetRasterBand(InputImg.BandList[i]).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                        for (int Col = 0; Col < xSize; Col++)   //对每一个值进行计算
                        {
                            //无拉伸不做处理直接导出
                            if (InputImg.StretchMode == 0)
                                break;
                            //已经有处理的情形
                            switch (InputImg.StretchMode)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 9:
                                    {
                                        //线性
                                        Values[Col] = LinearStretch(Values[Col], InputImg.StretchInfo[InputImg.BandList[i] - 1].Item1, InputImg.StretchInfo[InputImg.BandList[i] - 1].Item2);
                                        break;
                                    }
                                case 5:
                                    {
                                        //直方图均衡
                                        Values[Col] = EqualizationStretch(Values[Col], InputImg.CumulativeProbability[InputImg.BandList[i] - 1], InputImg.Min[InputImg.BandList[i] - 1], InputImg.Max[InputImg.BandList[i] - 1]);
                                        break;
                                    }
                                case 6:
                                    {
                                        //高斯
                                        Values[Col] = GaussianStretch(Values[Col], InputImg.CumulativeProbability[InputImg.BandList[i] - 1], InputImg.Min[InputImg.BandList[i] - 1], InputImg.Mean[InputImg.BandList[i] - 1], InputImg.Stddev[InputImg.BandList[i] - 1]);
                                        break;
                                    }
                                case 7:
                                    {
                                        //平方根
                                        Values[Col] = SquarerootStretch(Values[Col], InputImg.Min[InputImg.BandList[i] - 1], InputImg.Max[InputImg.BandList[i] - 1]);
                                        break;
                                    }
                                case 8:
                                    {
                                        //对数
                                        Values[Col] = LinearStretch(LogarithmicStretch(Values[Col], InputImg.Min[InputImg.BandList[i] - 1], InputImg.Max[InputImg.BandList[i] - 1]), InputImg.Min[InputImg.BandList[i] - 1], InputImg.Max[InputImg.BandList[i] - 1]);
                                        break;
                                    }
                                default:
                                    {
                                        //不是0-9还能是啥？
                                        throw new Exception("拉伸模式未知。");
                                    }
                            }
                        }
                        //写结果到新栅格
                        DS.GetRasterBand(i + 1).WriteRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
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
                MessageBox.Show(err.Message);
                return false;
            }
        }

        /// <summary>
        /// RGB转灰度显示。
        /// </summary>
        /// <param name="InputImg">影像对象。</param>
        /// <param name="RGBWeight">RGB权重数组，长度为3。</param>
        /// <param name="OutDataType">输出数据类型。</param>
        /// <param name="OutPath">输出路径。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool RGB2GrayScale(Img InputImg, double[] RGBWeight, OSGeo.GDAL.DataType OutDataType, string OutPath)
        {
            try
            {
                if (OutPath == InputImg.Path)
                    throw new Exception("输出路径与源文件相同。");
                if (InputImg.GDALDataset == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                if (RGBWeight.Length != 3)
                    throw new ArgumentException("权重数组长度无效，应为3。");
                if (Math.Abs(RGBWeight[0] + RGBWeight[1] + RGBWeight[2] - 1) > 1E-7)
                    throw new ArgumentOutOfRangeException("RGB分量权重设置错误。总和应为1。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                int xSize = InputImg.Width;
                int ySize = InputImg.Height;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在导出灰度影像...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, 1, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(InputImg.GDALDataset, DS);

                for (int Row = 0; Row < ySize; Row++)
                {
                    FP.SetProgress1("正在处理", Row + 1, ySize, "行");
                    double[] RValues = new double[xSize];
                    double[] GValues = new double[xSize];
                    double[] BValues = new double[xSize];
                    double[] GrayValues = new double[xSize];

                    InputImg.GDALDataset.GetRasterBand(InputImg.BandList[0]).ReadRaster(0, Row, xSize, 1, RValues, xSize, 1, 0, 0);
                    InputImg.GDALDataset.GetRasterBand(InputImg.BandList[1]).ReadRaster(0, Row, xSize, 1, GValues, xSize, 1, 0, 0);
                    InputImg.GDALDataset.GetRasterBand(InputImg.BandList[2]).ReadRaster(0, Row, xSize, 1, BValues, xSize, 1, 0, 0);
                    for (int Col = 0; Col < xSize; Col++)
                    {
                        //拉伸到0~255后再加权计算。
                        RValues[Col] = LinearStretch(RValues[Col], InputImg.Min[InputImg.BandList[0] - 1], InputImg.Max[InputImg.BandList[0] - 1]);
                        GValues[Col] = LinearStretch(GValues[Col], InputImg.Min[InputImg.BandList[1] - 1], InputImg.Max[InputImg.BandList[1] - 1]);
                        BValues[Col] = LinearStretch(BValues[Col], InputImg.Min[InputImg.BandList[2] - 1], InputImg.Max[InputImg.BandList[2] - 1]);
                        GrayValues[Col] = RGBWeight[0] * RValues[Col] + RGBWeight[1] * GValues[Col] + RGBWeight[2] * BValues[Col];
                    }

                    //写结果到新栅格
                    DS.GetRasterBand(1).WriteRaster(0, Row, xSize, 1, GrayValues, xSize, 1, 0, 0);
                    DS.FlushCache();
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
        #endregion

        #region 颜色空间变换
        /// <summary>
        /// RGB转IHS
        /// </summary>
        /// <param name="RGB">RGB空间颜色数组。</param>
        /// <returns>IHS颜色空间数组。</returns>
        public static double[] RGB2IHS(double[] RGB)
        {
            double angle = 0.0;
            double R = RGB[0] / 255.0, G = RGB[1] / 255.0, B = RGB[2] / 255.0;
            double I = 0.0, H = 0.0, S = 0.0;
            I = (R + G + B) / 3.0;
            S = 1 - Math.Min(Math.Min(R, G), B) / I;
            if (S == 0)
            {
                H = 0;
            }
            if (R == G && R == B)
            {
                B = 0;
            }
            else
            {
                angle = Math.Acos(0.5 * (R - G + R - B) / (Math.Sqrt((R - G) * (R - G) + (R - B) * (G - B))));
                angle = angle * 180.0 / Math.PI;
            }
            if (B > G)
            {
                H = 360 - angle;        //H量计算
            }
            else
            {
                H = angle;
            }

            I = I * 255.0;
            H = H * 255.0 / 360.0;
            S = S * 255.0;
            return new double[3] { I, H, S };
        }
        //public static double[] RGB2IHS2(double[] RGB)
        //{
        //    double R = RGB[0] / 255.0, G = RGB[1] / 255.0, B = RGB[2] / 255.0;

        //    double I = 0.0, H = 0.0, S = 0.0;

        //    I = (R + G + B) / 3;
        //    if (B == RGB.Min())
        //        H = (G - B) / (I - 3 * B);
        //    if (R == RGB.Min())
        //        H = (B - R) / (I - 3 * R) + 1;
        //    if (G == RGB.Min())
        //        H = (R - G) / (I - 3 * G) + 2;

        //    if (H >= 0 && H <= 1)
        //        S = (I - 3 * B) / I;
        //    else if (H <= 2)
        //        S = (I - 3 * R) / I;
        //    else if (H <= 3)
        //        S = (I - 3 * G) / I;
        //    return new double[3] { I, H, S };
        //}

        /// <summary>
        /// IHS转RGB。
        /// </summary>
        /// <param name="iHS">IHS颜色对象。</param>
        /// <returns>RGB颜色。</returns>
        public static double[] IHS2RGB(double[] IHS)
        {
            double R = 0.0, G = 0.0, B = 0.0;
            double i = (IHS[0]) / 255;
            double h = (IHS[1]) * 360 / 255;
            double s = (IHS[2]) / 255;
            while (h < 0)
            {
                h += 360;
            }
            while (h > 360)
            {
                h -= 360;
            }
            if (h < 120 && h >= 0)
            {
                R = i * (1.0 + ((s * Math.Cos(h * Math.PI / 180)) / Math.Cos((60 - h) * Math.PI / 180)));
                B = i * (1.0 - s);
                G = 3.0 * i - (R + B);
            }
            if (h < 240 && h >= 120)
            {
                h = h - 120;
                G = i * (1.0 + ((s * Math.Cos(h * Math.PI / 180)) / Math.Cos((60 - h) * Math.PI / 180)));
                R = i * (1.0 - s);
                B = 3.0 * i - (R + G);
            }
            if (h >= 240 && h <= 360)
            {
                h = h - 240;
                B = i * (1.0 + ((s * Math.Cos(h * Math.PI / 180)) / Math.Cos((60 - h) * Math.PI / 180)));
                G = i * (1.0 - s);
                R = 3 * i - (G + B);
            }
            return new double[3] { R * 255, G * 255, B * 255 };
        }
        //public static double[] IHS2RGB2(double[] IHS)
        //{
        //    double R = 0.0, G = 0.0, B = 0.0;
        //    double I = IHS[0], H = IHS[1], S = IHS[2];
        //    if (IHS[1] >= 0 && IHS[1] <= 1)
        //    {
        //        R = I * (1 + 2 * S - 3 * S * H) / 3;
        //        G = I * (1 - S + 3 * S * H) / 3;
        //        B = I * (1 - S) / 3;
        //    }
        //    else if (IHS[1] <= 2)
        //    {
        //        R = I * (1 - S) / 3;
        //        G = I * (1 + 2 * S - 3 * S * (H - 1)) / 3;
        //        B = I * (1 - S + 3 * S * (H - 1)) / 3;
        //    }
        //    else if (IHS[1] <= 3)
        //    {
        //        R = I * (1 - S + 3 * S * (H - 2)) / 3;
        //        G = I * (1 - S) / 3;
        //        B = I * (1 + 2 * S - 3 * S * (H - 2)) / 3;
        //    }
        //    return new double[3] { R, G, B };
        //}
        #endregion

        #region 影像统计特征
        /// <summary>
        /// 计算波段最小值、最大值、平均值、标准差。
        /// </summary>
        /// <param name="band">波段。</param>
        /// <param name="min">最小值。</param>
        /// <param name="max">最大值。</param>
        /// <param name="mean">平均值。</param>
        /// <param name="stddev">标准差。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool GetStatistics(Band band, out double min, out double max, out double mean, out double stddev)
        {
            try
            {
                min = 100000000; max = -100000000; mean = 0.0; stddev = 0.0;
                double Total = 0.0;
                //求最大、最小、平均值。
                for (int row = 0; row < band.YSize; row++)
                {
                    double[] Values = new double[band.XSize];
                    band.ReadRaster(0, row, band.XSize, 1, Values, band.XSize, 1, 0, 0);
                    for (int col = 0; col < band.XSize; col++)
                    {
                        Total += Values[col];
                        if (Values[col] < min)
                            min = Values[col];
                        if (Values[col] > max)
                            max = Values[col];
                    }
                }
                mean = Total / (band.XSize * band.YSize);
                //求标准差。
                Total = 0.0;
                for (int row = 0; row < band.YSize; row++)
                {
                    double[] Values = new double[band.XSize];
                    band.ReadRaster(0, row, band.XSize, 1, Values, band.XSize, 1, 0, 0);
                    for (int col = 0; col < band.XSize; col++)
                    {
                        Total += Math.Pow(Values[col] - mean, 2);
                    }
                }
                stddev = Math.Sqrt(Total / (band.XSize * band.YSize));
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                min = max = mean = stddev = 0;
                return false;
            }
        }

        /// <summary>
        /// 计算波段最小值。
        /// </summary>
        /// <param name="band">波段。</param>
        /// <param name="min">最小值。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool GetMinimum(Band band, out double min)
        {
            try
            {
                min = 100000000;
                //求最小值。
                for (int row = 0; row < band.YSize; row++)
                {
                    double[] Values = new double[band.XSize];
                    band.ReadRaster(0, row, band.XSize, 1, Values, band.XSize, 1, 0, 0);
                    for (int col = 0; col < band.XSize; col++)
                    {
                        if (Values[col] < min)
                            min = Values[col];
                    }
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                min = 0;
                return false;
            }
        }

        /// <summary>
        /// 计算波段最大值。
        /// </summary>
        /// <param name="band">波段。</param>
        /// <param name="min">最大值。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool GetMaximum(Band band, out double max)
        {
            try
            {
                max = -100000000;
                //求最小值。
                for (int row = 0; row < band.YSize; row++)
                {
                    double[] Values = new double[band.XSize];
                    band.ReadRaster(0, row, band.XSize, 1, Values, band.XSize, 1, 0, 0);
                    for (int col = 0; col < band.XSize; col++)
                    {
                        if (Values[col] > max)
                            max = Values[col];
                    }
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                max = 0;
                return false;
            }
        }

        /// <summary>
        /// 计算波段最大、最小值。
        /// </summary>
        /// <param name="band">波段。</param>
        /// <param name="min">最小值。</param>
        /// <param name="max">最大值。</param>
        /// <returns>操作成功或失败。</returns>
        public static bool ComputeRasterMinMax(Band band, out double min, out double max)
        {
            try
            {
                min = 100000000; max = -100000000;
                //求最小值。
                for (int row = 0; row < band.YSize; row++)
                {
                    double[] Values = new double[band.XSize];
                    band.ReadRaster(0, row, band.XSize, 1, Values, band.XSize, 1, 0, 0);
                    for (int col = 0; col < band.XSize; col++)
                    {
                        if (Values[col] < min)
                            min = Values[col];
                        if (Values[col] > max)
                            max = Values[col];
                    }
                }
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                min = max = 0;
                return false;
            }
        }

        /// <summary>
        ///计算影像的协方差矩阵。使用前需先计算数据集的波段数、像素数和平均值。
        /// </summary>
        /// <param name="InputImg">输入的影像对象。</param>          
        /// <param name="force">是否强制计算。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool CalcCovarianceMatrix(Img InputImg, bool force)
        {
            try
            {
                if (force)
                    InputImg.IsCovarianceMatrixCalculated = false;
                if (InputImg.IsCovarianceMatrixCalculated)
                    throw new Exception("已计算过该影像的协方差矩阵。");
                InputImg.CovarianceMatrix = new double[InputImg.BandNum, InputImg.BandNum];
                int xSize = InputImg.Width;
                int ySize = InputImg.Height;

                for (int i = 0; i < InputImg.BandNum; i++)
                {
                    for (int j = 0; j < InputImg.BandNum; j++)
                    {
                        if (i > j)  //下三角阵直接对称。
                            continue;

                        //协方差两波段的平均值。
                        double IMean = InputImg.Mean[i], JMean = InputImg.Mean[j];
                        double sum = 0.0;
                        //按行读取计算减少压力。
                        for (int Row = 0; Row < ySize; Row++)
                        {
                            double[] IValues = new double[xSize];
                            double[] JValues = new double[xSize];

                            InputImg.GDALDataset.GetRasterBand(i + 1).ReadRaster(0, Row, xSize, 1, IValues, xSize, 1, 0, 0);
                            InputImg.GDALDataset.GetRasterBand(j + 1).ReadRaster(0, Row, xSize, 1, JValues, xSize, 1, 0, 0);
                            //对每一个值进行统计累加。
                            for (int Col = 0; Col < xSize; Col++)
                            {
                                sum += (IValues[Col] - IMean) * (JValues[Col] - JMean);
                            }
                        }
                        InputImg.CovarianceMatrix[i, j] = InputImg.CovarianceMatrix[j, i] = sum / InputImg.PixelCount;
                    }
                }
                InputImg.IsCovarianceMatrixCalculated = true;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        /// <summary>
        ///计算影像的相关系数矩阵。使用前需先计算数据集的波段数、标准差和协方差矩阵。
        /// </summary>
        /// <param name="InputImg">输入的影像对象。</param>          
        /// <param name="force">是否强制计算。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool CalcCorrelationMatrix(Img InputImg, bool force)
        {
            try
            {
                if (force)
                    InputImg.IsCorrelationMatrixCalculated = false;
                if (InputImg.IsCorrelationMatrixCalculated)
                    throw new Exception("已计算过该影像的相关系数矩阵。");
                if (!InputImg.IsCovarianceMatrixCalculated) //若未计算协方差阵，则调用方法计算。
                    CalcCovarianceMatrix(InputImg, false);

                InputImg.CorrelationMatrix = new double[InputImg.BandNum, InputImg.BandNum];

                for (int i = 0; i < InputImg.BandNum; i++)
                {
                    for (int j = 0; j < InputImg.BandNum; j++)
                    {
                        if (i > j)  //下三角阵直接对称。
                            continue;
                        if (i == j)    //对角线始终为1。
                        {
                            InputImg.CorrelationMatrix[i, j] = 1.0;
                            continue;
                        }
                        //计算两波段的相关系数。
                        double IStddev = InputImg.Stddev[i], JStddev = InputImg.Stddev[j];
                        InputImg.CorrelationMatrix[i, j] = InputImg.CorrelationMatrix[j, i] = InputImg.CovarianceMatrix[i, j] / (IStddev * JStddev);
                    }
                }
                InputImg.IsCorrelationMatrixCalculated = true;
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 获取程序（GDAL）支持的文件类型列表用于文件对话框的筛选器。
        /// </summary>
        /// <returns>返回Filter属性所需的字符串。</returns>
        public static string GetSupportedFileType()
        {
            string result = String.Empty;
            for (int i = 0; i < Enum.GetNames(typeof(SupportedFileType)).GetLength(0); i++)
            {
                result += ((typeof(SupportedFileType).GetField(((SupportedFileType)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description) + "|";
            }
            return result.Substring(0, result.Length - 1);
        }

        /// <summary>
        /// 拷贝元数据至新的数据集。
        /// </summary>
        /// <param name="InputDS">输入的数据集。</param>
        /// <param name="TargetDS">要将元数据拷贝到的数据集。</param>
        public static void CopyMetadata(OSGeo.GDAL.Dataset InputDS, OSGeo.GDAL.Dataset TargetDS)
        {
            if (InputDS == null || TargetDS == null)
                throw new ArgumentNullException("数据集不能为空。");
            //写入投影和变换信息
            double[] TransformArgs = new double[6];
            InputDS.GetGeoTransform(TransformArgs);
            TargetDS.SetGeoTransform(TransformArgs);
            TargetDS.SetProjection(InputDS.GetProjection());
            //DS.SetMetadata(InputDS.GetMetadata());
        }

        /// <summary>
        /// 设置提示。
        /// </summary>
        /// <param name="TSSL">传入的提示控件。</param>
        /// <param name="Hint">要设置的提示文本。</param>
        public static void SetHint(ToolStripStatusLabel TSSL, string Hint)
        {
            if (TSSL != null)
            {
                TSSL.Text = Hint;
                TSSL.Invalidate();
            }
        }

        /// <summary>
        /// 设置进度条的值。
        /// </summary>
        /// <param name="PB">进度条。</param>
        /// <param name="Val">值。</param>
        public static void SetProgress(ToolStripProgressBar PB, double Val)
        {
            if (PB != null)
            {
                PB.Value = ((int)Val > 100) ? 100 : (((int)Val < 0) ? 0 : (int)Val);
                PB.Invalidate();
            }
        }

        /// <summary>
        /// 清理文件。
        /// </summary>
        /// <param name="FileName">文件的完整路径。</param>
        public static void CleanUp(string FileName)
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }

        /// <summary>
        /// 获取临时文件名。
        /// </summary>
        /// <param name="Suffix">文件扩展名。默认为.tif。</param>
        /// <returns>临时文件名。</returns>
        public static string GetTempFileName(string Suffix = ".tif")
        {
            Thread.Sleep(1100); //防止创建同名文件。
            return Path.Combine(Path.GetTempPath(), GetTime()) + Suffix;
        }

        /// <summary>
        /// 获取当前时间。
        /// </summary>
        /// <returns>返回形如“20190101185903”形式的字符串。</returns>
        public static string GetTime()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
