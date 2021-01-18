using Blog.DAL.Classes;
using Blog.UI.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Blog.UI.Controllers.Admin
{
    [SessionController]
    public class AdminController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ProjectCount = new BLL.Classes.ProjectController().GetAllProjects().Count(x=>x.TagDetails.Any(y=>y.Tag.Name.Contains("Proje")));
            ViewBag.BlogCount = new BLL.Classes.ProjectController().GetAllProjects().Count(x => x.TagDetails.Any(y => y.Tag.Name.Contains("Blog")));
            ViewBag.CommentCount = new BLL.Classes.CommentController().GetAllActives().Count;
            ViewBag.Visitors = new BLL.Classes.VisitorController().GetAllVisitors();
            return View();
        }

        public ActionResult Project()
        {
            return View(new BLL.Classes.ProjectController().GetAllProjects());
        }

        [HttpPost]
        public ActionResult DeleteProject(int id)
        {
            if (!new BLL.Classes.ProjectController().DeleteProject(id))
                return HttpNotFound();
            return RedirectToAction("Project");
        }

        public ActionResult AddProject()
        {
            ViewBag.Tags = new BLL.Classes.TagController().GetTags();
            return View();
        }

        [ValidateAntiForgeryToken, HttpPost, ValidateInput(false)]
        public ActionResult AddProject(Project project, HttpPostedFileBase File, int[] tags)
        {
            if (!new BLL.Classes.ProjectController().AddProject(project, new WebImage(File.InputStream).GetBytes(), tags))
                return HttpNotFound();
            return RedirectToAction("Project");
        }

        public ActionResult UpdateProject(int id)
        {
            ViewBag.Tags = new BLL.Classes.TagController().GetTags();
            return View(new BLL.Classes.ProjectController().GetByID(id));
        }

        [ValidateAntiForgeryToken, HttpPost, ValidateInput(false)]
        public ActionResult UpdateProject(Project project, HttpPostedFileBase File, int[] tags)
        {
            if(File != null)
                project.Image = new WebImage(File.InputStream).GetBytes();
            if (!new BLL.Classes.ProjectController().UpdateProject(project, tags))
                return HttpNotFound();
            return RedirectToAction("Project");
        }

        public ActionResult Tag()
        {
            return View(new BLL.Classes.TagController().GetTags());
        }

        [HttpPost]
        public ActionResult DeleteTag(int id)
        {
            if (!new BLL.Classes.TagController().DeleteTag(id))
                return HttpNotFound();
            return RedirectToAction("Project");
        }

        [HttpPost]
        public void AddTag(string name)
        {
            new BLL.Classes.TagController().AddTag(name);
        }

        public ActionResult Comment()
        {
            return View(new BLL.Classes.CommentController().GetAllActives());
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            if (!new BLL.Classes.CommentController().DeleteComment(id))
                return HttpNotFound();
            return RedirectToAction("Comment");
        }

        public ActionResult InActiveComment()
        {
            return View(new BLL.Classes.CommentController().GetInActives());
        }

        [HttpPost]
        public ActionResult AcceptComment(int id)
        {
            if (!new BLL.Classes.CommentController().AcceptComment(id))
                return HttpNotFound();
            return RedirectToAction("Comment");
        }

        public ActionResult Info()
        {
            return View(new BLL.Classes.InfoController().Get());
        }

        [ValidateAntiForgeryToken, HttpPost, ValidateInput(false)]
        public ActionResult UpdateInfo(Info info)
        {
            if (!new BLL.Classes.InfoController().Update(info))
                return HttpNotFound();
            return RedirectToAction("Info");
        }
    }
}