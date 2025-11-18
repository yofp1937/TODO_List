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

namespace TODO_LIst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Todos todos;
        public MainWindow()
        {
            InitializeComponent();

            todos = new Todos();
            // todos 타겟팅
            DataContext = todos;
        }

        private void OnclickAddTodoBtn(object sender, RoutedEventArgs e)
        {
            TODO todo = new TODO()
            {
                Title = NewTodoTextBox.Text
            };
            todos.AllTodos.Add(todo);
        }
    }
}