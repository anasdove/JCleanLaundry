using System.Data.Entity;
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
            var models = _db.BarangDbSet.Include(x => x.TipeCuciFK).OrderBy(x => x.Nama).Select(x => new BarangViewModel
            {
                Harga = x.Harga,
                Id = x.Id,
                Nama = x.Nama,
                TipeCuci = new TipeCuciViewModel
                {
                    Id = x.TipeCuciFK.Id,
                    Tipe = x.TipeCuciFK.Tipe
                }
            }).OrderBy(x => x.Nama).ToList();

            return View(models);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var barang = _db.BarangDbSet.Find(id);
            if (barang == null) return HttpNotFound();
            return View(barang);
        }

        // GET: Barang/Create
        public ActionResult Create()
        {
            ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BarangViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe", model.TipeCuciId);
                return View(model);
            }

            var barang = new Barang
            {
                Harga = model.Harga,
                Nama = model.Nama,
                TipeCuciId = model.TipeCuciId
            };

            _db.BarangDbSet.Add(barang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var barang = _db.BarangDbSet.Find(id);

            if (barang == null)
            {
                return HttpNotFound();
            }

            var model = new BarangViewModel
            {
                Id = barang.Id,
                Harga = barang.Harga,
                Nama = barang.Nama,
                TipeCuciId = barang.TipeCuciId
            };

            ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe", barang.TipeCuciId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BarangViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe", model.TipeCuciId);
                return View(model);
            }

            var barang = new Barang
            {
                Id = model.Id,
                Harga = model.Harga,
                Nama = model.Nama,
                TipeCuciId = model.TipeCuciId
            };

            _db.Entry(barang).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Barang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var barang = _db.BarangDbSet.Find(id);

            if (barang == null)
            {
                return HttpNotFound();
            }

            return View(barang);
        }

        // POST: Barang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var barang = _db.BarangDbSet.Find(id);

            _db.BarangDbSet.Remove(barang);

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
