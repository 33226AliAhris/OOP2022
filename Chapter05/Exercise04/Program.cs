using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var split = line.Split(';', '=');

            var noveList = String.Format("{0}: {1}", ToJapanese(split[0]), split[1]);
            var bestWork = String.Format("{0}: {1}", ToJapanese(split[2]), split[3]);
            var born = String.Format("{0}: {1}", ToJapanese(split[4]), split[5]);

            Console.WriteLine("{0} \n{1} \n{2}", noveList,bestWork,born);

        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家　";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
            }
            throw new ArgumentException("引数keyは、正しい値ではありません");
        }
    }
}
