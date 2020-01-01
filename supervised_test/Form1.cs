using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using System.IO;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;

namespace supervised_test
{
    public partial class FmDefineROI : Form
    {
        List<string> DefineROIName = new List<string>();

        string imageFilePath = "";
        IGeometryCollection pGeometryCollection = new GeometryBagClass();
        IRasterLayer baseRasterLayer = new RasterLayerClass();
        ISpatialReference spatialReference = null;
        IGraphicsContainer pGraphic = null;
        IPointCollection pointCollection = null;
        string xCoordinate = "";
        string yCoordinate = "";
        //是否开始绘制
        bool bCreateOrNot = false;
        //一个类别多边形的个数
        int polyGonCount = 0;
        //是否新建类别
        bool bNewClassOrNot = false;
        //是否编辑
        bool bEditOrNot = false;

        public FmDefineROI(string BaseMap)
        {
            InitializeComponent();
            imageFilePath = BaseMap;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            this.listView1.SmallImageList = imgList;
            this.listView1.GridLines = true;
            this.listView1.View = View.Details;
            this.listView1.LabelEdit = true;
            this.listView1.Scrollable = true;
            this.listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.listView1.FullRowSelect = true;

            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("编号", 40, HorizontalAlignment.Center);
            this.listView1.Columns.Add("类别名称", 80, HorizontalAlignment.Center);
            this.listView1.Columns.Add("样本个数", 80, HorizontalAlignment.Center);
            this.listView1.Columns.Add("颜  色", 80, HorizontalAlignment.Center);
            this.listView1.Columns.Add("多边形", 80, HorizontalAlignment.Center);
            baseRasterLayer.CreateFromFilePath(imageFilePath);
            axMapControl1.AddLayer(baseRasterLayer);
            this.Text = "正在选择ROI：" + System.IO.Path.GetFileName(imageFilePath);
            spatialReference = axMapControl1.Map.SpatialReference;
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            IMap pMap = axMapControl1.Map;
            if (pMap.LayerCount == 0)
            {
                MessageBox.Show("没有加载栅格数据，请加载数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            ILayer pLayer = axMapControl1.get_Layer(0);
            IRasterLayer pRasterLayer = pLayer as IRasterLayer;
            imageFilePath = pRasterLayer.FilePath.Trim();

            this.cbClassName.Text = "";
            this.txtSampleCount.Text = "";
            this.cbClassName.Enabled = true;
            this.txtColorRamp.Enabled = true;
            this.txtClassID.Text = (this.listView1.Items.Count + 1).ToString();
            this.tsbStartCreate.Enabled = true;
            this.txtClassID.Enabled = true;

            this.txtColorRamp.BackColor = SetColorByIndex(this.listView1.Items.Count + 1);
            polyGonCount = 0;
            bNewClassOrNot = true;

            //if (btnSaveClass.Enabled)
            //{
            //    MessageBox.Show("当前分类没有保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            this.btnSaveClass.Enabled = true;
        }

        private Color SetColorByIndex(int p)
        {
            Color pColor = Color.FromArgb(0, 0, 0);
            switch (p)
            {
                case 1:
                    pColor = Color.FromKnownColor(KnownColor.Red);
                    break;
                case 2:
                    pColor = Color.FromKnownColor(KnownColor.Green);
                    break;
                case 3:
                    pColor = Color.FromKnownColor(KnownColor.Blue);
                    break;
                case 4:
                    pColor = Color.FromKnownColor(KnownColor.Yellow);
                    break;
                case 5:
                    pColor = Color.FromKnownColor(KnownColor.Cyan);
                    break;
                case 6:
                    pColor = Color.FromKnownColor(KnownColor.Magenta);
                    break;
                case 7:
                    pColor = Color.FromKnownColor(KnownColor.Maroon);
                    break;
                case 8:
                    pColor = Color.FromKnownColor(KnownColor.SeaGreen);
                    break;
                case 9:
                    pColor = Color.FromKnownColor(KnownColor.Purple);
                    break;
                case 10:
                    pColor = Color.FromKnownColor(KnownColor.Coral);
                    break;
                case 11:
                    pColor = Color.FromKnownColor(KnownColor.Aquamarine);
                    break;
                case 12:
                    pColor = Color.FromKnownColor(KnownColor.Orchid);
                    break;
                case 13:
                    pColor = Color.FromKnownColor(KnownColor.Sienna);
                    break;
                case 14:
                    pColor = Color.FromKnownColor(KnownColor.Chartreuse);
                    break;
                case 15:
                    pColor = Color.FromKnownColor(KnownColor.Thistle);
                    break;
            }
            return pColor;
        }

        private void tsbStartCreate_Click(object sender, EventArgs e)
        {
            axMapControl1.CurrentTool = null;
            this.tsbStartCreate.Enabled = false;
            this.tsbEndCreate.Enabled = true;
            bCreateOrNot = true;
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                object missing = Type.Missing;
                if (bCreateOrNot)
                {
                    axMapControl1.CurrentTool = null;

                    ESRI.ArcGIS.Geometry.IGeometry pGeometry = axMapControl1.TrackPolygon();

                    pGeometryCollection.AddGeometry(pGeometry, ref missing, ref missing);
                    ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbol();
                    pSimpleLineSymbol.Color = GetAEColor(this.listView1.Items.Count + 1);
                    pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
                    ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbol();
                    pSimpleFillSymbol.Color = GetAEColor(this.listView1.Items.Count + 1);
                    IFillShapeElement pFillElement = new PolygonElementClass();
                    pFillElement.Symbol = pSimpleFillSymbol;
                    IElement pElement;

                    pElement = pFillElement as IElement;
                    pElement.Geometry = pGeometry;
                    pGraphic = axMapControl1.ActiveView as IGraphicsContainer;
                    pGraphic.AddElement(pElement, 0);
                    axMapControl1.Refresh();

                    polyGonCount += 1;
                    this.txtSampleCount.Text = polyGonCount.ToString();

                    IElementProperties pElementProperties = pElement as IElementProperties;
                    pElementProperties.Name = txtClassID.Text;
                }
            }
            if(e.button==4)
            {
                axMapControl1.Pan();
            }
        }

        private IColor GetAEColor(int p)
        {
            Color pColor = SetColorByIndex(p);
            IRgbColor pColorAE = new RgbColor();
            pColorAE.Red = pColor.R;
            pColorAE.Blue = pColor.B;
            pColorAE.Green = pColor.G;
            return pColorAE;
        }

        private void tsbEndCreate_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            tsbStartCreate.Enabled = true;
            tsbEndCreate.Enabled = false;
        }

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            if (cbClassName.Text == "")
            {
                MessageBox.Show("请输入类别名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (txtSampleCount.Text == "")
            {
                MessageBox.Show("没有需要保存的样本！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (bNewClassOrNot)
            {
                ListViewItem pListViewItem = new ListViewItem(this.txtClassID.Text);
                pListViewItem.SubItems.Add(this.cbClassName.Text);
                pListViewItem.SubItems.Add(this.txtSampleCount.Text);
                pListViewItem.SubItems.Add(SetColorByIndex(this.listView1.Items.Count + 1).Name);
                for (int i = 0; i < pGeometryCollection.GeometryCount; i++)
                {
                    pointCollection = pGeometryCollection.get_Geometry(i) as IPointCollection;
                    for (int j = 0; j < pointCollection.PointCount; j++)
                    {
                        xCoordinate += pointCollection.get_Point(j).X.ToString() + ",";
                        yCoordinate += pointCollection.get_Point(j).Y.ToString() + ",";
                    }
                    xCoordinate = xCoordinate.Substring(0, xCoordinate.Length - 1);
                    yCoordinate = yCoordinate.Substring(0, yCoordinate.Length - 1);
                    xCoordinate = xCoordinate + "*";
                    yCoordinate = yCoordinate + "*";
                }
                xCoordinate = xCoordinate.Substring(0, xCoordinate.Length - 1);
                yCoordinate = yCoordinate.Substring(0, yCoordinate.Length - 1);

                pListViewItem.SubItems.Add(xCoordinate + ":" + yCoordinate);
                pListViewItem.BackColor = SetColorByIndex(this.listView1.Items.Count + 1);
                this.listView1.Items.Add(pListViewItem);

                pointCollection.RemovePoints(0, pointCollection.PointCount);
                pGeometryCollection.RemoveGeometries(0, pGeometryCollection.GeometryCount);
                xCoordinate = "";
                yCoordinate = "";
            }
            this.bNewClassOrNot = false;
            this.tsbEndCreate.Enabled = false;
            this.bCreateOrNot = false;
            this.btnSaveClass.Enabled = false;
        }

        private void btnSaveROI_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageFilePath == "")
                {
                    MessageBox.Show("没有分类图像！", "用户提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string resultPath = "";
                string txtfilePath = Application.StartupPath + "\\temp.txt";
                string executePath = Application.StartupPath;

                if (this.listView1.Items.Count == 0)
                {
                    MessageBox.Show("当前没有需要保存的记录！", "用户提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    SaveFileDialog sav = new SaveFileDialog
                    {
                        AddExtension = true,
                        Title = "ROI保存",
                        Filter = "ROI文件|*.roi",
                        DefaultExt = ".roi",
                    };
                    if (sav.ShowDialog() == DialogResult.OK)
                    {
                        resultPath = sav.FileName;

                        using (StreamWriter sw = new StreamWriter(txtfilePath))
                        {
                            sw.Write("");
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                int colorindex = TransferColorToIDLIndexColor(listView1.Items[i].SubItems[3].Text);
                                string className = listView1.Items[i].SubItems[1].Text;
                                string value = listView1.Items[i].SubItems[4].Text + ":" + colorindex.ToString() + ":" + className;

                                sw.WriteLine(value);
                            }
                            sw.Close();
                        }

                        //记载IDL程序
                        COM_IDL_connectLib.COM_IDL_connect com = new COM_IDL_connectLib.COM_IDL_connect();
                        com.CreateObject(0, null, null);
                        com.ExecuteString(".compile '" + executePath + "\\createroi_polygon.pro'");
                        string executeStr = "createroi_polygon,'" + imageFilePath + "','" + txtfilePath + "','" + resultPath + "'";
                        com.ExecuteString(executeStr);
                        com.DestroyObject();
                        MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        bEditOrNot = false;
                        this.Close();
                        Environment.Exit(1);
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private int TransferColorToIDLIndexColor(string p)
        {
            int i = 0;

            switch (p)
            {
                //紅色
                case "Red":
                    i = 2;
                    break;
                //綠色
                case "Green":
                    i = 3;
                    break;
                //蓝色
                case "Blue":
                    i = 4;
                    break;
                //黄色
                case "Yellow":
                    i = 5;
                    break;
                //蓝绿色
                case "Cyan":
                    i = 6;
                    break;
                //品红色
                case "Magenta":
                    i = 7;
                    break;
                //褐红色
                case "Maroon":
                    i = 8;
                    break;
                //海绿色
                case "Sea Green":
                    i = 9;
                    break;
                //紫色
                case "Purple":
                    i = 10;
                    break;
                //珊瑚色
                case "Coral":
                    i = 11;
                    break;
                //浅绿色
                case "Aquamarine":
                    i = 12;
                    break;
                //浅紫色
                case "Orchid":
                    i = 13;
                    break;
                //黄褐色
                case "Sienna":
                    i = 14;
                    break;
                //黄绿色
                case "Chartreuse":
                    i = 15;
                    break;
                //蓟
                case "Thistle":
                    i = 16;
                    break;
            }
            return i;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(-1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            ICommand pCommand = this.axToolbarControl1.GetItem(0).Command as ICommand;
            pCommand.OnCreate(this.axMapControl1.Object);
            pCommand.OnClick();
            this.axMapControl1.CurrentTool = pCommand as ITool;
            this.tsbStartCreate.Enabled = true;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            bEditOrNot = true;
            int i = listView1.SelectedItems.Count;
            if (i == 0)
            {
                MessageBox.Show("请选择需要删除的记录", "用户提示");
                return;
            }
            pGraphic.Reset();
            string name = listView1.SelectedItems[0].SubItems[0].Text;
            IElement pElement = pGraphic.Next();

            while (pElement != null)
            {
                IElementProperties pd = pElement as IElementProperties;
                if (pd.Name == name)
                {
                    pGraphic.DeleteElement(pElement);
                }
                pElement = pGraphic.Next();
            }
            axMapControl1.Refresh();

            this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
            for (int j = 0; j < listView1.Items.Count; j++)
            {
                listView1.Items[j].SubItems[0].Text = (j + 1).ToString();
            }
            MessageBox.Show("删除成功，请保存更改！", "用户提示", MessageBoxButtons.OK
                , MessageBoxIcon.Asterisk);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            if (tsbStartCreate.Enabled == false)
            {
                axMapControl1.CurrentTool = null;
                ICommand command = new ControlsMapZoomInToolClass();
                command.OnCreate(axMapControl1.Object);
                axMapControl1.CurrentTool = (ITool)command;
                this.tsbStartCreate.Enabled = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            axMapControl1.CurrentTool = null;
            ICommand command = new ControlsMapZoomOutToolClass();
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = (ITool)command;
            this.tsbStartCreate.Enabled = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            axMapControl1.CurrentTool = null;
            ICommand command = new ControlsMapPanToolClass();
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = (ITool)command;
            this.tsbStartCreate.Enabled = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            axMapControl1.CurrentTool = null;
            ICommand command = new ControlsMapFullExtentCommandClass();
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = (ITool)command;
            this.tsbStartCreate.Enabled = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bCreateOrNot = false;
            axMapControl1.CurrentTool = null;
            ICommand command = this.axToolbarControl1.GetItem(5).Command as ICommand;
            command.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = (ITool)command;
            this.tsbStartCreate.Enabled = true;
        }
    }
}