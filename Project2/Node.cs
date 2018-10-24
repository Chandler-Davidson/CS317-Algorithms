using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Node
    {
        public readonly int Probability;
        public readonly int ID;

        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int probability, int ID)
        {
            this.Probability = probability;
            this.ID = ID;
        }

        public override string ToString()
        {
            return this.ID.ToString();
        }
    }
}
