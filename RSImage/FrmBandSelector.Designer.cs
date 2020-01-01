namespace RSImage
{
    partial class FrmBandSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBandSelector));
            this.BandSelectTreeView = new System.Windows.Forms.TreeView();
            this.BandSelectorImageList = new System.Windows.Forms.ImageList(this.components);
            this.BSConfirmAbortButtons = new RSImage.CommonControls.ConfirmAbortButtons();
            this.SuspendLayout();
            // 
            // BandSelectTreeView
            // 
            this.BandSelectTreeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.BandSelectTreeView.HideSelection = false;
            this.BandSelectTreeView.ImageIndex = 0;
            this.BandSelectTreeView.ImageList = this.BandSelectorImageList;
            this.BandSelectTreeView.Location = new System.Drawing.Point(0, 0);
            this.BandSelectTreeView.Name = "BandSelectTreeView";
            this.BandSelectTreeView.SelectedImageIndex = 1;
            this.BandSelectTreeView.Size = new System.Drawing.Size(384, 219);
            this.BandSelectTreeView.TabIndex = 0;
            this.BandSelectTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ChangeBand);
            // 
            // BandSelectorImageList
            // 
            this.BandSelectorImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BandSelectorImageList.ImageStream")));
            this.BandSelectorImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.BandSelectorImageList.Images.SetKeyName(0, "filemultispectral.png");
            this.BandSelectorImageList.Images.SetKeyName(1, "Empty.png");
            this.BandSelectorImageList.Images.SetKeyName(2, "red.png");
            this.BandSelectorImageList.Images.SetKeyName(3, "green.png");
            this.BandSelectorImageList.Images.SetKeyName(4, "blue.png");
            this.BandSelectorImageList.Images.SetKeyName(5, "rg.png");
            this.BandSelectorImageList.Images.SetKeyName(6, "rb.png");
            this.BandSelectorImageList.Images.SetKeyName(7, "gb.png");
            this.BandSelectorImageList.Images.SetKeyName(8, "rgb.png");
            // 
            // BSConfirmAbortButtons
            // 
            this.BSConfirmAbortButtons.Location = new System.Drawing.Point(251, 225);
            this.BSConfirmAbortButtons.MinimumSize = new System.Drawing.Size(120, 30);
            this.BSConfirmAbortButtons.Name = "BSConfirmAbortButtons";
            this.BSConfirmAbortButtons.Size = new System.Drawing.Size(133, 30);
            this.BSConfirmAbortButtons.TabIndex = 1;
            this.BSConfirmAbortButtons.ConfirmBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.ConfirmBtnClickEventHander(this.BSConfirmAbortButtons_ConfirmBtnClick);
            this.BSConfirmAbortButtons.AbortBtnClick += new RSImage.CommonControls.ConfirmAbortButtons.AbortBtnClickEventHander(this.BSConfirmAbortButtons_AbortBtnClick);
            // 
            // frmBandSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.BSConfirmAbortButtons);
            this.Controls.Add(this.BandSelectTreeView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "frmBandSelector";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView BandSelectTreeView;
        private System.Windows.Forms.ImageList BandSelectorImageList;
        private CommonControls.ConfirmAbortButtons BSConfirmAbortButtons;
    }
}