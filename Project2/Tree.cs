using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Tree
    {
        public Node Root { get; set; }
        public DPTable DPTable { get; set; }

        public override string ToString()
        {
            return PrintTree(1, DPTable.Count, 0);
        }

        private string PrintTree(int i, int j, int spaceNeeded)
        {
            string str = "";

            if (i <= j)
            {
                str += new string(' ', spaceNeeded) + DPTable[i][j];
                PrintTree(i, DPTable[i][j].ID - 1, spaceNeeded++);
                PrintTree(i, DPTable[i][j].ID + 1, spaceNeeded++);
            }

            return str;
        }
    }
}
