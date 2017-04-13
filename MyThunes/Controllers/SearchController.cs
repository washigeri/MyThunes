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

        // GET: Search
        public ActionResult Index(string searchbar)
        {
            SearchResponseVM searchResponseVM = new SearchResponseVM();
            if(!string.IsNullOrEmpty(searchbar))
            {
                searchResponseVM.Songs = db.Songs.Where(c => c.Name.Contains(searchbar)).ToList();
                searchResponseVM.SongsCounter = searchResponseVM.Songs.Count;
                searchResponseVM.Albums = db.Albums.Where(c => c.Name.Contains(searchbar)).ToList();
                searchResponseVM.AlbumsCounter = searchResponseVM.Albums.Count;
                searchResponseVM.Artists = db.Artists.Where(c => c.Name.Contains(searchbar)).ToList();
                searchResponseVM.ArtistsCounter = searchResponseVM.Artists.Count;
            }
            return View(searchResponseVM);
        }
    }
}