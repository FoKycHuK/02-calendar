using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        static void Main(string[] args)
        {
            var message = "";
            message = args.Length == 0 ? Console.ReadLine() : args[0];
            try
            {
                DateTime.Parse(message);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Неверная дата");
                Environment.Exit(1);
            }
            var maker = new CalendarMaker();
            maker.SetDate(DateTime.Parse(message));
            var calendar = maker.GetCalendar();
            //foreach (var value in calendar)
            //{
            //    foreach (var value1 in value)
            //    {
            //        Console.Write(value1 + "\t");
            //    }
            //    Console.WriteLine();
            //}
            Application.Run(new Calendar(calendar));
            Thread.Sleep(3000);
            maker.SetDate(DateTime.Parse("06.06.2014"));
            Application.Run(new Calendar(maker.GetCalendar()));
        }
    }
}
