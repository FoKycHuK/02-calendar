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

        public CalendarData(int curDay, string[] namesDays, List<int[]> weeks)
        {
            this.namesDays = namesDays;
            this.weeks = weeks;
            currentDay = curDay;
        }
    }
}
