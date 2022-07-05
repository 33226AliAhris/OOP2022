using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var file = "sports.xml";

            Exercise1_1(file);
            Console.WriteLine();

            Exercise1_2(file);
            Console.WriteLine();

            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            //Exercise1_4(file, newfile);

            //確認用
            var text = File.ReadAllText(newfile);
            Console.WriteLine();
            Console.WriteLine(text);
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
            var ballSports = xdoc.Root.Elements()
                                 .Select(x => new { 
                                    Firstplayed = x.Element("firstplayed").Value,
                                    Name = x.Element("name").Attribute("kanji").Value
                                  })
                                  .OrderBy(x => int.Parse(x.Firstplayed));

            foreach (var sports in ballSports) {
                Console.WriteLine("{0}({1})",sports.Name,sports.Firstplayed);
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var ballSports = xdoc.Root.Elements()
                                 .Select(x => new {
                                     Teammembers = x.Element("teammembers").Value,
                                     Name = x.Element("name").Value,
                                 })
                                 .OrderByDescending(x => int.Parse(x.Teammembers)).First();

            Console.WriteLine(ballSports.Name);
        }

        private static void Exercise1_4(string file, string newfile) {
            var xdoc = XDocument.Load(file);
            var element = new XElement("ballsport",
                            new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                            new XElement("teammembers", "11"),
                            new XElement("firstplayed", "1863")
                );
            xdoc.Root.Add(element);
            xdoc.Save(newfile);

            //確認用
            foreach (var item in xdoc.Root.Elements()) {
                var name = item.Element("name").Value;
                var kanji = item.Element("name").Attribute("kanji").Value;
                var members = item.Element("teammembers").Value;
                var firstplayed = item.Element("firstplayed").Value;
                Console.WriteLine("{0}({1}) {2} {3}",name,kanji,members,firstplayed);
            }
        }
    }
}
