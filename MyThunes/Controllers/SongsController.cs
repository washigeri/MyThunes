using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyThunes.Models;
using System.IO;

namespace MyThunes.Controllers
{
    public class SongsController : Controller
    {
        private MyThunesDbContext db = new MyThunesDbContext();

        // GET: Songs
        public ActionResult Index(string song, string album, string artist, string genre)
        {
            var songs = db.Songs.Include(s => s.Album).ToList();
            var filteredSongs = db.Songs.Include(s => s.Album).ToList();
            if (!string.IsNullOrEmpty(song))
            {
                filteredSongs = filteredSongs.Where(c => c.Name.Contains(song)).ToList();
            }
            if(!string.IsNullOrEmpty(album))
            {
                filteredSongs = filteredSongs.Where(c => c.Album.Name.Contains(album)).ToList();
            }
            if(!string.IsNullOrEmpty(artist))
            {
                filteredSongs = filteredSongs.Where(c => c.Album.Artist.Name.Contains(artist)).ToList();
            }
            if(!string.IsNullOrEmpty(genre))
            {
                filteredSongs = filteredSongs.Where(c => c.Genre == genre).ToList();
            }
            SongResponseVM songResponseVM = new SongResponseVM()
            {
                SongsCounter = songs.Count,
                FilteredSongsCounter = filteredSongs.Count,
                Songs = filteredSongs,
                SongGenres = db.Songs.Select(c => c.Genre).Distinct().ToList()
            };
            return View(songResponseVM);
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name");
            return View();
        }

        // POST: Songs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ReleaseDate,Genre,Price,Format,AlbumID")] Song song, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0 && file.ContentType.Split('/')[0] == "audio")
                {
                    var fileName = "song_" + ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString() + "_" + song.Name + Path.GetExtension(file.FileName);
                    song.Path = "Uploads/Song/" + fileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads/Song"), fileName);
                    file.SaveAs(path);
                }
                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name", song.AlbumID);
            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name", song.AlbumID);
            return View(song);
        }

        // POST: Songs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ReleaseDate,Genre,Price,Format,Path,AlbumID")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name", song.AlbumID);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
