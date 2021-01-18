using Blog.DAL.Classes;
using Blog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repostories
{
    public class InfoDAL
    {
        BlogDBContext db;
        public InfoDAL()
        {
            db = new BlogDBContext();
        }

        public int Add(Info info)
        {
            db.Entry(info).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }
        public int Update(Info info)
        {
            db.Entry(Get()).CurrentValues.SetValues(info);
            return db.SaveChanges();
        }
        public Info Get() => db.Info.FirstOrDefault();
    }
}
