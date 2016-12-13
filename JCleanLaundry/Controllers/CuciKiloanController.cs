using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
	public class CuciKiloanController : Controller
	{
		private readonly JCleanLaundryEntities _db;

        public CuciKiloanController()
        {
            _db = new JCleanLaundryEntities();
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}