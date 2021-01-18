using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class TagDAL
    {
        BlogDBContext db;
        public TagDAL()
        {
            db = new BlogDBContext();
        }
        public int Add(Tag tag)
        {
            db.Entry(tag).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
        public int Update(Tag tag)
        {
            db.Entry(tag).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(Tag tag)
        {
            db.Entry(tag).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }
        public List<Tag> GetAll()
        {
            return db.Tags.ToList();
        }
        public Tag GetByID(int id)
        {
            return db.Tags.Find(id);
        }
    }
}
