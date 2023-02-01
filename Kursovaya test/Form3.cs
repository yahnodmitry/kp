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
        string state_n;
        //Form2 form_2;
        int enter = 0;

        public Form3(Mineral min, string state)
        {
            InitializeComponent();
           
            //form_2 = form2;
            state_n = state;
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
                    label1.Text = "Очікуваний прибуток за " + time.ToString() + " рік: " + income.ToString();
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
                    label1.Text = "Очікуваний прибуток до " + time.ToString() + " року: " + income.ToString();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            //form_2.Show();
            Form2 form2 = new Form2(state_n);
            form2.Show();            
            
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            if(enter==0)
            {
                MessageBox.Show("Аби почати розрахунок оберіть потрібний пункт та введіть рік в поле напроти нього.", "Підказка!");
                enter = 1;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            label8.Text = min.Name + ". Статистика";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataOperating.write();
        }
        //public Mineral mineral;
    }

   
}
