using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

        MyColor mycolor = new MyColor();

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        public List<MyColor> stockMyColor = new List<MyColor>();

        private void rSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            colorLabel.Background = new SolidColorBrush(Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value));
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        public class MyColor {
            public Color Color { get; set; }
            public string Name { get; set; }

        }

        private void Border_Loaded(object sender, RoutedEventArgs e) {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            var name = mycolor.Name;

            stockMyColor.Add(new MyColor() {
                Name = name,
                Color = color
            });

            colorLabel.Background = new SolidColorBrush(Color.FromRgb(color.R,color.G,color.B));

            redValue.Text = color.R.ToString();
            greenValue.Text = color.G.ToString();
            blueValue.Text = color.B.ToString();
 
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var color = stockMyColor.Select(c => c.Color);
            var name = stockMyColor.Select(n => n.Name);
            //colorList.Items.Add(("R：" + color.Last().R, " G：" + color.Last().G, " B：" + color.Last().B,name.Last()));
            colorList.Items.Add($"R：{color.Last().R}  G：{color.Last().G}  B：{color.Last().B}  {name.Last()}");
        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}