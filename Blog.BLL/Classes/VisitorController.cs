using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class VisitorController
    {
        VisitorDAL visitorDAL;
        public VisitorController()
        {
            visitorDAL = new VisitorDAL();
        }

        public bool Add(string ip)
        {
            Visitor visitor = visitorDAL.GetByIP(ip);
            if (visitor != null)
            {
                visitor.VisitedDate = DateTime.Now;
                return visitorDAL.Update(visitor) > 0;
            }
            return visitorDAL.Add(new Visitor() { VisitedDate = DateTime.Now, IP = ip }) > 0;
        }

        public int GetVisitorDay()
        {
            return visitorDAL.GetAll().Count(x => (DateTime.Now - x.VisitedDate).Days < 1);
        }
        public int GetVisitorWeek()
        {
            return visitorDAL.GetAll().Count(x => (DateTime.Now - x.VisitedDate).Days < 8);
        }
        public int GetVisitorMonth()
        {
            return visitorDAL.GetAll().Count(x => (DateTime.Now - x.VisitedDate).Days < 32);
        }
        public int GetAllVisitors() => visitorDAL.GetAll().Count;
    }
}
