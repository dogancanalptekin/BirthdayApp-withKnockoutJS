using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BirthdayApp.Models;

namespace BirthdayApp.Controllers
{
    public class DavetiyeController : ApiController
    {
        public IEnumerable<DavetiyeModel> GetKatilanlar()
        {
            return Veritabani.Liste.Where(i => i.KatilmaDurumu == true);
        }

        public IEnumerable<DavetiyeModel> GetKatilmayanlar()
        {
            return Veritabani.Liste.Where(i => i.KatilmaDurumu == false);
        }

        [HttpPost]
        public void Ekle(DavetiyeModel model)
        {
            if (ModelState.IsValid)
            {
                Veritabani.Add(model);
            }
        }
    }
}
