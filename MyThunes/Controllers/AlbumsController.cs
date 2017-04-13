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
    public class AlbumsController : Controller
    {
        private MyThunesDbContext db = new MyThunesDbContext();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist);
            return View(albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        [Authorize]
        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name");
            return View();
        }

        // POST: Albums/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name,Date,ArtistID,Genre,Price")] Album album, HttpPostedFileBase cover)
        {
            if (ModelState.IsValid)
            {
                if (cover != null && cover.ContentLength > 0 && cover.ContentType.Split('/')[0] == "image")
                {
                    var fileName = "alb_" + ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString() + "_" + album.Name + Path.GetExtension(cover.FileName);
                    album.Cover = "Uploads/Album/" + fileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads/Album"), fileName);
                    cover.SaveAs(path);
                }
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name", album.ArtistID);
            return View(album);
        }

        // GET: Albums/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name", album.ArtistID);
            return View(album);
        }

        // POST: Albums/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Name,Date,ArtistID,Genre,Price")] Album album, HttpPostedFileBase cover)
        {
            if (ModelState.IsValid)
            {
                if (cover != null && cover.ContentLength > 0 && cover.ContentType.Split('/')[0] == "image")
                {
                    var fileName = "alb_" + ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString() + "_" + album.Name + Path.GetExtension(cover.FileName);
                    album.Cover = "Uploads/Album/" + fileName;
                    string path = Path.Combine(Server.MapPath("~/Uploads/Album"), fileName);
                    cover.SaveAs(path);
                }
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ID", "Name", album.ArtistID);
            return View(album);
        }

        // GET: Albums/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);

            if (album.Cover != String.Empty)
            {
                string fullPath = Path.Combine(Server.MapPath("~/Uploads/Album"), album.Cover.Split('/')[2]);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                } 
            }
            db.Albums.Remove(album);
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
