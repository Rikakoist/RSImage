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
    /// 导出路径选择窗口。
    /// </summary>
    public partial class FrmExport : Form
    {
        public string OutPath;
        public OSGeo.GDAL.DataType OutDataType;

        public FrmExport(string Title = "选择影像存储位置...", string Filter = "All files|*.*|GeoTIFF files|*.tif" ,int FilterIndex = 2)
        {
            InitializeComponent();
            this.Text = Title;
            EFFilePathSelector.Filter = Filter;
            EFFilePathSelector.FilterIndex = FilterIndex;
        }

        private void EFConfirmAbortButtons_ConfirmBtnClick(object sender, EventArgs e)
        {
            OutPath = EFFilePathSelector.Path;
            OutDataType = EFFilePathSelector.OutDataType;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EFConfirmAbortButtons_AbortBtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
