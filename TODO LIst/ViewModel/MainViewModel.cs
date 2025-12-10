/*
 * 화면에 표시될 Data를 담당
 */
using System.Windows.Input;
using TODO_List.Model;

namespace TODO_List.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Property
        public CalendarViewModel CalendarVM { get; private set; }
        public TodoViewModel TodoVM { get; private set; }

        // MainTitleBar에 존재하는 버튼들은 MainViewModel에서 관리
        public ICommand? PreviousMonthCommand { get; private set; }
        public ICommand? NextMonthCommand { get; private set; }
        public ICommand? CalendarChangeCommand { get; private set; }
        public ICommand? OpenAddScheduleCommand { get; private set; }
        public ICommand? OpenAddRoutineCommand { get; private set; }
        #endregion

        #region 생성자, override
        public MainViewModel()
        {
            // UI 동적 생성
            CalendarVM = new CalendarViewModel();
        }

        protected override void RegisterICommands()
        {
            PreviousMonthCommand = new RelayCommand(_ => CalendarVM.CurrentMonth = CalendarVM.CurrentMonth.AddMonths(-1));
            NextMonthCommand = new RelayCommand(_ => CalendarVM.CurrentMonth = CalendarVM.CurrentMonth.AddMonths(1));
            CalendarChangeCommand = new RelayCommand(_ => { }); // 달력 클릭 처리

            OpenAddScheduleCommand = new RelayCommand(OpenAddScheduleExecute); // 일정 추가 처리
            OpenAddRoutineCommand = new RelayCommand(OpenAddRoutineExecute); // 규칙 추가 처리
        }
        #endregion

        // 임시
        private void OpenAddScheduleExecute(object obj)
        {
            var todoVM = new TodoViewModel(false);
            // TODO: AddTodoWindow 생성 및 DataContext 설정 후 ShowDialog() 호출
        }

        private void OpenAddRoutineExecute(object obj)
        {
            var todoVM = new TodoViewModel(true);
            // TODO: AddTodoWindow 생성 및 DataContext 설정 후 ShowDialog() 호출
        }
    }
}
