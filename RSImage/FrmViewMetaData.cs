using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;

namespace RSImage
{
    public partial class FrmViewMetaData : Form
    {
        Img img;
        public FrmViewMetaData(Img img)
        {
            InitializeComponent();
            this.img = img;
            this.Text = "影像元数据 - " + Path.GetFileName(img.Path);
        }

        private void FrmViewMetaData_Load(object sender, EventArgs e)
        {
            TreeNode TNRoot = new TreeNode(Path.GetFileName(img.Path));
            //添加元数据域
            foreach(string MetadataDomain in img.MetadataDomainList)
            {
                TNRoot.Nodes.Add(MetadataDomain);
            }
            //对每个元数据域添加元数据项
            foreach(TreeNode DomainTN in TNRoot.Nodes)
            {
                string[] MetadataInDomain = img.GDALDataset.GetMetadata(DomainTN.Text);
                foreach (string Metadata in MetadataInDomain)
                {
                    DomainTN.Nodes.Add(Metadata.Substring(0, Metadata.IndexOf("=")));
                }
                foreach(TreeNode MetadataTN in DomainTN.Nodes)
                {
                   MetadataTN.Nodes.Add(img.GDALDataset.GetMetadataItem(MetadataTN.Text,MetadataTN.Parent.Text));
                }
            }
            MetaDataTreeView.Nodes.Add(TNRoot);
            MetaDataTreeView.ExpandAll();
            string filePath = "文件：" + img.Path;
            string dims = "维度：" + img.Width.ToString() + " × " + img.Height.ToString() + " × " + img.BandNum.ToString();
            string size = "大小：" + new FileInfo(img.Path).Length.ToString() + "字节（Byte）。";
            string projection = "投影：" + img.Projection;
            //string desc = "描述："+img.GDALDataset.GetDescription();
            FileInfoTextBox.Clear();
            FileInfoTextBox.Text += filePath + "\r\n" + dims + "\r\n" + size + "\r\n" + projection;// + "\r\n" + desc;
        }
    }
}
