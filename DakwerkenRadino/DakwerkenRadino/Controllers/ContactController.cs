using System.Web.Mvc;
using DakwerkenRadino.Business.Models;
using DakwerkenRadino.Business.Email;
using System.Threading.Tasks;

namespace DakwerkenRadino.Controllers
{
    [RoutePrefix("contact")]
    public class ContactController : Controller
    {
        private IEmailProcessor emailProcessor { get; set; }

        public ContactController(IEmailProcessor emailProcessor)
        {
            this.emailProcessor = emailProcessor;
        }

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

        public ActionResult ContactForm()
        {
            return PartialView("_ContactForm");
        }
    }
}