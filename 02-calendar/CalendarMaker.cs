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
        string[] namesDays;
        List<int[]> weeks;
        readonly int countOfDaysInWeek = typeof(DayOfWeek).GetEnumValues().Length;

        public CalendarMaker()
        {
            namesDays = new string[countOfDaysInWeek];
            InitDaysNames();
        }

        public CalendarData GetCalendar()
        {
            return new CalendarData(date.Day, namesDays, weeks);
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
            weeks = new List<int[]>() { new int[countOfDaysInWeek] };
            Init();
        }

        void InitDaysNames()
        {
            foreach (var nameDay in typeof(DayOfWeek).GetEnumValues())
            {
                var numOfDay = ((int)nameDay + countOfDaysInWeek - 1) % countOfDaysInWeek;
                namesDays[numOfDay] = nameDay.ToString().Substring(0, 3);
            }
        }
        void Init()
        {
            foreach (var day in GetAllDaysOfMounth(date.Year, date.Month))
            {
                var numOfDay = ((int)day.DayOfWeek + countOfDaysInWeek - 1) % countOfDaysInWeek;
                weeks[weeks.Count - 1][numOfDay] = day.Day;
                if (day.DayOfWeek == DayOfWeek.Sunday)
                    weeks.Add(new int[countOfDaysInWeek]);
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
