namespace ImgGeoReg
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddPointButton = new System.Windows.Forms.ToolStripButton();
            this.ApplyButton = new System.Windows.Forms.ToolStripButton();
            this.ResetReferenceButton = new System.Windows.Forms.ToolStripButton();
            this.ClearPointsAndResetButton = new System.Windows.Forms.ToolStripButton();
            this.SaveResultButton = new System.Windows.Forms.ToolStripButton();
            this.PointsDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FromX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.TransparencyLabel = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.ToolStripSplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.TopToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransparencyTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(244, 62);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(940, 445);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(564, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(0, 62);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(238, 597);
            this.axTOCControl1.TabIndex = 2;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(799, 529);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY,
            this.AboutButton});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 26);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 21);
            this.statusBarXY.Text = "Test 123";
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopToolStrip.AutoSize = false;
            this.TopToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPointButton,
            this.ApplyButton,
            this.ResetReferenceButton,
            this.ClearPointsAndResetButton,
            this.SaveResultButton});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.Size = new System.Drawing.Size(564, 25);
            this.TopToolStrip.TabIndex = 4;
            this.TopToolStrip.Text = "toolStrip1";
            // 
            // AddPointButton
            // 
            this.AddPointButton.CheckOnClick = true;
            this.AddPointButton.Image = ((System.Drawing.Image)(resources.GetObject("AddPointButton.Image")));
            this.AddPointButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPointButton.Name = "AddPointButton";
            this.AddPointButton.Size = new System.Drawing.Size(88, 22);
            this.AddPointButton.Text = "添加参考点";
            this.AddPointButton.CheckedChanged += new System.EventHandler(this.AddPointButton_CheckedChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Image = ((System.Drawing.Image)(resources.GetObject("ApplyButton.Image")));
            this.ApplyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(76, 22);
            this.ApplyButton.Text = "配准预览";
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ResetReferenceButton
            // 
            this.ResetReferenceButton.Image = ((System.Drawing.Image)(resources.GetObject("ResetReferenceButton.Image")));
            this.ResetReferenceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetReferenceButton.Name = "ResetReferenceButton";
            this.ResetReferenceButton.Size = new System.Drawing.Size(100, 22);
            this.ResetReferenceButton.Text = "重置配准预览";
            this.ResetReferenceButton.Click += new System.EventHandler(this.ResetReferenceButton_Click);
            // 
            // ClearPointsAndResetButton
            // 
            this.ClearPointsAndResetButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearPointsAndResetButton.Image")));
            this.ClearPointsAndResetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearPointsAndResetButton.Name = "ClearPointsAndResetButton";
            this.ClearPointsAndResetButton.Size = new System.Drawing.Size(136, 22);
            this.ClearPointsAndResetButton.Text = "删除点对并重置配准";
            this.ClearPointsAndResetButton.Click += new System.EventHandler(this.ResetWarpButton_Click);
            // 
            // SaveResultButton
            // 
            this.SaveResultButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveResultButton.Image")));
            this.SaveResultButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveResultButton.Name = "SaveResultButton";
            this.SaveResultButton.Size = new System.Drawing.Size(136, 22);
            this.SaveResultButton.Text = "保存配准结果并退出";
            this.SaveResultButton.Click += new System.EventHandler(this.SaveResultButton_Click);
            // 
            // PointsDataGridView
            // 
            this.PointsDataGridView.AllowUserToAddRows = false;
            this.PointsDataGridView.AllowUserToDeleteRows = false;
            this.PointsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PointsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PointsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteBtn,
            this.FromX,
            this.FromY,
            this.ToX,
            this.ToY});
            this.PointsDataGridView.Location = new System.Drawing.Point(244, 513);
            this.PointsDataGridView.Name = "PointsDataGridView";
            this.PointsDataGridView.RowHeadersVisible = false;
            this.PointsDataGridView.Size = new System.Drawing.Size(940, 143);
            this.PointsDataGridView.TabIndex = 1;
            this.PointsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PointsDataGridView_CellClick);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.HeaderText = "删除";
            this.DeleteBtn.MinimumWidth = 50;
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.ReadOnly = true;
            this.DeleteBtn.Text = "删除";
            this.DeleteBtn.UseColumnTextForButtonValue = true;
            this.DeleteBtn.Width = 50;
            // 
            // FromX
            // 
            this.FromX.HeaderText = "起始X";
            this.FromX.MinimumWidth = 120;
            this.FromX.Name = "FromX";
            this.FromX.ReadOnly = true;
            this.FromX.Width = 120;
            // 
            // FromY
            // 
            this.FromY.HeaderText = "起始Y";
            this.FromY.MinimumWidth = 120;
            this.FromY.Name = "FromY";
            this.FromY.ReadOnly = true;
            this.FromY.Width = 120;
            // 
            // ToX
            // 
            this.ToX.HeaderText = "配准X";
            this.ToX.MinimumWidth = 120;
            this.ToX.Name = "ToX";
            this.ToX.ReadOnly = true;
            this.ToX.Width = 120;
            // 
            // ToY
            // 
            this.ToY.HeaderText = "配准Y";
            this.ToY.MinimumWidth = 120;
            this.ToY.Name = "ToY";
            this.ToY.ReadOnly = true;
            this.ToY.Width = 120;
            // 
            // TransparencyTrackBar
            // 
            this.TransparencyTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransparencyTrackBar.Location = new System.Drawing.Point(699, 11);
            this.TransparencyTrackBar.Maximum = 100;
            this.TransparencyTrackBar.Name = "TransparencyTrackBar";
            this.TransparencyTrackBar.Size = new System.Drawing.Size(473, 45);
            this.TransparencyTrackBar.TabIndex = 5;
            this.TransparencyTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TransparencyTrackBar.Scroll += new System.EventHandler(this.TransparencyTrackBar_Scroll);
            // 
            // TransparencyLabel
            // 
            this.TransparencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransparencyLabel.AutoSize = true;
            this.TransparencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransparencyLabel.Location = new System.Drawing.Point(570, 23);
            this.TransparencyLabel.Name = "TransparencyLabel";
            this.TransparencyLabel.Size = new System.Drawing.Size(98, 18);
            this.TransparencyLabel.TabIndex = 12;
            this.TransparencyLabel.Text = "顶层透明度：";
            // 
            // AboutButton
            // 
            this.AboutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(36, 24);
            this.AboutButton.Text = "你说啥？";
            this.AboutButton.ButtonClick += new System.EventHandler(this.AboutButton_ButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.TransparencyLabel);
            this.Controls.Add(this.TransparencyTrackBar);
            this.Controls.Add(this.PointsDataGridView);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.TopToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "MainForm";
            this.Text = "栅格配准";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransparencyTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStrip TopToolStrip;
        private System.Windows.Forms.ToolStripButton AddPointButton;
        private System.Windows.Forms.ToolStripButton ApplyButton;
        private System.Windows.Forms.ToolStripButton SaveResultButton;
        private System.Windows.Forms.DataGridView PointsDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromX;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToY;
        private System.Windows.Forms.TrackBar TransparencyTrackBar;
        private System.Windows.Forms.Label TransparencyLabel;
        private System.Windows.Forms.ToolStripButton ClearPointsAndResetButton;
        private System.Windows.Forms.ToolStripButton ResetReferenceButton;
        private System.Windows.Forms.ToolStripSplitButton AboutButton;
    }
}

