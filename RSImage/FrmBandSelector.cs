using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace RSImage
{
    /// <summary>
    /// 波段选择窗口
    /// </summary>
    public partial class FrmBandSelector : Form
    {
        bool Checked = false;   //前三次选择不能启用确定键
        public int[] BandList = new int[3] { 0, 0, 0 };
        private Img Image;
        private int Count = 0;
        TreeNode TN;

        public FrmBandSelector(Img Image, string Title = "选择波段组合")
        {
            try
            {
                InitializeComponent();
                this.Image = Image;
                if (Image.BandNum < 2)
                    throw new Exception("选择了灰度影像...");
                this.Text = Title + " - " + Path.GetFileName(Image.Path);
                Checked = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        //Load
        private void FormLoad(object sender, EventArgs e)
        {
            BandSelectTreeView.Nodes.Add("Root", Path.GetFileName(Image.Path), 0, 0);
            TN = BandSelectTreeView.Nodes["Root"];
            for (int i = 1; i <= Image.BandNum; i++)
            {
                TN.Nodes.Add(i.ToString(), "Band " + i.ToString(), 1, 1);
            }
            BandSelectTreeView.ExpandAll();
        }

        //NodeMouseClick事件
        private void ChangeBand(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && e.Node.Name != "Root")
            {
                BandList[Count] = e.Node.Index + 1;
                Count = (Count + 1) % 3;
                ResetPic();

                if (!Checked)    //循环一次后启用“确定”按钮
                {
                    if (BandList[0] != 0 && BandList[1] != 0 && BandList[2] != 0)
                    {
                        BSConfirmAbortButtons.ConfirmButton.Enabled = true;
                        Checked = true;
                    }
                }
            }
        }

        //重置Image
        private bool ResetPic()
        {
            //全部重置以后再按情况分别赋值
            for (int i = 0; i < TN.Nodes.Count; i++)
            {
                TN.Nodes[i].ImageIndex = 1;
            }
            /*
            ImageKey:
            0. filemultispectral;
            1. Empty;
            2. R;
            3. G;
            4. B;
            5. RG;
            6. RB;
            7. GB;
            8. RGB;
            */
            if (BandList[0] == BandList[1] && BandList[1] == BandList[2] && BandList[0] != 0)  //RGB
            {
                TN.Nodes[BandList[0] - 1].ImageIndex = TN.Nodes[BandList[0] - 1].SelectedImageIndex = 8;
                return true;
            }
            if (BandList[0] == BandList[1] && BandList[0] != 0) //RG
            {
                TN.Nodes[BandList[0] - 1].ImageIndex = TN.Nodes[BandList[0] - 1].SelectedImageIndex = 5;
                if (BandList[2] != 0)
                    TN.Nodes[BandList[2] - 1].ImageIndex = TN.Nodes[BandList[2] - 1].SelectedImageIndex = 4;
                return true;
            }
            if (BandList[0] == BandList[2] && BandList[0] != 0) //RB
            {
                TN.Nodes[BandList[0] - 1].ImageIndex = TN.Nodes[BandList[0] - 1].SelectedImageIndex = 6;
                TN.Nodes[BandList[1] - 1].ImageIndex = TN.Nodes[BandList[1] - 1].SelectedImageIndex = 3;
                return true;
            }
            if (BandList[1] == BandList[2] && BandList[1] != 0) //GB
            {
                TN.Nodes[BandList[1] - 1].ImageIndex = TN.Nodes[BandList[1] - 1].SelectedImageIndex = 7;
                TN.Nodes[BandList[0] - 1].ImageIndex = TN.Nodes[BandList[0] - 1].SelectedImageIndex = 2;
                return true;
            }
            //分别赋值
            if (BandList[0] != 0)
                TN.Nodes[BandList[0] - 1].ImageIndex = TN.Nodes[BandList[0] - 1].SelectedImageIndex = 2;
            if (BandList[1] != 0)
                TN.Nodes[BandList[1] - 1].ImageIndex = TN.Nodes[BandList[1] - 1].SelectedImageIndex = 3;
            if (BandList[2] != 0)
                TN.Nodes[BandList[2] - 1].ImageIndex = TN.Nodes[BandList[2] - 1].SelectedImageIndex = 4;
            return true;
        }

        private void BSConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BSConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }
    }
}
