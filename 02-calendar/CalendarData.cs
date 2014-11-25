using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_calendar
{
    public class CalendarData
    {
        public readonly string[] namesDays;
        public readonly List<int[]> weeks;
        public readonly int currentDay;
        public CalendarData(List<string[]> calendar, int curDay)
        {
            namesDays = calendar[0];
            weeks = calendar
                .Skip(1)
                .Select(week => week
                    .Select(day => day == null ? 0 : int.Parse(day))
                    .ToArray())
                .ToList();
            currentDay = curDay;
        }
    }
}
