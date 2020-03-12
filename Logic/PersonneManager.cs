using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /* sauvegarde le nom de la personne lors de l'inscription */
   public class PersonneManager
    {
       public void InsertNom(string userId, string nom)
        {
            using(var context = new avisEntities())
            {
             var personEntity = context.personne.FirstOrDefault(p => p.UserId == userId);
                if(personEntity == null)
                {
                    var p = new personne();
                    p.Nom = nom;
                    p.UserId = userId;
                    context.personne.Add(p);
                    context.SaveChanges();
                }
            }
        }

        /* Utiliser le nom de la personne lors du depot de l'avis */
        public string GetNomFromUserId(string userId)
        {
            using (var context = new avisEntities())
            {
                var personEntity = context.personne.FirstOrDefault(p => p.UserId == userId);
                if (personEntity == null)
                {
                    return "Anonyme";
                }
                return personEntity.Nom;
            }
        }
    }
}
