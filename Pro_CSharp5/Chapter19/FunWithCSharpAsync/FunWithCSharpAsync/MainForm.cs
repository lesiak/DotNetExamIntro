using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunWithCSharpAsync {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
          
        }

        private async void btnCallMethod_Click(object sender, EventArgs e) {
            this.Text = await DoWorkAsync();
        }

        private Task<string> DoWorkAsync() {
            return Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work";
            });
        }

        private async void btnMultipleAwaits_Click(object sender, EventArgs e) {
            await Task.Run(() => Thread.Sleep(2000));
            MessageBox.Show("Done with first task");

            await Task.Run(() => Thread.Sleep(2000));
            MessageBox.Show("Done with second task");

            await Task.Run(() => Thread.Sleep(2000));
            MessageBox.Show("Done with third task");
        }

      /*  private async Task<string> DoWorkAsync() {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work";
            });
        }*/
    }
}
