using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_test
{
    public partial class Form3 : Form
    {
        Mineral min;
        double avalue;
        double aprice;

        public Form3(Mineral min)
        {
            InitializeComponent();
            this.min = min;
            Node<Yearly> temp = min.list.head;
            double sumvalue = 0, sumprice = 0;
            while (temp != null)
            {
                chart1.Series[0].Points.AddXY(temp.data.year, temp.data.income);
                chart2.Series[0].Points.AddXY(temp.data.year, temp.data.value);
                chart3.Series[0].Points.AddXY(temp.data.year, temp.data.exp);
                sumvalue += temp.data.value;
                sumprice += temp.data.income / temp.data.value;
                temp = temp.next;
            }
            this.avalue = sumvalue/min.list.size;
            this.aprice = sumprice / min.list.size;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                int time = int.Parse(textBox1.Text) - min.list.tail.data.year;

                double value = min.Value;
                double income = 0;
                while(value > 0)
                {
                    if (min.Value > this.avalue)
                    {
                        income += this.aprice * this.avalue;
                        value -= this.avalue;
                    }
                    else
                    {
                        income += this.aprice * value;
                        value -= this.avalue;
                    }
                    label1.Text = time.ToString() + " | " + income.ToString();
                }
                
            }
            else if (radioButton2.Checked == true)
            {
                int time = int.Parse(textBox2.Text);

                double value = min.Value;
                double income = 0;
                while (value > 0)
                {
                    if (min.Value > this.avalue)
                    {
                        income += this.aprice * this.avalue;
                        value -= this.avalue;
                    }
                    else
                    {
                        income += this.aprice * value;
                        value -= this.avalue;
                    }
                    label1.Text = time.ToString() + " | " + income.ToString();
                }
            }
        }
        //public Mineral mineral;
    }

   
}
