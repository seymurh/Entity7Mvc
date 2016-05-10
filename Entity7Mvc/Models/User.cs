using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Entity7Mvc.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<Post> Post { get; set; }
    }
}