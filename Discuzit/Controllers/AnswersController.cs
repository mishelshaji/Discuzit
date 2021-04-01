using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Discuzit.Models;

namespace Discuzit.Controllers
{
    public class AnswersController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Answers
        [Route("{id}")]
        public ActionResult Index(int id)
        {
            ViewBag.Answers = _db.Answers.Where(m => m.QuestionId == id).Take(20);
            return View();
        }

        // GET: Answers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Answers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Answers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Answers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
