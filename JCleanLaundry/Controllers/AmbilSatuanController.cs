using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    public class AmbilSatuanController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}