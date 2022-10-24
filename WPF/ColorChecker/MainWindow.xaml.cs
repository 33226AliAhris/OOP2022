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

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        int rValue = 0;
        int gValue = 0;
        int bValue = 0;

        public MainWindow() {
            InitializeComponent();
        }

        private void rSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            int rValue = (int)rSlider.Value;
            colorLabel.Background = new SolidColorBrush(Color.FromRgb((byte)rValue, (byte)gValue, (byte)bValue));
        }

        private void gSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            int gValue = (int)gSlider.Value;
            colorLabel.Background = new SolidColorBrush(Color.FromRgb((byte)rValue, (byte)gValue, (byte)bValue));
        }

        private void bSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            int bValue = (int)bSlider.Value;
            colorLabel.Background = new SolidColorBrush(Color.FromRgb((byte)rValue, (byte)gValue, (byte)bValue));
        }
    }
}
