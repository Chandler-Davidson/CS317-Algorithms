using System;
using System.Collections.Generic;

namespace Project1
{
    public partial class MatrixSorter
    {
        /// <summary>
        /// Partitions the specified list from low to high.
        /// </summary>
        /// <returns>The partition index.</returns>
        /// <param name="arr">List of values.</param>
        /// <param name="low">Low end of list.</param>
        /// <param name="high">High end of list.</param>
        static int Partition<T>(List<T> arr, int low, int high, T pivot)
            where T : IComparable<T>
        {
            int leftPtr = low;
            int rightPtr = high - 1;

            while (true)
            {
                // Iterate until pointer is >= pivot
                while (CompareElements(LessThan, arr[++leftPtr], pivot)) { }

                // Iterate until pointer is <= pivot
                while (CompareElements(GreaterThan, arr[--rightPtr], pivot)) { }

                if (leftPtr >= rightPtr)
                    break;

                SwapElements(arr, leftPtr, rightPtr);
            }

            SwapElements(arr, leftPtr, high - 1);

            return leftPtr;
        }

        /// <summary>
        /// Quicks the sort.
        /// 
        /// QuickSort using the MedianOf3 partition method and once the size of
        /// is small enough, swaps to an iterative sort to reduce comparisons.
        /// </summary>
        /// <param name="arr">A list of values.</param>
        /// <param name="low">Low end of the list.</param>
        /// <param name="high">High end of the list.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        static void QuickSort<T>(List<T> arr, int low, int high)
            where T : IComparable<T>
        {
            int size = high - low + 1;

            // If 3 or less elements, its faster to sort iteratively
            if (size <= 3)
                ManualSort(arr, low, high);

            // Sort recursively using QuickSort
            else
            {
                // Choose the median as the pivot
                var median = MedianOf3(arr, low, high);
                var partition = Partition(arr, low, high, median);

                // Recursive call
                QuickSort(arr, low, partition - 1);
                QuickSort(arr, partition + 1, high);
            }
        }

        /// <summary>
        /// Used towards the end of QuickSort to speed up sorting a list of 3 or 
        /// less elements.
        /// </summary>
        /// <param name="arr">A list of values.</param>
        /// <param name="low">Low end of the list.</param>
        /// <param name="high">High end of the list.</param>
        static void ManualSort<T>(List<T> arr, int low, int high)
            where T : IComparable<T>
        {
            int size = high - low + 1;

            if (size <= 1)
                return;

            if (size == 2)
            {
                // If out of order, simply swap places
                if (CompareElements(GreaterThan, arr[low], arr[high]))
                    SwapElements(arr, low, high);
                return;
            }

            // Compare each element, if out of order then swap with neighbors
            if (CompareElements(GreaterThan, arr[low], arr[high - 1]))
                SwapElements(arr, low, high - 1);

            if (CompareElements(GreaterThan, arr[low], arr[high]))
                SwapElements(arr, low, high);

            if (CompareElements(GreaterThan, arr[high - 1], arr[high]))
                SwapElements(arr, high - 1, high);
        }

        /// <summary>
        /// Finds the median of the elements within a list.
        /// </summary>
        /// <returns>The median element within the list.</returns>
        /// <param name="arr">A list of values.</param>
        /// <param name="low">Low end of the list.</param>
        /// <param name="high">High end of the list.</param>
        static T MedianOf3<T>(List<T> arr, int low, int high)
            where T : IComparable<T>

        {
            int center = (low + high) / 2;

            if (CompareElements(GreaterThan, arr[low], arr[center]))
                SwapElements(arr, low, center);

            if (CompareElements(GreaterThan, arr[low], arr[high]))
                SwapElements(arr, low, high);

            if (CompareElements(GreaterThan, arr[center], arr[high]))
                SwapElements(arr, center, high);

            SwapElements(arr, center, high - 1);

            return arr[high - 1];
        }
    }
}
