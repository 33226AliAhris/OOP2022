using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherAppNew {
    public partial class Form1 : Form {
        int areaCode = 0;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        private void btSearchArea_Click(object sender, EventArgs e) {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"C:\Users\infosys\Documents\areacode.csv", Encoding.GetEncoding("Shift_JIS")))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<AreaCode>().ToList();
                var area = tbArea.Text;

                foreach (var item in records) {
                    if (item.area == area) {
                        areaCode = item.code;
                        
                    }
                }
                var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=" + areaCode);
                var json = JsonConvert.DeserializeObject<Rootobject>(dString);
                lbWeather.Text = json.forecasts[0].telop;
                pbWeatherImage.LoadAsync(@"https://www.jma.go.jp/bosai/forecast/img/110.svg");
                lbTemp.Text = json.forecasts[0].temperature.max.celsius + "℃";

            }
        }

        private void btCelcius_Click(object sender, EventArgs e) {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=" + areaCode);
            var json = JsonConvert.DeserializeObject<Rootobject>(dString);
            lbTemp.Text = json.forecasts[0].temperature.max.celsius + "℃";
        }

        private void btFahrenheit_Click(object sender, EventArgs e) {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=" + areaCode);
            var json = JsonConvert.DeserializeObject<Rootobject>(dString);
            lbTemp.Text = json.forecasts[0].temperature.max.fahrenheit + "℉";
        }
    }
}
