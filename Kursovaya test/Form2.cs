using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kursovaya_test
{
    
    public partial class Form2 : Form
    {
        int enter = 0;
        private string state = "";
        private DoubleList<Mineral> lst;
        public Form2(string state)
        {
            InitializeComponent();
            this.state = state;
            lst = new DoubleList<Mineral>();

            testinput();
            
        }

        private void testinput()
        {
            DataOperating.countryName = this.state;
            DataOperating.list = this.lst;
            DataOperating.jsonDeserialization(/*lst*/);
            
            if(lst.size == 0)
            {
                Label l = new Label();
                l.Name = "Error";
                l.Text = "Помилка зчитування даних";
                l.Location = new Point(10, 0);
                l.Size = new Size(150, 20);
                this.Controls.Add(panel1);
                panel1.Controls.Add(l);
            }
            else
            {
                output();
            }
            

        }

        private void output()
        {
            int p = 0;
            for (int i = 0; i < lst.size; i++)
            {

                

                if(Search.Text != "")
                {
                    if(!lst.find(i).data.Name.ToUpper().Contains(Search.Text.ToUpper()))
                    {
                        continue;
                    }
                }

                    Label l = new Label();
                    l.Name = lst.find(i).data.Name;
                    l.Text = lst.find(i).data.Name + '\n';
                    if (lst.find(i).data.list != null)
                    {
                        l.Text += "Залишок: " + lst.find(i).data.Value.ToString("#.##") + ", "
                        + "Ср. прибуток: " + lst.find(i).data.Income.ToString("#.##") + ", " +
                        "Ср. експорт: " + lst.find(i).data.Exp.ToString("#.##");
                    }
                    else
                    {
                        l.Text += "Помилка при зчитуванні CSV файлу";
                    }
                    l.Location = new Point(10, p * 50);
                //l.Size = new Size(150, 20);
                    l.AutoSize = true;
                    l.Click += label_Click;
                    this.Controls.Add(panel1);
                    panel1.Controls.Add(l);
                    p++; 
            }
        }
        private void label_Click(object sender, EventArgs e)
        {
            Mineral m = null;
            string name = (sender as Label).Text.Substring(0, (sender as Label).Text.IndexOf('\n'));
            Node<Mineral> temporary = lst.head;
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
                Form3 form3 = new Form3(m, state);
                form3.Show();
                this.Hide();
            }

        }


        private void Comparison_btn_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(lst, state);
            form4.Show();
            this.Hide();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();        
            Form1 form1 = new Form1();
            form1.Show();

        }

        private void sort_button_Click(object sender, EventArgs e)
        {
            BinaryHeap sorting = new BinaryHeap();
            if(Profit_sort.Checked == true)
            {
                sorting.sortByIncome(lst);
            }
            else if(Export_sort.Checked == true)
            {
                sorting.sortByExp(lst);
            }
            else
            {
                MessageBox.Show("Оберіть критерій сортування");
            }
            panel1.Controls.Clear();
            output();
        }

        private void Form2_MouseEnter(object sender, EventArgs e)
        {
            if(enter==0)
            {
                MessageBox.Show("Натисність на назву копалини щоб пепрейти до статистики.", "Підказка!");
                enter = 1;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = state + ". Cписок копалин";
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            if(lst.size != null)
            {
                panel1.Controls.Clear();
                output();
            }
        }
    }
}
