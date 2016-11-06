using System.Linq;
using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public TransactionController()
        {
            _db = new JCleanLaundryEntities();
        }

        [HttpGet]
        public ActionResult MenuUtama()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CuciBaru()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CariCucian()
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
        public ActionResult TambahBarang()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pelanggan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CekNoPelanggan(string noHp)
        {
            var noHpAda = false;

            var pelanggan = _db.PelangganDbSet.FirstOrDefault(x => x.Hp == noHp);

            if (pelanggan != null)
            {
                noHpAda = true;
            }

            return Json(new {noHpAda = noHpAda, pelanggan = pelanggan}, JsonRequestBehavior.AllowGet);
        }
    }
}
