using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Factures
{
    class FactureController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Facture> Factures { get; set; } = new ObservableCollection<Facture>(HibernateFactureService.RetrieveAll());
        public static Facture Facture { get; set; }
        public string Titre { get; set; }


        public FactureController()
        {
            Factures = new ObservableCollection<Facture>(HibernateFactureService.RetrieveAll());
            Titre = "Factures";
        }
    }
}
