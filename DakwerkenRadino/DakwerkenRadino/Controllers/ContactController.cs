using System.Web.Mvc;
using DakwerkenRadino.Business.Models;

namespace DakwerkenRadino.Controllers
{
    public class ContactController : Controller
    {
        [Route("contact")]
        public ActionResult Index()
        {
            ViewBag.Title = "Contact";
            ViewBag.MetaDescription =
                "Aarzel niet en vraag een gratis offerte aan!";
            var contactFormModel = new ContactFormModel();
            return View(contactFormModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMail(ContactFormModel contactFormModel)
        {
            return View("Index", contactFormModel);
        }
    }
}