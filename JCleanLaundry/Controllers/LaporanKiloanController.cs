using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    public class LaporanKiloanController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}