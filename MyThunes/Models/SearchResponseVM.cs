using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyThunes.Models
{
    public class SearchResponseVM
    {
        public List<Song> Songs { get; set; }
        public int SongsCounter { get; set; }
        public List<Artist> Artists { get; set; }
        public int ArtistsCounter { get; set; }
        public List<Album> Albums { get; set; }
        public int AlbumsCounter { get; set; }
    }
}