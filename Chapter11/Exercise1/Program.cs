using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var file = "sample.xml";

            Exercise1_1(file);
            Console.WriteLine();

            Exercise1_2(file);
            Console.WriteLine();

            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);
        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var ballSports = xdoc.Root.Elements()
                                  .Select(x => new { 
                                    Name = x.Element("name").Value,
                                    Members = x.Element("teammembers").Value
                                   });

            foreach (var sports in ballSports) {
                Console.WriteLine("{0} {1}",sports.Name,sports.Members);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var ballSports = xdoc.Root.Elements().OrderBy(x => (string)x.Element("firstplayed"));

            foreach (var sports in ballSports) {
                var name = sports.Element("name").Attribute("kanji").Value;
                var year = sports.Element("firstplayed").Value;
                Console.WriteLine("{0}({1})",name,year);
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var ballSports = xdoc.Root.Elements().Max(x => x.Element("teammembers"));

            //foreach (var sports in ballSports) {
            //    var name = sports.Element("name");

            //}
        }

        private static void Exercise1_4(string file, string newfile) {

        }

    }
}
