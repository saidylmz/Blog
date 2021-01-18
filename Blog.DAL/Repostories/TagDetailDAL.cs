using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class TagDetailDAL
    {
        BlogDBContext db;
        public TagDetailDAL()
        {
            db = new BlogDBContext();
        }
        public int Add(TagDetail TagDetail)
        {
            db.Entry(TagDetail).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
        public int Update(TagDetail TagDetail)
        {
            db.Entry(TagDetail).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(TagDetail TagDetail)
        {
            db.Entry(TagDetail).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }
        public List<TagDetail> GetAll()
        {
            return db.TagDetails.ToList();
        }
        public TagDetail GetByID(int id)
        {
            return db.TagDetails.Find(id);
        }
    }
}
