using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity7Mvc.Models;
using Entity7Mvc.Repository;

namespace Entity7Mvc.Controllers
{
    public class CommentsController : Controller
    {
        private ent6Context db = new ent6Context();

        // GET: /Comments/
        public async Task<ActionResult> Index()
        {
            List<Comment> comments = await db.Comments.ToListAsync();
           
            db.Entry(comments.First()).Reference(c => c.Post).Load();
            Post post = comments.First().Post;
            //for (int i = 0; i < comments.Count(); i++)
            //{
            //    db.Entry(comments[i]).Reference(c => c.Post).Load();
            //}
                return View(comments);
        }

        // GET: /Comments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /Comments/Create
        public ActionResult Create(int? postId)
        {
            if (postId.HasValue)
            {
                TempData["postId"] = postId.Value;
            }
            return View();
        }

        // POST: /Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="CommentId,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                object pId = TempData["postId"];
                if (pId!=null)
                {
                    int postId = Convert.ToInt32(pId);
                    Post post=await db.Posts.Where(p => p.PostId == postId).Select(p => p).FirstOrDefaultAsync();
                    comment.Post = post;
                }
                db.Comments.Add(comment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index","Posts");
            }

            return View(comment);
        }

        // GET: /Comments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="CommentId,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: /Comments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            db.Comments.Remove(comment);
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
