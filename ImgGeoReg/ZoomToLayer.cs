// Copyright 2010 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at &lt;your ArcGIS install location&gt;/DeveloperKit10.0/userestrictions.txt.
// 

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System.Drawing;
using System;

namespace ImgGeoReg
{
	public sealed class ZoomToLayer : BaseCommand  
	{
		private IMapControl3 m_mapControl;

		public ZoomToLayer()
		{
			base.m_caption = "缩放到图层";
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }

        }

        public override void OnClick()
		{
			ILayer layer = (ILayer) m_mapControl.CustomProperty;
			m_mapControl.Extent = layer.AreaOfInterest;
		}
	
		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
		}
	}
}

