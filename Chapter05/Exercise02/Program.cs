using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            int num;
            Console.Write("数字文字列を入力：");
            var input1 = Console.ReadLine();

            if(int.TryParse(input1,out num)){
                Console.WriteLine(int.Parse(input1).ToString("0,0"));
            }
            else {
                Console.WriteLine("変換できない文字列が含まれている");
            }
        }
    }
}
