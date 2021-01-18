using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class CommentDAL
    {
        BlogDBContext db;
        public CommentDAL()
        {
            db = new BlogDBContext();
        }

        public int Add(Comment comment)
        {
            db.Entry(comment).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
        public int Update(Comment comment)
        {
            db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(Comment comment)
        {
            db.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }
        public List<Comment> GetAll()
        {
            return db.Comments.ToList();
        }
        public Comment GetByID(int id)
        {
            return db.Comments.Find(id);
        }
    }
}
