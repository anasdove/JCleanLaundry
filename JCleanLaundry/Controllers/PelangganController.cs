﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JCleanLaundry.Models;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class PelangganController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public PelangganController()
        {
            _db = new JCleanLaundryEntities();
        }
        
        public ActionResult Index()
        {
            var model = _db.Pelanggans.Select(x => new PelangganViewModel
            {
                Alamat = x.Alamat,
                Hp = x.Hp,
                Kode = x.Kode,
                Nama = x.Nama,
                NoKtp = x.NoKtp
            }).ToList();

            return View(model);
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pelanggan = _db.Pelanggans.Find(id);

            if (pelanggan == null) return HttpNotFound();

            var model = new PelangganViewModel
            {
                Alamat = pelanggan.Alamat,
                Hp = pelanggan.Hp,
                Kode = pelanggan.Kode,
                Nama = pelanggan.Nama,
                NoKtp = pelanggan.NoKtp
            };

            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PelangganViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var pelanggan = new Pelanggan
            {
                Alamat = model.Alamat,
                Hp = model.Hp,
                Nama = model.Nama,
                NoKtp = model.NoKtp
            };

            _db.Pelanggans.Add(pelanggan);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pelanggan = _db.Pelanggans.Find(id);

            if (pelanggan == null) return HttpNotFound();

            var model = new PelangganViewModel
            {
                Alamat = pelanggan.Alamat,
                Hp = pelanggan.Hp,
                Kode = pelanggan.Kode,
                Nama = pelanggan.Nama,
                NoKtp = pelanggan.NoKtp
            };

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PelangganViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var pelanggan = new Pelanggan
            {
                Kode = model.Kode,
                Alamat = model.Alamat,
                Hp = model.Hp,
                Nama = model.Nama,
                NoKtp = model.NoKtp
            };

            _db.Entry(pelanggan).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Pelanggan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pelanggan = _db.Pelanggans.Find(id);

            if (pelanggan == null) return HttpNotFound();

            return View(pelanggan);
        }

        // POST: Pelanggan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pelanggan = _db.Pelanggans.Find(id);

            _db.Pelanggans.Remove(pelanggan);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
