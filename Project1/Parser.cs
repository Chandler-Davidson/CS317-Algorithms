using System;
using System.IO;
using System.Linq;

namespace Project1
{
    class Parser<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the file path for the input file.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; } = "input.txt";

        private readonly string[] FileLines;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser{T}"/> class.
        /// </summary>
        public Parser()
        {
            FileLines = File.ReadAllLines(FilePath);
        }
        /// <summary>
        /// Parses the input file given by the <see cref="T:Project1.FilePath`1"/> property.
        /// </summary>
        /// <returns>The matrix generated from file.</returns>
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

            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return new Matrix<T>();
        }
    }
}
