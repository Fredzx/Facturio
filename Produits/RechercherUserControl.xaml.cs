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
        public RechercherUserControl()
        {
            InitializeComponent();
            ProduitsController.Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur ajouter on veut : 
            // Que le usercontrol Produit change d'onglet > direction : onglet Ajout.            
            ProduitUserControl.TbcProduitPublic.SelectedIndex = 1;

            // Ajuster le titre
            AjoutModifUserControl.LblFormTitle.Content = "Ajouter un produit";

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (SiProduitSelectionne())
            {
                // Lorsqu'il clique sur mofifier on veut : 
                // Que le usercontrol Produti change d'onglet > direction : onglet Modifier.
                ProduitUserControl.TbcProduitPublic.SelectedIndex = 1;

                // Ajuster le titre
                AjoutModifUserControl.LblFormTitle.Content = "Modifier un produit";
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (Confirmation())
            {
                // Delete
                //Produit p = (Produit)dtgAfficheProduits.SelectedItem;
                ProduitsController.DeleteProduit((Produit)dtgAfficheProduits.SelectedItem);
                dtgAfficheProduits.SelectedIndex = -1;
            }
        }

        private bool Confirmation()
        {
            MessageBoxResult resultat;
            if(SiProduitSelectionne())
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
                    return false;
                }
                return true;
            }
            return false;

        }

        private bool SiProduitSelectionne()
        {
            MessageBoxResult resultat;
            if (dtgAfficheProduits.SelectedIndex == -1)
            {
                resultat = MessageBox.Show("Vous devez sélectionner un produit pour pouvoir supprimer"
                    , "Info"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Exclamation
                    , MessageBoxResult.OK);
                return false;
            }
            return true;

        }

        private void txtRechercherProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ObservableCollection<Produit> filtered = new ObservableCollection<Produit>();
            //ObservableCollection<Produit> bck = new ObservableCollection<Produit>(ProduitsController.Produits);
            //filtered.Clear();
            //foreach(var item in bck)
            //{
            //    if(item.Nom.Contains(txtRechercherProduit.Text.ToString()) || item.Code.Contains(txtRechercherProduit.Text.ToString()))
            //    {
            //        filtered.Add(item);
            //    }
            //    ProduitsController.ocProduits = filtered;
            //}
            //    dtgAfficheProduits.Items.Refresh();

            if (txtRechercherProduit.Text.ToString() == "")
            {
                //ProduitsController.ChargerListeProduits();
                ProduitsController.Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            }
            else
            {
                ProduitsController.LiveFiltering(txtRechercherProduit.Text.ToString());
               // System.Windows.Forms.MessageBox.Show("Allo");
            }
            dtgAfficheProduits.ItemsSource = null;
            dtgAfficheProduits.ItemsSource = ProduitsController.Produits;
// dtgAfficheProduits.Items.Refresh();
        }
    }
}
