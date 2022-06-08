using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using IFFSystem.Wpf.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IFFSystem.Wpf.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
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
            mapControl.Zoom = 8;     //当前缩放
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitMap();
            _vm = this.DataContext as MainViewModel;
        }

        private MainViewModel _vm = null;


        public void CombinedDialogOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {
            CombinedCalendar.SelectedDate = _vm.Date;
            CombinedClock.Time = _vm.Time;
        }

        public void CombinedDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (Convert.ToBoolean(Convert.ToUInt16(eventArgs.Parameter)) && CombinedCalendar.SelectedDate is DateTime selectedDate)
            {
                DateTime combined = selectedDate.AddSeconds(CombinedClock.Time.TimeOfDay.TotalSeconds);
                _vm.Time = combined;
                _vm.Date = combined;
            }
        }


        private void exitRad_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("您确定要退出吗？", "系统提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Application.Current.MainWindow.Close();
        }

       
    }
}
