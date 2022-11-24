﻿using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WeatherAppNew { 
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        //インターネット接続確認
        public static bool IsConnectedToInternet() {
            try {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch { }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e) {
            var keepRetrying = true;
            while (keepRetrying) {
                if (IsConnectedToInternet()) {
                    keepRetrying = false;
                    plOverview.Visible = false;
                    tbArea.Text = "群馬県";
                    SetWeatherDetails();
                }
                else {
                    keepRetrying = true;
                    MessageBox.Show("インターネットに接続されていません！接続してからもう一度実行してください。","エラー");
                    Application.Exit();
                }
            }
        }

        //地域検索
        private void btSearchArea_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                MessageBox.Show("都道府県名を入力してください！", "エラー");
                return;
            }
            SetWeatherDetails();           
        }

        //全ての天気情報を設定
        public void SetWeatherDetails() {
            tbDetails.Text = GetJsonData().description.bodyText;
            tbNight.Text = GetJsonData().forecasts[0].chanceOfRain.T00_06;
            tbMorning.Text = GetJsonData().forecasts[0].chanceOfRain.T06_12;
            tbAfternoon.Text = GetJsonData().forecasts[0].chanceOfRain.T12_18;
            tbEvening.Text = GetJsonData().forecasts[0].chanceOfRain.T18_24;
            tbPublishingOffice.Text = GetJsonData().publishingOffice;
            tbWindDirection.Text = GetJsonData().forecasts[0].detail.wind;
            tbWeather.Text = GetJsonData().forecasts[0].telop;
            SetWeatherIcons();
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbAreaName.Text = GetJsonData().location.area;
            tbPref.Text = GetJsonData().location.prefecture;
            tbCity.Text = GetJsonData().location.city;
            lbDay.Text = DateTime.Now.ToString("dddd");
            lbTime.Text = DateTime.Now.ToShortTimeString();
            lbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            tbMaxTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbMinTemp.Text = GetJsonData().forecasts[2].temperature.min.celsius + "℃";
            GetRiseAndSetTime();       
        }

        //地域コード取得
        public int GetAreaCode() {
            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };
            int areaCode = 0;

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"areacode.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<AreaCode>().ToList();
                var area = tbArea.Text;

                foreach (var item in records) {
                    if (item.area == area) {
                        areaCode = item.areaCode;
                    }
                }
            }
            return areaCode;
        }

        //都道府県コード取得
        public int GetPrefCode() {
            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"areacode.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<AreaCode>().ToList();
                var area = GetJsonData().location.prefecture;
                int prefCode = 0;
                foreach (var item in records) {
                    if (item.area == area) {
                        prefCode = item.prefCode;
                    }
                }
                return prefCode;
            }
        }

        //緯度取得
        public double GetLatitude() {
            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",

            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"riseandset.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<RiseAndSet>().ToList();
                var area = GetJsonData().location.prefecture;
                double latitude = 0;
                foreach (var item in records) {
                    if (item.area == area) {
                        latitude = item.lat;
                    }
                }
                return latitude;
            }
        }

        //経度取得
        public double GetLongitude() {
            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"riseandset.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<RiseAndSet>().ToList();
                var area = GetJsonData().location.prefecture;
                double longitude = 0;
                foreach (var item in records) {
                    if (item.area == area) {
                        longitude = item.lng;
                    }
                }
                return longitude;
            }
        }

        //摂氏取得
        private void btCelcius_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                MessageBox.Show("都道府県名を入力してください！","エラー");
                return;
            }
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
        }

        //華氏取得
        private void btFahrenheit_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                MessageBox.Show("都道府県名を入力してください！", "エラー");
                return;
            }
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.fahrenheit + "℉";
            tbMaxTemp.Text = GetJsonData().forecasts[0].temperature.max.fahrenheit + "℉";
            tbMinTemp.Text = GetJsonData().forecasts[2].temperature.min.fahrenheit + "℉";
        }

        //ブラウザからJsonデータを取得
        public Rootobject GetJsonData() {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            string code = GetAreaCode().ToString();
            switch (GetAreaCode()) {
                case 16010:
                    code = "0" + code;
                    break;
                case 20010:
                    code = "0" + code;
                    break;
                case 30010:
                    code = "0" + code;
                    break;
                case 40010:
                    code = "0" + code;
                    break;
                case 50010:
                    code = "0" + code;
                    break;
                case 60010:
                    code = "0" + code;
                    break;
                case 70010:
                    code = "0" + code;
                    break;
                case 80010:
                    code = "0" + code;
                    break;
                case 90010:
                    code = "0" + code;
                    break;
            }
            var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=" + code);
            var json = JsonConvert.DeserializeObject<Rootobject>(dString);
            return json;
        }

        //Enterキー押されたら検索
        private void tbArea_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                    MessageBox.Show("都道府県名を入力してください！", "エラー");
                    return;
                }
                SetWeatherDetails();
            }    
        }

        //3日間の天気情報取得
        private void btThreeDays_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                MessageBox.Show("都道府県名を入力してください！", "エラー");
                return;
            }

            var today = DateTime.Today;

            plOverview.Visible = false;

            plDay1.Visible = true;
            plDay2.Visible = true;
            plRiseAndSet.Visible = true;

            lbDay1.Text = today.AddDays(1).ToString("dddd");
            lbDay2.Text = today.AddDays(2).ToString("dddd");

            lbMaxDay1.Text = GetJsonData().forecasts[1].temperature.max.celsius + "°";
            lbMinDay1.Text = GetJsonData().forecasts[1].temperature.min.celsius + "°";
            lbMaxDay2.Text = GetJsonData().forecasts[2].temperature.max.celsius + "°";
            lbMinDay2.Text = GetJsonData().forecasts[2].temperature.min.celsius + "°";

            pbDay1.ImageLocation = GetJsonData().forecasts[1].image.url.Replace("svg", "png");
            pbDay2.ImageLocation = GetJsonData().forecasts[2].image.url.Replace("svg", "png");

            lbDateDay1.Text = today.AddDays(1).ToString("dd") + "日";
            lbDateDay2.Text = today.AddDays(2).ToString("dd") + "日";
        }

        //週間の天気情報取得
        private void btWeek_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                MessageBox.Show("都道府県名を入力してください！", "エラー");
                return;
            }
            plOverview.Visible = true;
            plRiseAndSet.Visible = false;
            plDay1.Visible = false;
            plDay2.Visible = false;

            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            string code = GetPrefCode().ToString();
            switch (GetPrefCode()) {
                case 16000:
                    code = "0" + code;
                    break;
                case 20000:
                    code = "0" + code;
                    break;
                case 30000:
                    code = "0" + code;
                    break;
                case 40000:
                    code = "0" + code;
                    break;
                case 50000:
                    code = "0" + code;
                    break;
                case 60000:
                    code = "0" + code;
                    break;
                case 70000:
                    code = "0" + code;
                    break;
                case 80000:
                    code = "0" + code;
                    break;
                case 90000:
                    code = "0" + code;
                    break;
            }
            try {
                var dString = wc.DownloadString(@"https://www.jma.go.jp/bosai/forecast/data/overview_week/" + code + ".json");
                var json = JsonConvert.DeserializeObject<WeekRootobject>(dString);
                tbWeekOverview.Text = json.text;
            }
            catch (Exception) {

                tbWeekOverview.Text = "サーバーエラーのため表示できません";
            }
        }

        //日の出、日の入りのデータ取得
        public void GetRiseAndSetTime() {
            var year = DateTime.Now.ToString("yyyy");
            var month = DateTime.Now.ToString("MM");
            var day = DateTime.Now.ToString("dd");
            var lat = GetLatitude();
            var lng = GetLongitude();

            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            //string link = @"https://labs.bitmeister.jp/ohakon/json/?mode=sun_moon_rise_set&year="+year+"&month="+month+"&day="+day+"&lat="+lat+"&lng="+lng;
            var dString = wc.DownloadString(@"https://labs.bitmeister.jp/ohakon/json/?mode=sun_moon_rise_set&year="+year+"&month="+month+"&day="+day+"&lat="+lat+"&lng="+lng);
            var json = JsonConvert.DeserializeObject<Rootobject_>(dString);

            tbRise.Text = json.rise_and_set.sunrise_hm;
            tbSet.Text = json.rise_and_set.sunset_hm;
        }

        //天気アイコンの設定
        public void SetWeatherIcons() {
            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
                MissingFieldFound = null,
            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"weatherImages.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<WeatherIconCode>().ToList();
                var weather = GetJsonData().forecasts[0].telop;
                foreach (var item in records) {
                    if (item.weather == weather) {
                        pbWeatherImage.ImageLocation = @"WeatherImages\" + item.weatherCode+".png";
                    }
                }
            }
        }
    }
}
