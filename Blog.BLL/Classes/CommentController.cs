using Blog.DAL.Classes;
using Blog.DAL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Classes
{
    public class CommentController
    {
        CommentDAL commentDAL;

        public CommentController()
        {
            commentDAL = new CommentDAL();
        }

        public List<Comment> GetAllActives() => commentDAL.GetAll().Where(x=>x.IsActive).ToList();
        public bool DeleteComment(int id) => commentDAL.Delete(commentDAL.GetByID(id)) > 0;
        public List<Comment> GetInActives() => commentDAL.GetAll().Where(x => x.IsActive == false).ToList();
        public bool AcceptComment(int id)
        {
            Comment cm = commentDAL.GetByID(id);
            cm.IsActive = true;
            return commentDAL.Update(cm) > 0;
        }
    }
}
