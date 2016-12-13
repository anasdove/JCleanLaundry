using JCleanLaundry.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class CekSatuanController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public CekSatuanController()
        {
            _db = new JCleanLaundryEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TampilTransaksi()
        {
            var daftarTransaksi = _db.TransaksiSatuans.Where(x => x.StatusTransaksi != "Selesai").Select(x => new ProsesSatuanViewModel
            {
                Kode = x.Kode,
                TanggalMasuk = x.TanggalMasuk,
                NamaCounter = x.CounterFK.Nama
            }).ToList();

            return Json(daftarTransaksi, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TampilDetil(string kodeTransaksi)
        {
            var daftarTransaksi = _db.TransaksiSatuans.SingleOrDefault(x => x.Kode == kodeTransaksi);

            var model = new CekSatuanViewModel
            {
                Kode = daftarTransaksi.Kode,
                TotalBayar = daftarTransaksi.TotalBayar,
                Staff = User.Identity.GetUserId()
            };

            var daftarDetilModel = new List<CekSatuanDetilViewModel>();

            foreach (var detil in daftarTransaksi.TransaksiSatuanDetilFK)
            {
                var detilModel = new CekSatuanDetilViewModel
                {
                    KodeBarang = detil.KodeBarang,
                    Jumlah = detil.Jumlah,
                    Barang = new BarangViewModel
                    {
                        Nama = detil.BarangFK.Nama,
                        TipeCuci = new TipeCuciViewModel
                        {
                            Tipe = detil.BarangFK.TipeCuciFK.Tipe
                        }
                    }
                };

                daftarDetilModel.Add(detilModel);
            }

            model.Detail = daftarDetilModel;

            return View(model);
        }
    }
}