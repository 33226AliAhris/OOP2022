using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppNew {

    public class Rootobject {
        public DateTime publicTime { get; set; }
        public string publicTimeFormatted { get; set; }
        public string publishingOffice { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public Description description { get; set; }
        public Forecast[] forecasts { get; set; }
        public Location location { get; set; }
        public Copyright copyright { get; set; }
    }

    public class Description {
        public DateTime publicTime { get; set; }
        public string publicTimeFormatted { get; set; }
        public string headlineText { get; set; }
        public string bodyText { get; set; }
        public string text { get; set; }
    }

    public class Location {
        public string area { get; set; }
        public string prefecture { get; set; }
        public string district { get; set; }
        public string city { get; set; }
    }

    public class Copyright {
        public string title { get; set; }
        public string link { get; set; }
        public Image image { get; set; }
        public Provider[] provider { get; set; }
    }

    public class Image {
        public string title { get; set; }
        public string link { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Provider {
        public string link { get; set; }
        public string name { get; set; }
        public string note { get; set; }
    }

    public class Forecast {
        public string date { get; set; }
        public string dateLabel { get; set; }
        public string telop { get; set; }
        public Detail detail { get; set; }
        public Temperature temperature { get; set; }
        public Chanceofrain chanceOfRain { get; set; }
        public Image1 image { get; set; }
    }

    public class Detail {
        public string weather { get; set; }
        public string wind { get; set; }
        public string wave { get; set; }
    }

    public class Temperature {
        public Min min { get; set; }
        public Max max { get; set; }
    }

    public class Min {
        public string celsius { get; set; }
        public string fahrenheit { get; set; }
    }

    public class Max {
        public string celsius { get; set; }
        public string fahrenheit { get; set; }
    }

    public class Chanceofrain {
        public string T00_06 { get; set; }
        public string T06_12 { get; set; }
        public string T12_18 { get; set; }
        public string T18_24 { get; set; }
    }

    public class Image1 {
        public string title { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
