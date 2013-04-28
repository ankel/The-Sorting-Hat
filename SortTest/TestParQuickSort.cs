using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSortingHat.Algorithms;
using TheSortingHat;

namespace SortTest {
    [TestClass]
    public class TestParQuickSort {
        [TestMethod]
        public void TestParQuickSort1 () {
            Double[] a = RandomAux.Randomize (1000);
            ( new ParQuickSort<Double> () ).Sort (a);
            for ( int j = 1; j < a.Length; ++j ) {
                Assert.IsTrue (a[j - 1] < a[j]);
            }
        }
        [TestMethod]
        public void TestParQuickSort2 () {
            for ( int i = 0; i < 1000; ++i ) {
                Double[] a = RandomAux.Randomize (1000);
                ( new ParQuickSort<Double> () ).Sort (a);
                for ( int j = 1; j < a.Length; ++j ) {
                    Assert.IsTrue (a[j - 1] < a[j]);
                }
            }
        }
    }
}
