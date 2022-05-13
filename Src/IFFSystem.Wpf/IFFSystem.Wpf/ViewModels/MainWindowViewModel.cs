using Prism.Mvvm;

namespace IFFSystem.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "敌我信号侦收识别系统";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }


    }
}
