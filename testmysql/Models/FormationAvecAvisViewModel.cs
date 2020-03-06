using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testmysql.Models
{
    public class FormationAvecAvisViewModel
    {
        public object dbo_formationNom { get; internal set; }
        public object dbo_formationDescription { get; internal set; }
        public object dbo_formationNomSeo { get; internal set; }
        public object dbo_formationUrl { get; internal set; }
        public object Note { get; internal set; }
        public object NombreAvis { get; internal set; }
        public List<dbo_avis> Avis { get; internal set; }
    }
}