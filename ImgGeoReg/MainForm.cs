using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;

namespace ImgGeoReg
{
    public sealed partial class MainForm : Form
    {
        private IMapControl3 m_mapControl = null;
        private IActiveView activeView;
        private IToolbarMenu LayerMenu = new ToolbarMenuClass();
        private string BaseMap, TopMap;
        //private string SavePath;
        private bool Exported = false;
        private bool IsAddingPoint = false;
        private bool AddingToPoint = false;
        private IPointCollection fromPoint = new MultipointClass();
        private IPointCollection toPoint= new MultipointClass();
        IRasterLayer topRasterLayer = new RasterLayerClass();
        IRasterLayer baseRasterLayer = new RasterLayerClass();
        IGeoReference geoReference;
        IRgbColor redColor = new RgbColorClass() { Red=255,Green=0,Blue=0};
        IRgbColor greenColor = new RgbColorClass() { Red=0,Green=255,Blue=0};
        IRgbColor blackColor = new RgbColorClass() { Red = 0, Green = 0, Blue = 0 };

        ITool panTool = new ControlsMapPanToolClass();

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string BaseMap, string TopMap)
        {
            InitializeComponent();
            this.BaseMap = BaseMap;
            this.TopMap = TopMap;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            activeView = m_mapControl.ActiveView;
            LayerMenu.SetHook(m_mapControl);
            LayerMenu.AddItem(new ZoomToLayer(), 0, 0, false, esriCommandStyles.esriCommandStyleIconAndText);

            //打开两张影像。
            if(BaseMap!=null&&TopMap!=null)
            {
                topRasterLayer.CreateFromFilePath(TopMap);
                axMapControl1.AddLayer(topRasterLayer, 0);
                baseRasterLayer.CreateFromFilePath(BaseMap);
                axMapControl1.AddLayer(baseRasterLayer,1);
                geoReference = topRasterLayer as IGeoReference;
                this.Text = "正在配准：" + System.IO.Path.GetFileName(TopMap) + " -> " + System.IO.Path.GetFileName(BaseMap);
                TransparencyLabel.Text = "顶层透明度：" + TransparencyTrackBar.Value.ToString() + "%";
            }          
        }

        //缩放到图层
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;

                //Hittest
                axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

                //选择物件
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    axTOCControl1.SelectItem(layer, null);
                    axMapControl1.CustomProperty = layer;
                    LayerMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                    axTOCControl1.Update();
                }
            }
        }

        //指示是否可添加控制点
        private void AddPointButton_CheckedChanged(object sender, EventArgs e)
        {
            if (AddPointButton.Checked)
            {
                IsAddingPoint = true;
            }
            else
            {
                IsAddingPoint = false;
            }
        }

        //添加控制点
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if(IsAddingPoint&&e.button==1)
            {
                if (!AddingToPoint)
                {
                    IPoint fromP = new PointClass();
                    fromP.PutCoords(e.mapX, e.mapY);
                    fromPoint.AddPoint(fromP);
                    DrawPoints();
                    AddingToPoint = true;
                    ApplyButton.Enabled = false;
                }
                else
                {
                    IPoint toP = new PointClass();
                    toP.PutCoords(e.mapX, e.mapY);
                    toPoint.AddPoint(toP);
                    DrawPoints();
                    AddingToPoint = false;
                    ApplyButton.Enabled = true;
                    AddPoint();
                }
            }
            if(e.button==4)
            {
                axMapControl1.Pan();
            }
        }

        //向DataGridView中添加点对
        private void AddPoint()
        {
            PointsDataGridView.Rows.Clear();
            for (int i = 0; i < fromPoint.PointCount; i++)
            {
                PointsDataGridView.Rows.Add("删除", fromPoint.Point[i].X.ToString(), fromPoint.Point[i].Y.ToString(), toPoint.Point[i].X.ToString(), toPoint.Point[i].Y.ToString());
            }
            //Register();
        }

        //删除点对
        private void PointsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex < PointsDataGridView.Rows.Count)
            {
                PointsDataGridView.Rows.RemoveAt(e.RowIndex);
                fromPoint.RemovePoints(e.RowIndex, 1);
                toPoint.RemovePoints(e.RowIndex, 1);
                AddPoint();
                //Register();
                activeView.Refresh();
                DrawPoints();
            }
        }

        //更改图层透明度
        private void TransparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            ILayerEffects eff = (m_mapControl.Layer[0] as ILayer) as ILayerEffects;
            eff.Transparency = (short)TransparencyTrackBar.Value;
            TransparencyLabel.Text = "顶层透明度：" + TransparencyTrackBar.Value.ToString()+"%";
            activeView.Refresh();
        }


        #region 绘制操作
        //绘制控制点
        private void DrawPoints()
        {
            int fCount = fromPoint.PointCount;
            int tCount = toPoint.PointCount;
            for(int i = 0;i<fCount;i++)
            {
                DrawPoint(activeView, fromPoint.Point[i],true);
            }
            for(int i = 0;i<tCount; i++)
            {
                DrawPoint(activeView, toPoint.Point[i], false);
                DrawLine(activeView, fromPoint.Point[i], toPoint.Point[i]);
            }
        }

        //重绘点对和连接线
        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            DrawPoints();
        }

        //绘制单个点操作
        public void DrawPoint(IActiveView activeView, IPoint p, bool red)
        {
            if (activeView == null)
                return;

            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache);
            ESRI.ArcGIS.Display.ISimpleMarkerSymbol simpleMarkerSymbol = new ESRI.ArcGIS.Display.SimpleMarkerSymbolClass();
            simpleMarkerSymbol.Style = ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCross;
            simpleMarkerSymbol.Size = 15;
            if (red)
            {
                simpleMarkerSymbol.Color = redColor;
            }
            else
            {
                simpleMarkerSymbol.Color = greenColor;
            }

            ESRI.ArcGIS.Display.ISymbol symbol = simpleMarkerSymbol as ESRI.ArcGIS.Display.ISymbol; // Dynamic cast.
            screenDisplay.SetSymbol(symbol);
            ESRI.ArcGIS.Display.IDisplayTransformation displayTransformation = screenDisplay.DisplayTransformation;
            screenDisplay.DrawPoint(p);
            screenDisplay.FinishDrawing();
        }

        //绘制线操作
        public void DrawLine(IActiveView activeView, IPoint fromP,IPoint toP)
        {
            if (activeView == null)
            {
                return;
            }
            IPolyline polyline = new PolylineClass();
            polyline.FromPoint = fromP;
            polyline.ToPoint = toP;
            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = activeView.ScreenDisplay;
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache);
            ILineSymbol lineSymbol = new SimpleLineSymbolClass();
            lineSymbol.Color = blackColor;
            lineSymbol.Width = 1;
            ESRI.ArcGIS.Display.ISymbol symbol = lineSymbol as ESRI.ArcGIS.Display.ISymbol; // Dynamic cast.
            screenDisplay.SetSymbol(symbol);
            ESRI.ArcGIS.Display.IDisplayTransformation displayTransformation = screenDisplay.DisplayTransformation;
            IGeometry pGeo = polyline;
            screenDisplay.DrawPolyline(pGeo);
            screenDisplay.FinishDrawing();
        }
        #endregion

        //配准按钮
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Register();
        }

        //配准但不Register
        private void Register()
        {
            geoReference.Reset();
            if (toPoint.PointCount > 0)
            {
                if (toPoint.PointCount == 1)
                {
                    geoReference.Shift(toPoint.Point[0].X - fromPoint.Point[0].X, toPoint.Point[0].Y - fromPoint.Point[0].Y);
                }
                if (toPoint.PointCount == 2)
                {
                    geoReference.TwoPointsAdjust(fromPoint, toPoint);
                }
                if (toPoint.PointCount >= 3)
                {
                    geoReference.Warp(fromPoint, toPoint, 1);
                }
            }
            axMapControl1.Refresh();
        }

        //重置配准预览
        private void ResetReferenceButton_Click(object sender, EventArgs e)
        {
            geoReference.Reset();
            axMapControl1.Refresh();
            DrawPoints();
        }

        //删除所有点并重置配准
        private void ResetWarpButton_Click(object sender, EventArgs e)
        {
            geoReference.Reset();
            fromPoint.RemovePoints(0, fromPoint.PointCount);
            toPoint.RemovePoints(0, toPoint.PointCount);
            PointsDataGridView.Rows.Clear();
            axMapControl1.Refresh();
            DrawPoints();
        }

        //保存配准后影像
        private void SaveResultButton_Click(object sender, EventArgs e)
        {
            //if (System.IO.File.Exists(SavePath))
            //    System.IO.File.Delete(SavePath);
            geoReference.Register();
            //IWorkspaceFactory workspaceFac = new RasterWorkspaceFactory();
            //IWorkspace rasterWorkspace = workspaceFac.OpenFromFile(System.IO.Path.GetDirectoryName(SavePath), 0);

            //IRasterLayerExport3 exportLayer = new RasterLayerExportClass();

            //exportLayer.RasterLayer = topRasterLayer;
            //exportLayer.Extent = topRasterLayer.AreaOfInterest;
            //exportLayer.Force2RGB = false;

            //IRasterStorageDef rsd = new RasterStorageDef();
            //rsd.CompressionType = esriRasterCompressionType.esriRasterCompressionUncompressed;
            //exportLayer.StorageDef = rsd;

            //exportLayer.Export(rasterWorkspace, System.IO.Path.GetFileName(SavePath), "TIFF");
            Environment.Exit(1);
        }

        private void AboutButton_ButtonClick(object sender, EventArgs e)
        {
            AboutImgGeoReg AIG = new AboutImgGeoReg();
            AIG.ShowDialog();
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }
    }
}