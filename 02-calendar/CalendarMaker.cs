using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_calendar
{
    public class CalendarMaker
    {
        DateTime date;
        List<string[]> calendar;
        int countOfDaysInWeek = typeof(DayOfWeek).GetEnumValues().Length;
        public CalendarMaker()
        {
            calendar = new List<string[]>() {new string[countOfDaysInWeek], new string[countOfDaysInWeek]};
        }
        public List<string[]> GetCalendar()
        {
            return calendar;
        }
        public void SetDate(DateTime date)
        {
            this.date = date;
            Init();
        }
        void Init()
        {
            foreach (var day in GetAllDaysOfMounth(date.Year, date.Month))
            {
                var numOfDay = ((int)day.DayOfWeek + countOfDaysInWeek - 1) % countOfDaysInWeek;
                if (calendar[0][numOfDay] == null)
                    calendar[0][numOfDay] = day.DayOfWeek.ToString().Substring(0, 3);
                calendar[calendar.Count - 1][numOfDay] = day.Day == date.Day ? String.Format("[{0}]", date.Day) : day.Day.ToString();
                if (day.DayOfWeek == DayOfWeek.Sunday)
                    calendar.Add(new string[countOfDaysInWeek]);
            }
        }
        static DateTime[] GetAllDaysOfMounth(int year, int month)
        {
            return Enumerable
                .Range(1, DateTime.DaysInMonth(year, month))
                .Select(x => new DateTime(year, month, x))
                .ToArray();
        }
    }
}
