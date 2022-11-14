using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp {

    public class Area : List<Area> {
        public string area { get; set; }
        public int code { get; set; }
    }

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void btWeatherGet_Click(object sender, EventArgs e) {
            

        }

        private void btTest_Click(object sender, EventArgs e) {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            var dString = wc.DownloadString(@"https://weather.tsukumijima.net/api/forecast?city=100010");

            var json = JsonConvert.DeserializeObject<Rootobject>(dString);

            //lbWeather.Text = json.forecasts[0].temperature.min;

        }

        private void btSearchArea_Click(object sender, EventArgs e) {
            List<Area> area = new List<Area>();
            area.Add(new Area() { area = "北海道", code = 016010 });


        }
    }
}
