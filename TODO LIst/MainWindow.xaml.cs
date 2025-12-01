using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TODO_List.Calendar;

namespace TODO_LIst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalendarBuilder _calendarBuilder;
        private DateTime _currentMonth;

        public MainWindow()
        {
            InitializeComponent();

            _calendarBuilder = new CalendarBuilder(DateGrid, CalendarGrid);
            _currentMonth = DateTime.Today;
            _calendarBuilder.CreateCalendar(_currentMonth);
        }

        #region MoveWindow
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        #endregion

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

        private void OnClick_PreviousMonth(object sender, RoutedEventArgs e)
        {

        }

        private void OnClick_Calneder(object sender, RoutedEventArgs e)
        {

        }

        private void OnClick_NextMonth(object sender, RoutedEventArgs e)
        {

        }
    }
}