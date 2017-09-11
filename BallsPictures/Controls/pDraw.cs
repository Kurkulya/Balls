using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallsPictures.Data;

namespace BallsPictures.Controls
{
    public partial class pDraw : UserControl
    {
        List<PictureBall> balls = new List<PictureBall>();

        public pDraw()
        {
            InitializeComponent();
            timer.Interval = 1;
        }

        private void AddBall(object sender, MouseEventArgs e)
        {
            if (balls.Count == 0)
                timer.Start();

            balls.Add(new PictureBall(e.Location, pBox.Size));
        }

        private void Update(object sender, EventArgs e)
        {
            foreach (PictureBall ball in balls)
            {
                ball.Translate();
            }
            pBox.Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics grph = e.Graphics;
            foreach (PictureBall ball in balls)
            {
                grph.DrawImage(ball.Image, ball.Center);
            }
        }
     }
}
