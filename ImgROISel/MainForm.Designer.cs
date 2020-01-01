namespace ImgROISel
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriggerEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.ROIDataGridView = new System.Windows.Forms.DataGridView();
            this.DeleteBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ROIName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ROIDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddROIToolStripMenuItem,
            this.TriggerEditToolStripMenuItem,
            this.SubmitROIToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddROIToolStripMenuItem
            // 
            this.AddROIToolStripMenuItem.Name = "AddROIToolStripMenuItem";
            this.AddROIToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.AddROIToolStripMenuItem.Text = "添加ROI";
            this.AddROIToolStripMenuItem.Click += new System.EventHandler(this.AddROIToolStripMenuItem_Click);
            // 
            // TriggerEditToolStripMenuItem
            // 
            this.TriggerEditToolStripMenuItem.CheckOnClick = true;
            this.TriggerEditToolStripMenuItem.Name = "TriggerEditToolStripMenuItem";
            this.TriggerEditToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.TriggerEditToolStripMenuItem.Text = "编辑";
            this.TriggerEditToolStripMenuItem.CheckedChanged += new System.EventHandler(this.TriggerEditToolStripMenuItem_CheckedChanged);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMapControl1.Location = new System.Drawing.Point(227, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(739, 511);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(966, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(3, 52);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(218, 355);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(922, 529);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 533);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(963, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // ROIDataGridView
            // 
            this.ROIDataGridView.AllowUserToAddRows = false;
            this.ROIDataGridView.AllowUserToDeleteRows = false;
            this.ROIDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ROIDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ROIDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteBtn,
            this.ROIName,
            this.SampleCount});
            this.ROIDataGridView.Location = new System.Drawing.Point(3, 413);
            this.ROIDataGridView.Name = "ROIDataGridView";
            this.ROIDataGridView.RowHeadersVisible = false;
            this.ROIDataGridView.Size = new System.Drawing.Size(218, 148);
            this.ROIDataGridView.TabIndex = 8;
            this.ROIDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ROIDataGridView_CellClick);
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
            // ROIName
            // 
            this.ROIName.HeaderText = "名称";
            this.ROIName.MinimumWidth = 80;
            this.ROIName.Name = "ROIName";
            this.ROIName.ReadOnly = true;
            this.ROIName.Width = 80;
            // 
            // SampleCount
            // 
            this.SampleCount.HeaderText = "样本个数";
            this.SampleCount.MinimumWidth = 80;
            this.SampleCount.Name = "SampleCount";
            this.SampleCount.ReadOnly = true;
            this.SampleCount.Width = 80;
            // 
            // SubmitROIToolStripMenuItem
            // 
            this.SubmitROIToolStripMenuItem.Name = "SubmitROIToolStripMenuItem";
            this.SubmitROIToolStripMenuItem.Size = new System.Drawing.Size(102, 21);
            this.SubmitROIToolStripMenuItem.Text = "提交ROI并退出";
            this.SubmitROIToolStripMenuItem.Click += new System.EventHandler(this.SubmitROIToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 586);
            this.Controls.Add(this.ROIDataGridView);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "区域选择";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ROIDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.DataGridView ROIDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROIName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleCount;
        private System.Windows.Forms.ToolStripMenuItem AddROIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TriggerEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubmitROIToolStripMenuItem;
    }
}

