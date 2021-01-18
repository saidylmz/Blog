using Blog.DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: sHome
        public ActionResult Index()
        {
            ViewBag.Tags = new BLL.Classes.TagController().GetTags().Where(x => x.TagDetails.Count() > 0);
            ViewBag.Projects = new BLL.Classes.ProjectController().GetAllProjects().Where(x => x.TagDetails.Any(y => y.Tag.Name.Contains("Proje"))).ToList();
            return View(new BLL.Classes.InfoController().Get());
        }

        public PartialViewResult ProjectDetail(int id)
        {
            return PartialView(new BLL.Classes.ProjectController().GetByID(id));
        }

        public ActionResult Blog()
        {
            return View(new BLL.Classes.ProjectController().GetAllProjects().Where(x => x.TagDetails.Any(y => y.Tag.Name.Contains("Blog"))).ToList());
        }

        public ActionResult BlogDetail(string Name)
        {
            Project p = new BLL.Classes.ProjectController().GetByName(Name);
            if (p == null)
                return HttpNotFound();
            return View(p);
        }

        public PartialViewResult BlogSide()
        {
            return PartialView();
        }

        public void AddVisitor(string ip)
        {
            new BLL.Classes.VisitorController().Add(ip);
        }

        [HttpPost]
        public string SendMail(string name, string email, string subject, string message)
        {
            if (name == "" || email == "" || message == "") return "er";
            SmtpClient smtp = new SmtpClient(); // smtp nesnesi oluşturuyoruz
            smtp.Credentials = new System.Net.NetworkCredential("noreply@saityilmaz.com", "Saidylmz34"); // mail adresimizin kullanıcı adı ve parolası
            smtp.Host = "saityilmaz.com"; // Mail sunucusu
            smtp.Port = 587; // Outlook için 587
            smtp.EnableSsl = false; // Sunucu SSL kullanıyorsa True olacak

            MailMessage eposta = new MailMessage(); // eposta adında bir mail nesnesi oluştur
            eposta.From = new MailAddress("noreply@saityilmaz.com", name); // Giden mailde görünecek e-posta adresi ve isim email adresi smtp ile aynı olmayınca hata veriyor.
            eposta.To.Add("info@saityilmaz.com"); // Mail gönderilecek kişi(ler). Eğer birden fazla kişiye gidecekse, kişiler arasına virgül koy
            eposta.To.Add("ylmazsaid@gmail.com");
         
            eposta.Subject = subject == "" ? "Sait Yılmaz İletişim" : subject; // konu özelliğine ekle
            eposta.Body = "Bir kişi siteye mesaj bıraktı. <br/><br/> İsim: "+name+"<br/> Mail: "+email+"<br/> Mesaj: "+ message; // mesaj içeriğini body özelliğine ekle
            eposta.IsBodyHtml = true;
            try
            {
                smtp.Send(eposta); // emaili gönder
            }
            catch (Exception ex) // Gönderimde hata oluşursa
            {
                return ex.ToString();
            }

            return "sc";
        }
    }
}