using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charp8 {
    public partial class Form1 : Form {

        private Charp8.model.Charp8 emulator;

        public Form1() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                emulator.initialize();
                if (emulator.loadGame(openFileDialog1.FileName)) {
                    // iniciar o Loop do jogo
                }
                else {
                    // alertar que a ROM não foi encontrada ou houve algum problema
                }
            }
        }

        private void Form1_Load (object sender, EventArgs e) {

        }

        private void Size1xMenu_Click (object sender, EventArgs e) {
            Form1.ActiveForm.Size = new Size (336, 223);
        }

        private void Size2xMenu_Click (object sender, EventArgs e) {
            Form1.ActiveForm.Size = new Size (656, 383);
        }

        private void Size3xMenu_Click (object sender, EventArgs e) {
            Form1.ActiveForm.Size = new Size (976, 543);
        }

        private void Size4xMenu_Click (object sender, EventArgs e) {
            Form1.ActiveForm.Size = new Size (1276, 703);
        }

    }
}
