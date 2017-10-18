using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports
{
    class RapportController : BaseViewModel, IOngletViewModel
    {

        public static ICollection<Rapport> LstRapport { get; set; } = new HashSet<Rapport>();

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
            ChargerListeRapport();
        }

        public static ICollection<Rapport> ChargerListeRapport()
        {
            //LstRapport.AddRange(HibernateRapportService.RetrieveAll());
            return HibernateRapportService.RetrieveAll();
            
        }

    }
}
