using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class StatusKiloanController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
	}
}