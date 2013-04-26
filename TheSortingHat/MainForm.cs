using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TheSortingHat {
    public partial class MainForm : Form {

        const int size = 52;

        public Double[] ToBeSorted{
            get;
            private set;
        }

        /// <summary>
        /// Create an array contains random numbers between 1 and size
        /// </summary>
        /// <remarks>This function uses Fisher–Yates shuffle, the algorithm can be found at http://en.wikipedia.org/wiki/Fisher-Yates_shuffle </remarks>
        /// <param name="size">size of the output array</param>
        /// <returns>array contains random numbers</returns>
        public static Double[] Randomize ( int size ) {
            Double[] r = new Double[size];
            Random rand = new Random();

            for ( int i = 0; i < size; ++i ) {
                r[i] = i + 1;
            }

            Shuffle (r);

            return r;
        }

        public MainForm () {
            InitializeComponent ();
        }

        private void randomizeBttn_Click ( object sender, EventArgs e ) {
            if ( inputTxtb.Text.Length == 0 ) {
                ToBeSorted = GenerateRandomInput ();
            } else {
                bool goodInput = true;
                ToBeSorted = Shuffle(ParseInputTextForCSV(ref goodInput));
                Debug.Assert (goodInput);   // can't be false - textbox passed Validating event
                RewriteInputTxt (ToBeSorted.Length, ToBeSorted);
            }
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
            Random rand = new Random();

            for ( int i = 1; i < list.Count; ++i ) {
                int j = rand.Next (i + 1);
                a[i] = a[j];
                a[j] = list[i];
            }

            return a;
        }

        private void inputTxtb_Validating ( object sender, CancelEventArgs e ) {
            foreach ( var c in inputTxtb.Text ) {
                if (!(Char.IsNumber(c) || c ==',' || c == ' ' || c == '.')){
                    MessageBox.Show("Input can only accept digit, comma, or dot.\nRandom numbers will be generated instead","Input error");

                    GenerateRandomInput();

                    break;
                }
            }

            bool goodInput = true;
            List<Double> d = ParseInputTextForCSV (ref goodInput);

            if (goodInput) {
                ToBeSorted = d.ToArray();
            } else {
                MessageBox.Show("Input can only accept digit, comma, or dot.\nRandom numbers will be generated instead","Input error");
                ToBeSorted = GenerateRandomInput();
            }

        }

        private List<double> ParseInputTextForCSV ( ref bool goodInput ) {
            List<Double> d = new List<Double> ();
            foreach ( var num in inputTxtb.Text.Split (',') ) {
                double t;
                if ( !Double.TryParse (num, out t) ) {
                    MessageBox.Show (String.Format ("{0} is not a valid numer.\nOnly support floating-point numbers", num), "Input error");
                    goodInput = false;
                    break;
                }
                d.Add (t);
            }
            return d;
        }

        private Double[] GenerateRandomInput () {
            Double[] a = Randomize (size);

            RewriteInputTxt (size, a);

            return a;
        }

        private void RewriteInputTxt ( int size, Double[] a ) {
            inputTxtb.Text = String.Empty;
            inputTxtb.Text += a[0];
            for ( int i = 1; i < size; ++i ) {
                inputTxtb.Text += String.Format (", {0}", a[i]);
            }
        }

    }
}
