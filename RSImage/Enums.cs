using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RSImage
{
    /// <summary>
    /// 影像拉伸模式枚举常量。
    /// </summary>
    public enum StretchModes
    {
        [Description("无拉伸")]
        No_stretch = 0,
        [Description("线性拉伸")]
        Linear = 1,
        [Description("1%线性拉伸")]
        Linear_1 = 2,
        [Description("2%线性拉伸")]
        Linear_2 = 3,
        [Description("5%线性拉伸")]
        Linear_5 = 4,
        [Description("直方图均衡化")]
        Equalization = 5,
        [Description("高斯（开发中）")]
        Gaussion = 6,
        [Description("平方根拉伸")]
        SquareRoot = 7,
        [Description("对数拉伸（有小bug）")]
        Logarithmic = 8,
        [Description("自定义线性拉伸（开发中）")]
        CustomLinear = 9,
    }

    /// <summary>
    /// 程序（GDAL）支持的文件类型枚举常量。
    /// </summary>
    public enum SupportedFileType
    {
        [Description("All Files|*.*")]
        All,
        [Description("Arc/Info ASCII Grid|*.asc; *.txt")]
        Arc_Info_ASCII_Grid,
        [Description("AutoCAD DWG raster layer|*.dwg")]
        AutoCAD_DWG_raster_layer,
        [Description("DPPDB|*.ntf")]
        DPPDB,
        [Description("DTED|*.dt0; *.dt1; *.dt2")]
        DTED,
        [Description("ENVI Annotation|*.ann; *.anz")]
        ENVI_Annotation,
        [Description("ENVI Raster|*.dat; *.img")]
        ENVI_Raster,
        [Description("ENVI Vector|*.evf")]
        ENVI_Vector,
        [Description("ERDAS|*.ige; *.img")]
        ERDAS,
        [Description("Esri grid|*.hdr; *.adf")]
        Esri_grid,
        [Description("GeoPackcge|*.gpkg; *.gpkx")]
        GeoPackcge,
        [Description("GIF|*.gif")]
        GIF,
        [Description("GRIB|*.grb; *.grb2; *.grib; *.grib2")]
        GRIB,
        [Description("HDF4|*.hdf")]
        HDF4,
        [Description("HDF5/NetCDF4|*.h5; *.hdf5; *.he5; *.nc")]
        HDF5_NetCDF4,
        [Description("JPEG|*.jpg; *.jpeg")]
        JPEG,
        [Description("JPEG2000|*.jp2; *.j2k")]
        JPEG2000,
        [Description("LiDAR|*.ini; *.las; *.laz")]
        LiDAR,
        [Description("MetaData|*.cat; *.dim; *.met; *.pvl; *.txt; *.xml")]
        MetaData,
        [Description("MrSID|*.sid")]
        MrSID,
        [Description("NITF and NSIF|*.ntf; *.nitf; *.nsf")]
        NITF_and_NSIF,
        [Description("PNG|*.png")]
        PNG,
        [Description("Region of Interest|*.roi; *.xml")]
        Region_of_Interest,
        [Description("Shapefile|*.shp")]
        Shapefile,
        [Description("Spectral Library|*.asd; *.msl; *.rad; *.sli")]
        Spectral_Library,
        [Description("TFRD|*.tfd; *.isd")]
        TFRD,
        [Description("TIFF|*.tif; *.tiff")]
        TIFF,
        [Description("Tiled Mosaic|*.til")]
        Tiled_Mosaic,
    }

    /// <summary>
    /// 平滑锐化方法枚举常量。
    /// </summary>
    public enum SmoothShapeninngMethods
    {
        [Description("（平滑）孤点噪声")]
        Smooth_SolitaryNoise,
        [Description("（平滑）行噪声")]
        Smooth_LineNoise,
        [Description("（平滑）列噪声")]
        Smooth_ColumnNoise,
        [Description("（平滑）中值滤波")]
        Smooth_MedianFiltering,
        [Description("（锐化）Prewitt算子")]
        Sharpening_PrewittOperator,
        [Description("（锐化）Sobel梯度")]
        Sharpening_SobelGradient,
        [Description("（锐化）4邻域Laplace算子")]
        Shrpening_LaplaceOperator4,
        [Description("（锐化）8邻域Laplace算子")]
        Shrpening_LaplaceOperator8,
        [Description("（锐化）方向算子")]
        Shrpening_DirectionOperator,
    }

    /// <summary>
    /// 图像分割方法枚举常量。
    /// </summary>
    public enum ImageSplitMethods
    {
        [Description("手动阈值")]
        Manual_None,
        [Description("最大类间方差法（Otsu）")]
        Auto_Otsu,
        [Description("迭代阈值法")]
        Auto_Iterate,
    }
}
