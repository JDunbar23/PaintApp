using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        
        // set the variables
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;


        public Form1()
        {
            InitializeComponent();

            g = panel1.CreateGraphics();

            pen = new Pen(Color.Black, 3); // set default line colour and size

            // smooth out the drawed lines
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        // function dealing with the colour picture boxes being clicked
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            // when a picture box is clicked it will send its back colour value to the pen
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        // function dealing with the left mouse being clicked
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            moving = true;
            x = e.X;
            y = e.Y;
        }

        // function dealing with the mouse moving
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if(moving && x != -1 && y != -1) // if the mouse is clicked
            {

                // draw line depending on location
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        // function dealing with mouse not being clicked
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            moving = false;
            x = -1;
            y = -1;
        }
    }
}
