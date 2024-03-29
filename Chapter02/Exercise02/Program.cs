﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice02 {
    class Program {
        static void Main(string[] args) {

            if (args.Length >= 1 && args[0] == "-tom")

                PrintMeterToInchlist(1, 10);

            else

                PrintInchToMeterList(1, 10);

        }

        //メートルからインチへの対応表を出力
        private static void PrintMeterToInchlist(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine("{0}m = {1:0.0000}in", meter, inch);
                 
            }
        }
        //インチからメートルへの対応表を出力
        private static void PrintInchToMeterList(int start, int stop) {
            for (int inch = start; inch <= stop; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine("{0}in = {1:0.0000}m", inch, meter);

            }
        }
    }
}
