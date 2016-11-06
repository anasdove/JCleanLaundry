using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JCleanLaundry;

namespace JCleanLaundry.Controllers
{
    public class PelangganController : Controller
    {
        private JCleanLaundryEntities db = new JCleanLaundryEntities();

        // GET: Pelanggan
        public ActionResult Index()
        {
            return View(db.PelangganDbSet.ToList());
        }

        // GET: Pelanggan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pelanggan = db.PelangganDbSet.Find(id);

            if (pelanggan == null)
            {
                return HttpNotFound();
            }

            return View(pelanggan);
        }

        // GET: Pelanggan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelanggan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nama,Hp,NoKtp,Alamat")] Pelanggan pelanggan)
        {
            if (!ModelState.IsValid) return View(pelanggan);

            db.PelangganDbSet.Add(pelanggan);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Pelanggan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pelanggan = db.PelangganDbSet.Find(id);

            if (pelanggan == null)
            {
                return HttpNotFound();
            }
            return View(pelanggan);
        }

        // POST: Pelanggan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nama,Hp,NoKtp,Alamat")] Pelanggan pelanggan)
        {
            if (!ModelState.IsValid) return View(pelanggan);

            db.Entry(pelanggan).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Pelanggan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pelanggan = db.PelangganDbSet.Find(id);

            if (pelanggan == null)
            {
                return HttpNotFound();
            }

            return View(pelanggan);
        }

        // POST: Pelanggan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pelanggan = db.PelangganDbSet.Find(id);

            db.PelangganDbSet.Remove(pelanggan);

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
