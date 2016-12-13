using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public MenuController()
        {
            _db = new JCleanLaundryEntities();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Transaksi()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cek()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ambil()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Laporan()
        {
            return View();
        }
	}
}