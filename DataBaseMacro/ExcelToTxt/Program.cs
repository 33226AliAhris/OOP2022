using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToTxt {
    class Program {
        static void Main(string[] args) {

            string file = @"C:\Users\infosys\Documents\SampleTest.txt";

            if (File.Exists(file)) {
                // Store each line in array of strings
                string[] lines = File.ReadAllLines(file);
                IEnumerable<string> enum_strings = new List<string>() { lines[0] };
                string joined_enum = string.Join(",''", enum_strings);
                Console.WriteLine(joined_enum);
            }


            //IEnumerable<string> enum_strings = new List<string>() { lines};
            //string joined_enum = string.Join(",''", enum_strings);
            //Console.WriteLine(joined_enum);
        
        }
    }
}
