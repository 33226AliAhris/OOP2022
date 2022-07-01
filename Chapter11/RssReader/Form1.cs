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
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        IEnumerable<string> xTitle;
        
        public Form1() {
            InitializeComponent();
        }

        private void btRssGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var stream = wc.OpenRead(cbRssUrl.Text);

                var xdoc = XDocument.Load(stream);
                xTitle = xdoc.Root.Descendants("item").Select(x => (string)x.Element("title"));

                foreach (var data in xTitle) {
                    lbRssTitle.Items.Add(data);

                }
                cbRssUrl.Items.Add(cbRssUrl.Text);
            }
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            var index = lbRssTitle.SelectedIndex;

            using (var wc = new WebClient()) {
                var stream = wc.OpenRead(cbRssUrl.Text);
                
                var xdoc = XDocument.Load(stream);
                var xNews = xdoc.Root.Descendants("item").Select(x => (string)x.Element("link"));
                var linklist = new List<string>(xNews);

                foreach (var link in xNews) {
                    wbBrowser.Url = new Uri(linklist[index]);
                }
            }
        }
    }
}
