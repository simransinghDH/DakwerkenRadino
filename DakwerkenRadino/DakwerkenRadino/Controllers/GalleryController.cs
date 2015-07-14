using System.Web.Mvc;

namespace DakwerkenRadino.Controllers
{
    public class GalleryController : Controller
    {
        [Route("gallerij")]
        public ActionResult Index()
        {
            ViewBag.Title = "Gallerij";
            ViewBag.MetaDescription =
               "Dakwerken Radino is uw garantie op expertise in elke vorm van Dakwerken. Bekijk onze gallerij";

            return View();
        }

        public PartialViewResult PhotoswipeOverlay()
        {
            return PartialView("_Photoswipe");
        }
    }
}