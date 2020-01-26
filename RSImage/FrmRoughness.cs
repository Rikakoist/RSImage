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
using System.Threading;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;

namespace RSImage
{
    public partial class FrmRoughness : Form
    {
        Img InputImg;
        public string OutPath;
        public DataType OutDataType;
        public int ConvertMode;
        public double NoDataValue = -9999;
        public double ReplaceValue = 0;
        public double NewNoDataValue = 9999;

        public List<double[]> ReplaceList = new List<double[]>();


        public FrmRoughness()
        {
            InitializeComponent();
        }

        public FrmRoughness(Img Image)
        {
            InitializeComponent();
            if(Image.BandNum==1)
            {
                this.InputImg = Image;
                NoDataValueTextBox.Text = InputImg.NoDataValue[0].ToString();
                NewNoDataValueTextBox.Text = NewNoDataValue.ToString();
                RFFilePathSelector.Filter = "All files|*.*|Geotiff|*.tif";
                RFFilePathSelector.FilterIndex = 2;
            }
            else
            {
                this.Close();
                throw new ArgumentOutOfRangeException("操作的影像不是灰度影像。");
            }
        }

        //转换操作控制
        private void Confirm(object sender, EventArgs e)
        {
            try
            {
                switch (ModeTabControl.SelectedIndex)
                {
                    case 0:
                        {
                            if (String.IsNullOrWhiteSpace(ReplaceValueTextBox.Text) || String.IsNullOrWhiteSpace(NoDataValueTextBox.Text)) //检查数值框
                            {
                                throw new NoNullAllowedException("输入的糙率或NoData值不正确！");
                            }
                            if(!Double.TryParse(NoDataValueTextBox.Text, out NoDataValue))
                            {
                                throw new FormatException("NoData值输入错误。");
                            }
                            if (!Double.TryParse(ReplaceValueTextBox.Text, out ReplaceValue))
                            {
                                throw new FormatException("替换值输入错误。");
                            }
                            if (!Double.TryParse(NewNoDataValueTextBox.Text, out NewNoDataValue))
                            {
                                throw new FormatException("新NoData值输入错误。");
                            }
                            break;
                        }
                    case 1:
                        {
                            if (ValuesDataGridView.RowCount < 2)
                            {
                                throw new Exception("无数据。");
                            }
                            ReplaceList.Clear();
                            for (int i = 0; i < ValuesDataGridView.RowCount - 1; i++)
                            {
                                double[] ReplaceItem = new double[2] { Convert.ToDouble(ValuesDataGridView[1, i].Value), Convert.ToDouble(ValuesDataGridView[2, i].Value)};
                                ReplaceList.Add(ReplaceItem);
                            }
                            break;
                        }
                    default:
                        {
                            throw new Exception("???");
                        }
                }
                ConvertMode = ModeTabControl.SelectedIndex;
                OutPath = RFFilePathSelector.Path;
                OutDataType = RFFilePathSelector.OutDataType;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (NoNullAllowedException err)
            {
                MessageBox.Show(err.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void ClickToDeleteRow(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex < ValuesDataGridView.Rows.Count - 1)
                {
                    ValuesDataGridView.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void RConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
