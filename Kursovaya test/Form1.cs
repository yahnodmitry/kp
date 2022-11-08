using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }
        int width, height;
        int x, y;


        void control_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pctr = sender as PictureBox;
            if(pctr!=null)
            {
                width = pctr.Width;
                height = pctr.Height;
                x = pctr.Location.X;
                y = pctr.Location.Y;
                pctr.Size = new Size(width + 30, height + 30);
                pctr.Location = new Point(x - 15, y - 15);
            }
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pctr = sender as PictureBox;
            if (pctr != null)
            {
                width = pctr.Width - 30;
                height = pctr.Height - 30;
                x = pctr.Location.X + 15;
                y = pctr.Location.Y + 15;
                pctr.Size = new Size(width, height);
                pctr.Location = new Point(x, y);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Information 1");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 2");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 3");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 4");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 5");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 6");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 7");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 8");
        }   

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 9");
        } 

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Information 10");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseEnter += control_MouseEnter;
            pictureBox2.MouseEnter += control_MouseEnter;
            pictureBox3.MouseEnter += control_MouseEnter;
            pictureBox4.MouseEnter += control_MouseEnter;
            pictureBox5.MouseEnter += control_MouseEnter;
            pictureBox6.MouseEnter += control_MouseEnter;
            pictureBox7.MouseEnter += control_MouseEnter;
            pictureBox8.MouseEnter += control_MouseEnter;
            pictureBox9.MouseEnter += control_MouseEnter;
            pictureBox10.MouseEnter += control_MouseEnter;
            pictureBox1.MouseLeave += control_MouseLeave;
            pictureBox2.MouseLeave += control_MouseLeave;
            pictureBox3.MouseLeave += control_MouseLeave;
            pictureBox4.MouseLeave += control_MouseLeave;
            pictureBox5.MouseLeave += control_MouseLeave;
            pictureBox6.MouseLeave += control_MouseLeave;
            pictureBox7.MouseLeave += control_MouseLeave;
            pictureBox8.MouseLeave += control_MouseLeave;
            pictureBox9.MouseLeave += control_MouseLeave;
            pictureBox10.MouseLeave += control_MouseLeave; 
        }

    }
}
