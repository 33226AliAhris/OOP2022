using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {

            var sales = new SalesCounter("sales.csv");

            while (true) {

                Console.WriteLine("売上高の表示選択");
                Console.WriteLine("1.店舗別");
                Console.WriteLine("2.商品カテゴリー別");
                Console.Write(">");
                int select = int.Parse(Console.ReadLine());

                if (select == 1) {
                    var amountPerStore = sales.GetPerStoreSales();
                    foreach (var obj in amountPerStore) {
                        Console.WriteLine("{0} {1}", obj.Key, obj.Value);
                    }
                }

                else if (select == 2) {
                    var amountPerStore = sales.GetPerProductSales();
                    foreach (var obj in amountPerStore) {
                        Console.WriteLine("{0} {1}", obj.Key, obj.Value);
                    }

                }else if(select == 999) {
                    return;
                }

                Console.WriteLine();
            }
        }
    }
}
