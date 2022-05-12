using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("売上高の表示選択");
            Console.WriteLine("1.店舗別");
            Console.WriteLine("2.商品カテゴリー別");
            Console.Write(">");
            int select = int.Parse(Console.ReadLine());

            var sales = new SalesCounter("sales.csv");

            if (select == 1) {
                var amountPerStore = sales.GetPerStoreSales();
                foreach (var obj in amountPerStore) {
                    Console.WriteLine("{0} {1}", obj.Key, obj.Value);
                }
            }

            else {
                var amountPerProduct = sales.GetPerProductSales();
                foreach (var obj in amountPerProduct) {
                    Console.WriteLine("{0} {1}", obj.Key, obj.Value);

                }
            }
        }
    }
}
