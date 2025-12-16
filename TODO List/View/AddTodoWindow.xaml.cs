using System.Diagnostics;
using System.Windows;
using TODO_List.ViewModel;

namespace TODO_List.View
{
    public partial class AddTodoWindow : Window

    {
        public AddTodoWindow(TodoViewModel todoVM)
        {
            InitializeComponent();

            this.DataContext = todoVM;
        }
    }
}
