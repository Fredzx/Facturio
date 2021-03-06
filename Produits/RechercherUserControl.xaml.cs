﻿using Facturio.Factures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facturio.Produits
{
    /// <summary>
    /// Logique d'interaction pour RechercherUserControl.xaml
    /// </summary>
    public partial class RechercherUserControl : UserControl
    {
        public static DataGrid DtgProduits { get; set; } = new DataGrid();
        public RechercherUserControl()
        {
            InitializeComponent();
            //ProduitsController.RafraichirGrille(false);
            ProduitsController.Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            DtgProduits = dtgAfficheProduits;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjoutModifUserControl.EstModif = false;
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
            dtgAfficheProduits.SelectedIndex = -1;
            // Lorsqu'il clique sur ajouter on veut : 
            // Que le usercontrol Produit change d'onglet > direction : onglet Ajout.            
            ProduitUserControl.TbcProduitPublic.SelectedIndex = 1;

            // Ajuster le titre
            AjoutModifUserControl.LblFormTitle.Content = "Ajouter un produit";

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (ProduitsController.SiProduitSelectionne("supprimer", RechercherUserControl.DtgProduits))
            {
                AjoutModifUserControl.EstModif = true;
                // Lorsqu'il clique sur mofifier on veut : 
                // Que le usercontrol Produti change d'onglet > direction : onglet Modifier.
                ProduitUserControl.TbcProduitPublic.SelectedIndex = 1;

                // Ajuster le titre
                ProduitUserControl.TbiAjouterModifierProduit.Header = "Modifier";
                AjoutModifUserControl.LblFormTitle.Content = "Modifier un produit";
                ProduitsController.Produit = (Produit)dtgAfficheProduits.SelectedItem;
                ProduitsController.AjoutModifUC.RemplirChampsModif(ProduitsController.Produit);
                dtgAfficheProduits.SelectedIndex = -1;
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (Confirmation())
            {
                // Delete
                ProduitsController.DeleteProduit((Produit)dtgAfficheProduits.SelectedItem);
                dtgAfficheProduits.SelectedIndex = -1;
            }
        }

        private bool Confirmation()
        {
            MessageBoxResult resultat;
            if(ProduitsController.SiProduitSelectionne("supprimer", RechercherUserControl.DtgProduits))
            {
                resultat = MessageBox.Show("Voulez-vous vraiment supprimer le produit sélectionné ?"
                    , "Supprimer?!"
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Warning
                    , MessageBoxResult.No
                    );

                if (resultat == MessageBoxResult.No)
                {
                    dtgAfficheProduits.SelectedIndex = -1;
                    btnModifier.IsEnabled = false;
                    btnSupprimer.IsEnabled = false;
                    return false;
                }
                return true;
            }
            return false;

        }

        

        private void txtRechercherProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRechercherProduit.Text.ToString() == "")
            {
                ProduitsController.Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            }
            else
            {
                ProduitsController.LiveFiltering(txtRechercherProduit.Text.ToString());
            }
            ProduitsController.RafraichirGrille(true);
        }

        private void dtgAfficheProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgAfficheProduits.CurrentCell != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
        }

        private void dtgAfficheProduits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProduitsController.SiProduitSelectionne("modifier", RechercherUserControl.DtgProduits))
            {
                AjoutModifUserControl.EstModif = true;
                // Lorsqu'il clique sur mofifier on veut : 
                // Que le usercontrol Produti change d'onglet > direction : onglet Modifier.
                ProduitUserControl.TbcProduitPublic.SelectedIndex = 1;

                // Ajuster le titre
                ProduitUserControl.TbiAjouterModifierProduit.Header = "Modifier";
                AjoutModifUserControl.LblFormTitle.Content = "Modifier un produit";
                ProduitsController.Produit = (Produit)dtgAfficheProduits.SelectedItem;
                ProduitsController.AjoutModifUC.RemplirChampsModif(ProduitsController.Produit);
                dtgAfficheProduits.SelectedIndex = -1;
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;

                e.Handled = true;
            }
        }
    }
}
