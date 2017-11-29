using System;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Facturio.GabaritsCriteres;
using System.Collections.ObjectModel;

namespace Facturio.Creation

{
    /// <summary>
    /// Logique d'interaction pour GabaritCreateurLogo.xaml
    /// </summary>
    public partial class GabaritCreateurLogo : System.Windows.Controls.UserControl
    {
        #region Propriétés
        public static System.Windows.Controls.DataGrid DtgCriteres { get; set; } = new System.Windows.Controls.DataGrid();
        public static ObservableCollection<Critere> LstObCritere { get; set; }
        #endregion

        public GabaritCreateurLogo()
        {
            InitializeComponent();
            DtgCriteres = dtgCritere;

            LstObCritere = new ObservableCollection<Critere>();
            foreach (GabaritCritere gabaritCritere in GabaritCreateurController.Gabarit.GabaritCriteres)
                if (gabaritCritere.EstUtilise)
                    LstObCritere.Add(gabaritCritere.Critere);

            DtgCriteres.ItemsSource = LstObCritere;
            
           
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
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }
        private void btnEnregistrer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Setter le logo
            // GabaritCreateurController.Gabarits.Logo

            // Setter le Titre
            GabaritCreateurController.Gabarit.TitreGabarit = "Test1";


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
            GabaritCreateurController.Gabarit.Logo = txtLogo.Text.ToString();

            try
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(GabaritCreateurController.Gabarit.Logo);
                bitmapImage.EndInit();
                imgLogo.Source = bitmapImage;

            }
            catch (Exception) { MessageBox.Show("Impossible d'importer cette image."); }
        }
        #endregion
    }
}
