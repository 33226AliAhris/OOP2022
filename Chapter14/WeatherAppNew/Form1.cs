using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
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
            plDay1.Visible = false;
            plDay2.Visible = false;
            plDay3.Visible = false;
            plDay4.Visible = false;
            plDay5.Visible = false;
            plDay6.Visible = false;
            plDay7.Visible = false;
        }

        //地域検索
        private void btSearchArea_Click(object sender, EventArgs e)
        {
            GetAreaCode();
            SetWeatherDetails();
        }

        public void SetWeatherDetails()
        {
            tbDetails.Text = GetJsonData().description.bodyText;
            tbNight.Text = GetJsonData().forecasts[0].chanceOfRain.T00_06;
            tbMorning.Text = GetJsonData().forecasts[0].chanceOfRain.T06_12;
            tbAfternoon.Text = GetJsonData().forecasts[0].chanceOfRain.T12_18;
            tbEvening.Text = GetJsonData().forecasts[0].chanceOfRain.T18_24;
            tbPublishingOffice.Text = GetJsonData().publishingOffice;
            tbWindDirection.Text = GetJsonData().forecasts[0].detail.wind;
            tbWeather.Text = GetJsonData().forecasts[0].telop;
            //pbWeatherImage.ImageLocation = "https://www.jma.go.jp/bosai/forecast/img/100.png";
            pbWeatherImage.ImageLocation = @"C:\Users\Buddy\Pictures\weather-gif-9.gif";
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbAreaName.Text = GetJsonData().location.area;
            tbPref.Text = GetJsonData().location.prefecture;
            tbCity.Text = GetJsonData().location.city;
            lbDay.Text = DateTime.Now.ToString("dddd");
            lbTime.Text = DateTime.Now.ToShortTimeString();
            lbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            tbMaxTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
            tbMinTemp.Text = GetJsonData().forecasts[0].temperature.min.celsius + "℃";
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
            using (var reader = new StreamReader(@"C:\Users\Buddy\Downloads\areacode.csv"))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<AreaCode>().ToList();
                var area = tbArea.Text;
                int areaCode = 0;
                foreach (var item in records) {
                    if (item.area == area) {
                        areaCode = item.code;  
                    }             
                }
                return areaCode;
            }
        }

        //摂氏取得
        private void btCelcius_Click(object sender, EventArgs e) {
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.celsius + "℃";
        }

        //華氏取得
        private void btFahrenheit_Click(object sender, EventArgs e) {
            lbTemp.Text = GetJsonData().forecasts[0].temperature.max.fahrenheit + "℉";
            
        }

        //ブラウザからJsonデータを取得
        public Rootobject GetJsonData() {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };
            var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=" + GetAreaCode());
            var json = JsonConvert.DeserializeObject<Rootobject>(dString);
            return json;
        }

        //Enterキー押されたら検索
        private void tbArea_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SetWeatherDetails();
            }    
        }

        public void GetWeatherImages() {
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
            using (var reader = new StreamReader(@"C:\Users\infosys\Documents\weatherImages.csv", Encoding.GetEncoding("Shift_JIS")))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<WeatherImages>().ToList();
                foreach (var item in records) {
                    if (item.weather == tbWeather.Text) {
                        pbWeatherImage.ImageLocation = item.path;
                    }
                }
            }
        }

        private void btThreeDays_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            
            plDay1.Visible = true;
            plDay2.Visible = true;
            plDay3.Visible = false;
            plDay4.Visible = false;
            plDay5.Visible = false;
            plDay6.Visible = false;
            plDay7.Visible = false;

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
            var today = DateTime.Today;

            plDay1.Visible = true;
            plDay2.Visible = true;
            plDay3.Visible = true;
            plDay4.Visible = true;
            plDay5.Visible = true;
            plDay6.Visible = true;
            plDay7.Visible = true;

            lbDay1.Text = today.AddDays(1).ToString("dddd");
            lbDay2.Text = today.AddDays(2).ToString("dddd");
            lbDay3.Text = today.AddDays(3).ToString("dddd");
            lbDay4.Text = today.AddDays(4).ToString("dddd");
            lbDay5.Text = today.AddDays(5).ToString("dddd");
            lbDay6.Text = today.AddDays(6).ToString("dddd");
            lbDay7.Text = today.AddDays(7).ToString("dddd");

            lbDateDay1.Text = today.AddDays(1).ToString("dd") + "日";
            lbDateDay2.Text = today.AddDays(2).ToString("dd") + "日";
            lbDateDay3.Text = today.AddDays(3).ToString("dd") + "日";
            lbDateDay4.Text = today.AddDays(4).ToString("dd") + "日";
            lbDateDay5.Text = today.AddDays(5).ToString("dd") + "日";
            lbDateDay6.Text = today.AddDays(6).ToString("dd") + "日";
            lbDateDay7.Text = today.AddDays(7).ToString("dd") + "日";

        }

        private void lbMinDay4_Click(object sender, EventArgs e)
        {

        }
    }
}
