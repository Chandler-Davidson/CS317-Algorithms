﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    /// <summary>
    /// 2D List collection that represents a matrix.
    /// </summary>
    public class Matrix<T> : List<List<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// The number of comparisons made.
        /// </summary>
        /// <value>The comparison count.</value>
        public int ComparisonCount { get; set; }

        /// <summary>
        /// The number of assignments made.
        /// </summary>
        /// <value>The assignment count.</value>
        public int AssignmentCount { get; set; }

        /// <summary>
        /// Gets or sets the sorting method used.
        /// </summary>
        /// <value>The sorting method used.</value>
        public string SortingMethod { get; set; } = "Not sorted";

        /// <summary>
        /// Gets the length of the row.
        /// </summary>
        /// <value>The length of each row.</value>
        public int RowLength => this[0].Count;

        /// <summary>
        /// Gets the length of the columns.
        /// </summary>
        /// <value>The length of the columns.</value>
        public int ColLength => this.Count;

        /// <summary>
        /// Returns the matrix as a one dimensional list.
        /// </summary>
        /// <returns>The matrix as a list.</returns>
        public List<T> ToList() => this.SelectMany(x => x).ToList();

        /// <summary>
        /// Initializes a new instance of the Matrix class with
        /// preinitialized rows with set capacities.
        /// </summary>
        /// <param name="rowSize">The number of rows needed.</param>
        /// <param name="columnSize">The capacity of each row.</param>
        public Matrix(int rowSize, int columnSize)
        {
            // Initialize a new List<List<>>
            var outer = new List<List<T>>(rowSize);

            // Add rowSize number of empty Lists
            for (int i = 0; i < rowSize; i++)
                outer.Add(new List<T>(columnSize));

            this.AddRange(outer);
        }

        /// <summary>
        /// Initializes a new instance of the Matrix class that is empty.
        /// </summary>
        public Matrix()
        {
        }

        /// <summary>
        /// Returns the matrix so that each collection is a column
        /// opposed to each sub <see cref="List{T}"/> being a row.
        /// </summary>
        /// <returns>The columns of the matrix.</returns>
        public Matrix<T> RotateMatrix()
        {
            var shiftedMatrix = new Matrix<T>();

            for (int i = 0; i < this[0].Count; i++)
                shiftedMatrix.Add(this.Select(x => x.ElementAt(i)).ToList());

            return shiftedMatrix;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Project1.Matrix`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Project1.Matrix`1"/>.</returns>
        public override string ToString()
        {
            var str = "";
            foreach (var row in this)
            {
                str += string.Join("", row.Select(x => x.ToString().PadRight(8)));
                str += Environment.NewLine + Environment.NewLine;
            }

            return str;
        }

        /// <summary>
        /// Generates a comprehensive report of the matrix.
        /// </summary>
        /// <returns>The report.</returns>
        public string GenerateReport()
        {
            return
                $"Matrix generated by: {SortingMethod}\n" +
                $"Data type: {typeof(T).Name}\n" +
                $"Comparisons made: {ComparisonCount}\n" +
                $"Assignments made: {AssignmentCount}\n" +
                $"Matrix:\n\n{this}"; 
        }
    }

    /// <summary>
    /// Extension methods for the conversion of <see cref="List{T}"/> to <see cref="Matrix{T}"/>
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Converts the given <see cref="List{T}"/> to a <see cref="Matrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">The data type represented within the <see cref="List{T}"/></typeparam>
        /// <param name="flatMatrix">The one dimensional list to convert.</param>
        /// <param name="rowLength">The designated length of each row.</param>
        /// <returns>A matrix containing the values from the given <see cref="List{T}"/>.</returns>
        public static Matrix<T> ToMatrix<T>(this List<T> flatMatrix, int rowLength)
            where T : IComparable<T>
        {
            var matrix = new Matrix<T>();

            for (int i = 0; i < flatMatrix.Count; i++)
            {
                if (i % rowLength == 0)
                    matrix.Add(new List<T>());
                matrix[i / rowLength].Add(flatMatrix[i]);
            }

            return matrix;
        }

        /// <summary>
        /// Converts the given <see cref="List{T}"/> to a <see cref="Matrix{T}"/>.
        /// </summary>
        /// <typeparam name="T">The data type represented within the <see cref="List{T}"/></typeparam>
        /// <param name="flatMatrix">The one dimensional list to convert.</param>
        /// <param name="matrix">The matrix structure to follow.</param>
        /// <returns>A matrix containing the values from the given <see cref="List{T}"/>.</returns>
        public static Matrix<T> ToMatrix<T>(this List<T> flatMatrix, Matrix<T> matrix)
            where T : IComparable<T>
        {
            return flatMatrix.ToMatrix(matrix.RowLength);
        }
    }
}
