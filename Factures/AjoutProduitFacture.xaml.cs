using Facturio.Produits;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Facturio.Factures
{
    /// <summary>
    /// Logique d'interaction pour AjoutProduitFacture.xaml
    /// </summary>
    public partial class AjoutProduitFacture : UserControl
    {
        public static DataGrid DtgAfficheProduits { get; set; }
        public static DoubleUpDown TxtQuantite { get; set; }
        public ObservableCollection<Produit> Produits { get; set; }

        public AjoutProduitFacture()
        {
            InitializeComponent();
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            DtgAfficheProduits = dtgAfficheProduits;
            TxtQuantite = txtQuantite;
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void txtRechercherProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRechercherProduit.Text.ToString() == "")
            {
                AjoutProduitFactureController.Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            }
            else
            {
                AjoutProduitFactureController.LiveFiltering(txtRechercherProduit.Text.ToString());
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur ajouter on veut : 
            // Que le usercontrol AjoutProduitFacture change d'onglet > direction : onglet Opérer.            
            //OpererFacture.TbcProduitPublic.SelectedIndex = 1;
            //MessageBox.Show("Fonctionnalité pas implémentée");
            AjoutProduitFactureController.AjouterProduitFacture();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            OpererFacture.TbcProduitPublic.SelectedIndex = 0;
        }

        private void dtgAfficheProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dtgAfficheProduits.SelectedItem != null)
            {
                Produit p = (Produit)dtgAfficheProduits.SelectedItem;
                if(p != null)
                    txtQuantite.Maximum = p.Quantite;
            }
        }
    }
}
