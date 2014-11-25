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
        List<int[]> calendar;
        string[] namesDays;
        int curDay;
        int size = 500;

        public Calendar(CalendarData calendar)
        {
            Size = new Size(size, (int)(size));
            this.calendar = calendar.weeks;
            DoubleBuffered = true;
            namesDays = calendar.namesDays;
            curDay = calendar.currentDay;
            Invalidate();
            using (var bitmap = new Bitmap(size, size))
            {
                DrawToBitmap(bitmap, new Rectangle(0, 0, size, size));
                bitmap.Save("my.png");
            }
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (var column = 0; column < namesDays.Length; column++)
            {
                var point = new Point(
                    (size / calendar[0].Length + 1) * column + size / calendar[0].Length / 2,
                    size / calendar.Count / 2);
                e.Graphics.DrawString(
                        namesDays[column].ToString(),
                        new Font("Arial", size / 30),
                        Brushes.Blue,
                        point,
                        new StringFormat() { 
                            Alignment = StringAlignment.Center, 
                            LineAlignment = StringAlignment.Center });
            }
            for (var row = 0; row < calendar.Count; row++)
            {
                for (var column = 0; column < calendar[row].Length; column++)
                {
                    var day = calendar[row][column];
                    if (day == 0)
                        continue;
                    var point = new Point(
                            (size / calendar[0].Length) * column + size / calendar[0].Length / 2,
                            (size / (calendar.Count + 1)) * row + size / calendar.Count);
                    if (day == curDay)
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
                    }
                    e.Graphics.DrawString(
                        day.ToString(),
                        new Font("Arial", size / 30),
                        Brushes.Black,
                        point,
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
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
