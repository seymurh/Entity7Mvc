using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Entity7Mvc.Models;
using Entity7Mvc.Repository;

namespace Entity7Mvc.Controllers
{
    public class PostController : ApiController
    {
        private ent6Context db = new ent6Context();

        // GET api/Post
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET api/Post/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            Post post = db.Posts.FindAsync(id).GetAwaiter().GetResult();
            //Task<Post> task = Task.Run<Post>(async () =>
            //{
            //    return await db.Posts.Where(p => p.PostId == id).FirstOrDefaultAsync();
            //});
            //post=await task;
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT api/Post/5
        public async Task<IHttpActionResult> PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.PostId)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Post
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = post.PostId }, post);
        }

        // DELETE api/Post/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            await db.SaveChangesAsync();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.PostId == id) > 0;
        }
    }
}