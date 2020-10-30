using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Discuzit.Models;
using Discuzit.Shared;
using Microsoft.AspNet.Identity;

namespace Discuzit.Areas.User.Controllers
{
    [Authorize(Roles = UserRoles.IsUser)]
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private MarkdownRenderer _markdownRenderer =  new MarkdownRenderer();

        // GET: User/Questions
        public async Task<ActionResult> Index()
        {
            var useriD = User.Identity.GetUserId();
            var questions = await db.Questions.Where(q=>q.CreatedBy == useriD).Take(100).Include(q => q.Category).ToListAsync();
            foreach (var question in questions)
            {
                question.Body = _markdownRenderer.RenderHtmlFromMd(question.Body);
            }
            return View(questions);
        }

        // GET: User/Questions/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: User/Questions/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: User/Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Body,CategoryId")] Question question)
        {
            question.CreatedBy = User.Identity.GetUserId();
            var dateTime = DateTime.Now;
            question.CreatedOn = dateTime;
            question.UpdatedOn = dateTime;

            ModelState[nameof(Question.CreatedBy)].Errors.Clear();
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", question.CategoryId);
            return View(question);
        }

        // GET: User/Questions/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", question.CategoryId);
            return View(question);
        }

        // POST: User/Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Body,TotalAnswers,TotalUpVotes,TotalDownVotes,CreatedOn,UpdatedOn,CategoryId,CreatedBy")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", question.CategoryId);
            return View(question);
        }

        // GET: User/Questions/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await db.Questions.FindAsync(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: User/Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Question question = await db.Questions.FindAsync(id);
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
