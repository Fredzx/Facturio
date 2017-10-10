using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapport
{
    class RapportController
    {

        public static List<Rapport> lstRapport { get; set; } = new List<Rapport>();

        public static void ChargerListeRapport()
        {
            lstRapport.AddRange(HibernateRapportService.RetrieveAll());
            
        }

    }
}
