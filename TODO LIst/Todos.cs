using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TODO_LIst
{
    public class Todos : INotifyPropertyChanged
    {
        private ObservableCollection<TODO> _allTodos;
        public ObservableCollection<TODO> AllTodos
        {
            get { return _allTodos; }
            set
            {
                _allTodos = value;
                OnPropertyChange(nameof(AllTodos));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Todos() // 생성자에서 기본 할일 부여
        {
            _allTodos = new ObservableCollection<TODO>()
            {
                new TODO() { Title =  "쓰레기를 버리세요." },
                new TODO() { Title = "개에게 밥을 주세요.", IsDone = true }
            };
        }

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
