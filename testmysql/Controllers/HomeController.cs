using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testmysql.Models;
using Microsoft.Ajax.Utilities;
using System.Data.Entity.SqlServer;

namespace testmysql.Controllers
{
    public class HomeController : Controller
    {
      

        public ActionResult Index()
        {
              
                var listFormation = new List<dbo_formation>();
            var vm = new AccueilViewModel();
            using(var context = new avisEntities())
            {


            
                listFormation = context.dbo_formation.Take(4).ToList();
                foreach(var f in listFormation)
                {
                   

                var dto = new FormationAvecAvisDto();
                    dto.Formation = f;
                    dto.Note = Math.Round(f.dbo_avis.Average(a => a.Note), 2);
                    vm.ListFormations.Add(dto);

                }

            }
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}