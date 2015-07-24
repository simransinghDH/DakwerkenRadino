using System.Web.Mvc;

namespace DakwerkenRadino.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 7200)]
        public ActionResult Index()
        {
            ViewBag.Title = "Uw dakwerken specialist";
            ViewBag.MetaDescription =
                "Dakwerken Radino is uw garantie op expertise in elke vorm van Dakwerken. Neem zo snel mogelijk contact op om te horen wat wij voor u kunnen betekenen!";
            return View();
        }

        [Route("over-ons")]
        [OutputCache(Duration = 7200)]
        public ActionResult About()
        {
            ViewBag.Title = "Over ons";
            ViewBag.MetaDescription =
                "Dakwerken Radino is uw garantie op expertise in elke vorm van Dakwerken. Wie zijn we?";
            return View();
        }

        #region Partials
        public PartialViewResult NavigationBar()
        {
            return PartialView("_NavigationBar");
        }

        public PartialViewResult HomeCarousel()
        {
            return PartialView("_Carousel");
        }

        public PartialViewResult Footer()
        {
            return PartialView("_Footer");
        }

        public PartialViewResult WhoWeAre()
        {
            return PartialView("_WhoWeAre");
        }
        #endregion
    }
}