using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_calendar
{
    public class Calendar : Form
    {
        List<string[]> calendar;
        int size = 500;
        public Calendar(CalendarData calendar)
        {
            Size = new Size(size, (int)(size));
            var handleCalendar = calendar.weeks;
            handleCalendar.Insert(0, calendar.namesOfWeekDays);
            this.calendar = handleCalendar;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            for (var column = 0; column < calendar.Count; column++)
            {
                for (var raw = 0; raw < calendar[column].Length; raw++)
                {
                    var day = calendar[column][raw];
                    var point = new Point(
                            (size / (int)(calendar[0].Length + 1)) * raw + size / calendar[0].Length / 2,
                            (size / (int)(calendar.Count + 1)) * column + size / calendar.Count / 2);
                    if (day != null && day[0] == '[')
                    {
                        e.Graphics.FillEllipse(
                            Brushes.Aqua,
                            new Rectangle(
                                new Point(
                                    point.X - size / calendar[0].Length / 2,
                                    point.Y - size / calendar.Count / 2),
                                new Size(
                                    size / calendar[0].Length,
                                    size / calendar.Count)));
                        day = day.Substring(1, day.Length - 2);
                    }
                    e.Graphics.DrawString(
                        day,
                        new Font("Arial", size / 30),
                        Brushes.Black,
                        point,
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }
        }
    }
}
