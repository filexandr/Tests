using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task40
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var bmp = new Bitmap(300, 300);
            Task40.DrawCircle(bmp, Color.Red,  150, 150, 50);
            Task40.DrawCircle(bmp, Color.Black,  150, 150, 100);
            Task40.DrawCircle(bmp, Color.Blue,  150, 150, 140);

            //Task40.DrawLine(bmp, Color.Black, 150, 150, 150, 100); // N
            //Task40.DrawLine(bmp, Color.Black, 150, 150, 175, 100); // NNE
            //Task40.DrawLine(bmp, Color.Red, 150, 150, 200, 100); // NE
            //Task40.DrawLine(bmp, Color.Red, 150, 150, 200, 125); // NEE
            //Task40.DrawLine(bmp, Color.Green, 150, 150, 200, 150); // E
            //Task40.DrawLine(bmp, Color.Green, 150, 150, 200, 175); // EES
            //Task40.DrawLine(bmp, Color.Blue, 150, 150, 200, 200); // SE
            //Task40.DrawLine(bmp, Color.Blue, 150, 150, 175, 200); // SSE
            //Task40.DrawLine(bmp, Color.BlueViolet, 150, 150, 150, 200); // S
            //Task40.DrawLine(bmp, Color.BlueViolet, 150, 150, 125, 200); // SSW
            //Task40.DrawLine(bmp, Color.Coral, 150, 150, 100, 200); // SW
            //Task40.DrawLine(bmp, Color.Coral, 150, 150, 100, 175); // SWW
            //Task40.DrawLine(bmp, Color.Crimson, 150, 150, 100, 150); // W
            //Task40.DrawLine(bmp, Color.Crimson, 150, 150, 100, 125); // WWN
            //Task40.DrawLine(bmp, Color.DarkBlue, 150, 150, 125, 100); // NNW
            //Task40.DrawLine(bmp, Color.DarkBlue, 150, 150, 100, 100); // NW

            pbCanvas.Image = bmp;
        }
    }
}
