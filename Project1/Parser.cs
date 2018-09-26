using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Parser<T> where T : IComparable<T>
    {
        public string FilePath { get; set; } = "input.txt";

        /// <summary>
        /// Parses the input file given by the <see cref="T:Project1.FilePath`1"/> property.
        /// </summary>
        /// <returns>The file.</returns>
        public Matrix<T> ParseFile()
        {
            try 
            {
                var fileLines = File.ReadAllLines(FilePath);
                var matrix = new Matrix<T>();

                matrix.AddRange(fileLines.Skip(1)
                    .Select(x => x.Split(' ')
                        .Select(y => (T)Convert.ChangeType(y, typeof(T))).ToList()));

                return matrix;
            }

            catch(System.FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return new Matrix<T>();
        }
    }
}
