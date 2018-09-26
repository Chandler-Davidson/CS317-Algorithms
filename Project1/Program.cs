using System;
using System.IO;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parser<double>();
            var matrix = p.ParseFile();

            Console.WriteLine(matrix);

            matrix.SortRowsIndividually();

            Console.WriteLine(matrix);


            File.WriteAllText("cmd0031_1.txt", matrix.GenerateReport());
            File.WriteAllText("cmd0031_2.txt", matrix.GenerateReport());
        }
    }
}
