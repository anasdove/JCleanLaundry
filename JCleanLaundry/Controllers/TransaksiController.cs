using System.Linq;
using System.Web.Mvc;

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
        public ActionResult Transaksi()
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
    }
}
