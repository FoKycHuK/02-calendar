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
        readonly string[] namesDays;
        CalendarData data;
        readonly int countOfDaysInWeek = typeof(DayOfWeek).GetEnumValues().Length;

        public CalendarMaker()
        {
            namesDays = BuildDaysNames();
        }

        public CalendarData GetCalendar()
        {
            return data;
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
            data = new CalendarData(date.Day, namesDays, BuildCalendarWeeks());
        }

        string[] BuildDaysNames()
        {
            var names = new string[countOfDaysInWeek];
            foreach (var nameDay in typeof(DayOfWeek).GetEnumValues())
            {
                var numOfDay = ((int)nameDay + countOfDaysInWeek - 1) % countOfDaysInWeek;
                names[numOfDay] = nameDay.ToString().Substring(0, 3);
            }
            return names;
        }
        List<int[]> BuildCalendarWeeks()
        {
            var weeks = new List<int[]>() { new int[countOfDaysInWeek] };
            foreach (var day in GetAllDaysOfMounth(date.Year, date.Month))
            {
                var numOfDay = ((int)day.DayOfWeek + countOfDaysInWeek - 1) % countOfDaysInWeek;
                weeks[weeks.Count - 1][numOfDay] = day.Day;
                if (day.DayOfWeek == DayOfWeek.Sunday)
                    weeks.Add(new int[countOfDaysInWeek]);
            }
            return weeks;
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
