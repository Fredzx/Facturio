using Facturio.Base;
using Facturio.Factures;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace Facturio.Factures
{
    public class AjoutProduitFactureController : BaseViewModel, IOngletViewModel, INotifyPropertyChanged
    {
        public static ObservableCollection<Produit> Produits { get; set; }
        public string Titre { get; set; }

        public AjoutProduitFactureController()
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            Titre = "Ajouter un produit la facture";
        }
        public static void LiveFiltering(string filter)
        {
            //TODO: Modif
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveFilter(filter));
            AjoutProduitFacture.DtgAfficheProduits.ItemsSource = Produits;
        }

        public static void AjouterProduitFacture()
        {
            if (ProduitsController.SiProduitSelectionne("l'ajouter à la facture", AjoutProduitFacture.DtgAfficheProduits))
            {
                Produit p = (Produit)AjoutProduitFacture.DtgAfficheProduits.SelectedItem;
                //MaxQuantite.Maximum = p.Quantite;
                if (valider(p))
                {
                    ProduitFacture pf = new ProduitFacture(p, OpererFactureController.LaFacture, float.Parse(AjoutProduitFacture.TxtQuantite.Value.ToString()));
                    OpererFactureController.LaFacture.LstProduitFacture.Add(pf);
                    AjoutProduitFacture.DtgAfficheProduits.SelectedIndex = -1;
                }
            }
        }

        private static bool valider(Produit p)
        {
            if (p.Quantite < float.Parse(AjoutProduitFacture.TxtQuantite.Value.ToString()))
            {
                System.Windows.MessageBox.Show("Il n'y a pas autant de produit en inventaire");
                return false;
            }
            // If valide
            return true;

        }
    }
}
