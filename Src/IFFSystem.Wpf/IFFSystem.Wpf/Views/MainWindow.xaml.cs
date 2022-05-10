using Prism.Regions;
using System.Windows;

namespace IFFSystem.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            //注册视图
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainView));//注册Region区域的视图View
        }
    }
}
