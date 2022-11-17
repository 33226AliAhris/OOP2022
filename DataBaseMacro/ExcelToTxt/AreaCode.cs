using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace WeatherAppNew {
    public class AreaCode {
        public string area { get; set; }
        public int code { get; set; }
    }
}
