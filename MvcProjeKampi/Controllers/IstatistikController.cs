using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {
           
            var toplamkategorisayısı = context.Categories.Count().ToString();
            ViewBag.a1 = toplamkategorisayısı;

            var basliksayisi = context.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.a2 = basliksayisi;

            var harfbul = (from x in context.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.a3 = harfbul;

            var enfazlabaslik = context.Categories.Where(u => u.CategoryID == (context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.a4 = enfazlabaslik;

           var kontrol = context.Categories.Count(p => p.CategoryStatus == true) - context.Categories.Count(p => p.CategoryStatus == false);
            ViewBag.a5 = kontrol;
            return View();
        }
    }
}
