using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
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
            Produits.Remove(produitADeleter);
            HibernateProduitService.Delete(produitADeleter);
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
                    AjoutModifUserControl.LblInfo.FontSize = 15;
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: Le prix doit correspondre au format XX,XX";
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
                    AjoutModifUserControl.LblInfo.Content = "ERREUR: le produit n'a pas pu être ajouté";
                    break;
            }
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
                    var regex = new Regex(@"^[0-9]*([\,]?\d{1,2})");
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
                        else
                        {
                            //if (Existe(GenererCodeProduit(AjoutModifUserControl.TxtNom.Text, AjoutModifUserControl.TxtDescription.Text)))
                            //{
                            //    GestionErreurs(6);
                            //    return false;
                            //}
                        }
                    }
                }
            }
            return true;
        }

        public static string GenererCodeProduit(string nom, string description)
        {
            string code = "";

            for (int i = 0; i < nom.Length || i < description.Length || i < 3; i++)
            {
                code += nom[i] + description[i];
            }
            return code;
        }

        public static string GenererCodeProduit()
        {
            string nom = Produit.Nom;
            string description = Produit.Description;
            
            string salt = Produit.Nom + Produit.Description;

            string n = (Produit.Nom[0] + Produit.Nom[1] + Produit.Description[0] + Produit.Description[1] + Produit.Nom.Length.ToString());

            //Guid code = new Guid(seed);
            ////ShortGuid sguid = code;

            ////for (int i = 0; i < nom.Length || i < description.Length || i < 3; i++)
            ////{
            ////    code += nom[i] + description[i];
            ////}
            ////string input = "asdfasdf";
            //using (SHA512 sha512 = SHA512.Create())
            //{
            //    byte[] hash = sha512.ComputeHash(Encoding.Default.GetBytes(seed));
            //    Guid result = new Guid(hash);
            //}
            ////string base64Guid = Convert.ToBase64String(code.ToByteArray());
            //return ;
            /*
            SHA512 shaM = new SHA512Managed();
            byte[] data = new byte[salt.Length];
            byte[] result;

            data = Encoding.UTF8.GetBytes(salt);
            result = shaM.ComputeHash(data);
            return Convert.ToBase64String(result);
            */
            return n;
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
            AjoutModifUserControl.LblFormTitle.Content = "Ajouter un produit";
            AjoutModifUserControl.viderChamps();
            AjoutModifUserControl.EstModif = false;
            AjoutModifUserControl.GrdTitre.SetValue(Grid.RowProperty, 1);
            AjoutModifUserControl.LblInfo.Content = "";
        }
    }
}
