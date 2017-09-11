﻿using System;
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
            timer.Interval = 1;
        }

        private void AddBall(object sender, MouseEventArgs e)
        {
            if (balls.Count == 0)
                timer.Start();

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
    }
}
