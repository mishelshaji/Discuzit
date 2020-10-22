using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Discuzit.Shared;

namespace Discuzit.Areas.User.Controllers
{
    [Authorize(Roles = UserRoles.IsUser)]
    public class HomeController : Controller
    {
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}