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
            //TODO: Modif
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveFilter(filter));
            AjoutProduitFacture.DtgAfficheProduits.ItemsSource = Produits;
        }

        public static void AjouterProduitFacture()
        {
            Produit p = (Produit)AjoutProduitFacture.DtgAfficheProduits.SelectedItem;
            ProduitFacture pf = new ProduitFacture(p, OpererFacture.LaFacture, 12);
            OpererFacture.LaFacture.LstProduitFacture.Add(pf);
        }
    }
}
