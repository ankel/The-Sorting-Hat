using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace TheSortingHat.Algorithms {
    public class ParQuickSort<T> : ISortable<T> where T : IComparable<T> {
        #region ISortable<T> Members

        public void Sort ( T[] arr ) {
            qSort (new ArraySection(arr, 0, arr.Length - 1));
        }

        #endregion

        struct ArraySection {
            public T[] arr;
            public int L;
            public int R;

            public ArraySection ( T[] arr, int L, int R ) {
                this.arr = arr;
                this.L = L;
                this.R = R;
            }
        }

        private void qSort ( object obj ) {
            Trace.Assert(obj is ArraySection);
            ArraySection asec = (ArraySection) obj;
            T[] arr = asec.arr;
            int L = asec.L;
            int R = asec.R;
            if ( L < R ) {
                int piv = L + ( R - L ) / 2;
                piv = Partition (arr, L, R, piv);
                Thread t = new Thread (qSort);
                t.Start( new ArraySection (arr, L, piv - 1));
                qSort (new ArraySection (arr, piv + 1, R));
                t.Join ();
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
