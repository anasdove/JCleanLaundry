﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JCleanLaundry.Models;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class BarangController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public BarangController()
        {
            _db = new JCleanLaundryEntities();
        }

        public ActionResult Index()
        {
            var models = _db.Barangs.Include(x => x.TipeCuciFK).OrderBy(x => x.Nama).Select(x => new BarangViewModel
            {
                Harga   = x.Harga,
                Kode    = x.Kode,
                Nama    = x.Nama,
                TipeCuci = new TipeCuciViewModel
                {
                    Kode = x.TipeCuciFK.Kode,
                    Tipe = x.TipeCuciFK.Tipe
                }
            }).OrderBy(x => x.Nama).ToList();

            return View(models);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var barang = _db.Barangs.Find(id);

            if (barang == null) return HttpNotFound();

            return View(barang);
        }

        public ActionResult Create()
        {
            ViewBag.KodeTipeCuci = new SelectList(_db.TipeCucis, "Kode", "Tipe");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BarangViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KodeTipeCuci = new SelectList(_db.TipeCucis, "Kode", "Tipe", model.KodeTipeCuci);

                return View(model);
            }

            var barang = new Barang
            {
                Harga           = model.Harga,
                Nama            = model.Nama,
                KodeTipeCuci    = model.KodeTipeCuci
            };

            _db.Barangs.Add(barang);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var barang = _db.Barangs.Find(id);

            if (barang == null)
            {
                return HttpNotFound();
            }

            var model = new BarangViewModel
            {
                Kode            = barang.Kode,
                Harga           = barang.Harga,
                Nama            = barang.Nama,
                KodeTipeCuci    = barang.KodeTipeCuci
            };

            ViewBag.KodeTipeCuci = new SelectList(_db.TipeCucis, "Kode", "Tipe", barang.KodeTipeCuci);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BarangViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KodeTipeCuci = new SelectList(_db.TipeCucis, "Kode", "Tipe", model.KodeTipeCuci);

                return View(model);
            }

            var barang = new Barang
            {
                Kode            = model.Kode,
                Harga           = model.Harga,
                Nama            = model.Nama,
                KodeTipeCuci    = model.KodeTipeCuci
            };

            _db.Entry(barang).State = EntityState.Modified;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var barang = _db.Barangs.Find(id);

            if (barang == null)
            {
                return HttpNotFound();
            }

            return View(barang);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var barang = _db.Barangs.Find(id);

            _db.Barangs.Remove(barang);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
