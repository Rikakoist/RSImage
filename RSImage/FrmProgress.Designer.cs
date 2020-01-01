namespace RSImage
{
    partial class FrmProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgress));
            this.FirstPBar = new System.Windows.Forms.ProgressBar();
            this.SecondPBar = new System.Windows.Forms.ProgressBar();
            this.FirstLabel = new System.Windows.Forms.Label();
            this.SecondLabel = new System.Windows.Forms.Label();
            this.AbortButton = new System.Windows.Forms.Button();
            this.OutText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FirstPBar
            // 
            this.FirstPBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstPBar.Location = new System.Drawing.Point(11, 261);
            this.FirstPBar.Margin = new System.Windows.Forms.Padding(2);
            this.FirstPBar.Name = "FirstPBar";
            this.FirstPBar.Size = new System.Drawing.Size(416, 24);
            this.FirstPBar.Step = 1;
            this.FirstPBar.TabIndex = 0;
            // 
            // SecondPBar
            // 
            this.SecondPBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondPBar.Location = new System.Drawing.Point(11, 331);
            this.SecondPBar.Margin = new System.Windows.Forms.Padding(2);
            this.SecondPBar.Name = "SecondPBar";
            this.SecondPBar.Size = new System.Drawing.Size(416, 24);
            this.SecondPBar.Step = 1;
            this.SecondPBar.TabIndex = 0;
            // 
            // FirstLabel
            // 
            this.FirstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstLabel.AutoSize = true;
            this.FirstLabel.Location = new System.Drawing.Point(17, 235);
            this.FirstLabel.Name = "FirstLabel";
            this.FirstLabel.Size = new System.Drawing.Size(0, 13);
            this.FirstLabel.TabIndex = 1;
            this.FirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondLabel
            // 
            this.SecondLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondLabel.AutoSize = true;
            this.SecondLabel.Location = new System.Drawing.Point(17, 305);
            this.SecondLabel.Name = "SecondLabel";
            this.SecondLabel.Size = new System.Drawing.Size(0, 13);
            this.SecondLabel.TabIndex = 1;
            this.SecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AbortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AbortButton.Location = new System.Drawing.Point(184, 363);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 30);
            this.AbortButton.TabIndex = 3;
            this.AbortButton.TabStop = false;
            this.AbortButton.Text = "取消";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // OutText
            // 
            this.OutText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutText.Location = new System.Drawing.Point(11, 12);
            this.OutText.Multiline = true;
            this.OutText.Name = "OutText";
            this.OutText.ReadOnly = true;
            this.OutText.ShortcutsEnabled = false;
            this.OutText.Size = new System.Drawing.Size(415, 209);
            this.OutText.TabIndex = 4;
            this.OutText.TabStop = false;
            // 
            // FrmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 402);
            this.Controls.Add(this.OutText);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.SecondLabel);
            this.Controls.Add(this.FirstLabel);
            this.Controls.Add(this.SecondPBar);
            this.Controls.Add(this.FirstPBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProgress_FormClosing);
            this.Load += new System.EventHandler(this.FrmProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar FirstPBar;
        private System.Windows.Forms.ProgressBar SecondPBar;
        private System.Windows.Forms.Label FirstLabel;
        private System.Windows.Forms.Label SecondLabel;
        internal System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.TextBox OutText;
    }
}