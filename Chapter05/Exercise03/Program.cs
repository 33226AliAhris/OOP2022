using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {
            var contains = text.Count(c => c == ' ');
            Console.WriteLine(contains);

        }

        private static void Exercise3_2(string text) {
            var replace = text.Replace("big", "small");
            Console.WriteLine(replace);
        }

        private static void Exercise3_3(string text) {
            var split = text.Split(' ').Length;
            Console.WriteLine(split);
        }

        private static void Exercise3_4(string text) {
            var count = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in count) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var words = text.Split(' ').ToArray();
          
            var sb = new StringBuilder(words[0]);
            sb.Append(words[0]);
            foreach (var word in words.Skip(1)) { 
                sb.Append(' ');
                sb.Append(word);
            }

            var convert = sb.ToString();
            Console.WriteLine(convert);
        }
    }
}
