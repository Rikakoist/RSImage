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
    /// <summary>
    /// 阈值分割窗体。
    /// </summary>
    public partial class FrmBinarize : Form
    {
        public double Threshold = 0.0;
        public ImageSplitMethods method = ImageSplitMethods.Manual_None;
        public FrmBinarize(Img img)
        {
            InitializeComponent();
            if (!img.IsGrayscale)
                throw new ArgumentException("输入的不是灰度图像。");
            BValueSelector.Min = img.Min[0];
            BValueSelector.Max = img.Max[0];
            BValueSelector.Value = (img.Min[0] + img.Max[0]) / 2;
            BValueSelector.Ratio = 0.1;
            BFilePathSelector.Filter = "All files|*.*|GeoTIFF|*.tif";
            BFilePathSelector.FilterIndex = 2;
            CheckMethod();
        }

        private void FrmBinarize_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Enum.GetNames(typeof(ImageSplitMethods)).GetLength(0); i++)
            {
               SplitMethodsComboBox.Items.Add((typeof(ImageSplitMethods).GetField(((ImageSplitMethods)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description);
            }
           SplitMethodsComboBox.SelectedIndex = 0;
        }

        //更改分割方式。
        private void SplitMethodsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            method = (ImageSplitMethods)SplitMethodsComboBox.SelectedIndex;
            CheckMethod();
        }

        /// <summary>
        ///  检查分割方式并决定是否禁用阈值选择器。
        /// </summary>
        private void CheckMethod()
        {
            if(method==ImageSplitMethods.Manual_None)
            {
                BValueSelector.Enabled = true;
            }
            else
            {
                BValueSelector.Enabled = false;
            }
        }

        private void BConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            Threshold = BValueSelector.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
