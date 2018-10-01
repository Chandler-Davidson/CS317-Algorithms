using System;

namespace Project1
{
    /// <summary>
    /// Comparison functions to be used in <see cref="MatrixSorter"/>.
    /// Methods are to be used as infix operators: first isLessThan second.
    /// </summary>
    public partial class MatrixSorter
    {
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
