using System;
using System.Collections.Generic;

namespace Project1
{
    public static partial class MatrixSorter
    {
        static int AssignmentCount;
        static int ComparisonCount;

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
            return flattenedMatrix.ToMatrix(matrix.RowLength);
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
    }
}
