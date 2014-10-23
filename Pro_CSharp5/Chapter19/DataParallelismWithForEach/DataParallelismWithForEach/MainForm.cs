using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace DataParallelismWithForEach {
    public partial class MainForm : Form {

        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainForm() {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e) {
        //    ProcessFiles();

            Task.Factory.StartNew(() => ProcessFiles());

        }

        private void ProcessFiles() {
            string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
            string newDir = @"C:\AAA\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            Console.WriteLine("Processor count {0}", System.Environment.ProcessorCount);
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            try {
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                    string fileName = Path.GetFileName(currentFile);


                    Console.WriteLine("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                    //hangs worker thread if called form UI thread
                    this.Invoke((Action)delegate
                    {
                        this.Text = string.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                    });

                    //works fine
                    /* this.BeginInvoke((Action)delegate
                     {
                         //     Thread.Sleep(100);
                         this.Text = string.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                     });*/
                    using (Bitmap bitmap = new Bitmap(currentFile)) {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, fileName));
                            Thread.Sleep(500);
                    }
                });
            } catch (OperationCanceledException ex) {
                this.Invoke((Action) delegate {
                    this.Text = ex.Message;
                });
            }
        }

        private void ProcessFilesSeq() {
            string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
            string newDir = @"C:\AAA\ModifiedPictures";
            Directory.CreateDirectory(newDir);
            foreach (string currentFile in files) {
                //Console.WriteLine(currentFile);
                string fileName = Path.GetFileName(currentFile);
                this.Text = string.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                using (Bitmap bitmap = new Bitmap(currentFile)) {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDir, fileName));
                    Thread.Sleep(500);
                    
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            cancelToken.Cancel(); 
        }
    }
}
