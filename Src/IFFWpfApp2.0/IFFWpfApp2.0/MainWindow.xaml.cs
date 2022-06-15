using GMap.NET;
using GMap.NET.WindowsPresentation;
using HandyControl.Controls;
using IFFSystem.Wpf;
using System.Windows;
using System.Windows.Input;

namespace HandyControlWpfApp
{
    public partial class MainWindow : GlowWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            InitMap();
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Growl.Success("文件保存成功！");
        }

        private void RadioButton_Checked_1(object sender, System.Windows.RoutedEventArgs e)
        {
            Growl.Warning("电脑磁盘空间不足！");
        }

        private void InitMap()
        {
            //try
            //{
            //    System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("ditu.google.cn");
            //}
            //catch
            //{
            //    mapControl.Manager.Mode = AccessMode.CacheOnly;
            //    MessageBox.Show("No internet connection avaible, going to CacheOnly mode.", "GMap.NET Demo", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            mapControl.Manager.Mode = AccessMode.ServerOnly;
            mapControl.MapProvider = AMapProvider.Instance;
            mapControl.MinZoom = 1;  //最小缩放
            mapControl.MaxZoom = 15; //最大缩放 
            mapControl.Zoom = 12;     //当前缩放
            mapControl.ShowCenter = false; //不显示中心十字点
            mapControl.DragButton = MouseButton.Left; //左键拖拽地图
            mapControl.Position = new PointLatLng(30.659462, 104.065735); //地图中心位置：成都

            mapControl.MouseLeftButtonDown += new MouseButtonEventHandler(mapControl_MouseLeftButtonDown);
        }

        void mapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(mapControl);
            PointLatLng point = mapControl.FromLocalToLatLng((int)clickPoint.X, (int)clickPoint.Y);
            GMapMarker marker = new GMapMarker(point);
            mapControl.Markers.Add(marker);
        }
    }
}
