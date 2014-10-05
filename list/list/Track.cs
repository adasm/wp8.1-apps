using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    class Track
    {
        public string artist { get; set; }
        public string album { get; set; }
        public string trackName { get; set; }

        override public string ToString()
        {
            return artist + " - " + album + " : " + trackName;
        }

        public static List<Track> list = new List<Track> {
            new Track { artist = "Adele", album = "21", trackName = "Someone Like You" },
            new Track { artist = "Trivium", album = "Shogun", trackName = "The Calamity" },
            new Track { artist = "Metallica", album = "Load", trackName = "Mama Said" },
            new Track { artist = "Lady Gaga", album = "ARTPOP", trackName = "G.U.Y." },
            new Track { artist = "Kavinsky", album = "OutRun", trackName = "ProtoVision" }
        };
    }
}
