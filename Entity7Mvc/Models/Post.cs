using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Entity7Mvc.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        
        public List<Comment> Comments { get; set; }
    }
    
}