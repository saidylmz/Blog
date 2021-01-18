using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class ProjectDAL
    {
        BlogDBContext db;
        public ProjectDAL()
        {
            db = new BlogDBContext();
        }
        public int Add(Project project)
        {
            db.Entry(project).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
        public int Update(Project project)
        {
            db.Entry(GetByID(project.ID)).CurrentValues.SetValues(project);
            return db.SaveChanges();
        }
        public int Delete(Project project)
        {
            db.Entry(project).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }
        public List<Project> GetAll()
        {
            return db.Projects.ToList();
        }
        public Project GetByID(int id)
        {
            return db.Projects.Find(id);
        }
    }
}
