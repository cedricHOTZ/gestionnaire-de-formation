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
           
            var vm = new AccueilViewModel();

            using (var context = new avisEntities())
            {
                var listFormation = context.dbo_formation.ToList();
                foreach (var f in listFormation)
                {
                    var dto = new FormationAvecAvisDto();
                    dto.Formation = f;
                    if (f.dbo_avis.Count == 0)
                        dto.Note = 0;
                    else
                    {
                        dto.Note = Math.Round(f.dbo_avis.Average(a => a.Note), 2);
                        vm.ListFormations.Add(dto);
                    }

                    
                }
            }
            return View(vm);
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