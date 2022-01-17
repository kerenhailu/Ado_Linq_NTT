using Ado_Linq_NTT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ado_Linq_NTT.Controllers
{
    public class CEOController : Controller
    {
        List<CEO> CEOs = new List<CEO>()
        {
            new CEO(0,"kerenHailu",23,"keren@gmail",80),
            new CEO(1,"GalLevi",23,"Gal@gmail",80),
            new CEO(2,"DanaFrider",23,"Dana@gmail",80),
            new CEO(3,"BarZomer",23,"Bar@gmail",80),
            new CEO(4,"NetaAl",23,"kNeta@gmail",80),
        };
        
        // GET: CEO
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult NameOfCeo()
        {
            return View(CEOs[3]);
        }
        public ActionResult AllTheSEO(int id)
        {
            return View(CEOs[id]);
        }
    }
}