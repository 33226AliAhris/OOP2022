using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            Exersice1_1(numbers);
            Console.WriteLine("------------------");

            Exersice1_2(numbers);
            Console.WriteLine("------------------");

            Exersice1_3(numbers);
            Console.WriteLine("------------------");

            Exersice1_4(numbers);
            Console.WriteLine("------------------");

        }

        private static void Exersice1_1(List<int> numbers) {
            var exists = numbers.Exists(n => n % 8 == 0 || n % 9 == 0);
            Console.WriteLine(exists);
        }

        private static void Exersice1_2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2.0));
        }

        private static void Exersice1_3(List<int> numbers) {
            var query = numbers.Where(n => n >= 50);
            foreach (var n in query) {
                Console.WriteLine(n);
            }
        }

        private static void Exersice1_4(List<int> numbers) {
            var list = numbers.Select(n => n * 2).ToList();

            numbers[5] = 5000;
            foreach (var n in list) {
                Console.WriteLine(n);

            }            
        }
    }
}
