using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSortingHat {
    public class QuickSort<T> : ISortable<T> where T : IComparable<T> {
        
        /// <summary>
        /// Quick sort.
        /// </summary>
        /// <remarks>Algorithm from http://en.wikipedia.org/wiki/Quicksort#In-place_version </remarks>
        /// <param name="arr">array contains elements to be sorted.</param>
        public void Sort ( T[] arr ) {
            qSort (arr, 0, arr.Length - 1);
        }

        private void qSort ( T[] arr, int L, int R ) {
            if ( L < R ) {
                int piv = L + ( R - L ) / 2;
                piv = Partition (arr, L, R, piv);
                qSort (arr, L, piv - 1);
                qSort (arr, piv + 1, R);
            }
        }

        private int Partition ( T[] arr, int L, int R, int piv ) {
            T pivValue = arr[piv];
            Swap (arr, piv, R);
            int j = L;
            for ( int i = L; i < R; ++i ) {
                if ( arr[i].CompareTo (pivValue) <= 0 ) {
                    Swap (arr, i, j);
                    ++j;
                }
            }
            Swap (arr, j, R);
            return j;
        }

        [System.Runtime.CompilerServices.MethodImpl (System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void Swap ( T[] arr, int p, int q ) {
            T temp = arr[p];
            arr[p] = arr[q];
            arr[q] = temp;
        }
    }
}
