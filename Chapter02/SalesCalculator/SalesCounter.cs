using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    public class SalesCounter {

        private List<Sale> _sales; //csvファイルから読み込んだデータ

        //コンストラクタ
        public SalesCounter(List<Sale> sales) {
            _sales = sales;

        }

        //店舗別売り上げを求める
        public Dictionary<String, int> GetPerStoreSales() {
            Dictionary<String, int> dict = new Dictionary<String, int>();
            foreach (Sale sale in _sales) {
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount;

                else

                    dict[sale.ShopName] = sale.Amount;
            }

            return dict;
        }
    }
}
