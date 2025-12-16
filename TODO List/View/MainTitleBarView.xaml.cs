using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace TODO_List.View
{
    public partial class MainTitleBarView
    {
        public MainTitleBarView()
        {
            InitializeComponent();
        }

        private Window GetMainWindow()
        {
            return Window.GetWindow(this);
        }

        #region MoveWindow
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = GetMainWindow();
            if (window != null && e.LeftButton == MouseButtonState.Pressed)
            {
                window.DragMove();
            }
        }
        #endregion
    }
}
