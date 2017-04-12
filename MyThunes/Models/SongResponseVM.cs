using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyThunes.Models
{
    public class SongResponseVM
    {
        public int SongsCounter { get; set; }
        public int FilteredSongsCounter { get; set; }
        public List<Song> Songs { get; set; }
        public List<string> SongGenres { get; set; }
    }
}