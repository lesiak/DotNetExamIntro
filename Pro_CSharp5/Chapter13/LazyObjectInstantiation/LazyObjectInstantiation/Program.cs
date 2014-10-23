using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation {
    class Program {
        static void Main(string[] args) {
            MediaPlayer mp = new MediaPlayer();
            mp.Play();
            mp.GetAllTracks();
            Console.ReadLine();
        }
    }

    class MediaPlayer {

        //private Lazy<AllTracks> allTracks = new Lazy<AllTracks>();

        private Lazy<AllTracks> allTracks = new Lazy<AllTracks>(() => {
            Console.WriteLine("Creating alltracks in lazy");
            return new AllTracks();
        });

        public void Play() { }
        public void Pause() { }
        public void Stop() { }

        public AllTracks GetAllTracks() {
            return allTracks.Value;
        }
    }

    class AllTracks {

        private Song[] allSongs = new Song[10000];

        public AllTracks() {
            Console.WriteLine("Filling up the songs");
        }
    }

    class Song {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public string TrackLength { get; set; }
    }

  

    

    
}
