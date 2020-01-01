 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage.Tools
{
    /// <summary>
    /// 辐射校正。
    /// </summary>
    class RadiometricCalibration
    {

        #region 辐射定标
        /// <summary>
        /// 辐射定标。
        /// </summary>
        /// <param name="InputDS">输入的栅格数据集。</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <param name="Gain">增益倍数。</param>
        /// <param name="Offset">偏移量。</param>
        /// <param name="OutPath">输出栅格数据集的位置。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool ApplyGainAndOffset(OSGeo.GDAL.Dataset InputDS, OSGeo.GDAL.DataType OutDataType, List<double> Gain, List<double> Offset, string OutPath)
        {
            try
            {
                if (InputDS == null)
                    throw new ArgumentNullException("输入数据集为空。");
                if (String.IsNullOrWhiteSpace(OutPath.Trim()))
                    throw new ArgumentNullException("输出路径为空或非法。");
                if ((Gain.Count != InputDS.RasterCount) || (Offset.Count != InputDS.RasterCount))
                    throw new IndexOutOfRangeException("增益数据或偏移数据与输入数据集波段数不符。");
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行辐射定标...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;
                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, InputDS.RasterCount, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(InputDS, DS);

                for (int i = 0; i < InputDS.RasterCount; i++) //遍历每个波段
                {
                    FP.SetProgress2("正在处理波段：",i+1, InputDS.RasterCount,"");
                    for (int Row = 0; Row < ySize; Row++)   //遍历每一行(y)
                    {
                        FP.SetProgress1("正在处理：", Row + 1, ySize, "行");
                        double[] Values = new double[xSize];

                        //读取DN到数组
                        InputDS.GetRasterBand(i + 1).ReadRaster(0, Row, xSize, 1, Values, xSize, 1, 0, 0);
                        for (int Col = 0; Col < xSize; Col++)   //对每一个值进行计算
                        {
                            Values[Col] = GainOffset(Values[Col], Gain[i], Offset[i]);
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
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        /// <summary>
        /// 增益偏移计算
        /// </summary>
        /// <param name="DN">输入的像元数值。</param>
        /// <param name="Gain">增益倍数。</param>
        /// <param name="Offset">偏移量。</param>
        /// <returns>返回计算值。</returns>
        private static double GainOffset(double DN, double Gain, double Offset)
        {
            return (Gain * DN + Offset);
        }

        /// <summary>
        /// 拉伸至范围
        /// </summary>
        /// <param name="DN">输入的像元数值。</param>
        /// <param name="LMax">整个栅格中的最大值。</param>
        /// <param name="LMin">整个栅格中的最小值。</param>
        /// <param name="Bit">影像量化位数。</param>
        /// <returns>返回计算值。</returns>
        private static double Stretch(double DN, double LMax, double LMin, int Bit)
        {
            return (DN * (LMax - LMin) / ((1 << Bit) - 1)) + LMin;
        }
        #endregion

        #region 地形校正
        //𝐿_𝑇=𝑎+𝑏*cos⁡(𝑖)
        //𝐿_𝐻=𝐿_𝑇+(cos⁡(𝜃𝑠)+𝑎/𝑏)/(cos⁡(𝑖)+𝑎/𝑏)
        //cos⁡𝑖=cos⁡(𝜃𝑠)*cos⁡𝑆+sin⁡(𝜃𝑠) cos⁡(𝜑𝑠−𝐴)

        public static OSGeo.GDAL.Dataset CCorrectionn(OSGeo.GDAL.Dataset InputDS, OSGeo.GDAL.DataType OutputDataType, string OutPath)
        {
            return null;
        }
        #endregion

    }
}
