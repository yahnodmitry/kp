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
        Form2 form_2;
        public Form4(DoubleList<Mineral> list, Form2 form2)
        {
            this.list = list;
            form_2= form2;
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
                l.Size = new Size(100, 20);
                l.Click += label_Click;
                this.Controls.Add(panel1);
                panel1.Controls.Add(l);

                l2.Name = list.find(i).data.Name;
                l2.Text = list.find(i).data.Name;
                l2.Location = new  Point(10, i * 22);
                l2.Size = new Size(100, 20);
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
                panel1.Hide();
                Label inc = new Label();
                Label exp = new Label();
                inc.Text = "Прибуток :"+m.Income.ToString();
                inc.Location = new Point(10, 35);
                inc.Font = new Font("Times New Roman", 12);
                inc.Size = new Size(200, 20);
                exp.Text = "Ціна :"+ m.Exp.ToString();
                exp.Location = new Point(10, 57);
                exp.Font = new Font("Times New Roman", 12);
                exp.Size = new Size(200, 20);
                this.Controls.Add(inc);
                this.Controls.Add(exp);
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
                panel2.Hide();
                Label inc2 = new Label();
                Label exp2 = new Label();
                inc2.Text ="Прибуток :"+ m.Income.ToString();
                inc2.Location = new Point(390, 35);
                inc2.Font = new Font("Times New Roman", 12);
                inc2.Size = new Size(200, 20);
                exp2.Text ="Ціна :"+ m.Exp.ToString();
                exp2.Location = new Point(390, 57);
                exp2.Font = new Font("Times New Roman", 12);
                exp2.Size = new Size(200, 20);
                this.Controls.Add(inc2);
                this.Controls.Add(exp2);
            }
            

        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_2.Show();
            
        }
        
    }
}
    
