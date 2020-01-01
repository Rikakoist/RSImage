namespace RSImage.CommonControls
{
    partial class NumericSelector
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
            this.NLabel = new System.Windows.Forms.Label();
            this.NNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NLabel
            // 
            this.NLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NLabel.AutoSize = true;
            this.NLabel.Location = new System.Drawing.Point(9, 6);
            this.NLabel.Name = "NLabel";
            this.NLabel.Size = new System.Drawing.Size(31, 13);
            this.NLabel.TabIndex = 0;
            this.NLabel.Text = "标题";
            // 
            // NNumericUpDown
            // 
            this.NNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NNumericUpDown.Location = new System.Drawing.Point(86, 3);
            this.NNumericUpDown.Name = "NNumericUpDown";
            this.NNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.NNumericUpDown.TabIndex = 1;
            this.NNumericUpDown.ValueChanged += new System.EventHandler(this.NNumericUpDown_ValueChanged);
            // 
            // NumericSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NNumericUpDown);
            this.Controls.Add(this.NLabel);
            this.MinimumSize = new System.Drawing.Size(100, 27);
            this.Name = "NumericSelector";
            this.Size = new System.Drawing.Size(149, 27);
            this.Load += new System.EventHandler(this.NumericSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NLabel;
        private System.Windows.Forms.NumericUpDown NNumericUpDown;
    }
}
