using JCleanLaundry.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;

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

            ViewBag.TipeCucian = new SelectList(_db.TipeCucis.OrderBy(x => x.Id), "Id", "Tipe");

            var daftarBarang = _db.Barangs.Where(x => x.TipeCuciId == 1).Select(x => new BarangViewModel
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
            var pelanggan = _db.Pelanggans.Where(x => x.Hp == noHp).Select(m => new PelangganViewModel
            {
                Nama    = m.Nama,
                NoKtp   = m.NoKtp,
                Alamat  = m.Alamat
            }).SingleOrDefault();

            return Json(new { noHpAda = pelanggan != null, pelanggan }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult TampilBarang(int tipeCuciId)
        {
            var daftarBarang = _db.Barangs.Where(x => x.TipeCuciId == tipeCuciId).Select(x => new BarangViewModel{
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
            var daftarBarang = _db.Barangs.Where(x => x.Id == kodeBarang).SingleOrDefault();

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

            var pelangganAda = _db.Pelanggans.Where(x => x.NoKtp == prosesSatuan.Pelanggan.NoKtp).Any();

            if (!pelangganAda)
            {
                SimpanDataPelanggan(prosesSatuan.Pelanggan);
            }

            var kodeTransaksiSatuan = SimpanTransaksiSatuan(prosesSatuan);

            return Json(kodeTransaksiSatuan, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CetakTransaksi(string kodeTransaksi)
        {
            var transaksiSatuan = _db.TransaksiSatuans.Where(x => x.KodeTransaksiSatuan == kodeTransaksi).SingleOrDefault();

            var model = new ProsesSatuanViewModel
            {
                KodeTransaksi   = transaksiSatuan.KodeTransaksiSatuan,
                Pelanggan = new PelangganViewModel
                {
                    NoKtp   = transaksiSatuan.PelangganFK.NoKtp,
                    Nama    = transaksiSatuan.PelangganFK.Nama,
                    Alamat  = transaksiSatuan.PelangganFK.Alamat,
                    Hp      = transaksiSatuan.PelangganFK.Hp
                },
                UangMuka        = transaksiSatuan.UangMuka,
                TotalBayar      = transaksiSatuan.TotalBayar,
                NamaCounter     = transaksiSatuan.CounterFK.Nama,
                Staff           = transaksiSatuan.StaffFK.UserName,
                TanggalMasuk    = transaksiSatuan.TanggalMasuk,
                TanggalSelesai  = transaksiSatuan.TanggalKeluar
            };
            
            var details = new List<ProsesSatuanDetailViewModel>();

            foreach (var detil in transaksiSatuan.TransaksiSatuanDetilFK)
            {
                var detailModel = new ProsesSatuanDetailViewModel
                {
                    Jumlah      = detil.Jumlah,
                    KodeBarang  = detil.KodeBarang,
                    Barang      = new BarangViewModel
                    {
                        Nama            = detil.BarangFK.Nama,
                        TipeCuciNama    = detil.BarangFK.TipeCuciFK.Tipe,
                        Harga           = detil.BarangFK.Harga
                    }
                };

                details.Add(detailModel);
            }

            model.Detail = details;

            return View(model);
        }

        [HttpGet]
        public ActionResult TampilTransaksiSatuan()
        {
            var daftarTransaksi = _db.TransaksiSatuans.Where(x => x.StatusTransaksi != "Selesai").Select(x => new ProsesSatuanViewModel
            {
                KodeTransaksi   = x.KodeTransaksiSatuan,
                TanggalMasuk    = x.TanggalMasuk,
                NamaCounter     = x.CounterFK.Nama
            }).ToList();

            return Json(daftarTransaksi, JsonRequestBehavior.AllowGet);
        }

        #region Private Method

        private void SimpanDataPelanggan(PelangganViewModel model)
        {
            var pelanggan = new Pelanggan
            {
                Alamat = model.Alamat,
                Hp = model.Hp,
                Nama = model.Nama,
                NoKtp = model.NoKtp
            };

            _db.Pelanggans.Add(pelanggan);
            _db.SaveChanges();
        }

        private string SimpanTransaksiSatuan(ProsesSatuanViewModel model)
        {
            var pelanggan = _db.Pelanggans.Where(x => x.NoKtp == model.Pelanggan.NoKtp).SingleOrDefault();

            if (pelanggan == null)
            {
                return string.Empty;
            }

            var userId = User.Identity.GetUserId();

            var staff = _db.Staffs.Where(x => x.Id == userId).SingleOrDefault();

            if (staff == null)
            {
                return string.Empty;
            }

            var counter = _db.StaffCounters.Where(x => x.KodeStaff == userId).SingleOrDefault();

            if (counter == null)
            {
                return string.Empty;
            }

            var kodeTransaksi = string.Format("TS-{0}-{1}", counter.KodeCounter, DateTime.Now.ToString("yyMMddHHmmss"));

            var totalBayar = HitungTotalBayar(model);

            var transaksiSatuan = new TransaksiSatuan
            {
                KodeTransaksiSatuan = kodeTransaksi,
                KodeCounter         = counter.KodeCounter,
                KodeStaff           = userId,
                TanggalMasuk        = DateTime.Now,
                TanggalKeluar       = DateTime.Now,
                TotalBayar          = totalBayar,
                KodePelanggan       = pelanggan.Id,
                UangMuka            = model.UangMuka,
                StatusTransaksi     = "Diterima"
            };

            transaksiSatuan.TransaksiSatuanDetilFK = new List<TransaksiSatuanDetil>();

            foreach (var detail in model.Detail)
            {
                var detil = new TransaksiSatuanDetil
                {
                    KodeTransaksiSatuan = kodeTransaksi,
                    KodeBarang          = detail.KodeBarang,
                    Jumlah              = detail.Jumlah
                };

                transaksiSatuan.TransaksiSatuanDetilFK.Add(detil);
            }

            try
            {
                _db.TransaksiSatuans.Add(transaksiSatuan);
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            

            return kodeTransaksi;
        }

        private decimal HitungTotalBayar(ProsesSatuanViewModel model)
        {
            var total = 0;

            foreach (var detail in model.Detail)
            {
                var harga = _db.Barangs.Where(x => x.Id == detail.KodeBarang).SingleOrDefault().Harga;

                total += detail.Jumlah * harga;
            }

            return total;
        }

        #endregion
    }
}
