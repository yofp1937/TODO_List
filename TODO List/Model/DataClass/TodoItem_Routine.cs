/*
 * 규칙 데이터 모델
 */
using TODO_List.Model.Enum;

namespace TODO_List.Model.DataClass
{
    public class TodoItem_Routine : TodoItem
    {
        #region Property
        // 반복 주기
        public RootineType RootineType { get; set; }
        // 매주 반복일 경우 어떤 요일에 반복할지
        public DayOfWeek? Weekly_DayOfWeek { get; set; }
        // 매달 반복일 경우 며칠에 반복할지
        public int? Monthly_Date { get; set; }
        // 반복 종료 날짜
        public DateTime? EndDate { get; set; }
        #endregion

        public TodoItem_Routine()
        {
            IsRoutine = true;
        }
    }
}
