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
            ViewBag.MetaDescription = "Aarzel niet en vraag een gratis offerte aan!";

            return View(new ContactFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMail(ContactFormModel contactFormModel)
        {
            if (ModelState.IsValid)
            {

            }

            return View(contactFormModel);
        }
    }
}