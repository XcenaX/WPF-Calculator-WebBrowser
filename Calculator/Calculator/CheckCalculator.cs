using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CheckCalculator
    {
        public static bool Check(string str)
        {
            const string tmp = ",";
            if (str.Contains(tmp))
                return true;
            return false;
        }

    }
}
