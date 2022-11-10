using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btWeatherGet_Click(object sender, EventArgs e) {
            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            var dString = wc.DownloadString(@"https://www.jma.go.jp/bosai/forecast/data/overview_forecast/130000.json");

            var json = JsonConvert.DeserializeObject<Rootobject>(dString);

            tbWeatherInfo.Text = json.text;
            
        }

        private void cbRegion_SelectedIndexChanged(object sender, EventArgs e) {
            switch (cbRegion.SelectedIndex) {
                case 0:
                    cbPref.DisplayMember = "関東";
                    break;
            }
        }
    }
}
