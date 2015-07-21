using System.Web.Mvc;
using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.Email;

namespace DakwerkenRadino.Controllers
{
    public class ContactController : Controller
    {
        private IEmailProcessor emailProcessor { get; set; }

        public ContactController(IEmailProcessor emailProcessor)
        {
            this.emailProcessor = emailProcessor;
        }

        [HttpGet]
        [Route("contact")]
        public ActionResult Contact()
        {
            bool isMailResult;
            bool.TryParse(Request.QueryString["mail"], out isMailResult);
            ViewBag.ShowSuccessMessage = isMailResult;
            ViewBag.Title = "Contact";
            ViewBag.MetaDescription = "Aarzel niet en vraag een gratis offerte aan!";

            return View(new ContactFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormModel contactFormModel)
        {
            if (!ModelState.IsValid) return View();

            //emailProcessor.Send(contactFormModel);
            return RedirectToAction("Contact", new { mail = true });
        }

        public ActionResult ContactInformation()
        {
            return PartialView("_ContactInformation");
        }

        public ActionResult ContactForm()
        {
            return PartialView("_ContactForm");
        }
    }
}