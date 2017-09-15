using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Balls.Data;
using System.Drawing.Drawing2D;

namespace Balls.Controls
{
    public partial class pDraw : UserControl
    {
        List<Ball> balls = new List<Ball>();

        public pDraw()
        {
            InitializeComponent();
            timer.Interval = 1;
        }

        private void AddBall(object sender, MouseEventArgs e)
        {
            if (balls.Count == 0)
                timer.Start();

            if(IsPointInsideRegion(e.Location) != true)
                balls.Add(new Ball(e.Location, pBox.Size));
        }

        private void Update(object sender, EventArgs e)
        {
            foreach (Ball ball in balls)
            {
                ball.Translate();               
            }
            pBox.Invalidate();
        }


        private void ReDraw(object sender, PaintEventArgs e)
        {
            Graphics grph = e.Graphics; 
            foreach(Ball ball in balls)
            {
                grph.FillPath(new SolidBrush(ball.Color), ball.Path);
            }
        }

        private bool IsPointInsideRegion(Point aim)
        {
            Graphics g = Graphics.FromImage(new Bitmap(100, 100));
            GraphicsPath path;
            Region pathRegion;
            foreach (Ball b in balls)
            {
                path = b.Path;
                pathRegion = new Region(path); 
                if (pathRegion.IsVisible(aim, g))
                {
                    balls.Remove(b);
                    return true;
                }                
            }
            return false;
        }
    }
}
