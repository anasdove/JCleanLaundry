using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    public class TransactionController : Controller
    {
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
    }
}
