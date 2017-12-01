using Facturio.Base;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

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
            double? quantiteInventaire = 0;

            if (ProduitsController.SiProduitSelectionne("l'ajouter à la facture", AjoutProduitFacture.DtgAfficheProduits))
            {
                bool estNouveau = true;
                Produit p = (Produit)AjoutProduitFacture.DtgAfficheProduits.SelectedItem;
                quantiteInventaire = p.Quantite;
                if (valider(p))
                {
                    if (p.Quantite > 0)
                    {
                        //if(p.Quantite == null)
                        //{
                        //    AjoutProduitFacture.TxtQuantite.IsEnabled = false;
                        //}
                        ProduitFacture pf = new ProduitFacture(p, OpererFactureController.LaFacture, qte);
                        if (OpererFactureUserControl.DtgFacture.Items.Count > 0)
                        {
                            for (int i = 0; i < OpererFactureUserControl.DtgFacture.Items.Count; i++)
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
                        OpererFactureUserControl.DtgFacture.Items.Refresh();
                        if (pf.Quantite == quantiteInventaire)
                        {
                            MessageBox.Show("Vous venez d'ajouter le maximum en inventaire de ce produit (" + quantiteInventaire + ")");
                        }
                    }
                    else
                    {
                        MessageBox.Show("L'inventaire de ce produit est vide.");
                    }
                }

                Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
                AjoutProduitFacture.DtgAfficheProduits.ItemsSource = null;
                AjoutProduitFacture.DtgAfficheProduits.ItemsSource = Produits;
                OpererFactureUserControl.BtnSauvegarder.IsEnabled = true;
                AjoutProduitFacture.DtgAfficheProduits.Items.Refresh();
                OpererFactureUserControl.RefreshAffichage();
                //TODO: Maintenant, je supprime la quantité dans la liste
                //      Il faut que je supprime la quantité en BD quand on confirme la facture
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
