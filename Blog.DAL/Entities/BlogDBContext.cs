using Blog.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Entities
{
    public class BlogDBContext : DbContext
    {
        //public BlogDBContext():base("Server=.;Database=BlogDB;user id=sa;pwd=123;")
        public BlogDBContext() : base(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString)
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagDetail> TagDetails { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Info> Info { get; set; }
    }
}
