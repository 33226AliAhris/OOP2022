using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            Console.Write("文字列１を入力：");
            var input1 = Console.ReadLine();
            Console.Write("文字列２を入力：");
            var input2 = Console.ReadLine();

            if(String.Compare(input1,input2,ignoreCase:true) == 0) {
                Console.WriteLine("等しい");
            }
            else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
