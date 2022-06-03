using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample0603 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //ボタンクリックイベントハンドラ
        private void btPush_Click(object sender, EventArgs e) {

            switch (dmas.Text) {
                case "+":
                    ans.Value = Sum1.Value + Sum2.Value;
                    break;

                case "-":
                    ans.Value = Sum1.Value - Sum2.Value;
                    break;

                case "/":
                    ans.Value = Sum1.Value / Sum2.Value;
                    break;

                case "*":
                    ans.Value = Sum1.Value * Sum2.Value;
                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            
        }
    }
}
