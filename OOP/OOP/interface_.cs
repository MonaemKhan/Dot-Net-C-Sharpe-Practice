using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class interface_ : Calcutalor
    {
        public int add(int n1, int n2)
        {
            return n1+n2;
        }

        public int sub(int n1, int n2)
        {
            return n1-n2;
        }

        public virtual int total()
        {
            return 60000;
        }
    }
}
