using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    public class AmbilKiloanController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}