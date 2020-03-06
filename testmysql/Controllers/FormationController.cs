using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testmysql.Models;

namespace testmysql.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult ToutesLesFormations()
        {
            List<dbo_formation> listFormations = new List<dbo_formation>();
            using (var context = new avisEntities())
            { 
                 listFormations = context.dbo_formation.ToList();
            }
            return View(listFormations);
        }

        public ActionResult DetailsFormation(string nomSeo)
        {
            var vm = new FormationAvecAvisViewModel();
            using (var context = new avisEntities())
            {
                var formationEntity = context.dbo_formation.Where(f=>f.NomSeo == nomSeo).FirstOrDefault();
                if (formationEntity == null)
                    return RedirectToAction("Accueil", "Home");

                vm.dbo_formationNom = formationEntity.Nom;
                vm.dbo_formationDescription = formationEntity.Nom;
                vm.dbo_formationNomSeo = nomSeo;
                vm.dbo_formationUrl = formationEntity.Url;
                if(formationEntity.dbo_avis.Count > 0)
                vm.Note = formationEntity.dbo_avis.Average(a=>a.Note);
                vm.NombreAvis = formationEntity.dbo_avis.Count;
                vm.Avis = formationEntity.dbo_avis.ToList();
            }
            return View(vm);
        }
    }
}