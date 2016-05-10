using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity7Mvc.Models
{
    public partial class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public Nullable<int> TeacherId { get; set; }

        //  public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}