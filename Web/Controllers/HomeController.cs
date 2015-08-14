using System.Linq;
using System.Web.Mvc;
using Web.Context;
using Web.Data;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ctx = new WebDbContext();
            var companies = ctx.Set<Company>().ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}