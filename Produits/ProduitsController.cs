using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Facturio.Produits
{
    // CRUD
    public class ProduitsController : BaseViewModel, IOngletViewModel
    {
        public static AjoutModifUserControl AjoutModifUC { get; set; } = new AjoutModifUserControl();
        public static RechercherUserControl RechercherUC { get; set; } = new RechercherUserControl();
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

            HibernateProduitService.Create(Produit);
        }

        public static bool Existe(String code)
        {
            foreach (Produit produit in Produits)
            {
                if (code == produit.Code)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ErreurAjout(int e)
        {
            switch (e)
            {
                case 0:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer un nom";
                    break;
                case 1:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer une description";
                    break;
                case 2:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer un prix";
                    break;
                case 3:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer une quantité";
                    break;
                case 4:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: le produit existe déjà";
                    break;
            }
        }

        public static void ErreurModif(int e)
        {
            switch (e)
            {
                case 0:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer un nom";
                    break;
                case 1:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer une description";
                    break;
                case 2:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer un prix";
                    break;
                case 3:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Le prix doit être un nombre";
                    break;
                case 4:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer une quantité";
                    break;
                case 5:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: La quantité doit être un nombre entier";
                    break;
                case 6:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: le produit n'a pas pu être modifié";
                    break;
            }
        }

        public static bool ValiderAjout()
        {
            if (AjoutModifUserControl.TxtNom.Text == "")
            {
                ErreurAjout(0);
                return false;
            }
            else
            {
                if (AjoutModifUserControl.TxtDescription.Text == "")
                {
                    ErreurAjout(1);
                    return false;
                }
                else
                {
                    if (AjoutModifUserControl.TxtPrix.Text == "")
                    {
                        ErreurAjout(2);
                        return false;
                    }
                    var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                    if (!regex.IsMatch(AjoutModifUserControl.TxtPrix.Text))
                    {
                        ErreurAjout(3);
                        return false;
                    }
                    else
                    {
                        if (AjoutModifUserControl.TxtQuantite.Text == "")
                        {
                            ErreurAjout(4);
                            return false;
                        }
                        regex = new Regex("^[0-9]*$");
                        if (!regex.IsMatch(AjoutModifUserControl.TxtQuantite.Text))
                        {
                            ErreurAjout(5);
                            return false;
                        }
                        else
                        {
                            if (Existe(GenererCodeProduit()))
                            {
                                ErreurAjout(6);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private static string GenererCodeProduit()
        {
            return "";
        }

        public static int ValiderModif()
        {
            int e = 0;
            if (AjoutModifUserControl.TxtNom.Text == "")
            {
                ErreurModif(0);
            }
            else
            {
                if (AjoutModifUserControl.TxtDescription.Text == "")
                {
                    ErreurModif(1);
                }
                else
                {
                    if (AjoutModifUserControl.TxtPrix.Text == "")
                    {
                        ErreurModif(2);
                    }
                    else
                    {
                        if (AjoutModifUserControl.TxtQuantite.Text == "")
                        {
                            ErreurModif(3);
                        }
                        else
                        {
                            ErreurModif(4);
                        }
                    }
                }

            }
            return e;
        }

        public static void SuccesAjout()
        {
            AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
            AjoutModifUserControl.LblInfo.Foreground = Brushes.Green;
            AjoutModifUserControl.LblInfo.Content = "Le produit a été ajouté avec succès!";
        }

        public static void SuccesModif()
        {
            AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
            AjoutModifUserControl.LblInfo.Foreground = Brushes.Green;
            AjoutModifUserControl.LblInfo.Content = "Le produit a été modifié avec succès!";
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

        //public static void RemplirChampsModif(Produit p)
        //{
        //    AjoutModifUserControl.TxtNom.Text = p.Nom;
        //    AjoutModifUserControl.TxtCode.Text = p.Code;
        //    AjoutModifUserControl.TxtDescription.Text = p.Description;
        //    AjoutModifUserControl.TxtPrix.Text = p.Prix.ToString();
        //    AjoutModifUserControl.TxtQuantite.Text = p.Quantite.ToString();
        //    AjoutModifUserControl.EstModif = true;
        //}

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
