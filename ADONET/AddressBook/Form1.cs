﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBook {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void addressTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.addressTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202221DataSet);

        }

        private void Form1_Load(object sender, EventArgs e) {
            

        }

        private void btAdd_Click(object sender, EventArgs e) {
            //氏名が未入力なら登録しない
            if (String.IsNullOrWhiteSpace(tbName.Text)) {
                MessageBox.Show("氏名が入力されていません", "エラー");
                return;
            }

            DataRow newRow = infosys202221DataSet.AddressTable.NewRow();
            newRow[1] = tbName.Text;
            newRow[2] = tbAddress.Text;
            newRow[3] = tbTel.Text;
            newRow[4] = tbMail.Text;
            newRow[5] = tbMemo.Text;
            newRow[6] = ImageToByteArray(pbImage.Image);

            //データセットへ新しいレコードを追加
            infosys202221DataSet.AddressTable.Rows.Add(newRow);
            //データベース更新
            this.addressTableTableAdapter.Update(this.infosys202221DataSet.AddressTable);

        }

        private void btUpdate_Click(object sender, EventArgs e) {
            //各テキストボックスからデータグリッドビューへの設定
            addressTableDataGridView.CurrentRow.Cells[1].Value = tbName.Text;
            addressTableDataGridView.CurrentRow.Cells[2].Value = tbAddress.Text;
            addressTableDataGridView.CurrentRow.Cells[3].Value = tbTel.Text;
            addressTableDataGridView.CurrentRow.Cells[4].Value = tbMail.Text;
            addressTableDataGridView.CurrentRow.Cells[5].Value = tbMemo.Text;
            addressTableDataGridView.CurrentRow.Cells[6].Value = ImageToByteArray(pbImage.Image);

            //データセットの中をデータベースへ反映（保存）
            this.Validate();
            this.addressTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202221DataSet);
        }

        private void addressTableDataGridView_Click(object sender, EventArgs e) {          
            if (addressTableDataGridView.CurrentRow == null) 
                return;
            

            //データグリッドビューの選択レコードを各テキストボックスへ設定
            tbName.Text = addressTableDataGridView.CurrentRow.Cells[1].Value.ToString();
            tbAddress.Text = addressTableDataGridView.CurrentRow.Cells[2].Value.ToString();
            tbTel.Text = addressTableDataGridView.CurrentRow.Cells[3].Value.ToString();
            tbMail.Text = addressTableDataGridView.CurrentRow.Cells[4].Value.ToString();
            tbMemo.Text = addressTableDataGridView.CurrentRow.Cells[5].Value.ToString();
            if (!(addressTableDataGridView.CurrentRow.Cells[6].Value is DBNull))
                pbImage.Image = ByteArrayToImage((byte[])addressTableDataGridView.CurrentRow.Cells[6].Value);
            else
                pbImage.Image = null;                   
        }

        //画像を開く
        private void btImageOpen_Click(object sender, EventArgs e) {
            //ofdImage.Filter = "画像ファイル(*.jpg; *.jpeg; *.png; *.bmp)| *.jpg; *.png; *.bmp *.jpeg;";
            if (ofdImage.ShowDialog() == DialogResult.OK) {
                pbImage.Image = System.Drawing.Image.FromFile(ofdImage.FileName);

            }
        }

        //画像を削除
        private void btImageDel_Click(object sender, EventArgs e) {
            pbImage.Image = null;
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        //名前検索
        private void btNameSearch_Click(object sender, EventArgs e) {
            addressTableTableAdapter.FillByName(infosys202221DataSet.AddressTable, tbNameSearch.Text);
        }

        //データグリッドビューをクリア
        private void btClear_Click(object sender, EventArgs e) {
            tbName.Text = null;
            tbAddress.Text = null;
            tbTel.Text = null;
            tbMemo.Text = null;
            tbMail.Text = null;
            pbImage.Image = null;

        }

        //データベース接続
        private void msDbConnect_Click(object sender, EventArgs e) {
            this.addressTableTableAdapter.Fill(this.infosys202221DataSet.AddressTable);
        }

        //名前検索をクリア・データベース再接続
        private void btSearchClear_Click(object sender, EventArgs e) {
            tbNameSearch.Text = null;
            this.addressTableTableAdapter.Fill(this.infosys202221DataSet.AddressTable);
        }

        //アプリを終了
        private void msExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //バージョン情報
        private void msVersionInfo_Click(object sender, EventArgs e) {
            new Version().ShowDialog();
        }
    }
}
