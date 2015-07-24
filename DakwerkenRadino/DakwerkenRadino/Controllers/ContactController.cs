using System.Threading.Tasks;
using System.Web.Mvc;
using DakwerkenRadino.Business.Email;
using DakwerkenRadino.Business.Models;

namespace DakwerkenRadino.Controllers
{
    [RoutePrefix("contact")]
    public class ContactController : Controller
    {
        private readonly IEmailProcessor emailProcessor;

        public ContactController(IEmailProcessor emailProcessor)
        {
            this.emailProcessor = emailProcessor;
        }

        [OutputCache(Duration = 7200, VaryByParam = "mail")]
        public ActionResult Index()
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
        [ActionName("send-mail")]
        public async Task<ActionResult> SendMail(ContactFormModel contactFormModel)
        {
            if (!ModelState.IsValid) return View("Index", contactFormModel);

            string result = (await emailProcessor.Send(contactFormModel)).ToString().ToLowerInvariant();
            return RedirectToAction("Index", new { mail = result });
        }

        public ActionResult ContactInformation()
        {
            return PartialView("_ContactInformation");
        }

        public ActionResult ContactForm(ContactFormModel contactFormModel)
        {
            return PartialView("_ContactForm");
        }
    }
}