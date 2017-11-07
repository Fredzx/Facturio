using Facturio.Base;
using Facturio.Factures;
using Facturio.ProduitsFactures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Facturio.Produits
{
    public class AjoutProduitFactureController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Produit> Produits { get; set; }
        public string Titre { get; set; }

        public AjoutProduitFactureController()
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            Titre = "Ajouter un produit à la facture";
        }
        public static void LiveFiltering(string filter)
        {
             Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveFilter(filter));
        }
    }
}
