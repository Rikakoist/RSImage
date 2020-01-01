using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS;
using ESRI.ArcGIS.Carto;

namespace ImgROISel
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
                    Environment.Exit(-1);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Args.Length != 1)
            {
                Args = new string[1];

            SelectFile:
                OpenFileDialog OFD = new OpenFileDialog()
                {
                    CheckPathExists = true,
                    Multiselect = false,
                    Title = "选择栅格底图...",
                };
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    IRasterLayer lyr = new RasterLayerClass();
                    try
                    {
                        lyr.CreateFromFilePath(OFD.FileName);
                        if (lyr != null)
                        {
                            Args[0] = OFD.FileName;
                        }
                        else
                        {
                            MessageBox.Show("选中的文件不能作为底图，请重新选择。");
                            goto SelectFile;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("选中的文件不能作为底图，请重新选择。");
                        goto SelectFile;
                    }
                }
                else
                {
                    Environment.Exit(-1);
                }
            }

            Application.Run(new MainForm(Args[0]));
        }
    }
}