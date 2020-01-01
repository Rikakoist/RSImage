using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage.Tools
{
    /// <summary>
    /// 空间域增强。
    /// </summary>
    public class SpatialEnhancement
    {
        /// <summary>
        /// 平滑锐化算法。
        /// </summary>
        /// <param name="InputDS">输入的栅格数据集。</param>
        /// <param name="OutDataType">输出的数据类型。</param>
        /// <param name="Method">平滑锐化方法。</param>
        /// <param name="OutPath">输出栅格数据集的位置。</param>
        /// <returns>返回操作成功或失败。</returns>
        public static bool SmoothSharpening(OSGeo.GDAL.Dataset InputDS, OSGeo.GDAL.DataType OutDataType, SmoothShapeninngMethods Method, string OutPath)
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

                int xSize = InputDS.RasterXSize;
                int ySize = InputDS.RasterYSize;

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在进行平滑锐化操作...",
                };

                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

                FP.Output("选择的平滑/锐化方法为：\"" + (typeof(SmoothShapeninngMethods).GetField((Method).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description + "\"");
                OSGeo.GDAL.Dataset DS = Dri.Create(OutPath, xSize, ySize, InputDS.RasterCount, OutDataType, null);
                FP.Output("已创建输出数据集\"" + OutPath + "\"，数据类型为" + OutDataType.ToString() + "。");
                Tools.Common.CopyMetadata(InputDS, DS);

                for (int band = 0; band < InputDS.RasterCount; band++) //遍历每个波段
                {
                    FP.SetProgress1("正在处理", band + 1, InputDS.RasterCount, "波段");
                    for (int Row = 0; Row < ySize - 2; Row++)   //从第1行遍历至倒数第三行
                    {
                        FP.SetProgress2("正在处理", Row, ySize - 2, "行");
                        double[] Values = new double[3 * xSize];  //读取的数值
                        double[] Result = new double[xSize];    //结果数值     
                        InputDS.GetRasterBand(band + 1).ReadRaster(0, Row, xSize, 3, Values, xSize, 3, 0, 0);  //读取3行
                        Array.Copy(Values, xSize, Result, 0, xSize);    //
                        for (int Col = 0; Col < xSize - 2; Col++)   //对每一个值进行计算
                        {
                            double[,] Input = new double[3, 3];
                            for (int i = 0; i < 3; i++)
                            {
                                Input[i, 0] = Values[Col + i * xSize];
                                Input[i, 1] = Values[Col + i * xSize + 1];
                                Input[i, 2] = Values[Col + i * xSize + 2];
                            }
                            Result[Col + 1] = SmoothSharpening(Input, Method);    //计算输入数据中心像元的值
                        }
                        //写结果到新栅格
                        DS.GetRasterBand(band + 1).WriteRaster(0, Row + 1, xSize, 1, Result, xSize, 1, 0, 0);
                    }
                    if ((Method.ToString()).Contains("Smooth"))
                    {
                        double[] row = new double[xSize];
                        InputDS.GetRasterBand(band + 1).ReadRaster(0, 0, xSize, 1, row, xSize, 1, 0, 0);  //读取第一行
                        DS.GetRasterBand(band + 1).WriteRaster(0, 0, xSize, 1, row, xSize, 1, 0, 0);
                        InputDS.GetRasterBand(band + 1).ReadRaster(0, ySize - 1, xSize, 1, row, xSize, 1, 0, 0);  //读取最后一行
                        DS.GetRasterBand(band + 1).WriteRaster(0, ySize - 1, xSize, 1, row, xSize, 1, 0, 0);
                    }
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
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        /// <summary>
        /// 平滑锐化模板应用。
        /// </summary>
        /// <param name="Input">输入的数据，大小为3×3。</param>
        /// <param name="Method">平滑锐化的方法。</param>
        /// <returns>平滑锐化结果。</returns>
        private static double SmoothSharpening(double[,] Input, SmoothShapeninngMethods Method)
        {
            if (Input.GetLength(0) != 3 || Input.GetLength(1) != 3)
                throw new RankException("输入数据大小错误，应为3×3。");
            double[,] Template1 = null;
            double[,] Template2 = null;
            switch (Method)
            {
                case SmoothShapeninngMethods.Smooth_SolitaryNoise:
                    {
                        Template1 = new double[3, 3] { { 1.0 / 8, 1.0 / 8, 1.0 / 8 }, { 1.0 / 8, 0, 1.0 / 8 }, { 1.0 / 8, 1.0 / 8, 1.0 / 8 } };
                        break;
                    }
                case SmoothShapeninngMethods.Smooth_LineNoise:
                    {
                        Template1 = new double[3, 3] { { 1.0 / 6, 1.0 / 6, 1.0 / 6 }, { 0, 0, 0 }, { 1.0 / 6, 1.0 / 6, 1.0 / 6 } };
                        break;
                    }
                case SmoothShapeninngMethods.Smooth_ColumnNoise:
                    {
                        Template1 = new double[3, 3] { { 1.0 / 6, 0, 1.0 / 6 }, { 1.0 / 6, 0, 1.0 / 6 }, { 1.0 / 6, 0, 1.0 / 6 } };
                        break;
                    }
                case SmoothShapeninngMethods.Smooth_MedianFiltering:
                    {
                        double[] arr = new double[9];
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                                arr[3 * i + j] = Input[i, j];
                        Array.Sort(arr);
                        return arr[4];
                    }
                case SmoothShapeninngMethods.Sharpening_PrewittOperator:
                    {
                        Template1 = new double[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
                        Template2 = new double[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
                        break;
                    }
                case SmoothShapeninngMethods.Sharpening_SobelGradient:
                    {
                        Template1 = new double[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
                        Template2 = new double[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                        break;
                    }
                case SmoothShapeninngMethods.Shrpening_LaplaceOperator4:
                    {
                        Template1 = new double[3, 3] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
                        Template2 = new double[3, 3] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } };
                        break;
                    }
                case SmoothShapeninngMethods.Shrpening_LaplaceOperator8:
                    {
                        Template1 = new double[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
                        Template2 = new double[3, 3] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } };
                        break;
                    }
                case SmoothShapeninngMethods.Shrpening_DirectionOperator:
                    {
                        Template1 = new double[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
                        Template2 = new double[3, 3] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } };
                        break;
                    }
            }
            if ((Method.ToString()).Contains("Smooth"))
                return TemplateBrush(Input, Template1);
            else
                return Math.Abs(TemplateBrush(Input, Template1)) + Math.Abs(TemplateBrush(Input, Template2));

        }

        /// <summary>
        /// 模板刷。将模板应用于指定的目标。
        /// </summary>
        /// <param name="Input">输入的数据。</param>
        /// <param name="Template">模板。</param>
        /// <returns>应用模板后的值。</returns>
        private static double TemplateBrush(double[,] Input, double[,] Template)
        {
            if (Input.GetLength(0) != Template.GetLength(0))
                throw new RankException("输入数据与模板的行数不一致。");
            if (Input.GetLength(1) != Template.GetLength(1))
                throw new RankException("输入数据与模板的列数不一致。");
            double Result = 0.0;
            for (int i = 0; i < Input.GetLength(0); i++)
            {
                for (int j = 0; j < Input.GetLength(1); j++)
                {
                    Result += Input[i, j] * Template[i, j];
                }
            }
            return Result;
        }
    }
}
