using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            //var novels = new Novel[] {
            //    new Novel {
            //    Author = "ジェイムズ・P・ホーガン",
            //    Title = "星を継ぐもの",
            //    Published = 1977,
            //    },

            //    new Novel {
            //    Author = "H・G",
            //    Title = "タイム・マシン",
            //    Published = 1895,
            //    },
            //};

            //var novelCollection = new NovelCollection {
            //    Novels = novels
            //};

            var settings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = "  ",
            };

            //逆シリアル化（リスト12-5）
            using (var reader = XmlReader.Create("novels.xml")) {
                var serializer = new XmlSerializer(typeof(NovelCollection));               
                var novels = serializer.Deserialize(reader) as NovelCollection;

                foreach (var novel in novels.Novels) {
                    Console.WriteLine(novel);
                }
            }

            //シリアル化（リスト12 - 6）
            //using (var writer = XmlWriter.Create("novels.xml")) {
            //    var serializer = new XmlSerializer(novelCollection.GetType());
            //    serializer.Serialize(writer, novelCollection);
            //}
        }
    }
}
