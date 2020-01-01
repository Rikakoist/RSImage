using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;

namespace ImgGeoReg
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            if (!RuntimeManager.Bind(ProductCode.Engine))
            {
                if (!RuntimeManager.Bind(ProductCode.Desktop))
                {
                    MessageBox.Show("Unable to bind to ArcGIS runtime. Application will be shut down.");
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Args.Length != 2)
            {
                Args = new string[2];
                
                SelectFile1:
                OpenFileDialog OFD = new OpenFileDialog()
                {                   
                    CheckPathExists = true,
                    Multiselect = false,
                    Title="选择栅格底图...",                  
                };
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    IRasterLayer lyr = new RasterLayerClass();
                    try
                    {
                        lyr.CreateFromFilePath(OFD.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("选中的文件不能作为底图，请重新选择。");
                        goto SelectFile1;
                    }
                    if (lyr != null)
                    {
                        Args[0] = OFD.FileName;
                        SelectFile2:
                        OFD = new OpenFileDialog()
                        {
                            CheckPathExists = true,
                            Multiselect = false,
                            Title = "选择要配准的栅格影像...",
                        };
                        if (OFD.ShowDialog() == DialogResult.OK)
                        {
                            lyr = new RasterLayerClass();
                            try
                            {
                                lyr.CreateFromFilePath(OFD.FileName);
                            }
                            catch
                            {
                                MessageBox.Show("选中的文件不能作为配准影像，请重新选择。");
                                goto SelectFile2;
                            }
                            if (lyr != null)
                            {
                                Args[1] = OFD.FileName;
                            }
                            else
                            {
                                MessageBox.Show("选中的文件不能作为配准影像，请重新选择。");
                                goto SelectFile2;
                            }
                        }
                        else
                        {
                            Environment.Exit(-1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("选中的文件不能作为底图，请重新选择。");
                        goto SelectFile1;
                    }
                }
                else
                {
                    Environment.Exit(-1);
                }
            }

            Application.Run(new MainForm(Args[0],Args[1]));

        }
    }
}