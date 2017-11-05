using Facturio.Produits;
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

namespace Facturio.Factures
{
    /// <summary>
    /// Logique d'interaction pour AjoutProduitFacture.xaml
    /// </summary>
    public partial class AjoutProduitFacture : UserControl
    {
        public AjoutProduitFacture()
        {
            InitializeComponent();
        }

        private void txtRechercherProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRechercherProduit.Text.ToString() == "")
            {
                //AjoutProduitFactureController.Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            }
            else
            {
                //AjoutProduitFactureController.LiveFiltering(txtRechercherProduit.Text.ToString());
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur ajouter on veut : 
            // Que le usercontrol AjoutProduitFacture change d'onglet > direction : onglet Opérer.            
            //OpererFacture.TbcProduitPublic.SelectedIndex = 1;
            MessageBox.Show("Fonctionnalité pas implémentée");
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            //OpererFacture.TbcProduitPublic.SelectedIndex = 0;
        }
    }
}
