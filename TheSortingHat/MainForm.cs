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

using TheSortingHat.Algorithms;

namespace TheSortingHat {
    public partial class MainForm : Form {

        const int size = 5;

        ISortable<Double> sortingAlgorithm;

        public Double[] ToBeSorted {
            get;
            private set;
        }

        public MainForm () {
            InitializeComponent ();
            ToBeSorted = GenerateRandomInput ();
            qsortRadio.Checked = true;
        }

        private void randomizeBttn_Click ( object sender, EventArgs e ) {
            if ( inputTxtb.Text.Length == 0 ) {
                ToBeSorted = GenerateRandomInput ();
            } else {
                bool goodInput = true;
                ToBeSorted = RandomAux.Shuffle (ParseInputTextForCSV (ref goodInput));
                Debug.Assert (goodInput);   // can't be false - textbox passed Validating event
                RewriteInputTxt (ToBeSorted.Length, ToBeSorted);
            }
        }

        private void inputTxtb_Validating ( object sender, CancelEventArgs e ) {
            foreach ( var c in inputTxtb.Text ) {
                if ( !( Char.IsNumber (c) || c == ',' || c == ' ' || c == '.' ) ) {
                    MessageBox.Show ("Input can only accept digit, comma, or dot.\nRandom numbers will be generated instead", "Input error");

                    GenerateRandomInput ();

                    break;
                }
            }

            bool goodInput = true;
            List<Double> d = ParseInputTextForCSV (ref goodInput);

            if ( goodInput ) {
                ToBeSorted = d.ToArray ();
            } else {
                MessageBox.Show ("Input can only accept digit, comma, or dot.\nRandom numbers will be generated instead", "Input error");
                ToBeSorted = GenerateRandomInput ();
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
            Double[] a = RandomAux.Randomize (size);

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

        private void qsortRadio_CheckedChanged ( object sender, EventArgs e ) {
            if ( qsortRadio.Checked ) {
                sortingAlgorithm = new QuickSort<Double> ();
            }
        }

        private void sortBttn_Click ( object sender, EventArgs e ) {

            bool goodInput = true;
            var l = ParseInputTextForCSV (ref goodInput);
            Debug.Assert (goodInput);
            ToBeSorted = l.ToArray ();

            sortingAlgorithm.Sort (ToBeSorted);
            RewriteInputTxt (ToBeSorted.Length, ToBeSorted);
        }

    }
}
