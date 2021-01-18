using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class TagController
    {
        TagDAL tagDAL;
        public TagController()
        {
            tagDAL = new TagDAL();
        }

        public List<Tag> GetTags()
        {
            return tagDAL.GetAll();
        }

        public bool DeleteTag(int id)
        {
            return tagDAL.Delete(tagDAL.GetByID(id)) > 0;
        }

        public bool AddTag(string name)
        {
            return tagDAL.Add(new Tag() { Name = name }) > 0;
        }
    }
}
