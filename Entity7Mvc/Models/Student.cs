using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity7Mvc.Models
{
    public partial class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public Nullable<int> StandardId { get; set; }
        public byte[] RowVersion { get; set; }

      //  public virtual Standard Standard { get; set; }
      //  public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }

  
}