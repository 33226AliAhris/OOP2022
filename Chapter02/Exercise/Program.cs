using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise {
    class Program {
        static void Main(string[] args) {

            //2.1.3
            var songs = new List<Song> {

               new Song("A", "B", 100),
               new Song("C", "D", 120),
               new Song("E", "F", 140),
               new Song("G", "H", 160),
               new Song("I", "J", 180),

            };
            
            PrintSongs(songs);
        
        }
        //2.1.4
        private static void PrintSongs(List<Song> songs) {

            foreach (var song in songs) {
                var t = TimeSpan.FromSeconds(song.Length); 
                Console.WriteLine("{0},{1},{2:m\\:ss}",song.Title,song.ArtistName,t);

            }
        }
    }
}
