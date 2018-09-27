using System;
using System.IO;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser<double>();
            var matrix = parser.ParseFile();

            Console.WriteLine(matrix);

            MatrixSorter.SortRowsIndividually(matrix);

            Console.WriteLine(matrix);


            File.WriteAllText("cmd0031_1.txt", matrix.GenerateReport());
            File.WriteAllText("cmd0031_2.txt", matrix.GenerateReport());
        }
    }
}
