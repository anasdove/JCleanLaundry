using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
	public class LaporanSatuanController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
	}
}