using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Parser
    {
        public string FilePath { get; set; } = "input.txt";

        public Matrix ParseFile()
        {
            var fileLines = File.ReadAllLines(FilePath);
            var matrix = new Matrix();

            matrix.AddRange(fileLines.Skip(1)
                .Select(x => x.Split(' ').Select(y => double.Parse(y)).ToList()));

            return matrix;
        }
    }
}
