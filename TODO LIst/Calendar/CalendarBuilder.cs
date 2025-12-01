/*
 * 기능
 * 메인 UI에 달력을 자동으로 생성해주는 클래스
 */
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TODO_List.Calendar
{
    class CalendarBuilder
    {
        private Grid _calendarGrid;

        public CalendarBuilder(Grid dateGrid, Grid calendarGrid)
        {
            CreateDayoftheWeekLine(dateGrid);
            _calendarGrid = calendarGrid;
        }

        // 달력 최상단에 일요일 ~ 토요일 표시해주는 행 한줄 생성
        private void CreateDayoftheWeekLine(Grid grid)
        {
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            for (int col = 0; col <= 6; col++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Border cell = new Border()
                {
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5, 0, 0, 5),
                    Padding = new Thickness(5),
                    BorderBrush = new SolidColorBrush(Colors.Black)
                };
                TextBlock tb = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    TextAlignment = TextAlignment.Center,
                    FontSize = 15,
                    FontWeight = FontWeights.Bold,
                    Text = days[col]
                };

                // 요일 색상 적용
                if (col == 0)
                {
                    // 일요일
                    cell.BorderBrush = new SolidColorBrush(Colors.Crimson);
                    tb.Foreground = Brushes.Crimson;
                }
                if (col == 6)
                {
                    // 토요일
                    cell.BorderBrush = new SolidColorBrush(Colors.Blue);
                    tb.Foreground = Brushes.Blue;
                }
                cell.Child = tb;
                Grid.SetColumn(cell, col);
                grid.Children.Add(cell);
            }
        }

        public void CreateCalendar(DateTime targetMonth)
        {
            DateTime firstDay = new DateTime(targetMonth.Year, targetMonth.Month, 1);

            int startOffset = (int)firstDay.DayOfWeek; // 0: 일요일 ~ 6: 토요일
            int daysInMonth = DateTime.DaysInMonth(targetMonth.Year, targetMonth.Month);
            int dayNumber = 1;
            int weekCount = (startOffset + daysInMonth + 6) / 7; // 해당 월이 총 몇주인지 계산

            ConfigureCalendarRowsAndColumns(weekCount);

            for (int row = 0; row < weekCount; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Border cell = new Border()
                    {
                        BorderThickness = new Thickness(1),
                        Margin = new Thickness(5, 0, 0, 5),
                        Padding = new Thickness(5),
                        BorderBrush = new SolidColorBrush(Colors.Black)
                    };
                    TextBlock tb = new TextBlock()
                    {
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 15
                    };

                    int cellIndex = row * 7 + col;
                    if (cellIndex >= startOffset && dayNumber <= daysInMonth)
                    {
                        DateTime date = new DateTime(targetMonth.Year, targetMonth.Month, dayNumber);
                        tb.Text = dayNumber.ToString();

                        // 요일별 색상
                        if (col == 0) // 일요일
                        {
                            tb.Foreground = Brushes.Crimson;
                            cell.BorderBrush = Brushes.Crimson;
                        }
                        else if (col == 6) // 토요일
                        {
                            tb.Foreground = Brushes.Blue;
                            cell.BorderBrush = Brushes.Blue;
                        }

                        // 공휴일 적용
                        if (HolidayProvider.IsHoliday(date))
                        {
                            tb.Foreground = Brushes.Red;
                            cell.BorderBrush = Brushes.Red;
                        }

                        // 오늘 날짜 강조
                        if (date == DateTime.Today)
                        {
                            cell.BorderThickness = new Thickness(3);
                            tb.FontWeight = FontWeights.Bold;
                        }

                        dayNumber++;
                    }
                    else
                    {
                        tb.Text = "test";
                        tb.Foreground = Brushes.Gray;
                        cell.BorderBrush = Brushes.Gray;
                    }
                    cell.Child = tb;

                    Grid.SetRow(cell, row);
                    Grid.SetColumn(cell, col);

                    _calendarGrid.Children.Add(cell);
                }
            }
        }

        // 동적으로 캘린더의 RowDefinitions와 ColumnDefinitions를 생성하는 메서드
        private void ConfigureCalendarRowsAndColumns(int weekCount)
        {
            _calendarGrid.Children.Clear();
            _calendarGrid.RowDefinitions.Clear();
            _calendarGrid.ColumnDefinitions.Clear();

            // 7열(요일)
            for(int row = 0; row < 7; row++)
                _calendarGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // weekCount만큼 행 생성
            for (int col = 0; col < weekCount; col++)
                _calendarGrid.RowDefinitions.Add(new RowDefinition());
        }

    }
}
