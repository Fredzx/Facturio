using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports
{
    class RapportController
    {

        public static ICollection<Rapport> LstRapport { get; set; } = new HashSet<Rapport>();

        public static ICollection<Rapport> ChargerListeRapport()
        {
            //LstRapport.AddRange(HibernateRapportService.RetrieveAll());
            return HibernateRapportService.RetrieveAll();
            
        }

    }
}
