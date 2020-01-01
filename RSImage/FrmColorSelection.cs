using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage
{
    public partial class FrmColorSelection : Form
    {
       public Color FromColor = Color.Black;
       public Color ToColor = Color.White;

        public FrmColorSelection(Color From,Color To)
        {
            InitializeComponent();
            FromColor = From;
            ToColor = To;
        }

        private void SelectionForm_Load(object sender, EventArgs e)
        {
            ResetF();
            ResetT();
            CreateColorRamp();
        }

        //点击PictureBox选择颜色。
        private void FromColorPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog CD = new ColorDialog()
                {
                    AllowFullOpen=true,
                    Color=FromColor,
                    FullOpen=true,
                };
                if (CD.ShowDialog()==DialogResult.OK)
                {
                    FromColor = CD.Color;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                FromColor = Color.Black;
            }
            finally
            {
                ResetF();
                ResetT();
                CreateColorRamp();
            }
        }

        private void ToColorPictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                ColorDialog CD = new ColorDialog()
                {
                    AllowFullOpen = true,
                    Color = ToColor,
                    FullOpen = true,
                };
                if (CD.ShowDialog() == DialogResult.OK)
                {
                    ToColor = CD.Color;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                ToColor = Color.White;
            }
            finally
            {
                ResetF();
                ResetT();
                CreateColorRamp();
            }
        }

        /// <summary>
        /// 创建渐变色带（ColorRamp不好使啊！）。
        /// </summary>
        private void CreateColorRamp()
        {
            Bitmap bitmap = new Bitmap(PreviewPictureBox.Width, PreviewPictureBox.Height);
            for (int i = 0; i < PreviewPictureBox.Width; i++)
            {
                for (int j = 0; j < PreviewPictureBox.Height; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(Gradient(FromColor.A, ToColor.A, i, PreviewPictureBox.Width), Gradient(FromColor.R, ToColor.R, i, PreviewPictureBox.Width), Gradient(FromColor.G, ToColor.G, i, PreviewPictureBox.Width), Gradient(FromColor.B, ToColor.B, i, PreviewPictureBox.Width)));
                }
            }
            PreviewPictureBox.Image = bitmap;
        }

        /// <summary>
        /// 渐变计算。
        /// </summary>
        /// <param name="from">起始值。</param>
        /// <param name="to">终止值。</param>
        /// <param name="now">迭代当前值。</param>
        /// <param name="desti">迭代终点值。</param>
        /// <returns>8位整型。</returns>
        private byte Gradient(int from, int to, int now, int desti)
        {
            return (byte)(from+((double)now/desti*(to-from)));
        }

        //重置预览颜色及文本。
        private void ResetF()
        {
            FromColorPictureBox.BackColor = FromColor;
            FromColorLabel.Text = "A: " + FromColor.A + "\r\nR: " + FromColor.R + "\r\nG: " + FromColor.G + "\r\nB: " + FromColor.B;
        }
        private void ResetT()
        {
            ToColorPictureBox.BackColor = ToColor;
            ToColorLabel.Text = "A: " + ToColor.A + "\r\nR: " + ToColor.R + "\r\nG: " + ToColor.G + "\r\nB: " + ToColor.B;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
