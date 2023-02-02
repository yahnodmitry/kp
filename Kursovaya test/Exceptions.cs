using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_test
{


    public class MineralNotFoundException : Exception
    {
        public MineralNotFoundException() : base(/*StandartMessage*/) { }
    }
    public class WrongFormatException : Exception
    {
        public WrongFormatException() : base() { }
    }



}
