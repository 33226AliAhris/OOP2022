using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {

            Exercise1_2();
            Console.WriteLine();

            Exercise1_3();
            Console.WriteLine();

            Exercise1_4();
            Console.WriteLine();

            Exercise1_5();
            Console.WriteLine();

            Exercise1_6();
            Console.WriteLine();

            Exercise1_7();
            Console.WriteLine();

            Exercise1_8();
            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max(p => p.Price);
            var select = Library.Books.First(b => b.Price == max);
            Console.WriteLine(select);
        }

        private static void Exercise1_3() {
            var count = Library.Books.GroupBy(g => g.PublishedYear)
                .Select(g => new {PublishedYear = g.Key, Count = g.Count() })
                .OrderBy(o => o.PublishedYear);
            foreach (var item in count) {             
                Console.WriteLine($"{item.PublishedYear}年 {item.Count}冊");               
            }
        }

        private static void Exercise1_4() {
            var selected = Library.Books
                .Select(b => b)
                .Join(Library.Categories,          
                      book => book.CategoryId,      
                      category => category.Id,      
                      (book, category) => new {
                          Title = book.Title,
                          Category = category.Name,
                          PublishedYear = book.PublishedYear,
                          Price = book.Price
                      });
            foreach (var book in selected
                                    .OrderByDescending(x => x.PublishedYear)
                                    .ThenByDescending(x => x.Price)) {

                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title} ({book.Category})");
            }
        }

        private static void Exercise1_5() {
            var selected = Library.Books
                .Where(b => b.PublishedYear == 2016)
                .Join(Library.Categories,           
                      book => book.CategoryId,      
                      category => category.Id,      
                      (book, category) => category.Name)
                .Distinct();

            foreach (var item in selected) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise1_6() {
            var group = Library.Books
                               .Join(Library.Categories,
                                     book => book.CategoryId,
                                     category => category.Id,
                                     (book, category) => new {
                                         Title = book.Title,
                                         CategoryName = category.Name
                                     })
                               .GroupBy(x => x.CategoryName)
                               .OrderBy(x => x.Key);
            foreach (var item in group) {
                Console.WriteLine($"#{item.Key}");
                foreach (var items in item) {
                    Console.WriteLine($" {items.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var categoryId = Library.Categories.Single(c => c.Name == "Development").Id;
            var groups = Library.Books
                                .Where(b => b.CategoryId == categoryId)
                                .GroupBy(b => b.PublishedYear)
                                .OrderBy(b => b.Key);

            foreach (var item in groups) {
                Console.WriteLine($"#{item.Key}");
                foreach (var items in item) {
                    Console.WriteLine($" {items.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var groups = Library.Categories
                                .GroupJoin(Library.Books,
                                           c => c.Id,
                                           b => b.CategoryId,
                                           (c, books) => new {
                                               Category = c.Name,
                                               Count = books.Count()
                                           });
            foreach (var item in groups.Where(c => c.Count >= 4)){
                Console.WriteLine(item.Category);
            }
        }
    }
}
