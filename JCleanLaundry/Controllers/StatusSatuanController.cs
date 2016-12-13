using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
	public class StatusSatuanController : Controller
	{
        [HttpGet]
		public ActionResult Index()
		{
			return View();
		}
	}
}