using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Matrix<T> : List<List<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// The number of comparisons made.
        /// </summary>
        /// <value>The comparison count.</value>
        public int ComparisonCount { get; private set; }

        /// <summary>
        /// The number of assignments made.
        /// </summary>
        /// <value>The assignment count.</value>
        public int AssignmentCount { get; private set; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Project1.Matrix`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Project1.Matrix`1"/>.</returns>
        public override string ToString()
        {
            var str = "";
            foreach (var row in this)
            {
                foreach (var number in row)
                {
                    str += number.ToString().PadRight(10);
                }

                str += Environment.NewLine;
            }

            return str;
        }

        /// <summary>
        /// Assigns the first element with the second's value.
        /// </summary>
        /// <param name="first">The element to assign to.</param>
        /// <param name="second">The element to duplicate the value of.</param>
        public void AssignElement(ref T first, T second)
        {
            AssignmentCount += 1;

            first = second;
        }

        /// <summary>
        /// Swaps the elements within a matrix.
        /// </summary>
        /// <param name="first">First element.</param>
        /// <param name="second">Second element.</param>
        public void SwapElements(ref T first, ref T second)
        {
            // Temp variable as an intermeditate
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
        public bool CompareElements(Func<T, T, bool> operation, T first, T second)
        {
            ComparisonCount += 1;

            return operation(first, second);
        }

        private bool LessThan(T first, T second)
        {
            return first.CompareTo(second) > 0;
        }

        private bool GreaterThan(T first, T second)
        {
            return first.CompareTo(second) < 0;
        }

        private bool EqualTo(T first, T second)
        {
            return first.CompareTo(second) == 0;
        }

        private bool LessThanOrEqual(T first, T second)
        {
            return LessThan(first, second) || EqualTo(first, second);
        }

        private bool GreaterThanOrEqual(T first, T second)
        {
            return GreaterThan(first, second) || EqualTo(first, second);
        }

        public void Quicksort(List<T> row, int left, int right)
        {
            int i = left, j = right;
            var pivotValue = row[left + right / 2];

            while (i <= j)
            {
                while (row[i].CompareTo(pivotValue) < 0)
                {
                    i++;
                }

                while (row[j].CompareTo(pivotValue) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T a = row[i], b = row[j];
                    SwapElements(ref a, ref b);
                    row[i] = a; row[j] = b;

                    i++;
                    j--;
                }
            }

            if (left < j)
                Quicksort(row, left, j);
            if (i < right)
                Quicksort(row, i, right);
        }
    }
}
