using System;
using System.Collections.Generic;

namespace Project1
{
    public static partial class MatrixSorter
    {
        private static int AssignmentCount;
        private static int ComparisonCount;

        /// <summary>
        /// Sorts the matrix using the given sorting method.
        /// </summary>
        /// <typeparam name="T">The data type contained in the matrix.</typeparam>
        /// <param name="sortingMethod">The method in which to sort by - Method1 or Method2</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        public static Matrix<T> SortMatrix<T>(this Matrix<T> matrix, Func<Matrix<T>, Matrix<T>> sortingMethod)
            where T : IComparable<T>
        {
            // Reset counters
            ComparisonCount = 0;
            AssignmentCount = 0;

            // Sort the given matrix
            var sortedMatrix = sortingMethod(matrix);

            // Apply properties
            sortedMatrix.SortingMethod = sortingMethod.Method.Name;
            sortedMatrix.ComparisonCount = ComparisonCount;
            sortedMatrix.AssignmentCount = AssignmentCount;
            sortedMatrix.RemoveAll(x => x.Count == 0);

            return sortedMatrix;
        }

        /// <summary>
        /// Sorts all of the elements within the matrix,
        /// then restructures it back to the original format.
        /// </summary>
        /// <typeparam name="T">The data type contained in the matrix.</typeparam>
        /// <param name="matrix">The matrix to sort.</param>
        /// <returns></returns>
        public static Matrix<T> SortingMethod1<T>(Matrix<T> matrix)
            where T : IComparable<T>
        {
            // Put all matrix elements into a single List, then sort
            var flattenedMatrix = matrix.ToList();
            QuickSort(flattenedMatrix, 0, flattenedMatrix.Count - 1);

            // Return the matrix in the original structure
            return flattenedMatrix.ToMatrix(matrix.RowLength, matrix.ColLength);
        }

        /// <summary>
        /// Sorts the elements in each row individually,
        /// then sorts the elements in each columns.
        /// </summary>
        /// <typeparam name="T">The data type contained in the matrix.</typeparam>
        /// <param name="matrix">The matrix to sort.</param>
        public static Matrix<T> SortingMethod2<T>(Matrix<T> matrix)
            where T : IComparable<T>
        {
            // Sort each row
            matrix.ForEach(x => QuickSort(x, 0, x.Count - 1));

            // Sort each column
            matrix = matrix.RotateMatrix();
            matrix.ForEach(x => QuickSort(x, 0, x.Count - 1));

            // Return the matrix in the original structure
            matrix = matrix.RotateMatrix();

            return matrix;
        }

        /// <summary>
        /// Partitions the specified row from low to high.
        /// </summary>
        /// <returns>The partition index.</returns>
        /// <param name="row">Row.</param>
        /// <param name="low">Low.</param>
        /// <param name="high">High.</param>
        private static int Partition<T>(List<T> row, int low, int high)
            where T : IComparable<T>
        {
            T pivot = row[high];

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (CompareElements(LessThanOrEqual, row[j], pivot))
                {
                    i++;

                    T a = row[i], b = row[j];
                    SwapElements(ref a, ref b);
                    row[i] = a; row[j] = b;
                }
            }

            T aa = row[i + 1], bb = row[high];
            SwapElements(ref aa, ref bb);
            row[i + 1] = aa; row[high] = bb;

            return i + 1;
        }

        /// <summary>
        /// Quicks the sort.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="low">Low.</param>
        /// <param name="high">High.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private static void QuickSort<T>(List<T> row, int low, int high)
            where T : IComparable<T>
        {
            if (low < high)
            {
                int partition = Partition(row, low, high);

                QuickSort(row, low, partition - 1);
                QuickSort(row, partition + 1, high);
            }
        }

        /// <summary>
        /// Assigns the first element with the second's value.
        /// </summary>
        /// <param name="first">The element to assign to.</param>
        /// <param name="second">The element to duplicate the value of.</param>
        public static void AssignElement<T>(ref T first, T second)
            where T : IComparable<T>
        {
            // Track number of assignments made
            AssignmentCount += 1;

            first = second;
        }

        /// <summary>
        /// Swaps the elements within a matrix.
        /// </summary>
        /// <param name="first">First element.</param>
        /// <param name="second">Second element.</param>
        public static void SwapElements<T>(ref T first, ref T second)
            where T : IComparable<T>
        {
            // Temp variable as an intermediate
            var temp = default(T);
            AssignElement(ref temp, first);

            AssignElement(ref first, second);

            AssignElement(ref second, temp);
        }

        /// <summary>
        /// Compares two elements using the given comparison.
        /// </summary>
        /// <returns>The result of the comparison.</returns>
        /// <param name="operation">Comparison method.</param>
        /// <param name="first">First element.</param>
        /// <param name="second">Second element.</param>
        public static bool CompareElements<T>(Func<T, T, bool> operation, T first, T second)
            where T : IComparable<T>
        {
            // Track number of comparisons made
            ComparisonCount += 1;

            return operation(first, second);
        }
    }
}
