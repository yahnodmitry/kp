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
            //Lst_struct lst_s = new Lst_struct();
            DoubleList<Yearly> lst_s = new DoubleList<Yearly>();
            Yearly year2021;
            year2021.year = 2021;            
            year2021.value = 1000;
            year2021.income = 3000;
            year2021.exp = 15;

            Yearly year2020;
            year2020.year = 2020;
            year2020.value = 1500;
            year2020.income = 4000;
            year2020.exp = 10;

            Yearly year2019;
            year2019.year = 2019;
            year2019.value = 1200;
            year2019.income = 3500;
            year2019.exp = 20;

            lst_s.add(year2019);
            lst_s.add(year2020);
            lst_s.add(year2021);

            Solid ugol = new Solid(lst_s, "ugol", 100000);

            //Lst_struct lst2 = new Lst_struct();
            DoubleList<Yearly> lst2 = new DoubleList<Yearly>();
            year2021.year = 2021;
            year2021.value = 2000;
            year2021.income = 4000;
            year2021.exp = 25;

            year2020.year = 2020;
            year2020.value = 2500;
            year2020.income = 5000;
            year2020.exp = 20;

            year2019.year = 2019;
            year2019.value = 2200;
            year2019.income = 4500;
            year2019.exp = 30;

            lst2.add(year2019);
            lst2.add(year2020);
            lst2.add(year2021);

            Liquid neft = new Liquid(lst2, "neft", 200000);

            //Lst_struct lst3 = new Lst_struct();
            DoubleList<Yearly> lst3 = new DoubleList<Yearly>();
            year2021.year = 2021;
            year2021.value = 3000;
            year2021.income = 5000;
            year2021.exp = 35;

            year2020.year = 2020;
            year2020.value = 3500;
            year2020.income = 6000;
            year2020.exp = 30;

            year2019.year = 2019;
            year2019.value = 3200;
            year2019.income = 5500;
            year2019.exp = 40;

            lst3.add(year2019);
            lst3.add(year2020);
            lst3.add(year2021);

            Gas gas = new Gas(lst3, "gas", 300000);

            lst.add(ugol);
            lst.add(neft);
            lst.add(gas);
            

            //minerals_list.Items.Add(lst.find(0));

            //minerals_list.Items.Add(neft.Name);
            //minerals_list.Items.Add(gas.Name);
            //Label label1 = new Label()
            //{
            //    Text = ugol.Name,
            //    Location = new Point(10, 10),
            //    TabIndex = 11
            //};
            //Label label2 = new Label()
            //{
            //    Text = neft.Name,
            //    Location = new Point(10, 20),
            //    TabIndex = 12
            //};
            //Label label3 = new Label()
            //{
            //    Text = gas.Name,
            //    Location = new Point(10, 30),
            //    TabIndex = 13
            //};
            //this.Controls.Add(label1);
            //panel1.Controls.Add(label1);
            //this.Controls.Add(label2);
            //panel1.Controls.Add(label2);
            //this.Controls.Add(label3);

            //panel1.Controls.Add(label3);
            for (int i = 0; i < 3; i++)
            {
                
                Label l = new Label();
                l.Name= lst.find(i).data.Name;
                l.Text = lst.find(i).data.Name; 
                l.Location = new Point(10, i * 22);
                l.Size = new Size(40, 20);
                l.Click += label_Click;
                this.Controls.Add(panel1);
                panel1.Controls.Add(l);

            }



        }
        private void label_Click(object sender, EventArgs e)
        {
            Mineral m = null;
            string name = (sender as Label).Text;
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
                Form3 form3 = new Form3(m, this);
                form3.Show();
                this.Hide();
            }

        }
        //private void label_Click(object sender, EventArgs e)
        //{
        //    for(int i = 0; i < 3; i++)
        //    {
        //        if(l )
        //    }
        //    Form3 form3 = new Form3
        //}

        private void minerals_list_Click(object sender, EventArgs e)
        { 
            //Mineral  m = minerals_list.Items.;
            //Form3 form3 = new Form3(m);
            ////this.Hide();
            //form3.Show();
        }

        private void Comparison_btn_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(lst, this);
            form4.Show();
            this.Hide();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();         
            Form1 form1 = new Form1();
            form1.Show();

        }
    }
}
