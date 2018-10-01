using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public partial class MatrixSorter
    {
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
