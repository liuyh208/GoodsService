using System.Web.Mvc;
using ServiceStack.CacheAccess;
using ServiceStack.WebHost.Endpoints;

namespace GoodsService.Web.Controllers
{
    public class BaseController : Controller
    {
        private ISession _serviceStackSession;

        protected ISession ServiceStackSession
        {
            get
            {
                return _serviceStackSession ??
                       (_serviceStackSession = AppHostBase.Resolve<ISessionFactory>().GetOrCreateSession());
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
        }
    }
}