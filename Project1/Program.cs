using System;
using System.IO;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read matrix in from file
            var parser = new Parser<double>();
            var matrix1 = parser.ParseFile();
            var matrix2 = parser.ParseFile();

            Console.WriteLine(matrix1);

            // Sort each frow of the matrix
            MatrixSorter.SortRowsIndividually(matrix1);

            Console.WriteLine(matrix1);

            // Write the contents of each matrix to file
            File.WriteAllText("cmd0031_1.txt", matrix1.GenerateReport());
            File.WriteAllText("cmd0031_2.txt", matrix2.GenerateReport());
        }
    }
}
