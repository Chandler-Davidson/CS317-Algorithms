using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class DPTable : List<List<Node>>
    {
        public override string ToString()
        {
            var output = "- ";

            for (int i = 1; i < this[0].Count + 1; i++)
                output += " " + i.ToString("00");

            output += "\n";

            for (int i = 0; i < this.Count; i++)
            {
                output += i.ToString("00") + "  ";
                output += string.Join("  ", this[i]) + "\n";
            }

            return output;
        }
    }
}
