/*
 * 할 일 데이터 모델
 */
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TODO_List.Model.DataClass
{
    public class TodoItem : INotifyPropertyChanged
    {
        #region Property
        // JSON의 Key 역할을 할 고유 ID
        public Guid Id { get; set; } = Guid.NewGuid();
        // 할 일 내용
        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
        // 완료 여부
        private bool _isCompeleted;
        public bool IsCompleted
        {
            get => _isCompeleted;
            set
            {
                _isCompeleted = value;
                OnPropertyChanged();
            }
        }
        // 규칙인지 일정인지 확인 (JSON 객체 타입 결정용)
        public bool IsRoutine { get; set; } = false;
        // 날짜 저장
        public DateTime DueDate { get; set; }
        // 생성 시각
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region OnPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
