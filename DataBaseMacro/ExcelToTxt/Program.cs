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
        static void Main(string[] args) {

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };
            using (var reader = new StreamReader(@"C:\Users\infosys\Documents\areacode.csv",Encoding.GetEncoding("Shift_JIS")))
            using (var csv = new CsvReader(reader, csvConfig)) {

                var records = csv.GetRecords<AreaCode>().ToList();
                var area = Console.ReadLine();

                foreach (var item in records) {
                    if (item.area == area) {
                        Console.WriteLine(item.code);
                    }
                }
                //while (csv.Read()) {
                //    var area = csv.GetField(0);
                //    var code = csv.GetField(1);

                //    Console.WriteLine($"{area} {code}");
                //}
            }

        }
    }
}
