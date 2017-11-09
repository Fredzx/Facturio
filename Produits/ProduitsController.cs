using Facturio.Base;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Facturio.Produits
{
    // CRUD
    public class ProduitsController : BaseViewModel, IOngletViewModel
    {
        public static AjoutModifUserControl AjoutModifUC { get; set; } = new AjoutModifUserControl();
        public static ObservableCollection<Produit> Produits { get; set; }
        public static Produit Produit { get; set; }

        public string Titre { get; set; }

        public ProduitsController()
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());

            Titre = "Produits";
        }

        public static void UpdateProduit()
        {
            HibernateProduitService.Update(Produit);
        }

        public static void DeleteProduit(Produit produitADeleter)
        {
            if(produitADeleter != null)
            {
                produitADeleter.EstActif = false;
                HibernateProduitService.Update(produitADeleter);

                Produits.Remove(produitADeleter);
                //Produits.Remove(produitADeleter);
                //HibernateProduitService.Delete(produitADeleter);
            }
        }

        public static void AjoutProduit()
        {
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

        public static void GestionErreurs(int e)
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
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Le nom doit contenir au moins 3 caractères";
                    break;
                case 2:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer une description";
                    break;
                case 3:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: La description doit contenir au moins 3 caractères";
                    break;
                case 4:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer un prix";
                    break;
                case 5:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.FontSize = 15;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Le prix doit correspondre au format XX,XX";
                    break;
                case 6:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Vous devez entrer une quantité";
                    break;
                case 7:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: La quantité doit être un nombre entier";
                    break;
                case 8:
                    AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 2);
                    AjoutModifUserControl.LblInfo.Foreground = Brushes.Red;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: le produit existe déjà";
                    break;
            }
        }

        internal static void DemanderSiModifAncienDelete()
        {
            MessageBoxResult resultat;
            resultat = MessageBox.Show("Le porduit a été supprimé auparavant.\nVoulez-vous le recréer avec vos nouvelles données ?"
                , "Info"
                , MessageBoxButton.YesNo
                , MessageBoxImage.Warning
                , MessageBoxResult.No
                );

                if (resultat == MessageBoxResult.Yes)
                {
                    ObservableCollection<Produit> p = new ObservableCollection<Produit>(HibernateProduitService.Retrieve(Produit.Code));
                    Produit.Id = p[0].Id;
                    HibernateProduitService.Update(Produit);
                }
        }

        public static bool VerifierInactif()
        {
            ObservableCollection<Produit> produits = new ObservableCollection<Produit>(HibernateProduitService.Retrieve(GenererCodeProduit(AjoutModifUserControl.TxtNom.Text, AjoutModifUserControl.TxtDescription.Text)));
            foreach(Produit p in produits)
            {
                if(p.Nom != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValiderAjout()
        {
            if (AjoutModifUserControl.TxtNom.Text == "")
            {
                GestionErreurs(0);
                return false;
            }
            else
            {
                if (AjoutModifUserControl.TxtNom.ToString().Length < 3)
                {
                    GestionErreurs(1);
                    return false;
                }
                else
                {
                    if (AjoutModifUserControl.TxtDescription.Text == "")
                    {
                        GestionErreurs(2);
                        return false;
                    }
                    else
                    {
                        if (AjoutModifUserControl.TxtDescription.ToString().Length < 3)
                        {
                            GestionErreurs(3);
                            return false;
                        }
                        else
                        {
                            if (AjoutModifUserControl.TxtPrix.Text == "")
                            {
                                GestionErreurs(4);
                                return false;
                            }
                            else
                            {
                                var regex = new Regex(@"^[0-9]*([\,]?\d{1,2})");
                                if (!regex.IsMatch(AjoutModifUserControl.TxtPrix.Text))
                                {
                                    GestionErreurs(5);
                                    return false;
                                }
                                else
                                {
                                    if (AjoutModifUserControl.TxtQuantite.Text == "")
                                    {
                                        GestionErreurs(6);
                                        return false;
                                    }
                                    else
                                    {
                                        regex = new Regex("^[0-9]*$");
                                        if (!regex.IsMatch(AjoutModifUserControl.TxtQuantite.Text))
                                        {
                                            GestionErreurs(7);
                                            return false;
                                        }
                                        else
                                        {
                                            if (Existe(GenererCodeProduit(AjoutModifUserControl.TxtNom.Text, AjoutModifUserControl.TxtDescription.Text)))
                                            {
                                                GestionErreurs(8);
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static string GenererCodeProduit(string nom, string description)
        {
            int no = nom.Length + description.Length + 1000;
            string noProduit = no.ToString();
            noProduit += "-";
            noProduit += nom[0].ToString().ToLower();
            noProduit += nom[1].ToString().ToLower();
            noProduit += nom[2].ToString();
            noProduit += nom[0].ToString();
            noProduit += description[2].ToString().ToLower();
            noProduit += description[1].ToString().ToLower();
            noProduit += description[0].ToString().ToLower();
            noProduit += description[description.Length-1].ToString();
            noProduit += "-";
            noProduit += description.Length.ToString();

            return noProduit;
        }

        public static string GenererCodeProduit()
        {
            int no = Produit.Nom.Length + Produit.Description.Length + 1000;
            string noProduit = no.ToString();
            noProduit += "-";
            noProduit += Produit.Nom[0].ToString().ToLower();
            noProduit += Produit.Nom[1].ToString().ToLower();
            noProduit += Produit.Nom[2].ToString();
            noProduit += Produit.Nom[0].ToString();
            noProduit += Produit.Nom[2].ToString().ToLower();
            noProduit += Produit.Nom[1].ToString().ToLower();
            noProduit += Produit.Nom[0].ToString().ToLower();
            noProduit += Produit.Description[Produit.Description.Length - 1].ToString();
            noProduit += "-";
            noProduit += Produit.Description.Length.ToString();

            return noProduit;
        }

        public static bool ValiderModif()
        {
            if (AjoutModifUserControl.TxtNom.Text == "")
            {
                GestionErreurs(0);
                return false;
            }
            else
            {
                if (AjoutModifUserControl.TxtDescription.Text == "")
                {
                    GestionErreurs(1);
                    return false;
                }
                else
                {
                    if (AjoutModifUserControl.TxtPrix.Text == "")
                    {
                        GestionErreurs(2);
                        return false;
                    }
                    var regex = new Regex(@"^[0-9]*(?:[\,][0-9]*)?$");
                    if (!regex.IsMatch(AjoutModifUserControl.TxtPrix.Text))
                    {
                        GestionErreurs(3);
                        return false;
                    }
                    else
                    {
                        if (AjoutModifUserControl.TxtQuantite.Text == "")
                        {
                            GestionErreurs(4);
                            return false;
                        }
                        regex = new Regex("^[0-9]*$");
                        if (!regex.IsMatch(AjoutModifUserControl.TxtQuantite.Text))
                        {
                            GestionErreurs(5);
                            return false;
                        }
                    }
                }
            }
            return true;
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

        public static void RafraichirGrille(bool estFiltre)
        {
            if(!estFiltre)
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            RechercherUserControl.DtgProduits.ItemsSource = null;
            RechercherUserControl.DtgProduits.ItemsSource = Produits;
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
            ProduitUserControl.TbiAjouterModifierProduit.Header = "Ajouter";
            AjoutModifUserControl.LblFormTitle.Content = "Ajouter un produit";
            AjoutModifUserControl.viderChamps();
            AjoutModifUserControl.EstModif = false;
            AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 1);
            AjoutModifUserControl.LblInfo.Content = "";
        }
    }
}
