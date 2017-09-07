using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls.Data
{
    class Ball
    {
        public GraphicsPath Path { get; }

        public int Radius { get; }
        public PointF Direction { get; set; }
        public Color Color { get; }
        public PointF Center { get; private set; }

        public Ball(PointF centr, int rad = 10)
        {
            Radius = rad;
            Center = centr;
            Color = GetRandomColor();
            Direction = GetRandomDirection();
            Path = new GraphicsPath();
            Path.AddEllipse(centr.X - rad, centr.Y - rad, 2 * rad, 2 * rad);
        }

        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private PointF GetRandomDirection()
        {
            Random rnd = new Random();
            return new PointF(rnd.Next(0, 500) / 100f, rnd.Next(0, 500) / 100f);
        }

        public void Translate()
        {
            Center = new PointF(Center.X + Direction.X, Center.Y + Direction.Y);

            Matrix translateMatrix = new Matrix();
            translateMatrix.Translate(Direction.X, Direction.Y);
            Path.Transform(translateMatrix);
        }
    }
}
