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
        CalendarData calendar;
        int size = 500;

        public Calendar(CalendarData calendar)
        {
            Size = new Size(size + 30, (int)(size));
            this.calendar = calendar;
            DoubleBuffered = true;
            Invalidate();
            using (var bitmap = new Bitmap(size, size))
            {
                DrawToBitmap(bitmap, new Rectangle(0, 0, size, size));
                bitmap.Save("my.png");
            }
            
        }

        void DrawCalendarPart(object text, Point point, bool isNameDay, Graphics graphics)
        {
            graphics.DrawString(
                text.ToString(), 
                new Font("Arial", isNameDay ? size / 25 : size / 30),
                isNameDay ? Brushes.Blue : Brushes.Black,
                point,
                new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
        }

        void PrintLine(IEnumerable<object> text, int y, bool isNameDay, Graphics graphics)
        {
            var array = text.ToArray();
            for (var row = 0; row < text.Count(); row++)
            {
                var point = new Point(size / calendar.weeks[0].Length * row + size / calendar.weeks[0].Length / 2, y);
                DrawCalendarPart(array[row].ToString(), point, isNameDay, graphics);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PrintLine(calendar.namesDays, size / calendar.weeks.Count / 2, true, e.Graphics);
            for (var row = 0; row < calendar.weeks.Count; row++)
                for (var column = 0; column < calendar.weeks[row].Length; column++)
                {
                    var day = calendar.weeks[row][column];
                    if (day == 0)
                        continue;
                    var point = new Point(
                            (size / calendar.weeks[0].Length) * column + size / calendar.weeks[0].Length / 2,
                            (size / (calendar.weeks.Count + 1)) * row + size / calendar.weeks.Count);
                    if (day == calendar.currentDay)
                        e.Graphics.FillEllipse(
                            Brushes.Aqua,
                            new Rectangle(
                                new Point(
                                    point.X - size / calendar.weeks[0].Length / 2,
                                    point.Y - size / calendar.weeks.Count / 2),
                                new Size(
                                    size / calendar.weeks[0].Length,
                                    size / calendar.weeks.Count)));
                    DrawCalendarPart(day, point, false, e.Graphics);
                }            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            size = Math.Min(Size.Height, Size.Width);
            Invalidate();
        }
    }
}
