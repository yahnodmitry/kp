﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_test
{
    public class StringIsEmptyException : Exception
    {
        public StringIsEmptyException(): base (StandartMessage ) { }
        static string StandartMessage = "Зчитана строка порожня";
        public StringIsEmptyException(string message) : base(message) { }
    }

    

}