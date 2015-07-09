using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EllipseDrawingAlgorithm
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(1500, 1500);
        Graphics g;
        // Settings
        int radiusX = 1500 / 2 - 120;
        int radiusY = 1500 / 2 - 370;
        int center = 1500 / 2;
        int angle = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp); //Binding the graphics to the Bitmap
            pictureBox1.Image = bmp;
            RotationTimer.Start();
        }

        private Point EllipseDrawing(int dHalfwidthEllipse, int dHalfheightEllipse, Point origin, int t)
        {
            Point ptfPoint = new Point((int)(origin.X + dHalfwidthEllipse * Math.Cos(t * Math.PI / 180)), (int)(origin.Y + dHalfheightEllipse * Math.Sin(t * Math.PI / 180)));
            return ptfPoint;
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp); //Binding the graphics to the Bitmap

            // g.Clear(Color.White); If you want to clear out the drawing on the previous angle

            // Draw the ellipse
            int x = EllipseDrawing(radiusX, radiusY, new Point(center, center), angle).X; // Find the X Coords
            int y = EllipseDrawing(radiusX, radiusY, new Point(center, center), angle).Y; // Find the Y Coords
            g.FillRectangle(new SolidBrush(Color.DarkBlue), x, y, 10, 10); // Draw rectangles as pixels
            // g.DrawLine(new Pen(Color.DarkBlue, 4f), new Point(center, center), new Point(x, y)); If you want to draw a line from the origin to the point on the ellipse

            pictureBox1.Image = bmp;
            g.Dispose();

            if (angle == 360)
            {
                RotationTimer.Stop();
            }
            else
            {
                angle++;
            }
        }
    }
}
