using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    public static class MatrixSorter
    {
        /// <summary>
        /// Sorts the rows individually.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void SortingMethod2<T>(Matrix<T> matrix)
            where T : IComparable<T>
        {
            matrix.ForEach(x => QuickSort(matrix, x, 0, x.Count - 1));
            var columnSortedMatrix = new Matrix<T>();

            for (int i = 0; i < matrix[0].Count; i++)
            {
                var column = matrix.Select(x => x.ElementAt(i)).ToList();
                QuickSort(matrix, column, 0, column.Count()-1);
            }

            matrix.SortingMethod = "Method 2";
        }

        public static void SortingMethod1<T>(Matrix<T> matrix)
            where T : IComparable<T>
        {
            var flattenedMatrix = matrix.SelectMany(x => x).ToList();
            QuickSort(matrix, flattenedMatrix, 0, flattenedMatrix.Count - 1);

            int rowLength = matrix[0].Count;
            int colLength = matrix.Count;
            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    var a = i * rowLength + j;
                    matrix[i][j] = flattenedMatrix[a];
                }
            }

            matrix.SortingMethod = "Method 1";
        }

        /// <summary>
        /// Partitions the specified row from low to high.
        /// </summary>
        /// <returns>The partition index.</returns>
        /// <param name="matrix">Matrix.</param>
        /// <param name="row">Row.</param>
        /// <param name="low">Low.</param>
        /// <param name="high">High.</param>
        private static int Partition<T>(Matrix<T> matrix, List<T> row, int low, int high)
            where T : IComparable<T>
        {
            T pivot = row[high];

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (matrix.CompareElements(LessThanOrEqual, row[j], pivot))
                {
                    i++;

                    T a = row[i], b = row[j];
                    matrix.SwapElements(ref a, ref b);
                    row[i] = a; row[j] = b;
                }
            }

            T aa = row[i + 1], bb = row[high];
            matrix.SwapElements(ref aa, ref bb);
            row[i + 1] = aa; row[high] = bb;

            return i + 1;
        }

        /// <summary>
        /// Quicks the sort.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        /// <param name="row">Row.</param>
        /// <param name="low">Low.</param>
        /// <param name="high">High.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private static void QuickSort<T>(Matrix<T> matrix, List<T> row, int low, int high)
            where T : IComparable<T>
        {
            if (low < high)
            {
                int partition = Partition(matrix, row, low, high);

                QuickSort(matrix, row, low, partition - 1);
                QuickSort(matrix, row, partition + 1, high);
            }
        }

        /// <summary>
        /// Assigns the first element with the second's value.
        /// </summary>
        /// <param name="first">The element to assign to.</param>
        /// <param name="second">The element to duplicate the value of.</param>
        public static void AssignElement<T>(this Matrix<T> matrix, ref T first, T second)
            where T : IComparable<T>
        {
            // Track number of assignments made
            matrix.AssignmentCount += 1;

            first = second;
        }

        /// <summary>
        /// Swaps the elements within a matrix.
        /// </summary>
        /// <param name="first">First element.</param>
        /// <param name="second">Second element.</param>
        public static void SwapElements<T>(this Matrix<T> matrix, ref T first, ref T second)
            where T : IComparable<T>
        {
            // Temp variable as an intermediate
            var temp = default(T);
            matrix.AssignElement(ref temp, first);

            matrix.AssignElement(ref first, second);

            matrix.AssignElement(ref second, temp);
        }

        /// <summary>
        /// Compares two elements using the given comparison.
        /// </summary>
        /// <returns>The result of the comparison.</returns>
        /// <param name="operation">Comparison method.</param>
        /// <param name="first">First element.</param>
        /// <param name="second">Second element.</param>
        public static bool CompareElements<T>(this Matrix<T> matrix, Func<T, T, bool> operation, T first, T second) 
            where T : IComparable<T>
        {
            // Track number of comparisions made
            matrix.ComparisonCount += 1;

            return operation(first, second);
        }

        private static bool LessThan<T>(T first, T second)
            where T : IComparable<T>
        {
            return first.CompareTo(second) < 0;
        }

        private static bool GreaterThan<T>(T first, T second)
            where T : IComparable<T>
        {
            return first.CompareTo(second) > 0;
        }

        private static bool EqualTo<T>(T first, T second) 
            where T : IComparable<T>
        {
            return first.CompareTo(second) == 0;
        }

        private static bool LessThanOrEqual<T>(T first, T second) 
            where T : IComparable<T>
        {
            return LessThan(first, second) || EqualTo(first, second);
        }

        private static bool GreaterThanOrEqual<T>(T first, T second) 
            where T : IComparable<T>
        {
            return GreaterThan(first, second) || EqualTo(first, second);
        }
    }
}
