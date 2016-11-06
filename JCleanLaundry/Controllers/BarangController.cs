using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
            return View(_db.BarangDbSet.Include(b => b.TipeCuciFK).OrderBy(x => x.Nama).ToList());
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
        public ActionResult Create([Bind(Include = "Id,Nama,Harga,TipeCuciId")] Barang barang)
        {
            if (ModelState.IsValid)
            {
                _db.BarangDbSet.Add(barang);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe", barang.TipeCuciId);
            return View(barang);
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var barang = _db.BarangDbSet.Find(id);

            if (barang == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe", barang.TipeCuciId);

            return View(barang);
        }

        // POST: Barang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nama,Harga,TipeCuciId")] Barang barang)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(barang).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.TipeCuciId = new SelectList(_db.TipeCuciDbSet, "Id", "Tipe", barang.TipeCuciId);

            return View(barang);
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
