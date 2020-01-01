using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;

namespace RSImage
{
    public class Img : IDisposable
    {
        #region 构造函数们
        public Img()
        {
            //不可删除！
        }
        public Img(string Path, Form F = null, ToolStripStatusLabel TSSL = null, ToolStripProgressBar P = null)
        {
            //初始化基本信息
            Gdal.AllRegister();
            this.Path = Path;
            OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
            this.GDALDataset = OSGeo.GDAL.Gdal.Open(this.Path, OSGeo.GDAL.Access.GA_ReadOnly);
            Tools.Common.SetProgress(P, 0);
            InitBaseInfo();
            Thread.Sleep(1);
            Tools.Common.SetHint(TSSL, Path + " - 正在计算元数据...");
            if (F != null)
                F.Refresh();
            //初始化元数据
            InitMatadata();
            Thread.Sleep(1);
            Tools.Common.SetProgress(P, 33);
            Tools.Common.SetHint(TSSL, Path + " - 正在计算统计信息...");
            if (F != null)
                F.Refresh();
            //初始化统计信息
            InitStatistics();
            Thread.Sleep(1);
            Tools.Common.SetProgress(P, 66);
            Tools.Common.SetHint(TSSL, Path + " - 正在初始化显示信息...");
            if (F != null)
                F.Refresh();
            //初始化显示信息
            InitDisplayInfo();
            Tools.Common.SetProgress(P, 100);
        }
        #endregion

        #region 影像基本信息
        /// <summary>
        /// 初始化影像基本信息。
        /// </summary>
        private void InitBaseInfo()
        {
            BandNum = GDALDataset.RasterCount;
            Width = GDALDataset.RasterXSize;
            Height = GDALDataset.RasterYSize;
            PixelCount = Width * Height;
            GDALDataType = GDALDataset.GetRasterBand(1).DataType;
            ColorInterpretation = GDALDataset.GetRasterBand(1).GetColorInterpretation();
            GDALColorTable = GDALDataset.GetRasterBand(1).GetColorTable();
            InitNoData();
            CheckGrayscale();
        }
        /// <summary>
        /// 影像路径。
        /// </summary>
        private string path;
        public string Path
        {
            get => path;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("影像路径不能为空！");
                }
                else
                {
                    path = value;
                }
            }
        }

        /// <summary>
        /// GDAL数据集。
        /// </summary>
        public readonly OSGeo.GDAL.Dataset GDALDataset;
        /// <summary>
        /// 影像的波段数。
        /// </summary>
        public int BandNum { get; private set; }
        /// <summary>
        /// 影像宽度。
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// 影像高度。
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// 影像的像素数。
        /// </summary>
        public double PixelCount { get; private set; }

        /// <summary>
        /// 数据类型。
        /// </summary>
        public DataType GDALDataType { get; private set; }
        /// <summary>
        /// 颜色信息。
        /// </summary>
        public ColorInterp ColorInterpretation { get; private set; }
        /// <summary>
        /// 颜色表。
        /// </summary>
        public ColorTable GDALColorTable { get; private set; }

        /// <summary>
        /// 影像每个波段是否有NoData值。
        /// </summary>
        public int[] HasNoDataValue { get; private set; }
        /// <summary>
        /// 影像每个波段的NoData值。
        /// </summary>
        public double[] NoDataValue { get; private set; }
        /// <summary>
        /// 初始化NoData数据。
        /// </summary>
        private void InitNoData()
        {
            HasNoDataValue = new int[BandNum];
            NoDataValue = new double[BandNum];
            for (int i = 0; i < BandNum; i++)
            {
                GDALDataset.GetRasterBand(i + 1).GetNoDataValue(out NoDataValue[i], out HasNoDataValue[i]);
            }
        }

        /// <summary>
        /// 影像是否为灰度。
        /// </summary>
        public bool IsGrayscale { get; private set; }
        /// <summary>
        /// 判断影像是否为灰度图，使用前必须对波段数赋值。
        /// </summary>
        private void CheckGrayscale()
        {
            if (BandNum < 1)
                throw new ArgumentException("波段数小于1，请检查影像是否损坏？");
            if (BandNum == 1)
            {
                IsGrayscale = true;
            }
            else
                IsGrayscale = false;
        }
        #endregion
        
        #region 影像元数据
        /// <summary>
        /// 初始化影像元数据。
        /// </summary>
        private void InitMatadata()
        {
            Projection = GDALDataset.GetProjection();
            GeoTransform = new double[6];
            GDALDataset.GetGeoTransform(GeoTransform);
            MetadataDomainList = GDALDataset.GetMetadataDomainList();
            Metadata = new string[MetadataDomainList.Length][];
            for(int i = 0;i<MetadataDomainList.Length;i++)
            {
                Metadata[i] = GDALDataset.GetMetadata(MetadataDomainList[i]);
            }
            //MetadataItem = new string[Metadata.Length, 2];
            //int k = 0;
            //for(int i=0;i<Metadata.GetLength(0);i++)
            //{
            //    for (int j = 0; j < Metadata.GetLength(1); j++)
            //    {
            //        MetadataItem[k, 0] = Metadata[i][j];
            //        MetadataItem[k, 1] = GDALDataset.GetMetadataItem(Metadata[i][j], MetadataDomainList[i]);
            //        k++;
            //    }
            //}
        }

        /// <summary>
        /// 投影信息。
        /// </summary>
        public string Projection { get; private set; }

        /// <summary>
        /// 仿射变换参数。
        /// </summary>
        public double[] GeoTransform { get; private set; }
        /*Xgeo = GT(0) + Xpixel*GT(1) + Yline*GT(2)
        Ygeo = GT(3) + Xpixel* GT(4) + Yline* GT(5)
        In case of north up images, the GT(2) and GT(4) coefficients are zero, 
        and the GT(1) is pixel width, 
        and GT(5) is pixel height.
        The(GT(0),GT(3)) position is the top left corner of the top left pixel of the raster.
        */

        /// <summary>
        /// 元数据域列表。
        /// </summary>
        public string[] MetadataDomainList { get; private set; }
        /// <summary>
        /// 元数据标签列表。
        /// </summary>
        public string[][] Metadata { get; private set; }
        #endregion

        #region 影像统计信息
        /// <summary>
        /// 初始化影像统计信息。
        /// </summary>
        private void InitStatistics()
        {
            InitHistogram();
            InitCumulativeProbability();
            Tools.Common.CalcCovarianceMatrix(this, true);
            Tools.Common.CalcCorrelationMatrix(this, true);
        }

        /// <summary>
        /// 影像各波段的直方图。
        /// </summary>
        public int[][] Histogram { get; private set; }
        /// <summary>
        /// 影像各波段的最小值。
        /// </summary>
        public double[] Min { get; private set; }
        /// <summary>
        /// 影像各波段的最大值。
        /// </summary>
        public double[] Max { get; private set; }
        /// <summary>
        /// 影像各波段的平均值。
        /// </summary>
        public double[] Mean { get; private set; }
        /// <summary>
        /// 影像各波段的标准差。
        /// </summary>
        public double[] Stddev { get; private set; }
        /// <summary>
        /// 初始化数据集的直方图及统计信息，该信息不会被改变。
        /// </summary>
        private void InitHistogram()
        {
            Histogram = new int[BandNum][];
            Min = new double[BandNum];
            Max = new double[BandNum];
            Mean = new double[BandNum];
            Stddev = new double[BandNum];
            for (int i = 0; i < BandNum; i++)
            {
                Tools.Common.GetStatistics(GDALDataset.GetRasterBand(i + 1), out double min, out double max, out double mean, out double stddev);   //计算最小值、最大值、平均值、标准差
                //GDALDataset.GetRasterBand(i+1).GetStatistics(0, 1, out double min, out double max, out double mean, out double stddev);    //计算最小值、最大值、平均值、标准差
                int[] His = new int[(int)(max - min) + 1];    //完整的直方图
                GDALDataset.GetRasterBand(i+1).GetHistogram(min, max, (int)(max - min) + 1, His, 1, 0, null, null);
                Histogram[i] = His;
                Min[i] = min;
                Max[i] = max;
                Mean[i] = mean;
                Stddev[i] = stddev;
            }
        }

        /// <summary>
        /// 各波段各像元值像元数列表。
        /// </summary>
        public double[][] Probability { get; private set; }
        /// <summary>
        /// 各波段的累积概率表。
        /// </summary>
        public double[][] CumulativeProbability { get; private set; }
        /// <summary>
        /// 初始化一个波段的累积概率表。使用前必须先计算该波段直方图。
        /// </summary>
        /// <returns>返回操作成功或失败。</returns>
        private bool InitCumulativeProbability()
        {
            if (PixelCount <= 0)
                throw new ArgumentNullException("像素数未初始化。");
            if (Histogram == null)
                throw new ArgumentNullException("直方图对象为空。");
            if (Histogram.Length < BandNum)
                throw new IndexOutOfRangeException("波段数与直方图对象大小不符。");
            Probability = new double[BandNum][];
            CumulativeProbability = new double[BandNum][];
            for (int i = 0; i < BandNum; i++)
            {
                CumulativeProbability[i]=GetBandCumulativeProbability(Histogram[i],out Probability[i]);
            }
            return true;
        }

        /// <summary>
        /// 获取指定波段、指定百分位在累积概率表中的索引。
        /// </summary>
        /// <param name="BandIndex">波段的数组索引（0为Band1）。</param>
        /// <param name="Percentage">指定的百分位（若需要取1%，则应输入1而不是0.01）。</param>
        /// <returns>返回不超过该百分位的像元值。</returns>
        public int GetPercentageValue(int BandIndex, double Percentage)
        {
            if (BandIndex < 0 || BandIndex > StretchInfo.Capacity)
                throw new ArgumentOutOfRangeException("指定的波段不存在。");
            if (Percentage < 0 || Percentage > 100)
                throw new ArgumentOutOfRangeException("输入的百分比不正确。");
            int i;
            for (i = 0; i < CumulativeProbability[BandIndex].Length; i++)
            {
                if (CumulativeProbability[BandIndex][i] > (Percentage / 100))
                    break;
            }
            return (int)(i + Min[BandIndex]);
        }

        /// <summary>
        /// 获取指定波段、指定百分位在累积概率表中的索引。
        /// </summary>
        /// <param name="BandIndex">波段的数组索引（0为Band1）。</param>
        /// <param name="Percentage">指定的百分位（若需要取1%，则应输入1而不是0.01）。</param>
        /// <returns>返回一个长度为2的数组，第一个数为输入Percentage对应的索引，第二个数为100-Percentage对应的索引</returns>
        public int[] GetPercentageIndex(int BandIndex, double Percentage)
        {
            int i, j;
            for (i = 0; i < CumulativeProbability[BandIndex].Length; i++)
            {
                if (CumulativeProbability[BandIndex][i] > (Percentage / 100))
                    break;
            }
            for (j = CumulativeProbability[BandIndex].Length; j > 0; j--)
            {
                if (CumulativeProbability[BandIndex][j] < (Percentage / 100))
                    break;
            }
            return new int[2] { i, j };
        }

        /// <summary>
        /// 计算一个波段的累积概率表。使用前必须先计算该波段直方图。
        /// </summary>
        /// <param name="bandHistogram">该波段的直方图数组，位于变量Histogram中。</param>
        /// <param name="pixelCount">该波段的像素总数，位于变量Histogram中。</param>
        /// <returns>返回累积概率表数组。</returns>
        private double[] GetBandCumulativeProbability(int[] bandHistogram,out double[] Probability)
        {
            double[] cumuprobability = new double[bandHistogram.Length];
            Probability = new double[bandHistogram.Length];
            for (int i = 0; i < bandHistogram.Length; i++)
            {
                cumuprobability[i] = bandHistogram[i] / PixelCount; //每个亮度的像元占比
                Probability[i] = bandHistogram[i]; //每个亮度的像元占比
                if (i > 0)
                {
                    cumuprobability[i] += cumuprobability[i - 1];   //累积概率
                }
            }
            return cumuprobability;
        }

        /// <summary>
        /// 数据集的协方差矩阵。
        /// </summary>
        public double[,] CovarianceMatrix;
        /// <summary>
        /// 数据集的协方差矩阵是否已计算。
        /// </summary>
        public bool IsCovarianceMatrixCalculated = false;

        /// <summary>
        /// 数据集的相关系数矩阵。
        /// </summary>
        public double[,] CorrelationMatrix;
        /// <summary>
        /// 数据集的相关系数矩阵是否已计算。
        /// </summary>
        public bool IsCorrelationMatrixCalculated = false;

        /// <summary>
        /// 数据集的特征向量矩阵。
        /// </summary>
        public double[,] EigenVectorsMatrix;
        /// <summary>
        /// 数据集的特征向量矩阵是否已计算。
        /// </summary>
        public bool IsEigenVectorsMatrixCalculated = false;

        /// <summary>
        /// 数据集每个波段的特征值。
        /// </summary>
        public double[] EigenValues;
        /// <summary>
        /// 数据集每个波段的特征值是否已计算。
        /// </summary>
        public bool IsEigenValuesCalculated = false;
        #endregion

        #region 影像显示
        /// <summary>
        /// 初始化影像显示信息。
        /// </summary>
        private void InitDisplayInfo()
        {
            InitColorTable();
            InitBandList();
            InitStretchInfo();
            Tools.Common.ResetStretchInfo(this);
        }

        /// <summary>
        /// 灰度影像的伪彩色颜色表。
        /// </summary>
        public Color[] Colortable { get; private set; } = new Color[256];
        /// <summary>
        /// 初始化默认伪彩色颜色表。使用前必须确认影像是否为灰度。
        /// </summary>
        private void InitColorTable()
        {
            if (IsGrayscale)
                SetColorTable(Color.Black, Color.White);
        }

        /// <summary>
        /// 设置伪彩色颜色表。使用前必须确认影像是否为灰度。
        /// </summary>
        /// <param name="StartColor">起始颜色。</param>
        /// <param name="EndColor">终止颜色。</param>
        /// <returns>返回操作成功或失败。</returns>
        public bool SetColorTable(Color StartColor, Color EndColor)
        {
            if (IsGrayscale)
            {
                for (int i = 0; i <= 255; i++)
                {
                    Colortable[i] = Color.FromArgb(
                        (int)(StartColor.A + i * (double)(EndColor.A - StartColor.A) / 255),
                        (int)(StartColor.R + i * (double)(EndColor.R - StartColor.R) / 255),
                        (int)(StartColor.G + i * (double)(EndColor.G - StartColor.G) / 255),
                        (int)(StartColor.B + i * (double)(EndColor.B - StartColor.B) / 255));
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 用于显示的波段组合。
        /// </summary>
        public int[] BandList;
        /// <summary>
        /// 初始化波段组合。
        /// </summary>
        private void InitBandList()
        {
            if (IsGrayscale)
            {
                BandList = new int[3] { 1, 1, 1 };
                return;
            }
            if (BandNum >= 3)
            {
                BandList = new int[3] { 1, 2, 3 };
            }
            else
            {
                FrmBandSelector BS = new FrmBandSelector(this)
                {
                    Text = "选择输入的波段组合...",
                };
                if (BS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.BandList = BS.BandList;
                }
                else
                {
                    BandList = new int[3] { 1, 2, 3 };
                }
                BS.Dispose();
                return;
            }
        }

        /// <summary>
        /// 设置新的波段组合。
        /// </summary>
        /// <param name="NewList">新的波段组合数组。</param>
        /// <returns>返回操作成功或失败。</returns>
        public bool SetBandList(int[] NewList)
        {
            if (NewList.Length != 3)
                throw new RankException("波段组合数组大小必须为3。");
            if (NewList[0] == BandList[0] && NewList[1] == BandList[1] && NewList[2] == BandList[2])    //更新的与原先组合相同，无需刷新位图缓存
                return false;
            BandList = NewList;
            return true;
        }

        /// <summary>
        /// 位图缓存。
        /// </summary>
        public Bitmap BitmapCache;

        /// <summary>
        /// 拉伸模式。
        /// </summary>
        public int StretchMode;

        /// <summary>
        /// 拉伸信息二元组，分别为左端点和右端点。
        /// </summary>
        public List<Tuple<double, double>> StretchInfo { get; private set; }
        /// <summary>
        /// 初始化数据集所有波段的拉伸端点信息，默认为该波段最小值和最大值。使用前必须先计算数据集的直方图及统计信息。
        /// </summary>
        /// <returns>返回操作成功或失败。</returns>
        private bool InitStretchInfo()
        {
            StretchInfo = new List<Tuple<double, double>>();
            for (int i = 0; i < BandNum; i++)
            {
                StretchInfo.Add(new Tuple<double, double>(Min[i], Max[i]));
            }
            InitStretchMode();
            return true;
        }

        /// <summary>
        /// 设置指定波段的拉伸信息。
        /// </summary>
        /// <param name="BandIndex">波段的数组索引（0为Band1）。</param>
        /// <param name="Min">拉伸区间的左端点。</param>
        /// <param name="Max">拉伸区间的右端点。</param>
        /// <returns>返回操作成功或失败。</returns>
        public bool SetStretchInfo(int BandIndex, double Min, double Max)
        {
            if (BandIndex < 0 || BandIndex > StretchInfo.Capacity)
                throw new ArgumentOutOfRangeException("指定的波段不存在。");
            StretchInfo[BandIndex] = new Tuple<double, double>(Min, Max);
            return true;
        }

        /// <summary>
        /// 初始化数据集拉伸模式。使用前必须先计算数据集的拉伸端点信息。
        /// </summary>
        /// <returns>返回操作成功或失败。</returns>
        private bool InitStretchMode()
        {
            if (IsGrayscale)
            {
                int i = 0;
                for (i = 0; i < BandNum; i++)
                {
                    if (StretchInfo[i].Item2 - StretchInfo[i].Item1 < 128)
                        break;
                    if (!(StretchInfo[i].Item1 >= 0 && StretchInfo[i].Item2 <= 255))
                        break;
                }
                if (i == BandNum)   //当且仅当数据集所有波段的像元值位于[0, 255]时才不进行拉伸
                    StretchMode = (int)StretchModes.No_stretch;
                else
                    StretchMode = (int)StretchModes.Linear_2;
            }
            else
            {
                int i = 0;
                for (i = 0; i < BandNum; i++)
                {
                    //真彩色直接读取即可
                    if (!(StretchInfo[i].Item1 >= 0 && StretchInfo[i].Item2 <= 255))
                        break;
                }
                if (i == BandNum)   //当且仅当数据集所有波段的像元值位于[0, 255]时才不进行拉伸
                    StretchMode = (int)StretchModes.No_stretch;
                else
                    StretchMode = (int)StretchModes.Linear_2;
            }
            return true;
        }

        /// <summary>
        /// 设置拉伸模式。设置完后需要手动重新获取Bitmap。
        /// </summary>
        /// <param name="NewMode">新的拉伸模式。</param>
        /// <returns>返回操作成功或失败。</returns>
        public bool SetStretchMode(int NewMode)
        {
            if (Enum.IsDefined(typeof(StretchModes), NewMode))
            {
                StretchMode = NewMode;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetStretchMode(StretchModes NewMode)
        {
            if (Enum.IsDefined(typeof(StretchModes), NewMode))
            {
                StretchMode = (int)NewMode;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。                 
                    GDALDataset.Dispose();
                    BitmapCache.Dispose();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~Img() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Img Image))
                return false;
            return (path == Image.path) && (IsGrayscale == Image.IsGrayscale) && (BandNum == Image.BandNum);
        }

        public override int GetHashCode()
        {
            return path.GetHashCode() * BandNum.GetHashCode();
        }

        #endregion
    }

    public class IHS
    {
        public IHS()
        {
            I = H = S = 0;
        }

        public IHS(double I,double H,double S)
        {
            this.I = I;
            this.H = H;
            this.S = S;
        }

        public IHS(int I, int H, int S)
        {
            this.I = I;
            this.H = H;
            this.S = S;
        }

        public IHS(double[] IHSArr)
        {
            if (IHSArr.Length != 3)
                throw new RankException("用于初始化的数组大小不正确，应为3。");
            I = IHSArr[0];
            H = IHSArr[1];
            S = IHSArr[2];
        }

        public IHS(int[] IHSArr)
        {
            if (IHSArr.Length != 3)
                throw new RankException("用于初始化的数组大小不正确，应为3。");
            I = IHSArr[0];
            H = IHSArr[1];
            S = IHSArr[2];
        }

        public double I;
        public double H;
        public double S;

        public double[] ToArray()
        {
            return new double[3] { I, H, S };
        }
    }
}
