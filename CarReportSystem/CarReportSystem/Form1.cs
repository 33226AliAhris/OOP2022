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

namespace CarReportSystem{
    public partial class Form1 : Form {
        //車データ管理用リスト
        BindingList<CarReport> listCar = new BindingList<CarReport>();
        int mode;

        public Form1() {
            InitializeComponent();
            dgvCars.DataSource = listCar;
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

        private void btExit_Click(object sender, EventArgs e) {
            //アプリケーションの終了
            Application.Exit();
        }

        //データグリッドビューに追加する
        private void btAddCar_Click(object sender, EventArgs e) {
            var newCar = new CarReport {
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Date = dtpDate.Value,
                Maker = GetCarMaker()

        };
            listCar.Add(newCar);
            dgvCars.Rows[dgvCars.RowCount - 1].Selected = true;

            JudgeMask();
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
        private CarReport.MakerGroup GetCarMaker() {
            //デフォルトの戻りを設定
            CarReport.MakerGroup selectedCarMaker = CarReport.MakerGroup.その他;

            if (rbToyota.Checked) {
                selectedCarMaker = CarReport.MakerGroup.トヨタ;
            }

            if (rbSubaru.Checked) {
                selectedCarMaker = CarReport.MakerGroup.スバル;
            }

            if (rbNissan.Checked) {
                selectedCarMaker = CarReport.MakerGroup.日産;
            }

            if (rbHonda.Checked) {
                selectedCarMaker = CarReport.MakerGroup.ホンダ;
            }

            if (rbImport.Checked) {
                selectedCarMaker = CarReport.MakerGroup.外国車;
            }

            return selectedCarMaker;
        }

        //データグリッドビューからデータを読み取って表示
        private void dgvCars_Click(object sender, EventArgs e) {
            if (dgvCars.CurrentRow == null) return;
            var index = dgvCars.CurrentRow.Index;
            
            cbAuthor.Text = listCar[index].Author;
            cbCarName.Text = listCar[index].CarName;
            tbReport.Text = listCar[index].Report;
            dtpDate.Value = listCar[index].Date;
            pbPicture.Image = listCar[index].Picture;

            CheckCarMaker(index);
        }

        //メーカ種別チェック処理
        private void CheckCarMaker(int index) {
            switch (listCar[index].Maker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;

                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;

                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;

                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;

                case CarReport.MakerGroup.外国車:
                    rbImport.Checked = true;
                    break;

                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;

                default:
                    break;
            }
        }

        //修正ボタンが押された時の処理
        private void btCorrection_Click(object sender, EventArgs e) {
            var index = dgvCars.CurrentRow.Index;

            listCar[index].Author = cbAuthor.Text;
            listCar[index].CarName = cbCarName.Text;
            listCar[index].Report = tbReport.Text;
            listCar[index].Date = dtpDate.Value;
            listCar[index].Picture = pbPicture.Image;
            listCar[index].Maker = GetCarMaker();

            dgvCars.Refresh(); //データグリッドビュー更新
        }

        //削除ボタン処理
        private void btDelete_Click(object sender, EventArgs e) {
            MessageBox.Show("この行を削除しますか？", "削除");
            listCar.RemoveAt(dgvCars.CurrentRow.Index);

            dgvCars.Rows[dgvCars.RowCount - 1].Selected = true;
            JudgeMask(); //マスク処理呼び出し
        }

        //更新・削除ボタンのマスク処理行う（マスク判定含む）
        private void JudgeMask() {
            btDelete.Enabled = btCorrection.Enabled = listCar.Count() > 0 ? true : false;

        }

        private void Form1_Load(object sender, EventArgs e) {
            JudgeMask();//マスク処理呼び出し
        }

        //保存ボタンのイベントハンドラ
        private void btSave_Click(object sender, EventArgs e) {
            if (sfdSaveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(sfdSaveFileDialog.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCar);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btOpen_Click(object sender, EventArgs e) {
            if (ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                try { 
                    //バイナリ形式で逆シリアル化
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(ofdFileOpenDialog.FileName, FileMode.Open, FileAccess.Read)) {

                        //逆シリアル化して読み込む
                        listCar = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCars.DataSource = null;
                        dgvCars.DataSource = listCar;
                    }
                }
                    catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                cbAuthor.Items.Clear();
                cbCarName.Items.Clear();

                foreach (var item in listCar.Select(p => p.Author)) {
                    setCbAuthor(item);//存在する会社を登録                   
                }

                foreach (var item in listCar.Select(p => p.CarName)) {
                    setCbCarName(item);//存在する会社を登録                   
                }

                JudgeMask();//マスク処理呼び出し
            }
        }

        //写真をリサイズ
        private void btResize_Click(object sender, EventArgs e) {
            pbPicture.SizeMode = (PictureBoxSizeMode)mode;
            mode = mode < 4 ? ++mode : 0;

        }
    }
}
