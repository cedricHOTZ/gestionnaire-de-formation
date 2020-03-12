using Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testmysql.Models;

namespace testmysql.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        [Authorize]
        public ActionResult LaisserUnAvis(string nomSeo)
        {
            var vm = new LaisserUnAvis();
            vm.NomSeo = nomSeo;
            using (var context = new avisEntities())
            {
                var formationEntity = context.dbo_formation.FirstOrDefault(f => f.NomSeo == nomSeo);
                if (formationEntity == null)
                    return RedirectToAction("Accueil", "Home");
               vm.FormationName = formationEntity.Nom;

            }
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveComment(string commentaire,string nom, string note, string nomSeo)
        {
            Data.dbo_avis nouvelleAvis = new dbo_avis();
            nouvelleAvis.DateAvis = DateTime.Now;
            nouvelleAvis.Description = commentaire;
            
            nouvelleAvis.Nom = nom;


            double dNote = 0;
          
            if(!double.TryParse(note,NumberStyles.Any,CultureInfo.InvariantCulture,out dNote))
            {
                throw new Exception("Impossible de parser la note" + note);
            }
            nouvelleAvis.Note = dNote;
            using(var context = new avisEntities())
            {
               var formationEntity =  context.dbo_formation.FirstOrDefault(f => f.NomSeo == nomSeo);
                if (formationEntity == null)
                    return RedirectToAction("Accueil", "Home");
                nouvelleAvis.idFormation = formationEntity.IdFormation;

                context.dbo_avis.Add(nouvelleAvis);
                context.SaveChanges();
            }
            return RedirectToAction("DetailsFormation","Formation",new { nomSeo = nomSeo });
        }
    }
}