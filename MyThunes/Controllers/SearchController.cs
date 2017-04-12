using MyThunes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyThunes.Controllers
{
    public class SearchController : Controller
    {

        private MyThunesDbContext db = new MyThunesDbContext();

        [HttpGet]
        public ActionResult Index(String songName, String albumName, String artistName)
        {
            IEnumerable<Song> filteredSongs = db.Songs.ToList();
            if (songName != null)
            {
                filteredSongs = filteredSongs.Where(c => c.Name.Contains(songName));
            }
            if (albumName != null)
            {
                filteredSongs = filteredSongs.Where(c => c.Album.Name.Contains(albumName));
            }
            if (artistName != null)
            {
                filteredSongs = filteredSongs.Where(c => c.Album.Artist.Name.Contains(artistName));
            }
            return View(filteredSongs);
        }
    }
}