using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Discuzit.Models;
using Discuzit.Models.ViewModels;

namespace Discuzit.Controllers
{
    public class QuestionController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Question
        public ActionResult Index()
        {
            var qq = new QuestionsAndCategory();
            qq.Questions = _db.Questions.Take(50).Include(m => m.Category).ToList();
            qq.Categories = _db.Categories.ToList();
            return View(qq);
        }
    }
}