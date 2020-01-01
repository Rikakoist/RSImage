using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSImage
{
    public partial class FilePathSelector : UserControl
    {
        [Description("保存文件对话框的标题"), Category("自定义")]
        public string Title { get; set; } = "选择保存位置";
        [Description("保存文件对话框扩展名筛选器"), Category("自定义")]
        public string Filter { get; set; } = "All files|*.*";
        [Description("保存文件对话框扩展名筛选器索引"), Category("自定义")]
        public int FilterIndex { get; set; } = 1;
        [Description("保存文件的路径"), Category("自定义")]
        public string Path { get; set; } = null;
        [Description("保存文件框的起始文件夹"), Category("自定义")]
        public string WorkFolder { get; set; } = Environment.SpecialFolder.Personal.ToString();
        [Description("输出影像的数据类型"), Category("自定义")]
        public OSGeo.GDAL.DataType OutDataType { get; set; } = OSGeo.GDAL.DataType.GDT_Float32;

        public FilePathSelector()
        {
            InitializeComponent();
        }

        //Load
        private void ControlInit(object sender, EventArgs e)
        {
            try
            {
                DataTypeComboBox.Items.AddRange(Enum.GetNames(typeof(OSGeo.GDAL.DataType)));    //直接调用GDAL的DataType枚举类型
                DataTypeComboBox.SelectedIndex = (int)OutDataType;
            }
            catch(Exception)
            {
                DataTypeComboBox.SelectedIndex = 0;
            }
        }

        //“浏览”按钮的Click事件
        private void BrowseFile(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog()
            {
                AddExtension = true,
                AutoUpgradeEnabled = true,
                CheckFileExists = false,
                CheckPathExists = true,
                CreatePrompt = false,
                DefaultExt = null,
                DereferenceLinks = true,
                FileName = null,
                Filter = this.Filter,
                FilterIndex = this.FilterIndex,
                InitialDirectory = WorkFolder,
                OverwritePrompt = true,
                RestoreDirectory = false,
                ShowHelp = false,
                SupportMultiDottedExtensions = false,
                Tag = null,
                Title = this.Title,
                ValidateNames = true,
            };
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                FilePathTextBox.Text = SFD.FileName;
            }
        }

        //文本框的TextChanged事件
        private void ChangeFilePath(object sender, EventArgs e)
        {
            Path = this.FilePathTextBox.Text;   //改变输出路径
        }

        //组框的SelectedIndexChanged事件
        private void ChangeDataType(object sender, EventArgs e)
        {
            OutDataType = (OSGeo.GDAL.DataType)Enum.Parse(typeof(OSGeo.GDAL.DataType),DataTypeComboBox.Text,true);   //改变输出的数据类型
        }
    }
}
