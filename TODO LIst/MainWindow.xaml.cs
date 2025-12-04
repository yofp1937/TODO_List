/*
 * 사용자가 보는 화면(View)을 담당
 */
using System.Windows;
using System.Windows.Input;
using TODO_List.ViewModel;

namespace TODO_LIst
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mvm;

        public MainWindow()
        {
            InitializeComponent();

            // DataContext 설정
            _mvm = new MainViewModel();
            DataContext = _mvm;
        }

        #region Opacity
        private void Slider_Opacity(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double percent = e.NewValue;              // 0~100
            this.Opacity = percent / 100.0;           // WPF Opacity는 0~1
        }
        #endregion

        #region OnClick
        private void OnClick_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnClick_Maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region MoveWindow
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        #endregion
    }
}