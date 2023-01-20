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
    public partial class Form4 : Form
    {
        DoubleList<Mineral> list;
        public Form4(DoubleList<Mineral> list)
        {
            this.list = list;
            InitializeComponent();
        }
    }
}
