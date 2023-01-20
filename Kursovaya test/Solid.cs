using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_test
{
    internal class Mass : Mineral
    {
        private double mass;
        public override double Value { get { return mass; } }
    }
}
