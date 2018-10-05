using System;
using System.Collections.Generic;

namespace Project1
{
    /// <summary>
    /// Comparison functions to be used in <see cref="MatrixSorter"/>.
    /// Methods are to be used as infix operators: first isLessThan second.
    /// </summary>
    public partial class MatrixSorter
    {
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
        /// <param name="arr">List of values that contains the elements to swap.</param>
        /// <param name="indexA">Index of the first element.</param>
        /// <param name="indexB">Index of the second element.</param>
        /// <exception cref="IndexOutOfRangeException"/>
        public static void SwapElements<T>(this List<T> arr, int indexA, int indexB)
            where T : IComparable<T>
        {
            // Temp variable as an intermediate
            var temp = default(T);
            T first = arr[indexA],
            second = arr[indexB];

            // Swap the elements by reference
            AssignElement(ref temp, first);
            AssignElement(ref first, second);
            AssignElement(ref second, temp);

            // Reassign to the array
            arr[indexA] = first;
            arr[indexB] = second;
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

        private static bool LessThan<T>(T first, T second)
            where T : IComparable<T> => first.CompareTo(second) < 0;

        private static bool GreaterThan<T>(T first, T second)
            where T : IComparable<T> => first.CompareTo(second) > 0;

        private static bool EqualTo<T>(T first, T second)
            where T : IComparable<T> => first.CompareTo(second) == 0;

        private static bool LessThanOrEqual<T>(T first, T second)
            where T : IComparable<T> => LessThan(first, second) || EqualTo(first, second);

        private static bool GreaterThanOrEqual<T>(T first, T second)
            where T : IComparable<T> => GreaterThan(first, second) || EqualTo(first, second);
    }
}
