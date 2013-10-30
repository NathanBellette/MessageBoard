using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Services;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _repo;

        public HomeController(IMailService mail, IMessageBoardRepository repo)
        {
            _mail = mail;
            _repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            var topics = _repo.GetTopics().OrderByDescending(t => t.Created).Take(25).ToList();

            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from: {1}{0}Email:{2}{0}Web Site:{3}{0}Comment{4}{0}",
                Environment.NewLine, model.Name, model.Email, model.WebSite, model.Comment);

            if (_mail.SendMail("noreply@mydomain.com", "youraddress@yourdomain.com", "Website Contact", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }

        [Authorize]
        public ActionResult Moderation()
        {
            return View();
        }
    }
}
