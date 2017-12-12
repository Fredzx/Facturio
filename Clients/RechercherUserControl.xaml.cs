using System.Windows;
using System.Windows.Controls;

namespace Facturio.Clients
{
    /// <summary>
    /// Logique d'interaction pour RechercherUserControl.xaml
    /// </summary>
    public partial class RechercherUserControl : UserControl
    {
        #region Propriétés
        public static DataGrid DtgClients { get; set; } = new DataGrid();
        public static Button BtnModifier { get; set; } = new Button();
        public static Button BtnSupprimer { get; set; } = new Button();
        public int Status { get; set; }

        enum StatusClient {Actif, Inactif, Tous};
        #endregion

        public RechercherUserControl()
        {
            InitializeComponent();
            DtgClients = dtgAfficheClients;
            Status = (int)StatusClient.Tous;
        }

        #region Méthodes        
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
            AjoutModifUserControl.CbxActif.IsChecked = true;
            AjoutModifUserControl.CbxActif.IsEnabled = false;
        }
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur modifier on veut : 
            // Que le usercontrol Client change d'onglet > direction : onglet Modifier.
            ClientsUserControl.TbcClientPublic.SelectedIndex = 1;

            // Ajuster le titre
            AjoutModifUserControl.LblFormTitle.Content = "Modifier un client";
            AjoutModifUserControl.CbxActif.IsEnabled = true;
            

            // Setter le client a modifier
            ClientsController.LeClient = (Client)dtgAfficheClients.SelectedItem;

            // Passer le client au controleur
            ClientsController.AfficherClient();            
        }
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (Confirmation())
            {
                ClientsController.SupprimerClient((Client)dtgAfficheClients.SelectedItem);
                dtgAfficheClients.SelectedIndex = -1;
            }
      
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
        private void dtgAfficheClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dtgAfficheClients.CurrentCell != null)
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
        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRecherche.Text.ToString() == "")
                // Charger la bonne liste selon le contexte.
                ClientsController.ChargerListeClients(Status);
            else      
                // Faire le trie selon le status des client.
                ClientsController.LiveFiltering(txtRecherche.Text.ToString(), Status);       

            // Dans tous les cas, rafraichir la grille.
            ClientsController.RafraichirGrille(true);
        }
        private void cbxActif_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)cbxInactif.IsChecked)
                cbxInactif.IsChecked = false;

            // Updater la liste aller chercher seulement les membres actif.
            ClientsController.ChargerListeClients((int)StatusClient.Actif);
            Status = (int)StatusClient.Actif;
        }
        private void cbxInactif_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)cbxActif.IsChecked)
                cbxActif.IsChecked = false;

            // Updater la liste aller chercher seulement les membres inactif.
            ClientsController.ChargerListeClients((int)StatusClient.Inactif);
            Status = (int)StatusClient.Inactif;
        }
        private void cbxActif_Unchecked(object sender, RoutedEventArgs e)
        {
            ClientsController.ChargerListeClients((int)StatusClient.Tous);
            Status = (int)StatusClient.Tous;
            ViderBarreRecherche();
        }
        private void cbxInactif_Unchecked(object sender, RoutedEventArgs e)
        {
            ClientsController.ChargerListeClients((int)StatusClient.Tous);
            Status = (int)StatusClient.Tous;
            ViderBarreRecherche();
        }
        private void ViderBarreRecherche()
        {
            txtRecherche.Text = "";
        }

        private void dtgAfficheClients_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Lorsqu'il clique sur modifier on veut : 
            // Que le usercontrol Client change d'onglet > direction : onglet Modifier.
            ClientsUserControl.TbcClientPublic.SelectedIndex = 1;

            // Ajuster le titre
            AjoutModifUserControl.LblFormTitle.Content = "Modifier un client";
            AjoutModifUserControl.CbxActif.IsEnabled = true;


            // Setter le client a modifier
            ClientsController.LeClient = (Client)dtgAfficheClients.SelectedItem;

            // Passer le client au controleur
            ClientsController.AfficherClient();
            e.Handled = true;
        }

        #endregion

        private void dtgAfficheClients_MouseDoubleClick_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
