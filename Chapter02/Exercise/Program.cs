using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise {
    class Program {
        static void Main(string[] args) {

            var songs = new List<Song> {

               new Song("A", "B", 100),
               new Song("C", "D", 120),
               new Song("E", "F", 140),
               new Song("G", "H", 160),
               new Song("I", "J", 180)

            };
            PrintSongs(songs);
        }

        private static void PrintSongs(List<Song> songs) {

            //songs[0].ForEach(Console.WriteLine);
            Console.WriteLine(songs[3]);
        }
    }
}
