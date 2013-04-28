using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSortingHat.Algorithms;
using TheSortingHat;

namespace SortTest {
    [TestClass]
    public class TestQuickSort {
        [TestMethod]
        public void TestQuickSort1 () {
            Int32[] a = new Int32[5] { 5, 1, 4, 3, 2 };
            ( new QuickSort<Int32> () ).Sort (a);
            for ( int i = 1; i < a.Length; ++i ) {
                Assert.IsTrue (a[i - 1] < a[i]);
            }
        }
        [TestMethod]
        public void TestQuickSort2 () {
            for ( int i = 0; i < 1000; ++i ) {
                Double[] a = RandomAux.Randomize (1000);
                ( new QuickSort<Double> () ).Sort (a);
                for ( int j = 1; j < a.Length; ++j ) {
                    Assert.IsTrue (a[j - 1] < a[j]);
                }
            }
        }
    }
}
