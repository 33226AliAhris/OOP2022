using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[]{2, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35,};

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            var max = numbers.Max();
            Console.WriteLine(max);
        }

        private static void Exercise1_2(int[] numbers) {
            var index = numbers.Skip(9);
            foreach (var item in index) {
                Console.WriteLine(item);
            }

        }

        private static void Exercise1_3(int[] numbers) {
            var convert = numbers.Select(n => n.ToString());
            foreach (var item in convert) {
                Console.WriteLine(item);                                                                                                                            
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var order = numbers.OrderBy(n => n).Take(3);
            foreach (var item in order) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise1_5(int[] numbers) {
            var distinct = numbers.Distinct().Count(n => n >= 10);
            Console.WriteLine(distinct);
        }
    }
}
