using CsvHelper;
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
        //int areaCode = 0;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            plOverview.Visible = false;
            tbArea.Text = "群馬県";
            SetWeatherDetails();
            SetThreeDaysWeather();

        }

        //地域検索
        private void btSearchArea_Click(object sender, EventArgs e) {
            if (String.IsNullOrWhiteSpace(tbArea.Text)) {
                MessageBox.Show("都道府県名を入力してください！", "エラー");
                return;
            }
            SetThreeDaysWeather();
            SetWeatherDetails();
        }

        public void SetWeatherDetails() {
            if (GetJsonData() == null) {
                return;
            }

            tbDetails.Text = GetJsonData().description.bodyText;
            tbNight.Text = GetJsonData().forecasts[0].chanceOfRain.T00_06;
            tbMorning.Text = GetJsonData().forecasts[0].chanceOfRain.T06_12;
            tbAfternoon.Text = GetJsonData().forecasts[0].chanceOfRain.T12_18;
            tbEvening.Text = GetJsonData().forecasts[0].chanceOfRain.T18_24;
            tbPublishingOffice.Text = GetJsonData().publishingOffice;
            tbWindDirection.Text = GetJsonData().forecasts[0].detail.wind;
            tbWeather.Text = GetJsonData().forecasts[0].telop;
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbAreaName.Text = GetJsonData().location.area;
            tbPref.Text = GetJsonData().location.prefecture;
            tbCity.Text = GetJsonData().location.city;
            lbDay.Text = DateTime.Now.ToString("dddd");
            lbTime.Text = DateTime.Now.ToShortTimeString();
            lbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            tbMaxTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbMinTemp.Text = GetJsonData().forecasts[0].temperature.min.celsius + "℃";
            GetRiseAndSetTime();
            SetWeatherImage();

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

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"areacode.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<AreaCode>().ToList();
                var area = tbArea.Text;
                int areaCode = 0;
                int prefCode = 0;
                foreach (var item in records) {
                    if (item.area == area) {
                        areaCode = item.areaCode;
                        prefCode = item.prefCode;
                    }
                }
                return areaCode;
            }
        }

        //地域コード取得
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
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbMaxTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbMinTemp.Text = GetJsonData().forecasts[0].temperature.min.celsius + "℃";
        }

        //華氏取得
        private void btFahrenheit_Click(object sender, EventArgs e) {
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.fahrenheit + "℉";
            tbMaxTemp.Text = GetJsonData().forecasts[0].temperature.max.fahrenheit + "℉";
            tbMinTemp.Text = GetJsonData().forecasts[0].temperature.min.fahrenheit + "℉";
        }

        //ブラウザからJsonデータを取得
        public Rootobject GetJsonData() {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            try {
                var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=" + GetAreaCode());
                var json = JsonConvert.DeserializeObject<Rootobject>(dString);
                return json;
            }
            catch (Exception) {

                MessageBox.Show("正しい都道府県名を入力してください！","エラー");
                return null;
            }
        }

        //Enterキー押されたら検索
        private void tbArea_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SetWeatherDetails();
            }
        }

        private void btThreeDays_Click(object sender, EventArgs e) {
            SetThreeDaysWeather();
        }

        private void SetThreeDaysWeather() {
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

        private void btWeek_Click(object sender, EventArgs e) {
            plOverview.Visible = true;
            plRiseAndSet.Visible = false;
            plDay1.Visible = false;
            plDay2.Visible = false;

            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            try {
                //string link = @"https://www.jma.go.jp/bosai/forecast/data/overview_week/" + GetPrefCode() + ".json";
                var dString = wc.DownloadString(@"https://www.jma.go.jp/bosai/forecast/data/overview_week/" + GetPrefCode() + ".json");
                var json = JsonConvert.DeserializeObject<WeekRootobject>(dString);

                tbWeekOverview.Text = json.text;
            }
            catch (Exception) {

                tbWeekOverview.Text = "サーバーエラーのため表示できません！";
            }

        }

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
            var dString = wc.DownloadString(@"https://labs.bitmeister.jp/ohakon/json/?mode=sun_moon_rise_set&year=" + year + "&month=" + month + "&day=" + day + "&lat=" + lat + "&lng=" + lng);
            var json = JsonConvert.DeserializeObject<Rootobject_>(dString);

            tbRise.Text = json.rise_and_set.sunrise_hm;
            tbSet.Text = json.rise_and_set.sunset_hm;
        }

        //天気画像を設定
        public void SetWeatherImage() {
            //CSVファイルコンフィグレーション
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
                MissingFieldFound = null,
                BadDataFound = null,
            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"weatherImages.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {
                var records = csv.GetRecords<WeatherImages>().ToList();
                var weather = GetJsonData().forecasts[0].telop;
                foreach (var item in records) {
                    if (item.weather == weather) {
                        pbWeatherImage.ImageLocation = @"Images\" + item.weatherCode + ".png";
                    }
                }
            }
        }
    }
}