using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            var freq = File.ReadAllLines("input.txt").Skip(1)
                .Select(x => Int32.Parse(x)).ToList();

            var table = new DPTable(freq);

            Console.WriteLine(table);
        }
    }
}
