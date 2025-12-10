/*
 * 공휴일 지정해놓는 클래스
 */
namespace TODO_List.Model
{
    public static class HolidayProvider
    {
        #region Property
        // 필요한 만큼 공휴일 추가하면 됨
        public static HashSet<DateTime> Holidays { get; private set; }
        #endregion

        #region 생성자
        static HolidayProvider()
        {
            Holidays = new HashSet<DateTime>()
            {
                new DateTime(2025, 1, 1), // 새해
                new DateTime(2025, 3, 1), // 삼일절
                new DateTime(2025, 5, 5), // 어린이날
                new DateTime(2025, 8, 15), // 광복절
                new DateTime(2025, 10, 3), // 개천절
                new DateTime(2025, 12, 25), // 크리스마스
            };
        }
        #endregion

        #region 메서드
        public static bool IsHoliday(DateTime date)
        {
            return Holidays.Contains(date);
        }
        #endregion
    }
}
