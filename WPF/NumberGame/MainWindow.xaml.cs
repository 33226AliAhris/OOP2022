﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumberGame {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        int rand = new Random().Next(1,26);

        public MainWindow() {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Button bt = (Button)sender;
            bt.Background = Brushes.AntiqueWhite;
            var btNum = int.Parse(bt.Content.ToString());
           
            switch (rand) {
                case int randNum when(randNum == btNum):
                    numTextBlock.Text = "当たり！";

                    //アニメーション
                    ColorAnimation animation;
                    animation = new ColorAnimation();
                    animation.From = Colors.Gray;
                    animation.To = Colors.Red;
                    animation.Duration = new Duration(TimeSpan.FromSeconds(1));
                    bt.Background = new SolidColorBrush(Colors.Orange);
                    bt.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                    
                    break;

                case int randNum when (randNum > btNum):
                    numTextBlock.Text = btNum + "より大きい";
                    break;

                case int randNum when (randNum < btNum):
                    numTextBlock.Text = btNum + "より小さい";
                    break;
            }
        }
    }
}