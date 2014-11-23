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
        public CalendarMaker(DateTime date)
        {
            this.date = date;
            calendar = new List<string[]>() {new string[countOfDaysInWeek], new string[countOfDaysInWeek]};
        }
        public List<string[]> GetCalendar()
        {
            Init();
            return calendar;
        }
        void Init()
        {
            foreach (var day in GetAllDaysOfMounth())
            {
                var numOfDay = ((int)day.DayOfWeek + countOfDaysInWeek - 1) % countOfDaysInWeek;
                if (calendar[0][numOfDay] == null)
                    calendar[0][numOfDay] = new string(day.DayOfWeek.ToString().Take(3).ToArray());
                calendar[calendar.Count - 1][numOfDay] = day.Day == date.Day ? String.Format("[{0}]", date.Day) : day.Day.ToString();
                if (day.DayOfWeek == DayOfWeek.Sunday)
                    calendar.Add(new string[countOfDaysInWeek]);
            }
        }
        DateTime[] GetAllDaysOfMounth()
        {
            return Enumerable
                .Range(1, DateTime.DaysInMonth(date.Year, date.Month))
                .Select(x => new DateTime(date.Year, date.Month, x))
                .ToArray();
        }
    }
}
