namespace RSImage.CommonControls
{
    partial class ValueSelector
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.ValueTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ValueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ValueLabel
            // 
            this.ValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueLabel.Location = new System.Drawing.Point(3, 18);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(32, 17);
            this.ValueLabel.TabIndex = 2;
            this.ValueLabel.Text = "值：";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTextBox.Location = new System.Drawing.Point(295, 15);
            this.ValueTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ValueTextBox.MaxLength = 20;
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(66, 21);
            this.ValueTextBox.TabIndex = 0;
            this.ValueTextBox.TextChanged += new System.EventHandler(this.ValueTextBox_TextChanged);
            // 
            // ValueTrackBar
            // 
            this.ValueTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTrackBar.Location = new System.Drawing.Point(53, 4);
            this.ValueTrackBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ValueTrackBar.Name = "ValueTrackBar";
            this.ValueTrackBar.Size = new System.Drawing.Size(236, 45);
            this.ValueTrackBar.TabIndex = 1;
            this.ValueTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ValueTrackBar.Scroll += new System.EventHandler(this.ValueTrackBar_Scroll);
            // 
            // ValueSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueTrackBar);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(364, 53);
            this.Name = "ValueSelector";
            this.Size = new System.Drawing.Size(364, 53);
            this.Load += new System.EventHandler(this.ValueSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ValueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.TrackBar ValueTrackBar;
    }
}
