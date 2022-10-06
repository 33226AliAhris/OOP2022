using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15 {
    class Program {
        static void Main(string[] args) {

            var years = new List<int>();
            int year;

            Console.WriteLine("出力したい西暦を入力（終了：-1）");
            year = int.Parse(Console.ReadLine());
            while (year != -1) {
                years.Add(year);
                year = int.Parse(Console.ReadLine());
            }

            int sort;

            Console.WriteLine();
            Console.Write("昇順：1 降順：2 ：");
            sort = int.Parse(Console.ReadLine());

            IEnumerable<Book> books;
            //昇順
            if (sort == 1) {
                books = Library.Books
                    .Where(b => years.Contains(b.PublishedYear))
                    .OrderBy(b => b.PublishedYear);
            }
            //降順
            else { 
                books = Library.Books
                    .Where(b => years.Contains(b.PublishedYear))
                    .OrderByDescending(b => b.PublishedYear);
            }

            //var years = new int[] { 2013, 2016 };
            foreach (var book in books) {
                Console.WriteLine(book);
            }

            Console.WriteLine();
            var selected = Library.Books
                .OrderByDescending(o => o.PublishedYear)
                .ThenBy(b => b.CategoryId)
                .Join(Library.Categories,           //結合する2番目のシーケンス
                      book => book.CategoryId,      //対象シーケンスの結合キー
                      category => category.Id,      //2番目のシーケンスの結合キー
                      (book, category) => new {
                          Title = book.Title,
                          Category = category.Name,
                          PublishedYear = book.PublishedYear
                      });

            foreach (var book in selected) {
                foreach (var y in years) {
                    if (y == book.PublishedYear) {
                        Console.WriteLine($" {book.PublishedYear},{book.Title},{book.Category}");
                    }
                }            
            }
        }
    }
}
