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
            
        }
    }
}
