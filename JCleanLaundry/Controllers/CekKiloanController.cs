using System.Web.Mvc;

namespace JCleanLaundry.Controllers
{
    [Authorize]
    public class CekKiloanController : Controller
    {
        private readonly JCleanLaundryEntities _db;

        public CekKiloanController()
        {
            _db = new JCleanLaundryEntities();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}