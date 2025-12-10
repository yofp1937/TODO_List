/*
 * 캘린더 UI 동적 생성용 데이터 클래스
 */

namespace TODO_List.Model.DataClass
{
    public class CalendarDay
    {
        public int DayNumber { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsCurrentMonth { get; set; }
        public bool IsToday { get; set; }
        public bool IsHoliday { get; set; }
    }
}
