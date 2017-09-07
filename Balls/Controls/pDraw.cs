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

namespace Balls.Controls
{
    public partial class pDraw : UserControl
    {
        List<Ball> balls = new List<Ball>();

        public pDraw()
        {
            InitializeComponent();
            timer.Interval = 5;
        }

        private void AddBall(object sender, MouseEventArgs e)
        {
            if (balls.Count == 0)
                timer.Start();

            balls.Add(new Ball(e.Location));
        }

        private void Update(object sender, EventArgs e)
        {
            foreach (Ball ball in balls)
            {
                ball.Direction = EvaluateDirection(ball);
                ball.Translate();               
            }
            pBox.Invalidate();
        }

        private PointF EvaluateDirection(Ball ball)
        {
            float difX = ball.Direction.X;
            float difY = ball.Direction.Y;

            if (ball.Center.X <= ball.Radius || ball.Center.X >= pBox.Width - ball.Radius)
                difX = -difX;
            if (ball.Center.Y <= ball.Radius || ball.Center.Y >= pBox.Height - ball.Radius)
                difY = -difY;

            return new PointF(difX, difY);
        }

        private void ReDraw(object sender, PaintEventArgs e)
        {
            Graphics grph = e.Graphics; 
            foreach(Ball ball in balls)
            {
                grph.FillPath(new SolidBrush(ball.Color), ball.Path);
            }
        }
    }
}
