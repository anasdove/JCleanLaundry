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
            var model = new SatuanViewModel
            {
                Barang = new BarangViewModel(),
                Pelanggan = new PelangganViewModel()
            };

            ViewBag.TipeCucian = new SelectList(_db.TipeCuciDbSet.OrderBy(x => x.Id), "Id", "Tipe");

            var daftarBarang = _db.BarangDbSet.Where(x => x.TipeCuciId == 1).Select(x => new BarangViewModel
            {
                Id = x.Id,
                Nama = x.Nama,
                Harga = x.Harga,
                TipeCuciId = x.TipeCuciId
            }).ToList();

            daftarBarang.Insert(0, new BarangViewModel { Id = 0, Nama = "-- Pilih Barang --" });

            ViewBag.BarangId = new SelectList(daftarBarang, "Id", "Nama");

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
            var daftarBarang = _db.BarangDbSet.Where(x => x.TipeCuciId == tipeCuciId).Select(x => new BarangViewModel{
                                                                                                       Id = x.Id,
                                                                                                       Nama = x.Nama
                                                                                                    }).ToList();

            daftarBarang.Insert(0, new BarangViewModel { Id = 0, Nama = "-- Pilih Barang --" });

            var barangDDL = new SelectList(daftarBarang, "Id", "Nama", 0);            

            return Json(barangDDL, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CariHarga(int kodeBarang)
        {
            var daftarBarang = _db.BarangDbSet.Where(x => x.Id == kodeBarang).SingleOrDefault();

            return Json(daftarBarang.Harga, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SimpanTransaksiSatuan(string[][] daftarCucian)
        {
            var daftarDetail = new List<ProsesSatuanDetailViewModel>();

            for(var i = 0; i < daftarCucian.Length; i++)
            {
                var detail = new ProsesSatuanDetailViewModel
                {
                    KodeBarang  = int.Parse(daftarCucian[i][0]),
                    Jumlah      = int.Parse(daftarCucian[i][1])
                };

                daftarDetail.Add(detail);
            }

            var prosesSatuan = new ProsesSatuanViewModel
            {
                Pelanggan   = new PelangganViewModel
                {
                    Nama    = daftarCucian[0][2],
                    Hp      = daftarCucian[0][3],
                    NoKtp   = daftarCucian[0][4],
                    Alamat  = daftarCucian[0][5]
                },
                UangMuka    = int.Parse(daftarCucian[0][6]),
                Detail      = daftarDetail
            };
            
            return null;
        }
    }
}
