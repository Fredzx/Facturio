﻿using Facturio.Base;
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
            StringBuilder code = new StringBuilder();
            code.Append(nom[0]).Append(nom[1]).Append(nom[2]).Append(description[0]).Append(description[1]).Append(description[2]).Append('-').Append(nom.Length.ToString());
            return code.ToString();
        }

        public static string GenererCodeProduit()
        {
            StringBuilder code = new StringBuilder();
            code.Append(Produit.Nom[0]).Append(Produit.Nom[1]).Append(Produit.Nom[2]).Append(Produit.Description[0]).Append(Produit.Description[1]).Append(Produit.Description[2]).Append('-').Append(Produit.Nom.Length.ToString());
            return code.ToString();
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
