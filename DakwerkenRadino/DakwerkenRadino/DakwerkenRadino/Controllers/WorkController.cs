﻿using System.Web.Mvc;

namespace DakwerkenRadino.Controllers
{
    public class WorkController : Controller
    {
        [Route("onswerk")]
        public ActionResult Index()
        {
            ViewBag.Title = "Onze werken";
            ViewBag.MetaDescription =
                "Dakwerken Radino is uw garantie op expertise in elke vorm van Dakwerken. Bekijk onze voorgaande projecten!";
            return View();
        }
    }
}