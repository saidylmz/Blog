using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class VisitorDAL
    {
        BlogDBContext db;
        public VisitorDAL()
        {
            db = new BlogDBContext();
        }
        public List<Visitor> GetAll()
        {
            return db.Visitors.ToList();
        }

        public int Add(Visitor visitor)
        {
            db.Entry(visitor).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
        
        public int Update(Visitor visitor)
        {
            db.Entry(visitor).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public Visitor GetByIP(string ip)
        {
            return db.Visitors.SingleOrDefault(x => x.IP == ip);
        }
    }
}
