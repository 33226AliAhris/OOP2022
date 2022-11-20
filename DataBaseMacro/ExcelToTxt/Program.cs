using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppNew;

namespace ExcelToTxt {
    class Program {
        static void Main(string[] args)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",

            };

            //CSVファイルからデータを読み込み
            using (var reader = new StreamReader(@"C:\Users\Buddy\Downloads\riseandset.csv", Encoding.GetEncoding("Shift_JIS")))
            using (var csv = new CsvReader(reader, csvConfig))
            {

                var records = csv.GetRecords<RiseAndSet>().ToList();
                var area = "沖縄県";
                double latitude = 0;
                foreach (var item in records)
                {
                    if (item.area == area)
                    {
                        latitude = item.lat;
                        Console.WriteLine(latitude);
                    }
                }
            }
        }
    }
}
