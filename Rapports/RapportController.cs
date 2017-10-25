using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports
{
    class RapportController : BaseViewModel, IOngletViewModel
    {
        public static ISet<Rapport> LstRapport { get; set; }
        

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
            LstRapport = new HashSet<Rapport>(HibernateRapportService.RetrieveAll());
        }
    }
}
