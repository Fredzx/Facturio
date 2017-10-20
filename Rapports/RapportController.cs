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
        public static IList<Rapport> LstRapport { get; set; } = new List<Rapport>();

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
            LstRapport = ChargerListeRapport();
        }

        public static List<Rapport> ChargerListeRapport()
        {
            return HibernateRapportService.RetrieveAll();
            
        }

    }
}
