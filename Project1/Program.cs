using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parser<double>();
            var matrix = p.ParseFile();

            Console.WriteLine(string.Join(" ", matrix[0]));

            matrix.Quicksort(matrix[0], 0, matrix[0].Count - 1);

            Console.WriteLine(string.Join(" ", matrix[0]));
        }
    }
}
