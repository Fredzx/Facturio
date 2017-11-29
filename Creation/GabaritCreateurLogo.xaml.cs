using System;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Facturio.GabaritsCriteres;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Facturio.Creation

{
    /// <summary>
    /// Logique d'interaction pour GabaritCreateurLogo.xaml
    /// </summary>
    public partial class GabaritCreateurLogo : System.Windows.Controls.UserControl
    {
        #region Propriétés
        const string AUCUN_CRIT = "Aucun critère sélectionné";
        public static System.Windows.Controls.DataGrid DtgCriteres { get; set; } = new System.Windows.Controls.DataGrid();
        public static ObservableCollection<Critere> LstObCritere { get; set; }
        public static ObservableCollection<Critere> LstObCritereTabulaire { get; set; }
        public static List<Critere> LstInfoClient { get; set; } = new List<Critere>();
        #endregion

        public GabaritCreateurLogo()
        {
            InitializeComponent();

            ChargerListeCriteres();
            ChargerListeCriteresTabulaire();
            ChargerListeInfoClient();


            if (GabaritCreateurController.Gabarit.Logo != null)
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(GabaritCreateurController.Gabarit.Logo); ;
                bitmapImage.EndInit();

                imgLogo.Source = bitmapImage;
            }
        }

        #region Méthodes
        private void ChargerListeCriteresTabulaire()
        {
            LstObCritereTabulaire = new ObservableCollection<Critere>();
            foreach (Critere c in LstObCritere)
                if (!c.Titre.Contains("client"))
                {
                    lblCritereTabulaire.Content += c.Titre + "\n";
                    LstObCritereTabulaire.Add(c);
                }
            if (LstObCritereTabulaire.Count < 1)
                lblCritereTabulaire.Content = AUCUN_CRIT;
        }
        private void ChargerListeInfoClient()
        {
            foreach (Critere c in LstObCritere)
            {
               if (c.Titre.Contains("client"))
                {
                    lblInfosClient.Content += c.Titre + "\n";
                    LstInfoClient.Add(c);
                }
            }
            if (LstInfoClient.Count < 1)
            {
                lblInfosClient.Content = AUCUN_CRIT;
                lblInfosClient.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            }
        }
        private void ChargerListeCriteres()
        {
            LstObCritere = new ObservableCollection<Critere>();
            foreach (GabaritCritere gabaritCritere in GabaritCreateurController.Gabarit.GabaritCriteres)
                if (gabaritCritere.EstUtilise)
                    LstObCritere.Add(gabaritCritere.Critere);
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }
        private void btnEnregistrer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Setter le logo
            //GabaritCreateurController.Gabarit.Logo = txtLogo.Text.ToString();

            // Setter le Titre
            GabaritCreateurController.Gabarit.TitreGabarit = txtTitre.Text.ToString();

            // Setter la date de création
            GabaritCreateurController.Gabarit.DateCreation = DateTime.Now;

            // Envoyer au controlleur.
            GabaritCreateurController.EnregistrerGabarit();
        }
        private void btnOuvrir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Dire au controleur de changer de fenêtre
            GabaritCreateurController.AfficherInterfaceOperationFacture();
        }
        private void btnImporterLogo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            

            try
            {
                GabaritCreateurController.Gabarit.Logo = txtLogo.Text.ToString();
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(GabaritCreateurController.Gabarit.Logo);
                bitmapImage.EndInit();
                imgLogo.Source = bitmapImage;
            }
            catch (Exception) {
                MessageBox.Show("Impossible d'importer cette image.");
                GabaritCreateurController.Gabarit.Logo = null;

            }
        }
        #endregion
    }
}
