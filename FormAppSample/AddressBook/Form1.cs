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

namespace AddressBook {
    public partial class Form1 : Form {
        //住所データ管理用リスト
        BindingList<Person> listPerson = new BindingList<Person>();

        public Form1() {
            InitializeComponent();
            dgvPersons.DataSource = listPerson;
        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            if (ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFileOpenDialog.FileName);

            }
        }

        private void btAddPerson_Click(object sender, EventArgs e) {
            //氏名が未入力なら登録しない
            if (String.IsNullOrWhiteSpace(tbName.Text)) {
                MessageBox.Show("氏名が入力されていません", "エラー");
                return;
            }

            Person newPerson = new Person {
                Name = tbName.Text,
                MailAddress = tbMailAddress.Text,
                Address = tbAddress.Text,
                Company = cbCompany.Text,
                Picture = pbPicture.Image,
                Registration = dtpRegistDate.Value,
                TelNumber = tbTelNumber.Text,
                //KindNumber = GetRadioButton(),
                listGroup = GetCheckBoxGroup(),
            };

            listPerson.Add(newPerson);
            dgvPersons.Rows[dgvPersons.RowCount - 1].Selected = true;

            JudgeMask();
            setCbCompany(cbCompany.Text);
        }

        //コンボボックスに会社名を登録する（重複なし）
        private void setCbCompany(string company) {
            if (!cbCompany.Items.Contains(company)) {

                //まだ登録されていなければ登録処理
                cbCompany.Items.Add(company);
            }
        }

        //private Person.KindNumberType GetRadioButton(){
           // var KindNumber = new Person.KindNumberType();
           // if (rbHome.Checked) {
           //     KindNumber(Person.KindNumberType.携帯);
           // }
            //return null;
       // }

        //チェックボックスにセットされている値をリストとして取り出す
        private List<Person.GroupType> GetCheckBoxGroup() {
            var listGroup = new List<Person.GroupType>();
            if (cbFamily.Checked) {
                listGroup.Add(Person.GroupType.家族);

            } if (cbFriend.Checked) {
                listGroup.Add(Person.GroupType.友人);

            } if (cbWork.Checked) {
                listGroup.Add(Person.GroupType.仕事);

            } if (cbOther.Checked) {
                listGroup.Add(Person.GroupType.その他);

            }
            return listGroup;
        }

        private void btPictureClear_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void dgvPersons_Click(object sender, EventArgs e) {
            if (dgvPersons.CurrentRow == null) return;
            var index = dgvPersons.CurrentRow.Index;

            tbName.Text = listPerson[index].Name;
            tbMailAddress.Text = listPerson[index].MailAddress;
            tbAddress.Text = listPerson[index].Address;
            cbCompany.Text = listPerson[index].Company;
            pbPicture.Image = listPerson[index].Picture;
            dtpRegistDate.Value = listPerson[index].Registration.Year > 1900 ? listPerson[index].Registration : DateTime.Today;
            tbTelNumber.Text = listPerson[index].TelNumber;
            
            groupCheckBoxAllClear(); //グループチェックボックスを一旦初期化

            foreach (var group in listPerson[index].listGroup) {
                switch (group) {
                    case Person.GroupType.家族:
                        cbFamily.Checked = true;
                        break;

                    case Person.GroupType.友人:
                        cbFriend.Checked = true;
                        break;

                    case Person.GroupType.仕事:
                        cbWork.Checked = true;
                        break;

                    case Person.GroupType.その他:
                        cbOther.Checked = true;
                        break;

                    default:
                        break;
                
                }
            }  
        }

        //グループのチェックボックスをオールクリア
        private void groupCheckBoxAllClear() {
            cbFamily.Checked = cbFriend.Checked = cbWork.Checked = cbOther.Checked = false;
        }

        //更新ボタンが押された時の処理
        private void btUpdate_Click(object sender, EventArgs e) {
            var index = dgvPersons.CurrentRow.Index;
        
            listPerson[index].Name = tbName.Text;
            listPerson[index].MailAddress = tbMailAddress.Text;
            listPerson[index].Address = tbAddress.Text;
            listPerson[index].Company = cbCompany.Text;
            listPerson[index].Picture = pbPicture.Image;
            listPerson[index].Registration = dtpRegistDate.Value;
            listPerson[index].TelNumber = tbTelNumber.Text;
            listPerson[index].listGroup = GetCheckBoxGroup();

            dgvPersons.Refresh(); //データグリッドビュー更新
        }

        private void btDelete_Click(object sender, EventArgs e) {
            MessageBox.Show("この行を削除しますか？","削除");
            listPerson.RemoveAt(dgvPersons.CurrentRow.Index);

            dgvPersons.Rows[dgvPersons.RowCount - 1].Selected = true;
            JudgeMask(); //マスク処理呼び出し
        }

        //更新・削除ボタンのマスク処理行う（マスク判定含む）
        private void JudgeMask() {
            btDelete.Enabled = btUpdate.Enabled = listPerson.Count() > 0 ? true : false;

        }

        private void Form1_Load_1(object sender, EventArgs e) {
            JudgeMask();//マスク処理呼び出し
        }

        //保存ボタンのイベントハンドラ
        private void btSave_Click(object sender, EventArgs e) {
            if (sfdSaveDialog.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();

                    using (FileStream fs = File.Open(sfdSaveDialog.FileName,FileMode.Create)) {
                        bf.Serialize(fs,listPerson);
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

                    using (FileStream fs = File.Open(ofdFileOpenDialog.FileName, FileMode.Open,FileAccess.Read)) {

                        //逆シリアル化して読み込む
                        listPerson = (BindingList<Person>) bf.Deserialize(fs);
                        dgvPersons.DataSource = null;
                        dgvPersons.DataSource = listPerson;

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                cbCompany.Items.Clear();

                foreach (var item in listPerson.Select(p => p.Company)) {
                    setCbCompany(item);//存在する会社を登録                   
                }

                JudgeMask();//マスク処理呼び出し
            }          
        }
    }
}
