using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace RSImage.Tools
{
    class FloodProcessing
    {

        public static bool CalculateFloodArea(string InDir, string OutDir)
        {
            try
            {
                if (!Directory.Exists(InDir))
                    throw new FileNotFoundException("输入路径不存在。");
                if (!Directory.Exists(OutDir))
                    Directory.CreateDirectory(OutDir);
                OSGeo.GDAL.Driver Dri = OSGeo.GDAL.Gdal.GetDriverByName("Gtiff");
                if (Dri == null)
                    throw new Exception("无法获取GDAL Driver。");

                FrmProgress FP = new FrmProgress()
                {
                    Text = "正在处理洪水范围...",
                };
                Thread t = new Thread(() =>
                {
                    FP.ShowDialog();
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();


                bool createFlag = true;
                string[] ascFiles = Directory.GetFiles(InDir);
                int xSize = 0;
                int ySize = 0;
                OSGeo.GDAL.Dataset rangeDS = new OSGeo.GDAL.Dataset(IntPtr.Zero,false,null);
                OSGeo.GDAL.Dataset depthDS= new OSGeo.GDAL.Dataset(IntPtr.Zero, false, null);
                OSGeo.GDAL.Dataset timeDS = new OSGeo.GDAL.Dataset(IntPtr.Zero, false, null);

                for (int i = 0;i<ascFiles.Length;i++)
                {
                    FP.SetProgress2("正在处理文件：", i + 1, ascFiles.Length, "");
                    string tmpPath = ascFiles[i];
                    FP.Output("正在处理：" + (i + 1).ToString() + ". " +tmpPath);
                    if (tmpPath.Substring(tmpPath.LastIndexOf(".")) != ".txt")
                    {
                        FP.Output(tmpPath + "不是txt文件。");
                        continue;
                    }

                    OSGeo.GDAL.Dataset tmpDS = OSGeo.GDAL.Gdal.Open(tmpPath, OSGeo.GDAL.Access.GA_ReadOnly);
                    if (createFlag)
                    {
                        xSize = tmpDS.RasterXSize;
                        ySize = tmpDS.RasterYSize;
                        string inDirName = Path.GetDirectoryName(tmpPath).Substring(Path.GetDirectoryName(tmpPath).LastIndexOf("\\")+1);
                        rangeDS = Dri.Create(Path.Combine(OutDir, inDirName+"_floodRange.tiff"),xSize,ySize,1,OSGeo.GDAL.DataType.GDT_Float32,null);
                        Tools.Common.CopyMetadata(tmpDS, rangeDS);
                        FP.Output("已创建输出数据集\"" + Path.Combine(OutDir, inDirName + "_floodRange.tiff") + "\"。");

                        depthDS = Dri.Create(Path.Combine(OutDir, inDirName + "_floodDepth.tiff"), xSize, ySize, 1, OSGeo.GDAL.DataType.GDT_Float32, null);
                        Tools.Common.CopyMetadata(tmpDS, depthDS);
                        FP.Output("已创建输出数据集\"" + Path.Combine(OutDir, inDirName + "_floodDepth.tiff") + "\"。");

                        timeDS = Dri.Create(Path.Combine(OutDir, inDirName + "_floodTime.tiff"), xSize, ySize, 1, OSGeo.GDAL.DataType.GDT_Float32, null);
                        Tools.Common.CopyMetadata(tmpDS, timeDS);
                        FP.Output("已创建输出数据集\"" + Path.Combine(OutDir, inDirName + "_floodTime.tiff") + "\"。");

                        createFlag =false;
                    }

                    for (int Row = 0; Row < ySize; Row++)
                    {
                        double[] tmpValues = new double[xSize];
                        double[] rangeValues = new double[xSize];
                        double[] depthValues = new double[xSize];
                        double[] timeValues = new double[xSize];

                        tmpDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, tmpValues, xSize, 1, 0, 0);
                        rangeDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, rangeValues, xSize, 1, 0, 0);
                        depthDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, depthValues, xSize, 1, 0, 0);
                        timeDS.GetRasterBand(1).ReadRaster(0, Row, xSize, 1, timeValues, xSize, 1, 0, 0);

                        for (int Col = 0; Col < xSize; Col++)
                        {
                            //计算洪水范围
                            if(Math.Abs(tmpValues[Col])<=1e-7)  //Nodata
                            {
                                continue;
                            }
                            else
                            {
                                rangeValues[Col] = 1;
                                if (tmpValues[Col] > depthValues[Col])
                                {
                                    depthValues[Col] = tmpValues[Col];
                                }
                                timeValues[Col]+=1;
                            }
                        }

                        rangeDS.GetRasterBand(1).WriteRaster(0, Row, xSize, 1, rangeValues, xSize, 1, 0, 0);
                        rangeDS.FlushCache();
                        depthDS.GetRasterBand(1).WriteRaster(0, Row, xSize, 1, depthValues, xSize, 1, 0, 0);
                        depthDS.FlushCache();
                        timeDS.GetRasterBand(1).WriteRaster(0, Row, xSize, 1, timeValues, xSize, 1, 0, 0); 
                        timeDS.FlushCache();
                    }


                      tmpDS.Dispose();
                    Thread.Sleep(1);
                    if (FP.Canceled)
                    {
                        Thread.Sleep(500);

                        FP.Finish();
                        throw new OperationCanceledException("操作被用户取消。");
                    }
                }
                FP.Finish();
                rangeDS.Dispose();
                depthDS.Dispose();
                timeDS.Dispose();
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
