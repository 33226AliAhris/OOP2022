using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGame {
    public partial class Form1 : Form {
        private Random rand = new Random();
        private int randomNumber;

        public Form1() {
            InitializeComponent();
        }

        private void btEnter_Click(object sender, EventArgs e) {
            if(randomNumber == nudNum.Value) {
                tbAns.BackColor = Color.Blue;
                tbAns.ForeColor = Color.White;
            }
        }

        private void btReset_Click(object sender, EventArgs e) {
            tbAns.BackColor = Color.White;
            tbAns.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
