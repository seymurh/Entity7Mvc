using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Entity7Mvc.Models
{
    public class Comment
    {
        public int CommentId { get; set;}
        public string Content { get; set; }
        public User Author { get; set; }
        public Post Post { get; set; }
    }
}