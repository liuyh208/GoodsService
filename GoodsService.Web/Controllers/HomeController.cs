using System.Web.Security;
using GoodsService.Services;
using System.Web.Mvc;
using GoodsService.Services.Host;

namespace GoodsService.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
             return View();
        }
    }
}