using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya_test
{
    public partial class Form4 : Form
    {
        DoubleList<Mineral> list;
        //Form2 form_2;
        string state_n;
        double price1;
        double income1;
        double price2;
        double income2;
        double val1, val2;

        Type t1;
        Type t2; 
        Label inc = new Label();
        Label exp = new Label();
        Label inc2 = new Label();
        Label exp2 = new Label();
        Label mineral1 = new Label();
        Label mineral2 = new Label();
        Label value1 = new Label();
        Label value2 = new Label();
        int count = 0;
        public Form4(DoubleList<Mineral> list, string state)
        {
            this.list = list;
            //form_2= form2;
            state_n = state;
            InitializeComponent();
            
            testinput();
        }
        private void testinput()
        {
            
            for (int i = 0; i < 3; i++)
            {

                Label l = new Label();
                Label l2 = new Label();

                l.Name = list.find(i).data.Name;
                l.Text = list.find(i).data.Name;
                l.Location = new Point(10, i * 22);
                l.Size = new Size(200, 20);
                l.Click += label_Click;
                this.Controls.Add(panel1);
                panel1.Controls.Add(l);

                l2.Name = list.find(i).data.Name;
                l2.Text = list.find(i).data.Name;
                l2.Location = new  Point(10, i * 22);
                l2.Size = new Size(200, 20);
                l2.Click += label2_Click;
                this.Controls.Add(panel2);
                panel2.Controls.Add(l2);

            }
            //this.Controls.Add(panel1);
            //this.Controls.Add(panel2);
        }
        private void label_Click(object sender, EventArgs e)
        {
            Mineral m = null;
            string name = (sender as Label).Text;
            Node<Mineral> temporary = list.head;
            while (temporary != null)
            {
                if (temporary.data.Name == name)
                {
                    m = temporary.data;
                    break;
                }
                temporary = temporary.next;
            }
            if (m != null)
            {
                count++;
                panel1.Hide();
                mineral1.Text = m.Name;
                mineral1.Location = new Point(12, 50);
                mineral1.Font = new Font("Times New Roman", 12);
                //mineral1.Size = new Size(200, 22);
                mineral1.AutoSize = true;

                if(m.list == null)
                {
                    count--;
                    value1.Text = "Залежі: " + m.Value.ToString("#.##");
                    value1.Location = new Point(12, 90);
                    value1.Font = new Font("Times New Roman", 12);
                    value1.AutoSize = true;
                    this.Controls.Add(value1);
                }
                else
                {
                    value1.Text = "Залежі: " + m.Value.ToString("#.##");
                    value1.Location = new Point(12, 90);
                    value1.Font = new Font("Times New Roman", 12);
                    value1.AutoSize = true;

                    inc.Text = "Прибуток  : " + m.Income.ToString("#.##");
                    inc.Location = new Point(12, 120);
                    inc.Font = new Font("Times New Roman", 12);
                    //inc.Size = new Size(200, 22);
                    inc.AutoSize = true;
                    exp.Text = "Експорт : " + m.Exp.ToString("#.##");
                    exp.Location = new Point(12, 150);
                    exp.Font = new Font("Times New Roman", 12);
                    exp.AutoSize = true;

                    t1 = m.GetType();

                    //exp.Size = new Size(200, 22);
                    this.Controls.Add(value1);
                    this.Controls.Add(inc);
                    this.Controls.Add(exp);
                    this.Controls.Add(mineral1);
                    price1 = m.Exp;
                    income1 = m.Income;
                    val1 = m.Value;
                }  
            }
            if(count ==2)
            {
                if (price1 > price2)
                {
                    exp.ForeColor = Color.Green;
                    exp2.ForeColor = Color.Red;
                }
                else if (price1 < price2)
                {
                    exp.ForeColor = Color.Red;
                    exp2.ForeColor = Color.Green;
                }
                if (income1>income2)
                {
                    inc.ForeColor = Color.Green;
                    inc.ForeColor = Color.Red;
                }
                else if (income1 < income2)
                {
                    inc.ForeColor = Color.Red;
                    inc2.ForeColor = Color.Green;
                }
                if (t1 != t2)
                {
                    value1.ForeColor = value2.ForeColor = Color.Gray;
                }
                else
                {
                    if (val1 > val2)
                    {
                        value1.ForeColor = Color.Green;
                        value2.ForeColor = Color.Red;
                    }
                    else if (val1 < val2)
                    {
                        value1.ForeColor = Color.Red;
                        value2.ForeColor = Color.Green;
                    }
                }
            }    

            

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Mineral m = null;
            string name = (sender as Label).Text;
            Node<Mineral> temporary = list.head;
            while (temporary != null)
            {
                if (temporary.data.Name == name)
                {
                    m = temporary.data;
                    break;
                }
                temporary = temporary.next;
            }
            if (m != null)
            {
                count++;
                panel2.Hide();
                mineral2.Text = m.Name;
                mineral2.Location = new Point(390, 50);
                mineral2.Font = new Font("Times New Roman", 12);
                mineral2.AutoSize = true;

                if(m.list == null)
                {
                    count--;
                    value2.Text = "Помилка при зчитуванні CSV файлу";
                    value2.Location = new Point(390, 90);
                    value2.Font = new Font("Times New Roman", 12);
                    value2.AutoSize = true;
                    this.Controls.Add(value2);
                }

                else
                {
                    value2.Text = "Залежі: " + m.Value.ToString("#.##");
                    value2.Location = new Point(390, 90);
                    value2.Font = new Font("Times New Roman", 12);
                    value2.AutoSize = true;

                    //mineral2.Size = new Size(200, 22);
                    inc2.Text = "Прибуток : " + m.Income.ToString();
                    inc2.Location = new Point(390, 120);
                    inc2.Font = new Font("Times New Roman", 12);
                    //inc2.Size = new Size(200, 22);
                    inc2.AutoSize = true;
                    exp2.Text = "Експорт : " + m.Exp.ToString();
                    exp2.Location = new Point(390, 150);
                    exp2.Font = new Font("Times New Roman", 12);
                    exp2.AutoSize = true;

                    t2 = m.GetType();
                    //exp2.Size = new Size(200, 22);
                    this.Controls.Add(inc2);
                    this.Controls.Add(exp2);
                    this.Controls.Add(value2);
                    this.Controls.Add(mineral2);
                    price2 = m.Exp;
                    income2 = m.Income;
                    val2 = m.Value;
                }
                

            }
            if (count == 2)
            {
                if (price1 > price2)
                {
                    exp.ForeColor = Color.Green;
                    exp2.ForeColor = Color.Red;
                }
                else if (price1 < price2)
                {
                    exp.ForeColor = Color.Red;
                    exp2.ForeColor = Color.Green;
                }
                if (income1 > income2)
                {
                    inc.ForeColor = Color.Green;
                    inc2.ForeColor = Color.Red;
                }
                else if (income1 < income2)
                {
                    inc.ForeColor = Color.Red;
                    inc2.ForeColor = Color.Green;
                }
                if(t1 != t2)
                {
                    value1.ForeColor = value2.ForeColor = Color.Gray;
                }
                else
                {
                    if (val1 > val2)
                    {
                        value1.ForeColor = Color.Green;
                        value2.ForeColor = Color.Red;
                    }
                    else if (val1 < val2)
                    {
                        value1.ForeColor = Color.Red;
                        value2.ForeColor = Color.Green;
                    }
                }
            }


        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            //form_2.Show();
            Form2 form2 = new Form2(state_n);
            form2.Show();
            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = state_n+". Порівняння";
        }
    }
}
    
