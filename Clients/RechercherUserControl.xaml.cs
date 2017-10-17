using System;
using System.Collections.Generic;
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

namespace Facturio.Clients
{
    /// <summary>
    /// Logique d'interaction pour RechercherUserControl.xaml
    /// </summary>
    public partial class RechercherUserControl : UserControl
    {
        public RechercherUserControl()
        {
            InitializeComponent();

            ClientsController.ChargerListeClients();
            dtgAfficheClients.ItemsSource = ClientsController.LstClients;
        }


        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();

        }

       
        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur ajouter on veut : 
            // Que le usercontrol Client change d'onglet > direction : onglet Ajout.            
            ClientsUserControl.TbcClientPublic.SelectedIndex = 1;

            // Ajuster le titre
            AjoutModifUserControl.LblFormTitle.Content = "Ajouter un client";

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur mofifier on veut : 
            // Que le usercontrol Client change d'onglet > direction : onglet Modifier.
            ClientsUserControl.TbcClientPublic.SelectedIndex = 1;

            // Ajuster le titre
            AjoutModifUserControl.LblFormTitle.Content = "Modifier un client";          



        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Confirmation();
        }

        private bool Confirmation()
        {
            MessageBoxResult resultat;

            resultat = MessageBox.Show("Voulez-vous vraiment supprimer le client sélectionné ?"
                , "Supprimer?!"
                , MessageBoxButton.YesNo
                , MessageBoxImage.Exclamation
                , MessageBoxResult.No
                );

            if (resultat == MessageBoxResult.No)
            {
                return false;
            }
            return true;
        }
    }
}
