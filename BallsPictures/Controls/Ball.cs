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
        public Size Owner { get; set; }
        public int Radius { get; }
        public PointF Direction { get; set; }
        public Color Color { get; }
        public PointF Center { get; private set; }

        public PictureBall(PointF centr, Size owner, int rad = 10)
        {
            Radius = rad;
            Center = centr;
            Owner = owner;
            Width = 2 * Radius;
            Height = 2 * Radius;
            Direction = GetRandomDirection();
            Color = GetRandomColor();
            Image = CreateBallImage(Radius);
        }

        private Bitmap CreateBallImage(int CornerRadius)
        {
            Bitmap RoundedImage = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(RoundedImage))
            {
                g.Clear(Color.WhiteSmoke);
                //g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(Color), 0, 0, Width, Height);
                return RoundedImage;
            }
        }
    

        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private PointF GetRandomDirection()
        {
            Random rnd = new Random();
            return new PointF(rnd.Next(-500, 500) / 100f, rnd.Next(-500, 500) / 100f);
        }

        public void Translate()
        {
            float difX = Direction.X;
            float difY = Direction.Y;

            if (Center.X <= 0 || Center.X >= Owner.Width - 2 * Radius)
                difX = -difX;
            if (Center.Y <= 0 || Center.Y >= Owner.Height - 2 * Radius)
                difY = -difY;

            Direction = new PointF(difX, difY);
            Center = new PointF(Center.X + Direction.X, Center.Y + Direction.Y);
        }
    }
}
