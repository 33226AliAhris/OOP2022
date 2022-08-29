using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    class Program {
        static void Main(string[] args) {
            TextProcessor.Run<LineCounterProcessor>(@"C:\Users\infosys\source\repos\OOP2022\CarReportSystem\CarReportSystem\Form1.cs");
        }
    }
}
