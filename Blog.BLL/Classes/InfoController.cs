using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class InfoController
    {
        InfoDAL infoDAL;

        public InfoController()
        {
            infoDAL = new InfoDAL();
        }

        public Info Get()
        {
            return infoDAL.Get();
        }

        public bool Update(Info info)
        {
            if (infoDAL.Get() == null)
                return infoDAL.Add(info) > 0;
            return infoDAL.Update(info) > 0;
        }
    }
}
