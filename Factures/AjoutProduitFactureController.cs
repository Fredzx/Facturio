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

        public static void AjouterProduitFacture(float qte)
        {
            if (ProduitsController.SiProduitSelectionne("l'ajouter à la facture", AjoutProduitFacture.DtgAfficheProduits))
            {
                bool estNouveau = true;
                Produit p = (Produit)AjoutProduitFacture.DtgAfficheProduits.SelectedItem;
                if (valider(p))
                {
                    ProduitFacture pf = new ProduitFacture(p, OpererFactureController.LaFacture, qte);
                    if (OpererFactureUC.DtgListeProduitsFacture.Items.Count > 0)
                    {
                        for (int i = 0; i < OpererFactureUC.DtgListeProduitsFacture.Items.Count; i++)
                        {
                            if (OpererFactureController.LaFacture.LstProduitFacture[i].Produit.Nom == pf.Produit.Nom && pf.Produit.Prix == OpererFactureController.LaFacture.LstProduitFacture[i].Produit.Prix && pf.Produit.Description == OpererFactureController.LaFacture.LstProduitFacture[i].Produit.Description)
                            {
                                OpererFactureController.LaFacture.LstProduitFacture[i].Quantite += pf.Quantite;
                                pf.Produit.Quantite -= pf.Quantite;
                                AjoutProduitFacture.DtgAfficheProduits.Items.Refresh();
                                estNouveau = false;
                            }
                        }
                        if (estNouveau)
                        {
                            pf.Produit.Quantite -= pf.Quantite;
                            OpererFactureController.LaFacture.LstProduitFacture.Add(pf);
                            AjoutProduitFacture.DtgAfficheProduits.Items.Refresh();
                        }
                    }
                    else
                    {
                        pf.Produit.Quantite -= pf.Quantite;
                        OpererFactureController.LaFacture.LstProduitFacture.Add(pf);
                        AjoutProduitFacture.DtgAfficheProduits.Items.Refresh();
                    }
                    AjoutProduitFacture.DtgAfficheProduits.SelectedIndex = -1;
                    OpererFactureUC.DtgListeProduitsFacture.Items.Refresh();
                }
            }
            //TODO: Maintenant, je supprime la quantité dans la liste
            //      Il faut que je supprime la quantité en BD quand on confirme la facture
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
