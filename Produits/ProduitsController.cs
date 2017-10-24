using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Facturio.Produits
{
    // CRUD
    public class ProduitsController : BaseViewModel, IOngletViewModel
    {
        public static ObservableCollection<Produit> Produits { get; set; }
        public static Produit Produit { get; set; }
        /*
        public static ObservableCollection<Produit> ocProduits { get; set; } = new ObservableCollection<Produit>();
        public static List<Produit> Produits { get; set; } = new List<Produit>();
        */

        public string Titre { get; set; }

        public ProduitsController()
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            Titre = "Produits";
            // ChargerListeProduits();
        }

        public static void ChargerListeProduits()
        {
            //Produits = HibernateProduitService.RetrieveAll();

            //foreach (Produit produit in Produits)
            //    ocProduits.Add(produit);
        }

        public static void UpdateProduit()
        {

            Produit ProduitModifie = new Produit("updateNom", "updateCode", "updateDescription", 10, 11);
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (Produit == null)
                return;
            // TODO: UPDATE en BD
            // TEST
            //DeleteProduit(Produit);
            //AjoutProduit();
            HibernateProduitService.Update(Produit);
            //Produits.Remove(p);
            //Produits.Add(ProduitModifie);
        }

        public static void DeleteProduit(Produit produitADeleter)
        {
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (produitADeleter == null)
                return;

            // TODO: DELETE en BD

            // TEST
            Produits.Remove(produitADeleter);
            HibernateProduitService.Delete(produitADeleter);
        }

        public static void AjoutProduit()
        {
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (Produit == null)
                return;

            // TODO: Ajouter en BD
            // TEST
            HibernateProduitService.Create(Produit);
            
            //Produits.Add(Produit);
        }

        public static void LiveFiltering(string filter)
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveFilter(filter));
        }

        public static void ConstruireModifUserControl()
        {
            //AjoutModifUserControl m = new AjoutModifUserControl(Produit);
            //AjoutModifUserControl.
        }

        public static void RemplirChampsModif(Produit p)
        {
            AjoutModifUserControl.TxtNom.Text = p.Nom;
            AjoutModifUserControl.TxtCode.Text = p.Code;
            AjoutModifUserControl.TxtDescription.Text = p.Description;
            AjoutModifUserControl.TxtPrix.Text = p.Prix.ToString();
            AjoutModifUserControl.TxtQuantite.Text = p.Quantite.ToString();
            AjoutModifUserControl.EstModif = true;
        }

        public static void RafraichirGrille()
        {
            RechercherUserControl.DtgProduits.ItemsSource = null;
            RechercherUserControl.DtgProduits.ItemsSource = ProduitsController.Produits;
            Produits.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
        }

        private static void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBoxResult a = MessageBox.Show("Nouvel élément"
                    , "Supprimer?!"
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Warning
                    , MessageBoxResult.No);
        }

        public static void reinitialiserOnglet()
        {
            AjoutModifUserControl.LblFormTitle.Content = "Ajouter un produit";
            AjoutModifUserControl.viderChamps();
            AjoutModifUserControl.EstModif = false;
            AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 1);
            AjoutModifUserControl.LblInfo.Content = "";
        }

        public static void ChangementNotificateur(ObservableCollection<Produit> lstProduits)
        {
            //https://stackoverflow.com/questions/8691202/comparing-two-observablecollections-to-see-if-they-are-different

            


        }

        public static void ChangementNotificateur(Produit produit)
        {

        }
    }
}
