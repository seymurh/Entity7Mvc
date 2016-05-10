using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Entity7Mvc.Models;

namespace Entity7Mvc.Repository
{
    public class ent6Context:DbContext
    {
        
        public ent6Context():base()
        {
            this.Database.Connection.ConnectionString = "Data Source=(local);" +
              "Initial Catalog=ent6;" +
              "Integrated Security=SSPI;"; 
              //"User id=UserName;" +
              //"Password=Secret;"; 
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Types().Configure(t => t.MapToStoredProcedures()); //All entities will use stored procedure
         //   modelBuilder.Entity<Student>().MapToStoredProcedures(); //auto create insert update delete stored procedures
       //     modelBuilder.Entity<Student>()
       //.MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertStudent").Parameter(pm => pm.StudentName, "name").Result(rs => rs.Student_ID, "Student_ID"))
       //.Update(sp => sp.HasName("sp_UpdateStudent").Parameter(pm => pm.StudentName, "name"))
       //.Delete(sp => sp.HasName("sp_DeleteStudent").Parameter(pm => pm.Student_ID, "Id"))
       //);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}