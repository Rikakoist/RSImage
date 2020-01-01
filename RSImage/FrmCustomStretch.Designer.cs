namespace RSImage
{
    partial class FrmCustomStretch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomStretch));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BandSelectComboBox = new System.Windows.Forms.ComboBox();
            this.BandLabel = new System.Windows.Forms.Label();
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.PixelCountLabel = new System.Windows.Forms.Label();
            this.StddevLabel = new System.Windows.Forms.Label();
            this.MeanLabel = new System.Windows.Forms.Label();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.BandSelectToolStrip = new System.Windows.Forms.ToolStrip();
            this.GrayButton = new System.Windows.Forms.ToolStripButton();
            this.OverviewButton = new System.Windows.Forms.ToolStripButton();
            this.BlueButton = new System.Windows.Forms.ToolStripButton();
            this.GreenButton = new System.Windows.Forms.ToolStripButton();
            this.RedButton = new System.Windows.Forms.ToolStripButton();
            this.BandHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InfoGroupBox.SuspendLayout();
            this.BandSelectToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BandHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // BandSelectComboBox
            // 
            this.BandSelectComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BandSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BandSelectComboBox.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BandSelectComboBox.FormattingEnabled = true;
            this.BandSelectComboBox.Location = new System.Drawing.Point(320, 12);
            this.BandSelectComboBox.Name = "BandSelectComboBox";
            this.BandSelectComboBox.Size = new System.Drawing.Size(115, 24);
            this.BandSelectComboBox.TabIndex = 0;
            this.BandSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeBand);
            // 
            // BandLabel
            // 
            this.BandLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BandLabel.AutoSize = true;
            this.BandLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BandLabel.Location = new System.Drawing.Point(235, 13);
            this.BandLabel.Name = "BandLabel";
            this.BandLabel.Size = new System.Drawing.Size(79, 20);
            this.BandLabel.TabIndex = 2;
            this.BandLabel.Text = "选择波段：";
            this.BandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.Controls.Add(this.PixelCountLabel);
            this.InfoGroupBox.Controls.Add(this.StddevLabel);
            this.InfoGroupBox.Controls.Add(this.MeanLabel);
            this.InfoGroupBox.Controls.Add(this.MaxLabel);
            this.InfoGroupBox.Controls.Add(this.MinLabel);
            this.InfoGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoGroupBox.Location = new System.Drawing.Point(0, 311);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Size = new System.Drawing.Size(565, 100);
            this.InfoGroupBox.TabIndex = 3;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "波段信息";
            // 
            // PixelCountLabel
            // 
            this.PixelCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PixelCountLabel.AutoSize = true;
            this.PixelCountLabel.Location = new System.Drawing.Point(155, 75);
            this.PixelCountLabel.Name = "PixelCountLabel";
            this.PixelCountLabel.Size = new System.Drawing.Size(43, 13);
            this.PixelCountLabel.TabIndex = 0;
            this.PixelCountLabel.Text = "像素：";
            // 
            // StddevLabel
            // 
            this.StddevLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StddevLabel.AutoSize = true;
            this.StddevLabel.Location = new System.Drawing.Point(305, 50);
            this.StddevLabel.Name = "StddevLabel";
            this.StddevLabel.Size = new System.Drawing.Size(55, 13);
            this.StddevLabel.TabIndex = 0;
            this.StddevLabel.Text = "标准差：";
            // 
            // MeanLabel
            // 
            this.MeanLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MeanLabel.AutoSize = true;
            this.MeanLabel.Location = new System.Drawing.Point(155, 50);
            this.MeanLabel.Name = "MeanLabel";
            this.MeanLabel.Size = new System.Drawing.Size(55, 13);
            this.MeanLabel.TabIndex = 0;
            this.MeanLabel.Text = "平均值：";
            // 
            // MaxLabel
            // 
            this.MaxLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(305, 25);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(55, 13);
            this.MaxLabel.TabIndex = 0;
            this.MaxLabel.Text = "最大值：";
            // 
            // MinLabel
            // 
            this.MinLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(155, 25);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(55, 13);
            this.MinLabel.TabIndex = 0;
            this.MinLabel.Text = "最小值：";
            // 
            // BandSelectToolStrip
            // 
            this.BandSelectToolStrip.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BandSelectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.BandSelectToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BandSelectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrayButton,
            this.OverviewButton,
            this.BlueButton,
            this.GreenButton,
            this.RedButton});
            this.BandSelectToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.BandSelectToolStrip.Location = new System.Drawing.Point(524, 119);
            this.BandSelectToolStrip.Name = "BandSelectToolStrip";
            this.BandSelectToolStrip.Size = new System.Drawing.Size(32, 136);
            this.BandSelectToolStrip.TabIndex = 5;
            this.BandSelectToolStrip.Text = "toolStrip1";
            // 
            // GrayButton
            // 
            this.GrayButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.GrayButton.Checked = true;
            this.GrayButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GrayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GrayButton.Image = ((System.Drawing.Image)(resources.GetObject("GrayButton.Image")));
            this.GrayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GrayButton.Name = "GrayButton";
            this.GrayButton.Size = new System.Drawing.Size(30, 20);
            // 
            // OverviewButton
            // 
            this.OverviewButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OverviewButton.Checked = true;
            this.OverviewButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OverviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OverviewButton.Image = ((System.Drawing.Image)(resources.GetObject("OverviewButton.Image")));
            this.OverviewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OverviewButton.Name = "OverviewButton";
            this.OverviewButton.Size = new System.Drawing.Size(30, 20);
            this.OverviewButton.Click += new System.EventHandler(this.ChangeShowBand);
            // 
            // BlueButton
            // 
            this.BlueButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BlueButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BlueButton.Image = ((System.Drawing.Image)(resources.GetObject("BlueButton.Image")));
            this.BlueButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BlueButton.Name = "BlueButton";
            this.BlueButton.Size = new System.Drawing.Size(30, 20);
            this.BlueButton.Click += new System.EventHandler(this.ChangeShowBand);
            // 
            // GreenButton
            // 
            this.GreenButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.GreenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GreenButton.Image = ((System.Drawing.Image)(resources.GetObject("GreenButton.Image")));
            this.GreenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GreenButton.Name = "GreenButton";
            this.GreenButton.Size = new System.Drawing.Size(30, 20);
            this.GreenButton.Click += new System.EventHandler(this.ChangeShowBand);
            // 
            // RedButton
            // 
            this.RedButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedButton.Image = ((System.Drawing.Image)(resources.GetObject("RedButton.Image")));
            this.RedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(30, 20);
            this.RedButton.Click += new System.EventHandler(this.ChangeShowBand);
            // 
            // BandHistogram
            // 
            this.BandHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX2.Maximum = 255D;
            chartArea2.AxisX2.Minimum = 0D;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY2.Maximum = 100D;
            chartArea2.AxisY2.Minimum = 0D;
            chartArea2.Name = "Histogram";
            this.BandHistogram.ChartAreas.Add(chartArea2);
            this.BandHistogram.IsSoftShadows = false;
            this.BandHistogram.Location = new System.Drawing.Point(9, 59);
            this.BandHistogram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BandHistogram.Name = "BandHistogram";
            this.BandHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series2.ChartArea = "Histogram";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "HistogramSeries";
            this.BandHistogram.Series.Add(series2);
            this.BandHistogram.Size = new System.Drawing.Size(509, 244);
            this.BandHistogram.TabIndex = 4;
            this.BandHistogram.TabStop = false;
            this.BandHistogram.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // frmCustomStretch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 411);
            this.Controls.Add(this.BandSelectToolStrip);
            this.Controls.Add(this.InfoGroupBox);
            this.Controls.Add(this.BandHistogram);
            this.Controls.Add(this.BandSelectComboBox);
            this.Controls.Add(this.BandLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 450);
            this.Name = "frmCustomStretch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.FormLoad);
            this.SizeChanged += new System.EventHandler(this.SizeChange);
            this.InfoGroupBox.ResumeLayout(false);
            this.InfoGroupBox.PerformLayout();
            this.BandSelectToolStrip.ResumeLayout(false);
            this.BandSelectToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BandHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BandSelectComboBox;
        private System.Windows.Forms.Label BandLabel;
        private System.Windows.Forms.GroupBox InfoGroupBox;
        private System.Windows.Forms.Label StddevLabel;
        private System.Windows.Forms.Label MeanLabel;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label PixelCountLabel;
        private System.Windows.Forms.ToolStrip BandSelectToolStrip;
        private System.Windows.Forms.ToolStripButton GrayButton;
        private System.Windows.Forms.ToolStripButton OverviewButton;
        private System.Windows.Forms.ToolStripButton BlueButton;
        private System.Windows.Forms.ToolStripButton GreenButton;
        private System.Windows.Forms.ToolStripButton RedButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart BandHistogram;
    }
}