using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample0607 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btRandom_Click(object sender, EventArgs e) {
            Number.Value = new Random().Next(minValue:(int)nudMin.Value, (int)nudMax.Value + 1);
        }
    }
}
