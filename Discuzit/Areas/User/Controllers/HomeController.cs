using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Discuzit.Models;
using Discuzit.Shared;

namespace Discuzit.Areas.User.Controllers
{
    [Authorize(Roles = UserRoles.IsUser)]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Questions()
        {
            var userId = _db.Users.FirstOrDefault(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name)?.Id;
            var questions = _db.Questions.Where(m => m.CreatedBy == userId).Include(m=>m.Category);
            return View(questions);
        }
    }
}