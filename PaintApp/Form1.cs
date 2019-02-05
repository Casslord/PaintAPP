using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PaintApp
{
    public partial class Form1 : Form
    {
            bool draw = false;

            ColorDialog MyDialog = new ColorDialog();

            int pX = -1;
            int pY = -1;

            Bitmap drawing;


            public Form1()
        {
            InitializeComponent();

            drawing = new Bitmap(panel1.Width, panel1.Height, panel1.CreateGraphics());
            Graphics.FromImage(drawing).Clear(Color.White);
        }

        protected void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                Graphics panel = Graphics.FromImage(drawing);

                Pen pen = new Pen(MyDialog.Color, 14); // Färg och storlek

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.Round;

                panel.DrawLine(pen, pX, pY, e.X, e.Y);

                panel1.CreateGraphics().DrawImageUnscaled(drawing, new Point(0, 0));
            }

            pX = e.X;
            pY = e.Y;
        }

            private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;

            pX = e.X;
            pY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(drawing, new Point(0, 0));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 14);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Blue, 14);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = textBox1.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                textBox1.ForeColor = MyDialog.Color;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
