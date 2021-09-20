using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical2_KochSnowflake
{
    public partial class Form1 : Form
    {
        static Graphics obj;
        static Pen penBlue;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a pen and a drawing area
            penBlue = new Pen(Color.DarkBlue, 2);
            obj = CreateGraphics();
            obj.Clear(Color.White);
            
            //simple triangle with fixed points
            var point1 = new PointF(200, 200);
            var point2 = new PointF(500, 200);
            var point3 = new PointF(350, 400);
            obj.DrawLine(penBlue, point1, point2);
            obj.DrawLine(penBlue, point2, point3);
            obj.DrawLine(penBlue, point3, point1);

            //calling the function
            FractalKoh(point1, point2, point3, 5);
            FractalKoh(point2, point3, point1, 5);
            FractalKoh(point3, point1, point2, 5);
        }

        static int FractalKoh(PointF p1, PointF p2, PointF p3, int iter)
        {
            if (iter > 0)
            {
                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                obj.DrawLine(penBlue, p4, pn);
                obj.DrawLine(penBlue, p5, pn);
                obj.DrawLine(penBlue, p4, p5);

                FractalKoh(p4, pn, p5, iter - 1);
                FractalKoh(pn, p5, p4, iter - 1);
                FractalKoh(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1);
                FractalKoh(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1);
            }
            return iter;
        }
    }
}
