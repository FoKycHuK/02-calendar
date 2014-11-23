using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_calendar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var message = Console.ReadLine();
            try
            {
                DateTime.Parse(message);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Неверная дата");
                Environment.Exit(1);
            }
            var calendar = new CalendarMaker(DateTime.Parse(message)).GetCalendar();
            foreach (var value in calendar)
            {
                foreach (var value1 in value)
                {
                    Console.Write(value1 + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
