using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Matrix : List<List<double>>
    {
        public static bool operator < (Matrix first, Matrix second)
        {
            throw new NotImplementedException();
        }

        public static bool operator > (Matrix first, Matrix second)
        {
            throw new NotImplementedException();
        }

        public bool Equals (Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static bool operator == (Matrix first, Matrix second)
        {
            throw new NotImplementedException();
        }

        public static bool operator != (Matrix first, Matrix second)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var str = "";
            foreach (var row in this)
            {
                str += string.Join(" ", row) + "\n";
            }

            return str;
        }
    }
}
