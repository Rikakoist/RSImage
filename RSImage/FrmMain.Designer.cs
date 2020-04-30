namespace RSImage
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Images");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ImageViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ImageListTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ViewHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeBandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Gray2RGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RainbowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RGB2GrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMetadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseCurrentImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.ImageViewPictureBox = new System.Windows.Forms.PictureBox();
            this.ImageViewStatusStrip = new System.Windows.Forms.StatusStrip();
            this.HintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.OperationProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ImageViewMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistogramMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReclassifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToAAIGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadiationCorrectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplyGainAndOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeometricProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeoreferncingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadiationEnhancementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmoothSharpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FFTFiltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageFusionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BroveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IHSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageClassificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnsupervisedClassificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KMeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsoDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SupervisedClassificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.OpenFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StretchModeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.AboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FloodingProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewSplitContainer)).BeginInit();
            this.ImageViewSplitContainer.Panel1.SuspendLayout();
            this.ImageViewSplitContainer.Panel2.SuspendLayout();
            this.ImageViewSplitContainer.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewPictureBox)).BeginInit();
            this.ImageViewStatusStrip.SuspendLayout();
            this.ImageViewMenuStrip.SuspendLayout();
            this.TopToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageViewSplitContainer
            // 
            this.ImageViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageViewSplitContainer.Location = new System.Drawing.Point(0, 55);
            this.ImageViewSplitContainer.Name = "ImageViewSplitContainer";
            // 
            // ImageViewSplitContainer.Panel1
            // 
            this.ImageViewSplitContainer.Panel1.Controls.Add(this.ImageListTreeView);
            this.ImageViewSplitContainer.Panel1MinSize = 150;
            // 
            // ImageViewSplitContainer.Panel2
            // 
            this.ImageViewSplitContainer.Panel2.Controls.Add(this.ImageViewPictureBox);
            this.ImageViewSplitContainer.Panel2MinSize = 100;
            this.ImageViewSplitContainer.Size = new System.Drawing.Size(1264, 601);
            this.ImageViewSplitContainer.SplitterDistance = 235;
            this.ImageViewSplitContainer.SplitterWidth = 5;
            this.ImageViewSplitContainer.TabIndex = 0;
            // 
            // ImageListTreeView
            // 
            this.ImageListTreeView.AllowDrop = true;
            this.ImageListTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.ImageListTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageListTreeView.ImageIndex = 0;
            this.ImageListTreeView.ImageList = this.TreeViewImageList;
            this.ImageListTreeView.Location = new System.Drawing.Point(0, 0);
            this.ImageListTreeView.Name = "ImageListTreeView";
            treeNode1.Name = "ImageList";
            treeNode1.Text = "Images";
            this.ImageListTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.ImageListTreeView.SelectedImageIndex = 0;
            this.ImageListTreeView.Size = new System.Drawing.Size(235, 601);
            this.ImageListTreeView.TabIndex = 0;
            this.ImageListTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ChangeSelectedFile);
            this.ImageListTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropOpenFile);
            this.ImageListTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageListTreeView_DragEnter);
            // 
            // TreeViewContextMenuStrip
            // 
            this.TreeViewContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewHistogramToolStripMenuItem,
            this.ChangeBandToolStripMenuItem,
            this.Gray2RGBToolStripMenuItem,
            this.RGB2GrayToolStripMenuItem,
            this.ExportViewToolStripMenuItem,
            this.ViewMetadataToolStripMenuItem,
            this.CloseCurrentImageToolStripMenuItem});
            this.TreeViewContextMenuStrip.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip.Size = new System.Drawing.Size(170, 186);
            this.TreeViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TreeViewContextMenuStrip_Opening);
            // 
            // ViewHistogramToolStripMenuItem
            // 
            this.ViewHistogramToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ViewHistogramToolStripMenuItem.Image")));
            this.ViewHistogramToolStripMenuItem.Name = "ViewHistogramToolStripMenuItem";
            this.ViewHistogramToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.ViewHistogramToolStripMenuItem.Text = "查看直方图";
            this.ViewHistogramToolStripMenuItem.Click += new System.EventHandler(this.ViewHistogramToolStripMenuItem_Click);
            // 
            // ChangeBandToolStripMenuItem
            // 
            this.ChangeBandToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ChangeBandToolStripMenuItem.Image")));
            this.ChangeBandToolStripMenuItem.Name = "ChangeBandToolStripMenuItem";
            this.ChangeBandToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.ChangeBandToolStripMenuItem.Text = "更改波段组合";
            this.ChangeBandToolStripMenuItem.Click += new System.EventHandler(this.ChangeBandToolStripMenuItem_Click);
            // 
            // Gray2RGBToolStripMenuItem
            // 
            this.Gray2RGBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrayscaleToolStripMenuItem,
            this.RainbowToolStripMenuItem,
            this.CustomColorToolStripMenuItem});
            this.Gray2RGBToolStripMenuItem.Name = "Gray2RGBToolStripMenuItem";
            this.Gray2RGBToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.Gray2RGBToolStripMenuItem.Text = "伪彩色增强";
            // 
            // GrayscaleToolStripMenuItem
            // 
            this.GrayscaleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GrayscaleToolStripMenuItem.Image")));
            this.GrayscaleToolStripMenuItem.Name = "GrayscaleToolStripMenuItem";
            this.GrayscaleToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.GrayscaleToolStripMenuItem.Text = "灰度";
            this.GrayscaleToolStripMenuItem.Click += new System.EventHandler(this.ChangeColorTable);
            // 
            // RainbowToolStripMenuItem
            // 
            this.RainbowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RainbowToolStripMenuItem.Image")));
            this.RainbowToolStripMenuItem.Name = "RainbowToolStripMenuItem";
            this.RainbowToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.RainbowToolStripMenuItem.Text = "彩虹";
            this.RainbowToolStripMenuItem.Click += new System.EventHandler(this.ChangeColorTable);
            // 
            // CustomColorToolStripMenuItem
            // 
            this.CustomColorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CustomColorToolStripMenuItem.Image")));
            this.CustomColorToolStripMenuItem.Name = "CustomColorToolStripMenuItem";
            this.CustomColorToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.CustomColorToolStripMenuItem.Text = "自定义";
            this.CustomColorToolStripMenuItem.Click += new System.EventHandler(this.ChangeColorTable);
            // 
            // RGB2GrayToolStripMenuItem
            // 
            this.RGB2GrayToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RGB2GrayToolStripMenuItem.Image")));
            this.RGB2GrayToolStripMenuItem.Name = "RGB2GrayToolStripMenuItem";
            this.RGB2GrayToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.RGB2GrayToolStripMenuItem.Text = "彩色影像灰度化";
            this.RGB2GrayToolStripMenuItem.Click += new System.EventHandler(this.RGB2GrayToolStripMenuItem_Click);
            // 
            // ExportViewToolStripMenuItem
            // 
            this.ExportViewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExportViewToolStripMenuItem.Image")));
            this.ExportViewToolStripMenuItem.Name = "ExportViewToolStripMenuItem";
            this.ExportViewToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.ExportViewToolStripMenuItem.Text = "导出到TIFF";
            this.ExportViewToolStripMenuItem.Click += new System.EventHandler(this.ExportViewToolStripMenuItem_Click);
            // 
            // ViewMetadataToolStripMenuItem
            // 
            this.ViewMetadataToolStripMenuItem.Name = "ViewMetadataToolStripMenuItem";
            this.ViewMetadataToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.ViewMetadataToolStripMenuItem.Text = "查看影像元数据";
            this.ViewMetadataToolStripMenuItem.Click += new System.EventHandler(this.ViewMetadataToolStripMenuItem_Click);
            // 
            // CloseCurrentImageToolStripMenuItem
            // 
            this.CloseCurrentImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CloseCurrentImageToolStripMenuItem.Image")));
            this.CloseCurrentImageToolStripMenuItem.Name = "CloseCurrentImageToolStripMenuItem";
            this.CloseCurrentImageToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.CloseCurrentImageToolStripMenuItem.Text = "关闭当前影像";
            this.CloseCurrentImageToolStripMenuItem.Click += new System.EventHandler(this.FileManagement);
            // 
            // TreeViewImageList
            // 
            this.TreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewImageList.ImageStream")));
            this.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewImageList.Images.SetKeyName(0, "view.png");
            this.TreeViewImageList.Images.SetKeyName(1, "layergrayscale.png");
            this.TreeViewImageList.Images.SetKeyName(2, "layerrgb.png");
            this.TreeViewImageList.Images.SetKeyName(3, "red.png");
            this.TreeViewImageList.Images.SetKeyName(4, "green.png");
            this.TreeViewImageList.Images.SetKeyName(5, "blue.png");
            // 
            // ImageViewPictureBox
            // 
            this.ImageViewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageViewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.ImageViewPictureBox.Name = "ImageViewPictureBox";
            this.ImageViewPictureBox.Size = new System.Drawing.Size(1024, 601);
            this.ImageViewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageViewPictureBox.TabIndex = 0;
            this.ImageViewPictureBox.TabStop = false;
            this.ImageViewPictureBox.SizeChanged += new System.EventHandler(this.RedrawBitmap);
            // 
            // ImageViewStatusStrip
            // 
            this.ImageViewStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ImageViewStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HintLabel,
            this.OperationProgressBar});
            this.ImageViewStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ImageViewStatusStrip.Location = new System.Drawing.Point(0, 656);
            this.ImageViewStatusStrip.Name = "ImageViewStatusStrip";
            this.ImageViewStatusStrip.Size = new System.Drawing.Size(1264, 25);
            this.ImageViewStatusStrip.TabIndex = 1;
            // 
            // HintLabel
            // 
            this.HintLabel.Image = ((System.Drawing.Image)(resources.GetObject("HintLabel.Image")));
            this.HintLabel.Name = "HintLabel";
            this.HintLabel.Size = new System.Drawing.Size(50, 20);
            this.HintLabel.Text = "Hint";
            // 
            // OperationProgressBar
            // 
            this.OperationProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OperationProgressBar.Name = "OperationProgressBar";
            this.OperationProgressBar.Size = new System.Drawing.Size(100, 19);
            this.OperationProgressBar.Step = 1;
            this.OperationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // ImageViewMenuStrip
            // 
            this.ImageViewMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ImageViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOperationToolStripMenuItem,
            this.BaseToolStripMenuItem,
            this.RadiationCorrectionToolStripMenuItem,
            this.GeometricProcessingToolStripMenuItem,
            this.RadiationEnhancementToolStripMenuItem,
            this.ImageFusionToolStripMenuItem,
            this.ChangeDetectionToolStripMenuItem,
            this.ImageClassificationToolStripMenuItem});
            this.ImageViewMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ImageViewMenuStrip.Name = "ImageViewMenuStrip";
            this.ImageViewMenuStrip.Size = new System.Drawing.Size(1264, 28);
            this.ImageViewMenuStrip.TabIndex = 2;
            this.ImageViewMenuStrip.Text = "menuStrip1";
            // 
            // FileOperationToolStripMenuItem
            // 
            this.FileOperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem,
            this.CloseFileToolStripMenuItem,
            this.CloseAllFilesToolStripMenuItem});
            this.FileOperationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FileOperationToolStripMenuItem.Image")));
            this.FileOperationToolStripMenuItem.Name = "FileOperationToolStripMenuItem";
            this.FileOperationToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.FileOperationToolStripMenuItem.Text = "文件";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileToolStripMenuItem.Image")));
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.OpenFileToolStripMenuItem.Text = "打开";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.FileManagement);
            // 
            // CloseFileToolStripMenuItem
            // 
            this.CloseFileToolStripMenuItem.Enabled = false;
            this.CloseFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CloseFileToolStripMenuItem.Image")));
            this.CloseFileToolStripMenuItem.Name = "CloseFileToolStripMenuItem";
            this.CloseFileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.CloseFileToolStripMenuItem.Text = "关闭";
            this.CloseFileToolStripMenuItem.Click += new System.EventHandler(this.FileManagement);
            // 
            // CloseAllFilesToolStripMenuItem
            // 
            this.CloseAllFilesToolStripMenuItem.Enabled = false;
            this.CloseAllFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CloseAllFilesToolStripMenuItem.Image")));
            this.CloseAllFilesToolStripMenuItem.Name = "CloseAllFilesToolStripMenuItem";
            this.CloseAllFilesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.CloseAllFilesToolStripMenuItem.Text = "关闭所有";
            this.CloseAllFilesToolStripMenuItem.Click += new System.EventHandler(this.FileManagement);
            // 
            // BaseToolStripMenuItem
            // 
            this.BaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HistogramMatchingToolStripMenuItem,
            this.ThresholdToolStripMenuItem,
            this.ReclassifyToolStripMenuItem,
            this.ConvertToAAIGridToolStripMenuItem,
            this.ImageCutToolStripMenuItem,
            this.FloodingProcessingToolStripMenuItem});
            this.BaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BaseToolStripMenuItem.Image")));
            this.BaseToolStripMenuItem.Name = "BaseToolStripMenuItem";
            this.BaseToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.BaseToolStripMenuItem.Text = "基础处理";
            // 
            // HistogramMatchingToolStripMenuItem
            // 
            this.HistogramMatchingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("HistogramMatchingToolStripMenuItem.Image")));
            this.HistogramMatchingToolStripMenuItem.Name = "HistogramMatchingToolStripMenuItem";
            this.HistogramMatchingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.HistogramMatchingToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.HistogramMatchingToolStripMenuItem.Text = "直方图匹配";
            this.HistogramMatchingToolStripMenuItem.Click += new System.EventHandler(this.HistogramMatchingToolStripMenuItem_Click);
            // 
            // ThresholdToolStripMenuItem
            // 
            this.ThresholdToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ThresholdToolStripMenuItem.Image")));
            this.ThresholdToolStripMenuItem.Name = "ThresholdToolStripMenuItem";
            this.ThresholdToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.ThresholdToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.ThresholdToolStripMenuItem.Text = "阈值分割";
            this.ThresholdToolStripMenuItem.Click += new System.EventHandler(this.ThresholdToolStripMenuItem_Click);
            // 
            // ReclassifyToolStripMenuItem
            // 
            this.ReclassifyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ReclassifyToolStripMenuItem.Image")));
            this.ReclassifyToolStripMenuItem.Name = "ReclassifyToolStripMenuItem";
            this.ReclassifyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ReclassifyToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.ReclassifyToolStripMenuItem.Text = "重分类";
            this.ReclassifyToolStripMenuItem.Click += new System.EventHandler(this.ReclassifyToolStripMenuItem_Click);
            // 
            // ConvertToAAIGridToolStripMenuItem
            // 
            this.ConvertToAAIGridToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ConvertToAAIGridToolStripMenuItem.Image")));
            this.ConvertToAAIGridToolStripMenuItem.Name = "ConvertToAAIGridToolStripMenuItem";
            this.ConvertToAAIGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ConvertToAAIGridToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.ConvertToAAIGridToolStripMenuItem.Text = "灰度影像转换到栅格";
            this.ConvertToAAIGridToolStripMenuItem.Click += new System.EventHandler(this.ConvertToAAIGridToolStripMenuItem_Click);
            // 
            // ImageCutToolStripMenuItem
            // 
            this.ImageCutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImageCutToolStripMenuItem.Image")));
            this.ImageCutToolStripMenuItem.Name = "ImageCutToolStripMenuItem";
            this.ImageCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.ImageCutToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.ImageCutToolStripMenuItem.Text = "影像裁剪";
            this.ImageCutToolStripMenuItem.Click += new System.EventHandler(this.ImageCutToolStripMenuItem_Click);
            // 
            // RadiationCorrectionToolStripMenuItem
            // 
            this.RadiationCorrectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplyGainAndOffsetToolStripMenuItem});
            this.RadiationCorrectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RadiationCorrectionToolStripMenuItem.Image")));
            this.RadiationCorrectionToolStripMenuItem.Name = "RadiationCorrectionToolStripMenuItem";
            this.RadiationCorrectionToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.RadiationCorrectionToolStripMenuItem.Text = "辐射校正";
            // 
            // ApplyGainAndOffsetToolStripMenuItem
            // 
            this.ApplyGainAndOffsetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ApplyGainAndOffsetToolStripMenuItem.Image")));
            this.ApplyGainAndOffsetToolStripMenuItem.Name = "ApplyGainAndOffsetToolStripMenuItem";
            this.ApplyGainAndOffsetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.ApplyGainAndOffsetToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ApplyGainAndOffsetToolStripMenuItem.Text = "辐射定标";
            this.ApplyGainAndOffsetToolStripMenuItem.Click += new System.EventHandler(this.ApplyGainAndOffsetToolStripMenuItem_Click);
            // 
            // GeometricProcessingToolStripMenuItem
            // 
            this.GeometricProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GeoreferncingToolStripMenuItem});
            this.GeometricProcessingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GeometricProcessingToolStripMenuItem.Image")));
            this.GeometricProcessingToolStripMenuItem.Name = "GeometricProcessingToolStripMenuItem";
            this.GeometricProcessingToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.GeometricProcessingToolStripMenuItem.Text = "几何处理";
            // 
            // GeoreferncingToolStripMenuItem
            // 
            this.GeoreferncingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("GeoreferncingToolStripMenuItem.Image")));
            this.GeoreferncingToolStripMenuItem.Name = "GeoreferncingToolStripMenuItem";
            this.GeoreferncingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.GeoreferncingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.GeoreferncingToolStripMenuItem.Text = "地理配准";
            this.GeoreferncingToolStripMenuItem.Click += new System.EventHandler(this.GeoreferncingToolStripMenuItem_Click);
            // 
            // RadiationEnhancementToolStripMenuItem
            // 
            this.RadiationEnhancementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SmoothSharpToolStripMenuItem,
            this.FFTFiltToolStripMenuItem});
            this.RadiationEnhancementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RadiationEnhancementToolStripMenuItem.Image")));
            this.RadiationEnhancementToolStripMenuItem.Name = "RadiationEnhancementToolStripMenuItem";
            this.RadiationEnhancementToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.RadiationEnhancementToolStripMenuItem.Text = "辐射增强";
            // 
            // SmoothSharpToolStripMenuItem
            // 
            this.SmoothSharpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SmoothSharpToolStripMenuItem.Image")));
            this.SmoothSharpToolStripMenuItem.Name = "SmoothSharpToolStripMenuItem";
            this.SmoothSharpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.SmoothSharpToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.SmoothSharpToolStripMenuItem.Text = "平滑锐化";
            this.SmoothSharpToolStripMenuItem.Click += new System.EventHandler(this.SmoothSharpToolStripMenuItem_Click);
            // 
            // FFTFiltToolStripMenuItem
            // 
            this.FFTFiltToolStripMenuItem.Enabled = false;
            this.FFTFiltToolStripMenuItem.Name = "FFTFiltToolStripMenuItem";
            this.FFTFiltToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.FFTFiltToolStripMenuItem.Text = "滤波（开发中）";
            this.FFTFiltToolStripMenuItem.Click += new System.EventHandler(this.FFTFiltToolStripMenuItem_Click);
            // 
            // ImageFusionToolStripMenuItem
            // 
            this.ImageFusionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BroveyToolStripMenuItem,
            this.IHSToolStripMenuItem});
            this.ImageFusionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImageFusionToolStripMenuItem.Image")));
            this.ImageFusionToolStripMenuItem.Name = "ImageFusionToolStripMenuItem";
            this.ImageFusionToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.ImageFusionToolStripMenuItem.Text = "影像融合";
            // 
            // BroveyToolStripMenuItem
            // 
            this.BroveyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("BroveyToolStripMenuItem.Image")));
            this.BroveyToolStripMenuItem.Name = "BroveyToolStripMenuItem";
            this.BroveyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.BroveyToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.BroveyToolStripMenuItem.Text = "Brovey";
            this.BroveyToolStripMenuItem.Click += new System.EventHandler(this.BroveyToolStripMenuItem_Click);
            // 
            // IHSToolStripMenuItem
            // 
            this.IHSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IHSToolStripMenuItem.Image")));
            this.IHSToolStripMenuItem.Name = "IHSToolStripMenuItem";
            this.IHSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.IHSToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.IHSToolStripMenuItem.Text = "IHS";
            this.IHSToolStripMenuItem.Click += new System.EventHandler(this.IHSToolStripMenuItem_Click);
            // 
            // ChangeDetectionToolStripMenuItem
            // 
            this.ChangeDetectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ChangeDetectionToolStripMenuItem.Image")));
            this.ChangeDetectionToolStripMenuItem.Name = "ChangeDetectionToolStripMenuItem";
            this.ChangeDetectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.ChangeDetectionToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.ChangeDetectionToolStripMenuItem.Text = "变化检测";
            this.ChangeDetectionToolStripMenuItem.Click += new System.EventHandler(this.ChangeDetectionToolStripMenuItem_Click);
            // 
            // ImageClassificationToolStripMenuItem
            // 
            this.ImageClassificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UnsupervisedClassificationToolStripMenuItem,
            this.SupervisedClassificationToolStripMenuItem});
            this.ImageClassificationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImageClassificationToolStripMenuItem.Image")));
            this.ImageClassificationToolStripMenuItem.Name = "ImageClassificationToolStripMenuItem";
            this.ImageClassificationToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.ImageClassificationToolStripMenuItem.Text = "影像分类";
            // 
            // UnsupervisedClassificationToolStripMenuItem
            // 
            this.UnsupervisedClassificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KMeansToolStripMenuItem,
            this.IsoDataToolStripMenuItem});
            this.UnsupervisedClassificationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UnsupervisedClassificationToolStripMenuItem.Image")));
            this.UnsupervisedClassificationToolStripMenuItem.Name = "UnsupervisedClassificationToolStripMenuItem";
            this.UnsupervisedClassificationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.UnsupervisedClassificationToolStripMenuItem.Text = "非监督分类";
            // 
            // KMeansToolStripMenuItem
            // 
            this.KMeansToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("KMeansToolStripMenuItem.Image")));
            this.KMeansToolStripMenuItem.Name = "KMeansToolStripMenuItem";
            this.KMeansToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.K)));
            this.KMeansToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.KMeansToolStripMenuItem.Text = "K-Means";
            this.KMeansToolStripMenuItem.Click += new System.EventHandler(this.KMeansToolStripMenuItem_Click);
            // 
            // IsoDataToolStripMenuItem
            // 
            this.IsoDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("IsoDataToolStripMenuItem.Image")));
            this.IsoDataToolStripMenuItem.Name = "IsoDataToolStripMenuItem";
            this.IsoDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.I)));
            this.IsoDataToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.IsoDataToolStripMenuItem.Text = "Iso Data";
            this.IsoDataToolStripMenuItem.Click += new System.EventHandler(this.IsoDataToolStripMenuItem_Click);
            // 
            // SupervisedClassificationToolStripMenuItem
            // 
            this.SupervisedClassificationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SupervisedClassificationToolStripMenuItem.Image")));
            this.SupervisedClassificationToolStripMenuItem.Name = "SupervisedClassificationToolStripMenuItem";
            this.SupervisedClassificationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.SupervisedClassificationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.SupervisedClassificationToolStripMenuItem.Text = "监督分类";
            this.SupervisedClassificationToolStripMenuItem.Click += new System.EventHandler(this.SupervisedClassificationToolStripMenuItem_Click);
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripButton,
            this.toolStripSeparator1,
            this.StretchModeToolStripComboBox,
            this.AboutToolStripButton});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 28);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Size = new System.Drawing.Size(1264, 27);
            this.TopToolStrip.TabIndex = 3;
            // 
            // OpenFileToolStripButton
            // 
            this.OpenFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenFileToolStripButton.Image")));
            this.OpenFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileToolStripButton.Name = "OpenFileToolStripButton";
            this.OpenFileToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.OpenFileToolStripButton.Click += new System.EventHandler(this.FileManagement);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // StretchModeToolStripComboBox
            // 
            this.StretchModeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StretchModeToolStripComboBox.Enabled = false;
            this.StretchModeToolStripComboBox.MaxDropDownItems = 11;
            this.StretchModeToolStripComboBox.Name = "StretchModeToolStripComboBox";
            this.StretchModeToolStripComboBox.Size = new System.Drawing.Size(121, 27);
            this.StretchModeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeStretchMode);
            // 
            // AboutToolStripButton
            // 
            this.AboutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutToolStripButton.Image")));
            this.AboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutToolStripButton.Name = "AboutToolStripButton";
            this.AboutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.AboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
            // 
            // FloodingProcessingToolStripMenuItem
            // 
            this.FloodingProcessingToolStripMenuItem.Name = "FloodingProcessingToolStripMenuItem";
            this.FloodingProcessingToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.FloodingProcessingToolStripMenuItem.Text = "洪水处理";
            this.FloodingProcessingToolStripMenuItem.Click += new System.EventHandler(this.FloodingProcessingToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.ImageViewSplitContainer);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.ImageViewStatusStrip);
            this.Controls.Add(this.ImageViewMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 597);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageView233";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExitApp);
            this.Load += new System.EventHandler(this.FormLoading);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmImageView_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmImageView_MouseUp);
            this.ImageViewSplitContainer.Panel1.ResumeLayout(false);
            this.ImageViewSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewSplitContainer)).EndInit();
            this.ImageViewSplitContainer.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewPictureBox)).EndInit();
            this.ImageViewStatusStrip.ResumeLayout(false);
            this.ImageViewStatusStrip.PerformLayout();
            this.ImageViewMenuStrip.ResumeLayout(false);
            this.ImageViewMenuStrip.PerformLayout();
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer ImageViewSplitContainer;
        private System.Windows.Forms.PictureBox ImageViewPictureBox;
        private System.Windows.Forms.TreeView ImageListTreeView;
        private System.Windows.Forms.StatusStrip ImageViewStatusStrip;
        private System.Windows.Forms.MenuStrip ImageViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel HintLabel;
        private System.Windows.Forms.ToolStripMenuItem CloseFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseAllFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageFusionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ViewHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeBandToolStripMenuItem;
        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripButton OpenFileToolStripButton;
        private System.Windows.Forms.ImageList TreeViewImageList;
        private System.Windows.Forms.ToolStripMenuItem CloseCurrentImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox StretchModeToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem Gray2RGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GrayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RainbowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton AboutToolStripButton;
        public System.Windows.Forms.ToolStripProgressBar OperationProgressBar;
        private System.Windows.Forms.ToolStripMenuItem BroveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewMetadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RGB2GrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HistogramMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReclassifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RadiationCorrectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ApplyGainAndOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RadiationEnhancementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmoothSharpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FFTFiltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IHSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GeometricProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GeoreferncingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageClassificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SupervisedClassificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnsupervisedClassificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KMeansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsoDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConvertToAAIGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FloodingProcessingToolStripMenuItem;
    }
}

