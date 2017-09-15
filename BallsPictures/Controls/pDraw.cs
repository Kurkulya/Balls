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
        public pDraw()
        {
            InitializeComponent();

        }

        private void AddBall(object sender, MouseEventArgs e)
        {
            pBox.Controls.Add(new PictureBall(e.Location));
        }

      
    }
}
