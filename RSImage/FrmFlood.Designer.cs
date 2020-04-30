namespace RSImage
{
    partial class FrmFlood
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
            this.FConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.OutPathButton = new System.Windows.Forms.Button();
            this.OutPathTextBox = new System.Windows.Forms.TextBox();
            this.OutPathLabel = new System.Windows.Forms.Label();
            this.InPathButton = new System.Windows.Forms.Button();
            this.InPathTextBox = new System.Windows.Forms.TextBox();
            this.InPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FConfirmAbortButtons
            // 
            this.FConfirmAbortButtons.Location = new System.Drawing.Point(266, 174);
            this.FConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 25);
            this.FConfirmAbortButtons.Name = "FConfirmAbortButtons";
            this.FConfirmAbortButtons.Size = new System.Drawing.Size(120, 25);
            this.FConfirmAbortButtons.TabIndex = 1;
            this.FConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.FConfirmAbortButtons_ConfirmBtnClick);
            this.FConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.FConfirmAbortButtons_AbortBtnClick);
            // 
            // OutPathButton
            // 
            this.OutPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutPathButton.Location = new System.Drawing.Point(327, 119);
            this.OutPathButton.Name = "OutPathButton";
            this.OutPathButton.Size = new System.Drawing.Size(59, 25);
            this.OutPathButton.TabIndex = 5;
            this.OutPathButton.Text = "浏览";
            this.OutPathButton.UseVisualStyleBackColor = true;
            this.OutPathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // OutPathTextBox
            // 
            this.OutPathTextBox.Location = new System.Drawing.Point(104, 122);
            this.OutPathTextBox.Name = "OutPathTextBox";
            this.OutPathTextBox.Size = new System.Drawing.Size(208, 20);
            this.OutPathTextBox.TabIndex = 6;
            // 
            // OutPathLabel
            // 
            this.OutPathLabel.AutoSize = true;
            this.OutPathLabel.Location = new System.Drawing.Point(31, 125);
            this.OutPathLabel.Name = "OutPathLabel";
            this.OutPathLabel.Size = new System.Drawing.Size(67, 13);
            this.OutPathLabel.TabIndex = 4;
            this.OutPathLabel.Text = "输出目录：";
            // 
            // InPathButton
            // 
            this.InPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InPathButton.Location = new System.Drawing.Point(327, 41);
            this.InPathButton.Name = "InPathButton";
            this.InPathButton.Size = new System.Drawing.Size(59, 25);
            this.InPathButton.TabIndex = 8;
            this.InPathButton.Text = "浏览";
            this.InPathButton.UseVisualStyleBackColor = true;
            this.InPathButton.Click += new System.EventHandler(this.InPathButton_Click);
            // 
            // InPathTextBox
            // 
            this.InPathTextBox.Location = new System.Drawing.Point(104, 44);
            this.InPathTextBox.Name = "InPathTextBox";
            this.InPathTextBox.Size = new System.Drawing.Size(208, 20);
            this.InPathTextBox.TabIndex = 9;
            // 
            // InPathLabel
            // 
            this.InPathLabel.AutoSize = true;
            this.InPathLabel.Location = new System.Drawing.Point(31, 47);
            this.InPathLabel.Name = "InPathLabel";
            this.InPathLabel.Size = new System.Drawing.Size(67, 13);
            this.InPathLabel.TabIndex = 7;
            this.InPathLabel.Text = "输入目录：";
            // 
            // FrmFlood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 217);
            this.Controls.Add(this.InPathButton);
            this.Controls.Add(this.InPathTextBox);
            this.Controls.Add(this.InPathLabel);
            this.Controls.Add(this.OutPathButton);
            this.Controls.Add(this.OutPathTextBox);
            this.Controls.Add(this.OutPathLabel);
            this.Controls.Add(this.FConfirmAbortButtons);
            this.Name = "FrmFlood";
            this.Text = "FrmFlood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CommonControls.ConfirmAbortButtons FConfirmAbortButtons;
        private System.Windows.Forms.Button OutPathButton;
        private System.Windows.Forms.TextBox OutPathTextBox;
        private System.Windows.Forms.Label OutPathLabel;
        private System.Windows.Forms.Button InPathButton;
        private System.Windows.Forms.TextBox InPathTextBox;
        private System.Windows.Forms.Label InPathLabel;
    }
}