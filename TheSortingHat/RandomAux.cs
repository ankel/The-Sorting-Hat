using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSortingHat {
    public class RandomAux {

        /// <summary>
        /// Create an array contains random numbers between 1 and size
        /// </summary>
        /// <remarks>This function uses Fisher–Yates shuffle, the algorithm can be found at http://en.wikipedia.org/wiki/Fisher-Yates_shuffle </remarks>
        /// <param name="size">size of the output array</param>
        /// <returns>array contains random numbers</returns>
        public static Double[] Randomize ( int size ) {
            Double[] r = new Double[size];
            Random rand = new Random ();

            for ( int i = 0; i < size; ++i ) {
                r[i] = i + 1;
            }
            return Shuffle (r); ;
        }

        /// <summary>
        /// Shuffle elements inside an array
        /// </summary>
        /// <remarks>This function uses Fisher–Yates shuffle, the algorithm can be found at http://en.wikipedia.org/wiki/Fisher-Yates_shuffle </remarks>
        /// <param name="list">List contains the array</param>
        /// <returns></returns>
        public static double[] Shuffle ( IList<Double> list ) {
            Double[] a = new Double[list.Count];
            a[0] = list[0];
            Random rand = new Random ();

            for ( int i = 1; i < list.Count; ++i ) {
                int j = rand.Next (i + 1);
                a[i] = a[j];
                a[j] = list[i];
            }

            return a;
        }

    }
}
