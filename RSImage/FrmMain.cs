using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;
using System.Diagnostics;

namespace RSImage
{
    public partial class FrmMain : Form
    {
        List<Img> Images = new List<Img>();
        int DisplayImageIndex = -1;
        bool CanRedraw = true;
        bool NeedRedraw = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FormLoading(object sender, EventArgs e)
        {
            try
            {
                this.SetHint("你好，" + Environment.UserName);
                OSGeo.GDAL.Gdal.AllRegister();
                OSGeo.GDAL.Gdal.SetConfigOption("GDAL_FILENAME_IS_UTF8", "YES");
                //初始化拉伸模式组框
                for (int i = 0; i < Enum.GetNames(typeof(StretchModes)).GetLength(0); i++)
                {
                    StretchModeToolStripComboBox.Items.Add((typeof(StretchModes).GetField(((StretchModes)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString() + "\r\n可能缺失dll文件。", "初始化错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void SetHint(string Str)
        {
            HintLabel.Text = Str;
            this.Refresh();
        }

        public void SetProgress(int Value)
        {
            OperationProgressBar.Value = Value;
            OperationProgressBar.Invalidate();
        }

        private void ExitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region TreeView
        private void ManageTreeView()
        {
            ImageListTreeView.Nodes.Clear();
            ImageListTreeView.Nodes.Add("ImageRoot", "Images", 0, 0);   //根节点
            if (Images.Count > 0)
            {
                TreeNode TNRoot = ImageListTreeView.Nodes[0];
                //逐图片添加
                for (int i = 0; i < Images.Count; i++)
                {
                    Img CurrentImage = Images[i];
                    if (CurrentImage.IsGrayscale)  //灰度
                        TNRoot.Nodes.Add(Path.GetFileName(CurrentImage.Path), Path.GetFileName(CurrentImage.Path), 1, 1);
                    else   //彩色
                        TNRoot.Nodes.Add(Path.GetFileName(CurrentImage.Path), Path.GetFileName(CurrentImage.Path), 2, 2);
                    TreeNode TN = TNRoot.Nodes[i];
                    if (!CurrentImage.IsGrayscale)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            TN.Nodes.Add("Band" + CurrentImage.BandList[j].ToString(), "Band " + CurrentImage.BandList[j].ToString(), j + 3, j + 3);
                        }
                    }
                }
                ImageListTreeView.ExpandAll();
            }
        }

        //更改当前选择影像的波段组合
        private void EditBand()
        {
            for (int i = 0; i < 3; i++)
                ImageListTreeView.Nodes["ImageRoot"].Nodes[Path.GetFileName(Images[DisplayImageIndex].Path)].Nodes[i].Text = "Band " + Images[DisplayImageIndex].BandList[i].ToString();
        }

        //更改当前选中影像
        private void ChangeSelectedFile(object sender, TreeNodeMouseClickEventArgs e)
        {
            ImageViewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (e.Node.Name != "ImageRoot" && e.Node.Level == 1 && DisplayImageIndex == -1)
            {
                DisplayImageIndex = e.Node.Index;
                ImageShow();
                return;
            }
            if (e.Node.Name != "ImageRoot" && e.Node.Level == 1 && e.Node.Text != Path.GetFileName(Images[DisplayImageIndex]?.Path))
            {
                DisplayImageIndex = e.Node.Index;
                ImageShow();
                return;
            }
        }
        #endregion

        #region 影像显示
        //刷新PictureBox和控制拉伸模式选单可用性
        private void ImageShow()
        {
            if (DisplayImageIndex == -1)
            {
                StretchModeToolStripComboBox.Enabled = false;
                ImageViewPictureBox.Image = null;
                ImageViewPictureBox.Invalidate();
                return;
            }
            else
            {
                StretchModeToolStripComboBox.Enabled = true;
                StretchModeToolStripComboBox.SelectedIndex = Images[DisplayImageIndex].StretchMode;
                ImageViewPictureBox.Image = Images[DisplayImageIndex].BitmapCache;
            }
        }

        //拉伸模式下拉框的SelectedIndexChanged事件，用于更改选中影像的拉伸模式。
        private void ChangeStretchMode(object sender, EventArgs e)
        {
            if (DisplayImageIndex != -1 && StretchModeToolStripComboBox.SelectedIndex != Images[DisplayImageIndex].StretchMode)
            {
                if (Images[DisplayImageIndex].SetStretchMode(StretchModeToolStripComboBox.SelectedIndex))
                {
                    Tools.Common.ResetStretchInfo(Images[DisplayImageIndex]);
                    RedrawBitmap(null, null);
                }
            }
        }

        //需要重绘Bitmap的情况
        private void RedrawBitmap(object sender, EventArgs e)
        {
            if (CanRedraw)
            {
                if (DisplayImageIndex != -1)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Tools.Common.RebuildBitmap(Images[DisplayImageIndex], ImageViewPictureBox.Width, ImageViewPictureBox.Height);
                    ImageShow();
                    this.Cursor = Cursors.Arrow;
                }
            }
            else
            {
                NeedRedraw = true;
            }
        }

        private void FrmImageView_MouseDown(object sender, MouseEventArgs e)
        {
            CanRedraw = false;
        }

        private void FrmImageView_MouseUp(object sender, MouseEventArgs e)
        {
            CanRedraw = true;
            if (NeedRedraw)
            {
                NeedRedraw = false;
                RedrawBitmap(null, null);
            }
        }
        #endregion

        #region 菜单工具
        //直方图匹配
        private void HistogramMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS1 = new FrmImgSelect(Images, "直方图匹配 - 选择要进行直方图匹配的影像...");
                if (FIS1.ShowDialog(this) == DialogResult.OK)
                {
                    FrmImgSelect FIS2 = new FrmImgSelect(Images, "直方图匹配 - 选择要匹配到的影像...");
                    if (FIS2.ShowDialog(this) == DialogResult.OK)
                    {
                        if (FIS1.SelectedImg.BandNum != FIS2.SelectedImg.BandNum)
                            throw new ArgumentException("选择的两影像波段数不一致。");
                        FrmExport E = new FrmExport();
                        if (E.ShowDialog(this) == DialogResult.OK)
                        {
                            if (Tools.BaseProcess.HistogramMatching(FIS1.SelectedImg.GDALDataset, FIS2.SelectedImg.GDALDataset, FIS1.SelectedImg.CumulativeProbability, FIS2.SelectedImg.CumulativeProbability, E.OutDataType, E.OutPath))
                            {
                                CheckFile(E.OutPath);
                                ManageTreeView();
                            }
                        }
                        E.Dispose();
                    }
                    FIS2.Dispose();
                }
                FIS1.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //重分类
        private void ReclassifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "重分类 - 选择单波段影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    if (FIS.SelectedImg.BandNum != 1)
                        throw new ArgumentException("选择的影像不是灰度影像。");
                    FrmRoughness RF = new FrmRoughness(FIS.SelectedImg);
                    if (RF.ShowDialog(this) == DialogResult.OK)
                    {
                        switch(RF.ConvertMode)
                        {
                            case 0:
                                {
                                    if (Tools.BaseProcess.ReplaceNoData(FIS.SelectedImg.GDALDataset,RF.NoDataValue,RF.ReplaceValue,RF.OutDataType,RF.OutPath))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        throw new OperationCanceledException("操作中断。");
                                    }
                                }
                            case 1:
                                {
                                    if (Tools.BaseProcess.Reclassify(FIS.SelectedImg.GDALDataset,RF.ReplaceList,RF.OutDataType,RF.OutPath))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        throw new OperationCanceledException("操作中断。");
                                    }
                                }
                            default:
                                {
                                    throw new ArgumentException("重分类模式参数错误。");
                                }
                        }
                        CheckFile(RF.OutPath);
                        ManageTreeView();               
                    }
                    RF.Dispose();
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //灰度转换到栅格
        private void ConvertToAAIGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "灰度影像转换到栅格 - 选择影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    FrmExport E = new FrmExport(Filter: "All files|*.*|AAIGrid files|*.asc");
                    E.EFFilePathSelector.OutDataType = FIS.SelectedImg.GDALDataset.GetRasterBand(1).DataType;
                    if (E.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Tools.BaseProcess.ConvertToAAIGrid(FIS.SelectedImg.GDALDataset, "AAIGrid", E.OutPath))
                        {
                            CheckFile(E.OutPath);
                            ManageTreeView();
                        }
                    }
                    E.Dispose();
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //影像裁剪
        private void ImageCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog()
                {
                    AutoUpgradeEnabled=true,
                    CheckFileExists = true,
                    InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                    Multiselect = false,
                    Title = "选择要进行分割的影像...",
                };
                if (OFD.ShowDialog(this) == DialogResult.OK)
                {
                    OSGeo.GDAL.Dataset tmpCutDS= OSGeo.GDAL.Gdal.Open(OFD.FileName, OSGeo.GDAL.Access.GA_ReadOnly);
                    if (tmpCutDS == null)
                        return;

                    FrmCut FC = new FrmCut(tmpCutDS.RasterXSize, tmpCutDS.RasterYSize, "影像裁剪 - "+Path.GetFileName(OFD.FileName));
                    if (FC.ShowDialog(this) == DialogResult.OK)
                    {
                        Tools.BaseProcess.CutImage(tmpCutDS,FC.ImgWidth,FC.ImgHeight,DataType.GDT_Byte,FC.OutPath);
                    }
                    FC.Dispose();
                }
                OFD.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //阈值分割
        private void ThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "阈值分割 - 选择单波段影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    if (FIS.SelectedImg.BandNum != 1)
                        throw new ArgumentException("选择的影像不是灰度影像。");
                    FrmBinarize FB = new FrmBinarize(FIS.SelectedImg);
                    if (FB.ShowDialog(this) == DialogResult.OK)
                    {
                        switch (FB.method)
                        {
                            //手动
                            case ImageSplitMethods.Manual_None:
                                {
                                    if (Tools.ImageSplit.Binarize(FIS.SelectedImg.GDALDataset, FB.Threshold, FB.ZeroValueSelector.Value, FB.OneValueSelector.Value, FB.BFilePathSelector.OutDataType, FB.BFilePathSelector.Path))
                                    {
                                        CheckFile(FB.BFilePathSelector.Path);
                                        ManageTreeView();
                                    }
                                    break;
                                }
                            //Otsu
                            case ImageSplitMethods.Auto_Otsu:
                                {
                                    double tmpThreshold = Tools.ImageSplit.Otsu(FIS.SelectedImg.GDALDataset);
                                    if (Tools.ImageSplit.Binarize(FIS.SelectedImg.GDALDataset, tmpThreshold, FB.ZeroValueSelector.Value, FB.OneValueSelector.Value, FB.BFilePathSelector.OutDataType, FB.BFilePathSelector.Path))
                                    {
                                        CheckFile(FB.BFilePathSelector.Path);
                                        ManageTreeView();
                                    }
                                    break;
                                }
                            //迭代
                            case ImageSplitMethods.Auto_Iterate:
                                {
                                    double tmpThreshold = Tools.ImageSplit.IterateThreshold(FIS.SelectedImg.GDALDataset);
                                    if (Tools.ImageSplit.Binarize(FIS.SelectedImg.GDALDataset, tmpThreshold, FB.ZeroValueSelector.Value, FB.OneValueSelector.Value, FB.BFilePathSelector.OutDataType, FB.BFilePathSelector.Path))
                                    {
                                        CheckFile(FB.BFilePathSelector.Path);
                                        ManageTreeView();
                                    }
                                    break;
                                }
                        }
                    }
                    FB.Dispose();
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //辐射定标
        private void ApplyGainAndOffsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "辐射定标 - 选择要进行辐射定标的影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    FrmApplyGainOffset AGAO = new FrmApplyGainOffset(FIS.SelectedImg.BandNum);
                    if (AGAO.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Tools.RadiometricCalibration.ApplyGainAndOffset(FIS.SelectedImg.GDALDataset, AGAO.OutDataType, AGAO.Gains, AGAO.Offsets, AGAO.OutPath))
                        {
                            CheckFile(AGAO.OutPath);
                            ManageTreeView();
                        }
                    }
                    AGAO.Dispose();
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //地理配准
        private void GeoreferncingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS1 = new FrmImgSelect(Images, "地理配准 - 选择栅格底图...");
                if (FIS1.ShowDialog(this) == DialogResult.OK)
                {
                    FrmImgSelect FIS2 = new FrmImgSelect(Images, "地理配准 - 选择要配准的栅格影像...");
                    if (FIS2.ShowDialog(this) == DialogResult.OK)
                    {
                        FrmExport FE = new FrmExport();
                        if (FE.ShowDialog(this) == DialogResult.OK)
                        {
                            //string fileName = @"D:\Documents\VSProjects\RSImage\ImgGeoReg\bin\Debug\ImgGeoReg.exe";
                            string fileName = @"REG\ImgGeoReg.exe";
                            if (!File.Exists(fileName))
                            {
                                MessageBox.Show("配准程序不存在，请重新指定位置。");
                                OpenFileDialog OFD = new OpenFileDialog()
                                {
                                    CheckFileExists = true,
                                    Filter = "可执行文件(*.exe)|*.exe",
                                    FilterIndex = 1,
                                    Multiselect = false,
                                    Title= "指定配准程序...",
                                };
                                if(OFD.ShowDialog()==DialogResult.OK)
                                {
                                    fileName = OFD.FileName;
                                }
                                else
                                {
                                    throw new OperationCanceledException("操作被用户取消。");
                                }
                            }
                            File.Copy(FIS2.SelectedImg.Path, FE.OutPath);
                            ProcessStartInfo startInfo = new ProcessStartInfo
                            {
                                FileName = fileName, //启动的应用程序路径
                                Arguments = FIS1.SelectedImg.Path + " " + FE.OutPath,
                                WindowStyle = ProcessWindowStyle.Maximized,
                            };
                            Process P = Process.Start(startInfo);
                            P.WaitForExit();
                            if (P.ExitCode == 1)
                            {
                                MessageBox.Show("配准已完成，GCP存储在xml文件中。");
                            }
                            else
                            {
                                MessageBox.Show("配准程序出现异常或操作被用户取消。");
                            }
                        }
                        FE.Dispose();
                    }
                    FIS2.Dispose();
                }
                FIS1.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //平滑锐化
        private void SmoothSharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "平滑锐化 - 选择影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    FrmSmooth S = new FrmSmooth(FIS.SelectedImg);
                    if (S.ShowDialog(this) == DialogResult.OK)
                    {
                        CheckFile(S.OutPath);
                        ManageTreeView();
                        S.Dispose();
                    }
                    FIS.Dispose();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //滤波
        private void FFTFiltToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Brovey融合
        private void BroveyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //选择全色影像
                FrmImgSelect FIS1 = new FrmImgSelect(Images, "Brovey融合 - 选择全色影像...");
                if (FIS1.ShowDialog(this) == DialogResult.OK)
                {
                    if (FIS1.SelectedImg.BandNum != 1)
                        throw new ArgumentException("全色影像光谱数不为1。");
                    //选择多光谱影像
                    FrmImgSelect FIS2 = new FrmImgSelect(Images, "Brovey融合 - 选择多光谱影像...");
                    if (FIS2.ShowDialog(this) == DialogResult.OK)
                    {
                        //选择多光谱影像波段组合
                        FrmBandSelector FBS = new FrmBandSelector(FIS2.SelectedImg);
                        if (FBS.ShowDialog(this) == DialogResult.OK)
                        {
                            //选择导出位置
                            FrmExport E = new FrmExport();
                            if (E.ShowDialog(this) == DialogResult.OK)
                            {
                                if (Tools.ImageFusion.Brovey(FIS1.SelectedImg.GDALDataset, FIS2.SelectedImg.GDALDataset, FIS1.SelectedImg.CumulativeProbability, FIS2.SelectedImg.CumulativeProbability, FBS.BandList, E.OutDataType, E.OutPath))
                                {
                                    CheckFile(E.OutPath);
                                    ManageTreeView();
                                }
                                E.Dispose();
                            }
                            FBS.Dispose();
                        }
                        FIS2.Dispose();
                    }
                    FIS1.Dispose();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //IHS融合
        private void IHSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //选择全色影像
                FrmImgSelect FIS1 = new FrmImgSelect(Images, "IHS融合 - 选择全色影像...");
                if (FIS1.ShowDialog(this) == DialogResult.OK)
                {
                    if (FIS1.SelectedImg.BandNum != 1)
                        throw new ArgumentException("全色影像光谱数不为1。");
                    //选择多光谱影像
                    FrmImgSelect FIS2 = new FrmImgSelect(Images, "IHS融合 - 选择多光谱影像...");
                    if (FIS2.ShowDialog(this) == DialogResult.OK)
                    {
                        //选择多光谱影像波段组合
                        FrmBandSelector FBS = new FrmBandSelector(FIS2.SelectedImg);
                        if (FBS.ShowDialog(this) == DialogResult.OK)
                        {
                            //选择导出位置
                            FrmExport E = new FrmExport();
                            if (E.ShowDialog(this) == DialogResult.OK)
                            {
                                if (Tools.ImageFusion.IHSFusion(FIS1.SelectedImg.GDALDataset, FIS2.SelectedImg.GDALDataset, FIS1.SelectedImg.CumulativeProbability, FIS2.SelectedImg.CumulativeProbability, FBS.BandList, E.OutDataType, E.OutPath))
                                {
                                    CheckFile(E.OutPath);
                                    ManageTreeView();
                                }
                                E.Dispose();
                            }
                            FBS.Dispose();
                        }
                        FIS2.Dispose();
                    }
                    FIS1.Dispose();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //变化检测
        private void ChangeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //选择第一张影像
                FrmImgSelect FIS1 = new FrmImgSelect(Images, "变化检测 - 选择变化前影像...");
                if (FIS1.ShowDialog(this) == DialogResult.OK)
                {
                    //选择第二张影像
                    FrmImgSelect FIS2 = new FrmImgSelect(Images, "变化检测 - 选择变化后影像...");
                    if (FIS2.ShowDialog(this) == DialogResult.OK)
                    {
                        //选择差值影像导出位置
                        FrmExport E1 = new FrmExport("选择差值计算结果存储位置。");
                        if (E1.ShowDialog(this) == DialogResult.OK)
                        {
                            //选择比值影像导出位置
                            FrmExport E2 = new FrmExport("选择比值计算结果存储位置。");
                            if (E2.ShowDialog(this) == DialogResult.OK)
                            {
                                string tmpD1Gray= Tools.Common.GetTempFileName();
                                string tmpD2Gray = Tools.Common.GetTempFileName();

                                string tmpMinus = Tools.Common.GetTempFileName();
                                string tmpDivide = Tools.Common.GetTempFileName();
                                bool divSucc = false;
                                bool minusSucc = false;

                                //灰度化
                                if (Tools.Common.RGB2GrayScale(FIS1.SelectedImg, new double[3] { 0.299, 0.587, 0.114 }, DataType.GDT_Float32, tmpD1Gray))
                                {
                                    OSGeo.GDAL.Dataset tmpD1GrayDS = OSGeo.GDAL.Gdal.Open(tmpD1Gray, OSGeo.GDAL.Access.GA_ReadOnly);
                                    if (Tools.Common.RGB2GrayScale(FIS2.SelectedImg, new double[3] { 0.299, 0.587, 0.114 }, DataType.GDT_Float32, tmpD2Gray))
                                    {
                                        OSGeo.GDAL.Dataset tmpD2GrayDS = OSGeo.GDAL.Gdal.Open(tmpD2Gray, OSGeo.GDAL.Access.GA_ReadOnly);

                                        //相减
                                        if (Tools.BaseProcess.Minus(tmpD2GrayDS, tmpD1GrayDS, DataType.GDT_Float32, tmpMinus))
                                        {
                                            OSGeo.GDAL.Dataset tmpMinusDS = OSGeo.GDAL.Gdal.Open(tmpMinus, OSGeo.GDAL.Access.GA_ReadOnly);
                                            if (Tools.ImageSplit.Binarize(tmpMinusDS, Tools.ImageSplit.IterateThreshold(tmpMinusDS), 0, 1, E1.OutDataType, E1.OutPath))
                                            {
                                                minusSucc = true;
                                            }
                                            tmpMinusDS.Dispose();
                                            if (File.Exists(tmpMinus))
                                                File.Delete(tmpMinus);
                                        }

                                        //相除
                                        if (Tools.BaseProcess.Divide(tmpD2GrayDS, tmpD1GrayDS, DataType.GDT_Float32, tmpDivide))
                                        {
                                            OSGeo.GDAL.Dataset tmpDivideDS = OSGeo.GDAL.Gdal.Open(tmpDivide, OSGeo.GDAL.Access.GA_ReadOnly);
                                            if (Tools.ImageSplit.Binarize(tmpDivideDS, Tools.ImageSplit.IterateThreshold(tmpDivideDS), 0, 1, E2.OutDataType, E2.OutPath))
                                            {
                                                divSucc = true;
                                            }
                                            tmpDivideDS.Dispose();
                                            if (File.Exists(tmpDivide))
                                                File.Delete(tmpDivide);
                                        }
                                        tmpD2GrayDS.Dispose();
                                        if (File.Exists(tmpD2Gray))
                                            File.Delete(tmpD2Gray);
                                    }
                                    tmpD1GrayDS.Dispose();
                                    if (File.Exists(tmpD1Gray))
                                        File.Delete(tmpD1Gray);
                                }
                                if (minusSucc)
                                {
                                    CheckFile(E1.OutPath);
                                    ManageTreeView();
                                }
                                if (divSucc)
                                {
                                    CheckFile(E2.OutPath);
                                    ManageTreeView();
                                }
                            }
                            E2.Dispose();
                        }
                        E1.Dispose();
                    }
                    FIS2.Dispose();
                }
                FIS1.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //K-Means非监督分类
        private void KMeansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {        
                FrmImgSelect FIS = new FrmImgSelect(Images, "K-Means非监督分类 - 选择影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    FrmKMeans FKM = new FrmKMeans();
                    if (FKM.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Tools.ImageClassification.KMeans(FIS.SelectedImg.GDALDataset,FKM.NumOfClass,FKM.MaxIterate,FKM.ChangeThreshold,FKM.Path))
                        {
                            CheckFile(FKM.Path);
                            ManageTreeView();
                        }
                    }
                    FKM.Dispose();
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //Iso Data非监督分类
        private void IsoDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "Iso Data非监督分类 - 选择影像...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    FrmIsoData FID = new FrmIsoData();
                    if (FID.ShowDialog(this) == DialogResult.OK)
                    {
                        if (Tools.ImageClassification.IsoData(FIS.SelectedImg.GDALDataset, FID.MinNumOfClass, FID.MaxNumOfClass, FID.MaxIterate, FID.MaxClassStddev, FID.MinPixCountInClass, FID.MaxClassStddev, FID.MinClassDistance, FID.Path))
                        {
                            CheckFile(FID.Path);
                            ManageTreeView();
                        }
                    }
                    FID.Dispose();
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //监督分类（选ROI）
        private void SupervisedClassificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmImgSelect FIS = new FrmImgSelect(Images, "监督分类 - 选择栅格底图...");
                if (FIS.ShowDialog(this) == DialogResult.OK)
                {
                    //string fileName = @"D:\Documents\VSProjects\RSImage\supervised_test\bin\Debug\CreateROI.exe";
                    string fileName = @"ROI\CreateROI.exe";
                    if (!File.Exists(fileName))
                    {
                        MessageBox.Show("勾选ROI程序不存在，请重新指定位置。");
                        OpenFileDialog OFD = new OpenFileDialog()
                        {
                            CheckFileExists = true,
                            Filter = "可执行文件(*.exe)|*.exe",
                            FilterIndex = 1,
                            Multiselect = false,
                            Title = "指定勾选ROI程序...",
                        };
                        if (OFD.ShowDialog() == DialogResult.OK)
                        {
                            fileName = OFD.FileName;
                        }
                        else
                        {
                            throw new OperationCanceledException("操作被用户取消。");
                        }
                    }
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = fileName, //启动的应用程序路径
                        Arguments = FIS.SelectedImg.Path,
                        WindowStyle = ProcessWindowStyle.Maximized,
                    };
                    Process P = Process.Start(startInfo);
                    P.WaitForExit();
                    if (P.ExitCode ==1)
                    {
                        MessageBox.Show("ROI勾选已完成，请在ENVI中完成监督分类。\r\n（没时间写了，这个程序是我拿的群里曹老大的改的o(=•ェ•=)m）。");
                    }
                    else
                    {
                        MessageBox.Show("ROI勾选程序出现异常或操作被用户取消。");
                    }
                }
                FIS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        #endregion

        #region 右键菜单
        //Opening事件，根据情况调整可用性
        private void TreeViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //未选中任何影像，禁用所有菜单。
            if (DisplayImageIndex == -1)
            {
                ViewHistogramToolStripMenuItem.Enabled = false;
                ChangeBandToolStripMenuItem.Enabled = false;
                Gray2RGBToolStripMenuItem.Enabled = false;
                RGB2GrayToolStripMenuItem.Enabled = false;
                ExportViewToolStripMenuItem.Enabled = false;
                ViewMetadataToolStripMenuItem.Enabled = false;
                CloseCurrentImageToolStripMenuItem.Enabled = false;
            }
            //选中灰度图。 
            if (DisplayImageIndex != -1 && Images[DisplayImageIndex].IsGrayscale)
            {
                ViewHistogramToolStripMenuItem.Enabled = true;
                ChangeBandToolStripMenuItem.Enabled = false;
                Gray2RGBToolStripMenuItem.Enabled = true;
                RGB2GrayToolStripMenuItem.Enabled = false;
                ExportViewToolStripMenuItem.Enabled = true;
                ViewMetadataToolStripMenuItem.Enabled = true;
                CloseCurrentImageToolStripMenuItem.Enabled = true;
            }
            //选中彩色图。 
            if (DisplayImageIndex != -1 && !Images[DisplayImageIndex].IsGrayscale)
            {
                ViewHistogramToolStripMenuItem.Enabled = true;
                ChangeBandToolStripMenuItem.Enabled = true;
                Gray2RGBToolStripMenuItem.Enabled = false;
                RGB2GrayToolStripMenuItem.Enabled = true;
                ExportViewToolStripMenuItem.Enabled = true;
                ViewMetadataToolStripMenuItem.Enabled = true;
                CloseCurrentImageToolStripMenuItem.Enabled = true;
            }
        }

        //右键查看直方图
        private void ViewHistogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Images[DisplayImageIndex].Path != null)
            {
                FrmViewHistogram VH = new FrmViewHistogram(Images[DisplayImageIndex])
                {
                    Path = Images[DisplayImageIndex].Path
                };
                VH.Show();
            }
        }

        //更改波段组合
        private void ChangeBandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBandSelector BS = new FrmBandSelector(Images[DisplayImageIndex]);
                if (BS.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    //若更改后的波段和原先不一样则刷新位图缓存。
                    if (Images[DisplayImageIndex].SetBandList(BS.BandList))
                        RedrawBitmap(null, null);
                    ImageShow();
                    EditBand();
                }
                BS.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //伪彩色颜色表
        private void ChangeColorTable(object sender, EventArgs e)
        {
            if (Images[DisplayImageIndex].IsGrayscale)
            {
                if (sender == GrayscaleToolStripMenuItem)
                {
                    Images[DisplayImageIndex].SetColorTable(Color.Black, Color.White);
                }
                if (sender == RainbowToolStripMenuItem)
                {
                    Images[DisplayImageIndex].SetColorTable(Color.FromArgb(255, 128, 0, 255), Color.FromArgb(255, 255, 0, 0));
                }
                if (sender == CustomColorToolStripMenuItem)
                {
                    FrmColorSelection FCS = new FrmColorSelection(Images[DisplayImageIndex].Colortable[0], Images[DisplayImageIndex].Colortable[255]);
                    if (FCS.ShowDialog() == DialogResult.OK)
                    {
                        Images[DisplayImageIndex].SetColorTable(FCS.FromColor, FCS.ToColor);
                        FCS.Dispose();
                    }
                    else
                    {
                        FCS.Dispose();
                        return;
                    }
                }
                RedrawBitmap(null, null);
                ImageShow();
            }
        }

        //RGB灰度化
        private void RGB2GrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Img img = Images[DisplayImageIndex];
                FrmRGB2Gray FRG = new FrmRGB2Gray(img);
                if (FRG.ShowDialog(this) == DialogResult.OK)
                {
                    if (Tools.Common.RGB2GrayScale(img, FRG.RGBValues, FRG.R2GFilePathSelector.OutDataType, FRG.R2GFilePathSelector.Path))
                    {
                        CheckFile(FRG.R2GFilePathSelector.Path);
                        ManageTreeView();
                    }
                }
                FRG.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //导出当前视图
        private void ExportViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Img img = Images[DisplayImageIndex];
                FrmExport EF = new FrmExport();
                if (EF.ShowDialog(this) == DialogResult.OK)
                {
                    if (Tools.Common.ExportView(img, EF.OutDataType, EF.OutPath))
                    {
                        CheckFile(EF.OutPath);
                        ManageTreeView();
                    }
                }
                EF.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //查看影像元数据
        private void ViewMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmViewMetaData FVMD = new FrmViewMetaData(Images[DisplayImageIndex]);
                FVMD.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        #endregion

        #region 文件管理
        private void ImageListTreeView_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Copy;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))   
                e.Effect = DragDropEffects.Link;              
            else
                e.Effect = DragDropEffects.None;
        }

        //通过拖放添加文件
        private void DragDropOpenFile(object sender, DragEventArgs e)
        {
            //try
            //{
            int AddedFileCount = 0;
            int FailedFileCount = 0;
            string[] tmpFileList = e.Data.GetData(DataFormats.FileDrop) as string[];
            List<string> fileList = new List<string>();
            fileList.AddRange(tmpFileList);
            for(int i = 0;i<fileList.Count;i++)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileList[i]);
                if ((fileInfo.Attributes & System.IO.FileAttributes.Directory) != 0)
                {
                    GetAllFiles(fileList[i], ref fileList);
                    continue;
                }
                if (CheckFile(fileList[i]))//System.IO.Path.GetFullPath(FileName)
                {
                    AddedFileCount++;
                }
                else
                {
                    FailedFileCount++;
                }
            }
            AddFileResult(AddedFileCount, FailedFileCount);
            FileManagement(null, null); //需要重置按钮可用性
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }

        //搜索目录下所有文件
        private void GetAllFiles(string Dir,ref List<string> Str)
        {
            DirectoryInfo root = new DirectoryInfo(Dir);
            foreach (FileInfo f in root.GetFiles())
            {
                Str.Add(f.FullName);
            }
            foreach (DirectoryInfo f in root.GetDirectories())
            {
                Str.Add(f.FullName);
            }
        }

        //文件管理大类
        private void FileManagement(object sender, EventArgs e)
        {
            //通过对话框打开文件
            if (sender == OpenFileToolStripMenuItem || sender == OpenFileToolStripButton)
            {
                OpenFileDialog OFD = new OpenFileDialog()
                {
                    InitialDirectory = Environment.SpecialFolder.Desktop.ToString(),
                    CheckFileExists = true,
                    Filter = Tools.Common.GetSupportedFileType(),
                    Multiselect = true,
                    FilterIndex = 1,
                };
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    int AddedFileCount = 0;
                    int FailedFileCount = 0;
                    foreach (string FileName in OFD.FileNames)
                    {
                        if (CheckFile(FileName))
                        {
                            AddedFileCount++;
                        }
                        else
                            FailedFileCount++;

                    }
                    AddFileResult(AddedFileCount, FailedFileCount);
                }
            }
            //影像数量大于0时才有的操作
            if (Images.Count > 0)
            {
                //重置按钮可用性
                CloseFileToolStripMenuItem.Enabled = true;
                CloseAllFilesToolStripMenuItem.Enabled = true;

                //关闭当前影像
                if (sender == CloseFileToolStripMenuItem || sender == CloseCurrentImageToolStripMenuItem)
                {
                    int TargetIndex = Images.FindIndex(Image => Image.Path == Images[DisplayImageIndex].Path);
                    Images[TargetIndex].Dispose();
                    ImageListTreeView.Nodes["ImageRoot"].Nodes.RemoveAt(TargetIndex);
                    Images.RemoveAt(TargetIndex);
                    if (DisplayImageIndex == TargetIndex)
                    {
                        if (Images.Count < 1)
                        {
                            DisplayImageIndex = -1;
                            ImageShow();
                        }
                        else
                        {
                            DisplayImageIndex = (TargetIndex + Images.Count) % Images.Count;
                            ImageListTreeView.SelectedNode = ImageListTreeView.Nodes["ImageRoot"].Nodes[DisplayImageIndex];
                            ImageShow();
                        }
                    }
                }
                //关闭所有影像
                if (sender == CloseAllFilesToolStripMenuItem)
                {
                    DisplayImageIndex = -1;
                    Images.Clear();
                    ManageTreeView();
                    ImageShow();
                }
            }
            //重置按钮可用性
            if (Images.Count == 0)
            {
                CloseFileToolStripMenuItem.Enabled = false;
                CloseAllFilesToolStripMenuItem.Enabled = false;
            }
        }

        //检查是否与已有文件重复
        private bool CheckFile(string CheckPath)
        {
            foreach (Img Image in Images)
            {
                if (Image.Path == CheckPath)
                {
                    return false;
                }
            }
            try
            {
                Img NewImg;
                this.Cursor = Cursors.WaitCursor;
                    NewImg = new Img(CheckPath,this,this.HintLabel,this.OperationProgressBar);
                    Images.Add(NewImg);
                Tools.Common.RebuildBitmap(Images[Images.Count - 1], ImageViewPictureBox.Width, ImageViewPictureBox.Height);    //添加完文件后生成Bitmap。
                this.Cursor = Cursors.Arrow;
            }
            catch (ApplicationException err)
            {
                this.Cursor = Cursors.Arrow;
                System.Diagnostics.Trace.Write(err.ToString());
                SetHint("打开失败" + CheckPath);

                return false;
            }
            catch (Exception err)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(err.ToString());
                SetHint("打开失败" + CheckPath);

                return false;
            }
            SetHint("已添加" + CheckPath);
            return true;
        }

        //管理添加文件的结果
        private void AddFileResult(int SuccessCount, int FailedCount)
        {
            if (SuccessCount > 0)
            {
                ManageTreeView();
            }
            SetHint("添加了" + (SuccessCount + FailedCount) + "个文件。成功" + SuccessCount + "个，失败" + FailedCount + "个。");
        }
        #endregion

        //“关于”对话框
        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            FrmAboutThisApp AT = new FrmAboutThisApp();
            AT.ShowDialog();
        }
    }
}
