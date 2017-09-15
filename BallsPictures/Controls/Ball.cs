using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsPictures.Data
{
    public partial class PictureBall : PictureBox
    {
        public Point Direction { get; set; }
        public Color Color { get; }

        Timer timer = new Timer();

        public PictureBall(Point centr)
        {
            Random rnd = new Random();
            
            Location = centr;
            Direction = new Point(rnd.Next(-10, 10), rnd.Next(-10, 10));
            Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Image = CreateBallImage();
            Width = 60;
            Height = 60;

            MouseClick += new MouseEventHandler(OnClick);

            
            timer.Interval = 5;
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            PictureBox parent = (PictureBox)Parent;

            int difX = Direction.X;
            int difY = Direction.Y;

            if (Location.X <= 0 || Location.X >= parent.Width - 60)
                difX = -difX;
            if (Location.Y <= 0 || Location.Y >= parent.Height - 60)
                difY = -difY;

            Direction = new Point(difX, difY);
            Location = new Point(Location.X + difX, Location.Y + difY);
        }

        private Bitmap CreateBallImage()
        {
            Bitmap RoundedImage = new Bitmap(60, 60);
            using (Graphics g = Graphics.FromImage(RoundedImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(Color), 0, 0, 60, 60);
                return RoundedImage;
            }
        }
    

        private void OnClick(object sender, MouseEventArgs e)
        {
            timer.Stop();
            Dispose();
        }
    }
}
