using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity7Mvc.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Entity7Mvc.Repository
{
    public class PostsRepository
    {
        ent6Context ctx;
        public PostsRepository()
        {
            ctx = new ent6Context();
        }
        public async Task<List<Post>> Get()
        {
            return await ctx.Posts.ToListAsync();
        }
        public List<Post> Find(Func<Post, int, bool> filter)
        {
            return ctx.Posts.Where(filter).Select(p => p).ToList();//.Select(filter);
        }
        public Post AddPost(Post post)
        {
            return ctx.Posts.Add(post);
        }
        public Post UpdatePost(Post post)
        {
            var Post = ctx.Posts.Attach(post);
            ctx.SaveChanges();
            return Post;
        }
    }
}