using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using System.Collections.Generic;
using ESRI.ArcGIS.DataSourcesFile;
using System.Threading;
using ESRI.ArcGIS.Geoprocessor;

namespace ImgROISel
{
    public sealed partial class MainForm : Form
    {
        private IMapControl3 m_mapControl = null;
        private bool CanEdit = false;
        private string BaseMap;
        IRasterLayer baseRasterLayer = new RasterLayerClass();
        IGeometryCollection pGeometryCollection = new GeometryBagClass();
        IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();
        IFeatureWorkspace featureWorkspace;
        IGraphicsContainer pGraphic = null;
        ISpatialReference spatialReference = null;
        ILayer EditingLayer = null;
        int EditingIndex = -1;
        List<string> ROINames = new List<string>();
        List<string> ROIFileNames = new List<string>();
        List<int> ROIFeatureCount = new List<int>();
        List<IRgbColor> ROIColors = new List<IRgbColor>();

        public MainForm(string BaseMap)
        {
            InitializeComponent();
            this.BaseMap = BaseMap;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_mapControl = (IMapControl3)axMapControl1.Object;
                if (BaseMap != null)
                {
                    baseRasterLayer.CreateFromFilePath(BaseMap);
                    axMapControl1.AddLayer(baseRasterLayer);
                    this.Text = "正在选择ROI：" + System.IO.Path.GetFileName(BaseMap);
                    spatialReference = axMapControl1.Map.SpatialReference;
                    //string dir = @"D:\Desktop\qwq";
                    string dir = System.IO.Path.GetTempPath();
                    //featureWorkspace = workspaceFactory.Create(dir, "owo", null, 0) as IFeatureWorkspace;
                    featureWorkspace = workspaceFactory.OpenFromFile(dir, 0) as IFeatureWorkspace;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //更改是否正在编辑
        private void TriggerEditToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CanEdit = TriggerEditToolStripMenuItem.Checked;
        }

        //添加ROI
        private void AddROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ROIEdit RE = new ROIEdit();
                if (RE.ShowDialog(this) == DialogResult.OK)
                {
                    if (CreateFeatureLayer(RE.ROIName))
                    {
                        ROINames.Add(RE.ROIName);
                        ROIColors.Add(RGB2IRgb(RE.ROIColor));
                        ROIDataGridView.Rows.Add("", RE.ROIName, "0");

                        EditingLayer = axMapControl1.get_Layer(ROINames.Count - 1);
                        axTOCControl1.Refresh();
                        TriggerEditToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        throw new Exception("创建要素类失败。");
                    }
                }
                RE.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //删除ROI
        private void ROIDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex < ROIDataGridView.Rows.Count)
                {
                    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(ROIFileNames[e.RowIndex]);
                    IDataset dataSet = featureClass as IDataset;
                    if (dataSet.CanDelete())
                    {
                        dataSet.Delete();
                    }
                    else
                    {
                        throw new Exception("删除数据集出错。");
                    }
                    ROIDataGridView.Rows.RemoveAt(e.RowIndex);
                    ROINames.RemoveAt(e.RowIndex);
                    ROIColors.RemoveAt(e.RowIndex);
                    ROIFileNames.RemoveAt(e.RowIndex);
                    m_mapControl.DeleteLayer(e.RowIndex);
                    axTOCControl1.Refresh();
                    if (ROIDataGridView.Rows.Count < 1)
                    {
                        ChangeEditingIndex(-1);
                    }
                    else if (ROIDataGridView.Rows.Count < EditingIndex + 1)
                    {
                        ChangeEditingIndex(0);
                    }
                }
                else if (e.RowIndex < ROIDataGridView.Rows.Count)
                {
                    ChangeEditingIndex(e.RowIndex);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //绘制
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            try
            {
                if (CanEdit && e.button == 1)
                {
                    if (EditingLayer == null)
                        return;

                    if (!Edit(EditingLayer, EditingIndex))
                    {
                        throw new Exception("编辑失败。");
                    }
                    //object missing = Type.Missing;
                    //IGeometry pGeometry = axMapControl1.TrackPolygon();



                    //pGraphic = axMapControl1.ActiveView as IGraphicsContainer;
                    //pGraphic.AddElement(pElement, 0);
                    //axMapControl1.Refresh();
                }
                if (e.button == 4)
                {
                    axMapControl1.Pan();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //创建要素类
        private bool CreateFeatureLayer(string FName)
        {
            try
            {
                IFields fields = new FieldsClass();
                IFieldsEdit fieldsEdit = (IFieldsEdit)fields;
                fieldsEdit.FieldCount_2 = 2;
                IField fieldUserDefined = new Field();
                IFieldEdit fieldEdit = (IFieldEdit)fieldUserDefined;
                fieldEdit.Name_2 = "FID";
                fieldEdit.AliasName_2 = "OBJECT ID";
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
                fieldsEdit.set_Field(0, fieldUserDefined);

                fieldUserDefined = new Field();
                fieldEdit = (IFieldEdit)fieldUserDefined;

                IGeometryDef geometryDef = new GeometryDefClass();
                IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
                geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                geometryDefEdit.GridCount_2 = 1;
                geometryDefEdit.set_GridSize(0, 0);
                geometryDefEdit.HasM_2 = false;
                geometryDefEdit.HasZ_2 = false;

                if (spatialReference != null)
                {
                    geometryDefEdit.SpatialReference_2 = spatialReference;
                }

                fieldEdit.Name_2 = "SHAPE";
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                fieldEdit.GeometryDef_2 = geometryDef;
                fieldEdit.IsNullable_2 = true;
                fieldEdit.Required_2 = true;
                fieldsEdit.set_Field(1, fieldUserDefined);

                UID CLSID = new UIDClass
                {
                    Value = "esriGeoDatabase.Feature"
                };
                Thread.Sleep(1000);
                string tmpLyrName = DateTime.Now.ToString("yyyyMMddHHmmss");
                IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(tmpLyrName, fields, CLSID, null, esriFeatureType.esriFTSimple, fields.get_Field(1).Name, "");
                ROIFileNames.Add(tmpLyrName);
                IFeatureLayer featureLayer = new FeatureLayerClass();
                featureLayer.FeatureClass = featureClass;
                featureLayer.Name = FName;
                featureLayer.Visible = true;

                ILayerEffects layerEffects = featureLayer as ILayerEffects;
                layerEffects.Transparency = 55;

                m_mapControl.ActiveView.FocusMap.AddLayer(featureLayer);
                m_mapControl.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeography, null, null);

                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        //向图层中添加要素
        private bool Edit(ILayer m_pCurrentLayer, int index)
        {
            try
            {
                IFeatureLayer pFeatureLayer = (IFeatureLayer)m_pCurrentLayer;
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                IDataset pDataset = (IDataset)pFeatureClass;
                if (pDataset == null)
                    throw new ArgumentNullException("数据集为空。");
                IWorkspaceEdit pWorkspaceEdit = (IWorkspaceEdit)pDataset.Workspace;
                pWorkspaceEdit.StartEditOperation();
                IFeature pFeature = pFeatureClass.CreateFeature();
                IGeometry pGeometry = axMapControl1.TrackPolygon();

                ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbol
                {
                    Color = RGB2IRgb(Color.Black),
                    Style = esriSimpleLineStyle.esriSLSSolid
                };
                ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbol
                {
                    Color = ROIColors[index],
                };
                IFillShapeElement pFillElement = new PolygonElementClass
                {
                    Symbol = pSimpleFillSymbol
                };
                IElement pElement;

                pElement = pFillElement as IElement;
                pElement.Geometry = pGeometry;
                pFeature.Shape = pGeometry;
                pFeature.Store();
                pWorkspaceEdit.StopEditOperation();
                ROIFeatureCount[index]++;
                RefreshCount();
                m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, m_pCurrentLayer, pGeometry.Envelope);
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                return false;
            }
        }

        //刷新DataGridView的ROI计数
        private void RefreshCount()
        {
            for (int i = 0; i < ROIFeatureCount.Count; i++)
            {
                ROIDataGridView[2, i].Value = ROIFeatureCount[i].ToString();
            }
        }

        //更改正在编辑的要素图层及索引
        private void ChangeEditingIndex(int index)
        {
            try
            {
                if (index < ROINames.Count)
                    throw new Exception("索引" + index + "不存在。");
                if (index < 0)
                {
                    EditingIndex = -1;
                    EditingLayer = null;
                    return;
                }
                EditingIndex = index;
                EditingLayer = axMapControl1.get_Layer(index);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        //确认并退出
        private void SubmitROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Geoprocessor gp = new Geoprocessor
            {
                OverwriteOutput = true
            };
            try
            {
                for(int i = 0;i<ROIFileNames.Count;i++)
                {
                    Clip clip = new Clip();
                    IEnumLayer enumLayer = axMapControl1.get_Layer(i) as IEnumLayer;
                    clip.in_features = axMapControl1.get_Layer(i) as IFeatureLayer;
                    //clip.out_feature_class = txtOutputPath.Text + "\\" + "clip_" + obj;
                }
                //if (GetFeatureLayer(obj) != null)
                //{
                //    clip.in_features = GetFeatureLayer(obj);
                //    clip.out_feature_class = txtOutputPath.Text + "\\" + "clip_" + obj;
                //}
                //else
                //{
                //    return;
                //}
                //clip.clip_features = clipFeatureClass;
                //clip.cluster_tolerance = tolerance;
                //IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(clip, null);
                //if (results != null)
                //{
                //    if (results.Status != esriJobStatus.esriJobSucceeded)
                //    {
                //        txtMessages.Text += "裁剪要素/层失败: " + obj + "\r\n";
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("裁剪要素问题： " + ex.Message);
            }
        }

        private IRgbColor RGB2IRgb(Color RGBColor)
        {
            IRgbColor rgbColor = new RgbColorClass()
            {
                Red = RGBColor.R,
                Green = RGBColor.G,
                Blue = RGBColor.B,
            };
            return rgbColor;
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }
    }
}