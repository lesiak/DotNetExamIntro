using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MyEBookReader {
    public partial class MainForm : Form {

        private static string theEBook = null;

        public MainForm() {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e) {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                theEBook = eArgs.Result;
                txtBook.Text = theEBook;
            };
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }


        private void btnGetStats_Click(object sender, EventArgs e) {
            string[] words = theEBook.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, 
                StringSplitOptions.RemoveEmptyEntries);

/*            string[] tenMostCommon = FindTenMostCommon(words);

            string longestWord = LongestWord(words);
            */
            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    tenMostCommon = FindTenMostCommon(words);
                },
                () =>
                {
                    longestWord = LongestWord(words);
                }
                );


            StringBuilder bookStats = new StringBuilder("The Mosc Common Words are:\n");
            foreach (string s in tenMostCommon) {
                bookStats.AppendLine(s);
            }

            bookStats.AppendFormat("Longest word is {0}", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book info");
        }

        private string[] FindTenMostCommon(string[] words) {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            string[] commoonWords = frequencyOrder.Take(10).ToArray();
            return commoonWords;
        }

        private string LongestWord(string[] words) {
            var orderedWords = from w in words
                               orderby w.Length descending
                               select w;
            return orderedWords.FirstOrDefault();
        }



    }
}
