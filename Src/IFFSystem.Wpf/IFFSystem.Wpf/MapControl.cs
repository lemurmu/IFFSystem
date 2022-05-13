using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.Projections;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFFSystem.Wpf
{
    public class MapControl : GMapControl
    {


    }

    public abstract class BaiduMapProviderBase : GMapProvider
    {
        public BaiduMapProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://map.baidu.com";
            Copyright = string.Format("©{0} Baidu Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);
        }

        public override GMap.NET.PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }
    }

    public class BaiduMapProvider : BaiduMapProviderBase
    {
        static BaiduMapProvider()
        {
            Instance = new BaiduMapProvider();
        }
        public static readonly BaiduMapProvider Instance;
        readonly Guid id = new Guid("47C1561B-C785-4EBF-9EC3-2CF0E416E219");
        public override GMap.NET.PureImage GetTileImage(GMap.NET.GPoint pos, int zoom)
        {
            try
            {
                string url = MakeTileImageUrl(pos, zoom, LanguageStr);
                return GetTileImageUsingHttp(url);
            }
            catch
            {
                return null;
            }
        }
        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            zoom = zoom - 1;
            var offsetX = Math.Pow(2, zoom);
            var offsetY = offsetX - 1;
            var numX = pos.X - offsetX;
            var numY = -pos.Y + offsetY;
            zoom = zoom + 1;
            var num = (pos.X + pos.Y) % 8 + 1;
            var x = numX.ToString().Replace("-", "M");
            var y = numY.ToString().Replace("-", "M");
            //原来：http://q3.baidu.com/it/u=x=721;y=209;z=12;v=014;type=web&fm=44
            //更新：http://online1.map.bdimg.com/tile/?qt=tile&x=23144&y=6686&z=17&styles=pl
            //string url = string.Format(UrlFormat, num, x, y, zoom, "014", "web", "44"); 
            string url = string.Format(UrlFormat, x, y, zoom);
            return url;
        }
        //static readonly string UrlFormat = "http://q{0}.baidu.com/it/u=x={1};y={2};z={3};v={4};type={5}&fm={6}";
        static readonly string UrlFormat = "http://online1.map.bdimg.com/tile/?qt=tile&x={0}&y={1}&z={2}&styles=pl";
        public override Guid Id
        {
            get { return id; }
        }
        readonly string name = "BaiduMap";
        public override string Name
        {
            get
            {
                return name;
            }
        }
    }


    public abstract class AMapProviderBase : GMapProvider
    {
        public AMapProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://www.amap.com/";
            //Copyright = string.Format("©{0} 高德 Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);    
        }

        public override PureProjection Projection => MercatorProjection.Instance;

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }
    }

    public class AMapProvider : AMapProviderBase
    {
        static Guid id = new Guid("EF3DD303-3F74-4938-BF40-232D1595EE88");
        public override Guid Id => id;
        public override string Name => "AMap";

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            var file = File.ReadAllBytes($@".\tiles\{zoom}\{pos.X}-{pos.Y}.jpg");
            return GetTileImageFromArray(file);
        }
    }
}
