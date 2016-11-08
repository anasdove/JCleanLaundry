using JCleanLaundry.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class TransaksiController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public TransaksiController()
        {
            _db = new JCleanLaundryEntities();
        }

        [HttpGet]
        public ActionResult MenuUtama()
        {
            return View();
        }

        [HttpGet]
        public ActionResult JenisTransaksi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Satuan()
        {
            var model = new CuciBaruViewModel
            {
                Barang = new BarangViewModel(),
                Pelanggan = new PelangganViewModel()
            };

            // List Tipe Cucian
            ViewBag.TipeCucian = new SelectList(_db.TipeCuciDbSet.OrderBy(x => x.Id), "Id", "Tipe");

            // List Barang
            ViewBag.BarangId = new SelectList(_db.BarangDbSet.Where(x => x.TipeCuciId == 1), "Id", "Nama");

            return View(model);
        }

        [HttpGet]
        public ActionResult Kiloan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pengambilan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Status()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pengecekan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Laporan()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult CekNoPelanggan(string noHp)
        {
            var pelanggan = _db.PelangganDbSet.FirstOrDefault(x => x.Hp == noHp);
            return Json(new { noHpAda = pelanggan != null, pelanggan }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TampilBarang(int tipeCuciId)
        {
            var daftarBarang = _db.BarangDbSet.Where(x => x.TipeCuciId == tipeCuciId).ToList();

            var barangDDL = new SelectList(daftarBarang, "Id", "Nama", 0);

            return Json(barangDDL, JsonRequestBehavior.AllowGet);
        }
    }
}
