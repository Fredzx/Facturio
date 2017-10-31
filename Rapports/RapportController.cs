using Facturio.Base;
using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using Facturio.Rapports.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports
{
    public class RapportController : BaseViewModel, IOngletViewModel
    {
        //public static ISet<Rapport> LstRapport { get; set; }
        public static ListeRapportUserControl RapportUserControl { get; set; } = new ListeRapportUserControl(); 

        

        public string Titre { get; set; }

        public RapportController()
        {
            Titre = "Rapports";
            //LstRapport = new HashSet<Rapport>(HibernateRapportService.RetrieveAll());

            
        }
    }
}
