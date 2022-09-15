using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //設定情報保存用オブジェクト
        Settings settings = Settings.getInstance();

        int mode = 0;

        public Form1(){
            InitializeComponent();
        }

        //写真追加
        private void btOpenPic_Click(object sender, EventArgs e) {
            if (ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFileOpenDialog.FileName);

            }
        }

        //写真削除
        private void btDelPic_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            try {
                ImageConverter imgconv = new ImageConverter();
                Image img = (Image)imgconv.ConvertFrom(b);
                return img;
            }
            catch (Exception) {
                return null;
            }       
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void btExit_Click(object sender, EventArgs e) {
            //アプリケーションの終了
            Application.Exit();
        }

        //データグリッドビューに追加する
        private void btAddCar_Click(object sender, EventArgs e) {
            //氏名が未入力なら登録しない
            if (String.IsNullOrWhiteSpace(cbAuthor.Text)) {
                MessageBox.Show("氏名が入力されていません", "エラー");
                return;
            }

            DataRow newRow = infosys202221DataSet.CarReportDB.NewRow();
            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = GetCarMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbPicture.Image);

            //データセットへ新しいレコードを追加
            infosys202221DataSet.CarReportDB.Rows.Add(newRow);
            //データベース更新
            this.carReportDBTableAdapter.Update(this.infosys202221DataSet.CarReportDB);

            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            
        }

      
        //コンボボックスに記者を登録する（重複なし）
        private void setCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {

                //まだ登録されていなければ登録処理
                cbAuthor.Items.Add(author);
            }
        }

        //コンボボックスに記者を登録する（重複なし）
        private void setCbCarName(string maker) {
            if (!cbCarName.Items.Contains(maker)) {

                //まだ登録されていなければ登録処理
                cbCarName.Items.Add(maker);
            }
        }

        //メーカを調べる
        private string GetCarMaker() {

            if (rbToyota.Checked) {
                return "トヨタ";
            }

            if (rbHonda.Checked) {
                return "ホンダ";
            }

            if (rbSubaru.Checked) {
                return "スバル";
            }

            if (rbNissan.Checked) {
                return "日産";
            }

            if (rbImport.Checked) {
                return "外国車";
            }

            return "その他";

        }

        //データグリッドビューからデータを読み取って表示
        private void dgvCars_Click(object sender, EventArgs e) {
            if (dgvCars.CurrentRow == null)
                return;

            //データグリッドビューの選択レコードを各テキストボックスへ設定
            dtpDate.Value = (DateTime)dgvCars.CurrentRow.Cells[1].Value;
            cbAuthor.Text = dgvCars.CurrentRow.Cells[2].Value.ToString();
            CheckCarMaker(dgvCars.CurrentRow.Cells[3].Value.ToString());
            cbCarName.Text = dgvCars.CurrentRow.Cells[4].Value.ToString();
            tbReport.Text = dgvCars.CurrentRow.Cells[5].Value.ToString();
            if (!(dgvCars.CurrentRow.Cells[6].Value is DBNull))
                pbPicture.Image = ByteArrayToImage((byte[])dgvCars.CurrentRow.Cells[6].Value);
            else
                pbPicture.Image = null;
        }

        //メーカ種別チェック処理
        private void CheckCarMaker(string maker) {
            switch (maker) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;

                case "日産":
                    rbNissan.Checked = true;
                    break;

                case "ホンダ":
                    rbHonda.Checked = true;
                    break;

                case "スバル":
                    rbSubaru.Checked = true;
                    break;

                case "外国車":
                    rbImport.Checked = true;
                    break;

                case "その他":
                    rbOther.Checked = true;
                    break;

                default:
                    break;
                    }
            }

        //修正ボタンが押された時の処理
        private void btCorrection_Click(object sender, EventArgs e) {
            if (dgvCars.CurrentRow == null) {
                MessageBox.Show("更新するデータがありません", "エラー");

            }
            else {
                //各テキストボックスからデータグリッドビューへの設定
                dgvCars.CurrentRow.Cells[1].Value = dtpDate.Value;
                dgvCars.CurrentRow.Cells[2].Value = cbAuthor.Text;
                dgvCars.CurrentRow.Cells[3].Value = GetCarMaker();
                dgvCars.CurrentRow.Cells[4].Value = cbCarName.Text;
                dgvCars.CurrentRow.Cells[5].Value = tbReport.Text;
                dgvCars.CurrentRow.Cells[6].Value = ImageToByteArray(pbPicture.Image);

                //データセットの中をデータベースへ反映（保存）
                this.Validate();
                this.carReportDBBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.infosys202221DataSet);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            //this.carReportDBTableAdapter.Fill(this.infosys202221DataSet.CarReportDB);

            try {
                //設定ファイルを逆シリアル化して背景の色を設定
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (Exception) {
               
            }                       
        }

        //写真をリサイズ
        private void btResize_Click(object sender, EventArgs e) {
            pbPicture.SizeMode = (PictureBoxSizeMode)mode;
            mode = mode < 4 ? ++mode : 0;

        }

        //フォームの色設定
        private void tsChangeColor_Click(object sender, EventArgs e) {
            if(cdColorSelect.ShowDialog() == DialogResult.OK) {
                BackColor = cdColorSelect.Color;
                settings.MainFormColor = cdColorSelect.Color.ToArgb();
            }
        }

        //メニューからアプリを終了
        private void tsExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルをシリアル化
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
                
            }
        }

        //データベース接続
        private void msDbConnect_Click(object sender, EventArgs e) {
            this.carReportDBTableAdapter.Fill(this.infosys202221DataSet.CarReportDB);

        }

        //名前検索をクリア・データベース再接続
        private void btSearchClear_Click(object sender, EventArgs e) {
            tbCarSearch.Text = null;
            this.carReportDBTableAdapter.Fill(this.infosys202221DataSet.CarReportDB);
        }

        //データグリッドビューをクリア
        private void btClear_Click(object sender, EventArgs e) {
            cbAuthor.Text = null;
            cbCarName.Text = null;
            tbReport.Text = null;
            pbPicture.Image = null;
        }

        private void dgvCars_DataError(object sender, DataGridViewDataErrorEventArgs e) {

        }

        //データ削除処理
        private void btDelete_Click(object sender, EventArgs e) {
            if (dgvCars.CurrentRow == null) 
                MessageBox.Show("削除するデータがありません","エラー");

            else

            dgvCars.Rows.RemoveAt(dgvCars.CurrentRow.Index);
            this.Validate();
            this.carReportDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202221DataSet);
        }

        //車名検索
        private void btCarNameSearch_Click(object sender, EventArgs e) {
            carReportDBTableAdapter.FillByName(infosys202221DataSet.CarReportDB, tbCarSearch.Text);
        }

        //車名検索をクリア・データベース再接続
        private void btClearSearch_Click(object sender, EventArgs e) {
            tbCarSearch.Text = null;
            this.carReportDBTableAdapter.Fill(this.infosys202221DataSet.CarReportDB);
        }
    }
}
