using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            //var ym = new YearMonth(2022, 5);

            //var check = ym.Is21Century;
            //var test = ym.AddOneMonth();

            //Console.WriteLine(ym);

            //4.2.1
            var ymCollection = new YearMonth[] {

                new YearMonth(1990,1),
                new YearMonth(2000,2),
                new YearMonth(2016,3),
                new YearMonth(2021,4),
                new YearMonth(2022,12),

            }; 

            //4.2.2
            Exercise2_2(ymCollection);
            Console.WriteLine("------------------");

            //4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("------------------");

            //4.2.5
            Exercise2_5(ymCollection);
            Console.WriteLine("------------------");

            //4.2.6
            Exercise2_6(ymCollection);
            Console.WriteLine("------------------");
        }

        //4.2.3
        //最初に見つかった21世紀のオブジェクトを返す
        //見つからない場合はnullを返す
        static YearMonth FindFirst21C(YearMonth[] yms) {
            foreach (var ym in yms) {
                if (ym.Is21Century is true) {
                    return ym;

                }
            }
            return null;
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }

        private static void Exercise2_4(YearMonth[] ymCollection) {
            if(FindFirst21C(ymCollection) is null) {
                Console.WriteLine("21世紀のデータはありません");
            }
            else {
                Console.WriteLine(FindFirst21C(ymCollection));
            }
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in array) {
                Console.WriteLine(ym);

            }
        }

        private static void Exercise2_6(YearMonth[] ymCollection) {

            //①月で昇順に出力、②偶数年のみ昇順に出力
            foreach (var ym in ymCollection.Where(ym => ym.Year % 2 == 0).OrderBy(ym => ym.Month)) {
                Console.WriteLine(ym);

            }

            //③閏年
            Console.WriteLine("------------------");
            foreach (var ym in ymCollection.Where(ym => DateTime.IsLeapYear(ym.Year))) {
                Console.WriteLine(ym.Year);

            }

            //④すべての年から12月に一番近い月を出力
            Console.WriteLine("------------------");
            var max = ymCollection.Max(ym => ym.Month);
                Console.WriteLine(max);

        }

    }
}
