namespace RSImage.CommonControls
{
    partial class ConfirmAbortButtons
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConfirmButton.Location = new System.Drawing.Point(0, 0);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(55, 25);
            this.ConfirmButton.TabIndex = 0;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.SetResult);
            // 
            // AbortButton
            // 
            this.AbortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AbortButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.AbortButton.Location = new System.Drawing.Point(65, 0);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(55, 25);
            this.AbortButton.TabIndex = 1;
            this.AbortButton.Text = "取消";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.SetResult);
            // 
            // ConfirmAbortButtons
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.ConfirmButton);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(120, 25);
            this.Name = "ConfirmAbortButtons";
            this.Size = new System.Drawing.Size(120, 25);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ConfirmButton;
        public System.Windows.Forms.Button AbortButton;
    }
}
