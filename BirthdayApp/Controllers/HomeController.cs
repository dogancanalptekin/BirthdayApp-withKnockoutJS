using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirthdayApp.Models;

namespace BirthdayApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DavetiyeFormu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DavetiyeFormu(DavetiyeModel model)
        {
            if (ModelState.IsValid)
            {
                Veritabani.Add(model);
                return View("Thanks", model);
            }

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Katilanlar()
        {
            var katilanlar = Veritabani.Liste.Where(i => i.KatilmaDurumu == true);

            return PartialView(katilanlar);
        }
    }
}