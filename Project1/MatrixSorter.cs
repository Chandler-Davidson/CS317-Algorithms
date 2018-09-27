using System;
using System.Collections.Generic;

namespace Project1
{
    public static class MatrixSorter
    {
        /// <summary>
        /// Sorts the rows individually.
        /// </summary>
        /// <param name="matrix">Matrix.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void SortRowsIndividually<T>(Matrix<T> matrix)
            where T : IComparable<T>
        {
            matrix.ForEach(x => matrix.SortRow(x, 0, x.Count - 1));
        }

        private static void SortRow<T>(this Matrix<T> matrix, List<T> row, int left, int right)
            where T : IComparable<T>
        {
            int i = left, j = right;
            var pivotValue = row[(left + right) / 2];

            while (i <= j)
            {
                while (matrix.CompareElements(LessThan, row[i], pivotValue))
                {
                    i++;
                }

                while (matrix.CompareElements(GreaterThan, row[j], pivotValue))
                {
                    j--;
                }

                if (i <= j)
                {
                    T a = row[i], b = row[j];
                    matrix.SwapElements(ref a, ref b);
                    row[i] = a; row[j] = b;

                    i++;
                    j--;
                }
            }

            if (left < j)
                matrix.SortRow(row, left, j);
            if (i < right)
                matrix.SortRow(row, i, right);
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
