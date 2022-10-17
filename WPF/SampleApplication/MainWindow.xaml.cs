using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleApplication {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            seasonTextBlock.Text = "春";
            seasonComboBox.SelectedIndex = getSeason();
        }

        private static int getSeason() {
            var month = int.Parse(DateTime.Now.Month.ToString("00"));
            var season = 0;

            switch (month) {

                case int n when (n >= 3 && n <= 5):
                    season = 0;
                    break;

                case int n when (n >= 6 && n <= 8):
                    season = 1;
                    break;

                case int n when (n >= 9 && n <= 11):
                    season = 2;
                    break;

                case int n when (n >= 1 && n <= 2):
                case 12:
                    season = 3;
                    break;
            }
            return season;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e) {
            checkBoxTextBlock.Text = "未チェック";
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e) {
            checkBoxTextBlock.Text = "チェック済み";
        }

        private void seasonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            seasonTextBlock.Text = (string)((ComboBoxItem)seasonComboBox.SelectedItem).Content;
        }

        private void redRadioButton_Checked(object sender, RoutedEventArgs e) {
            colorTextBox.Text = "赤";
        }

        private void blueRadioButton_Checked(object sender, RoutedEventArgs e) {
            colorTextBox.Text = "青";
        }

        private void yellowRadioButton_Checked(object sender, RoutedEventArgs e) {
            colorTextBox.Text = "黄";
        }
    }
}
