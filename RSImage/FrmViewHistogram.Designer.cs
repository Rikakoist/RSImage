namespace RSImage
{
    partial class FrmViewHistogram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewHistogram));
            this.BandSelectComboBox = new System.Windows.Forms.ComboBox();
            this.BandLabel = new System.Windows.Forms.Label();
            this.BandHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.PixelCountLabel = new System.Windows.Forms.Label();
            this.StddevLabel = new System.Windows.Forms.Label();
            this.MeanLabel = new System.Windows.Forms.Label();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BandHistogram)).BeginInit();
            this.InfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BandSelectComboBox
            // 
            this.BandSelectComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BandSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BandSelectComboBox.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BandSelectComboBox.FormattingEnabled = true;
            this.BandSelectComboBox.Location = new System.Drawing.Point(207, 32);
            this.BandSelectComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BandSelectComboBox.Name = "BandSelectComboBox";
            this.BandSelectComboBox.Size = new System.Drawing.Size(152, 25);
            this.BandSelectComboBox.TabIndex = 0;
            this.BandSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeBand);
            // 
            // BandLabel
            // 
            this.BandLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BandLabel.AutoSize = true;
            this.BandLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BandLabel.Location = new System.Drawing.Point(93, 33);
            this.BandLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BandLabel.Name = "BandLabel";
            this.BandLabel.Size = new System.Drawing.Size(100, 24);
            this.BandLabel.TabIndex = 2;
            this.BandLabel.Text = "选择波段：";
            this.BandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BandHistogram
            // 
            this.BandHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX2.Maximum = 255D;
            chartArea1.AxisX2.Minimum = 0D;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY2.Maximum = 100D;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "Histogram";
            this.BandHistogram.ChartAreas.Add(chartArea1);
            this.BandHistogram.IsSoftShadows = false;
            this.BandHistogram.Location = new System.Drawing.Point(0, 90);
            this.BandHistogram.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BandHistogram.Name = "BandHistogram";
            this.BandHistogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "Histogram";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "HistogramSeries";
            this.BandHistogram.Series.Add(series1);
            this.BandHistogram.Size = new System.Drawing.Size(445, 284);
            this.BandHistogram.TabIndex = 1;
            this.BandHistogram.TabStop = false;
            this.BandHistogram.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.Controls.Add(this.PixelCountLabel);
            this.InfoGroupBox.Controls.Add(this.StddevLabel);
            this.InfoGroupBox.Controls.Add(this.MeanLabel);
            this.InfoGroupBox.Controls.Add(this.MaxLabel);
            this.InfoGroupBox.Controls.Add(this.MinLabel);
            this.InfoGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoGroupBox.Location = new System.Drawing.Point(0, 383);
            this.InfoGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InfoGroupBox.Size = new System.Drawing.Size(445, 123);
            this.InfoGroupBox.TabIndex = 3;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "波段信息";
            // 
            // PixelCountLabel
            // 
            this.PixelCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PixelCountLabel.AutoSize = true;
            this.PixelCountLabel.Location = new System.Drawing.Point(53, 92);
            this.PixelCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PixelCountLabel.Name = "PixelCountLabel";
            this.PixelCountLabel.Size = new System.Drawing.Size(50, 17);
            this.PixelCountLabel.TabIndex = 0;
            this.PixelCountLabel.Text = "像素：";
            // 
            // StddevLabel
            // 
            this.StddevLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StddevLabel.AutoSize = true;
            this.StddevLabel.Location = new System.Drawing.Point(253, 62);
            this.StddevLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StddevLabel.Name = "StddevLabel";
            this.StddevLabel.Size = new System.Drawing.Size(64, 17);
            this.StddevLabel.TabIndex = 0;
            this.StddevLabel.Text = "标准差：";
            // 
            // MeanLabel
            // 
            this.MeanLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MeanLabel.AutoSize = true;
            this.MeanLabel.Location = new System.Drawing.Point(53, 62);
            this.MeanLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MeanLabel.Name = "MeanLabel";
            this.MeanLabel.Size = new System.Drawing.Size(64, 17);
            this.MeanLabel.TabIndex = 0;
            this.MeanLabel.Text = "平均值：";
            // 
            // MaxLabel
            // 
            this.MaxLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(253, 31);
            this.MaxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(64, 17);
            this.MaxLabel.TabIndex = 0;
            this.MaxLabel.Text = "最大值：";
            // 
            // MinLabel
            // 
            this.MinLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(53, 31);
            this.MinLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(64, 17);
            this.MinLabel.TabIndex = 0;
            this.MinLabel.Text = "最小值：";
            // 
            // FrmViewHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 506);
            this.Controls.Add(this.BandHistogram);
            this.Controls.Add(this.InfoGroupBox);
            this.Controls.Add(this.BandSelectComboBox);
            this.Controls.Add(this.BandLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(394, 543);
            this.Name = "FrmViewHistogram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.FormLoad);
            this.SizeChanged += new System.EventHandler(this.SizeChange);
            ((System.ComponentModel.ISupportInitialize)(this.BandHistogram)).EndInit();
            this.InfoGroupBox.ResumeLayout(false);
            this.InfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BandSelectComboBox;
        private System.Windows.Forms.Label BandLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart BandHistogram;
        private System.Windows.Forms.GroupBox InfoGroupBox;
        private System.Windows.Forms.Label StddevLabel;
        private System.Windows.Forms.Label MeanLabel;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label PixelCountLabel;
    }
}