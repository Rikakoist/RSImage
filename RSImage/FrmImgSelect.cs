using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RSImage
{
    /// <summary>
    /// 影像选择窗口。
    /// </summary>
    public partial class FrmImgSelect : Form
    {
        private List<Img> imgs;
        public Img SelectedImg;
        public FrmImgSelect(List<Img> imgs, string Title="选择影像...")
        {
            InitializeComponent();
            this.imgs = imgs;
            this.Text = Title;
        }

        private void frmImgSelect_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < imgs.Count; i++)
            {
                InputFileListView.Items.Add(Path.GetFileName(imgs[i].Path));
            }
            ISConfirmAbortButtons.ConfirmButton.Enabled = false;
        }

        private void InputFileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InputFileListView.SelectedIndices.Count > 0)
            {
                ISConfirmAbortButtons.ConfirmButton.Enabled = true;
                SelectedImg = imgs[InputFileListView.SelectedIndices[0]];
                string filePath = "文件：" + SelectedImg.Path;
                string dims = "维度：" + SelectedImg.Width.ToString() + " × " + SelectedImg.Height.ToString() + " × " + SelectedImg.BandNum.ToString();
                string size = "大小：" + new FileInfo(SelectedImg.Path).Length.ToString() + "字节（Byte）。";
                string projection = "投影：" + SelectedImg.Projection;
                FileInfoRichTextBox.Clear();
                FileInfoRichTextBox.Text += filePath + "\r\n" + dims + "\r\n" + size + "\r\n" + projection;
            }
            else
                ISConfirmAbortButtons.ConfirmButton.Enabled = false;
        }

        private void ISConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ISConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }
    }
}
