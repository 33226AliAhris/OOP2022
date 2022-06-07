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

        private void tbCalc_Click(object sender, EventArgs e) {
            if (ndNum2.Value == 0) {
                MessageBox.Show(
                    "0で割り算できません",
                    "エラー",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            else {
                ndAns.Value = ndNum1.Value / ndNum2.Value;
                ndMod.Value = ndNum1.Value % ndNum2.Value;
            }
        }
    }
}
