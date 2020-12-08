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
        private MarkdownRenderer _markdownRenderer = new MarkdownRenderer();
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Questions()
        {
            //var userId = _db.Users.FirstOrDefault(x => x.UserName == System.Web.HttpContext.Current.User.Identity.Name)?.Id;
            //var questions = _db.Questions.Where(m => m.CreatedBy == userId).Include(m=>m.Category);
            //return View(questions);

            var questions = _db.Questions.Take(100).Include(q => q.Category).ToList();
            foreach (var question in questions)
            {
                question.Body = _markdownRenderer.RenderHtmlFromMd(question.Body);
            }
            return View(questions);
        }
    }
}