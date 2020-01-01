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
    public partial class FrmSmooth : Form
    {
        public string OutPath;
        Img InputImg = new Img();

        public FrmSmooth()
        {
            InitializeComponent();
        }

        public FrmSmooth(Img Image)
        {
            InitializeComponent();
            this.InputImg = Image;
            SFilePathSelector.Filter = "All files|*.*|GeoTIFF files|*.tif";
            SFilePathSelector.FilterIndex = 2;
        }

        private void FrmSmooth_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Enum.GetNames(typeof(SmoothShapeninngMethods)).GetLength(0); i++)
            {
                SmoothMethodsComboBox.Items.Add((typeof(SmoothShapeninngMethods).GetField(((SmoothShapeninngMethods)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description);
            }
            SmoothMethodsComboBox.SelectedIndex = 0;          
        }

        private void SConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            if (Tools.SpatialEnhancement.SmoothSharpening(InputImg.GDALDataset, SFilePathSelector.OutDataType, (SmoothShapeninngMethods)SmoothMethodsComboBox.SelectedIndex, SFilePathSelector.Path))
            {
                OutPath = SFilePathSelector.Path;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                throw new Exception("遇到错误，输出影像为空。");
            }
        }

        private void SConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
