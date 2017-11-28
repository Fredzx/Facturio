using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
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
        public static ObservableCollection<Critere> LstObCritere { get; set; } = new ObservableCollection<Critere>();
        #endregion

        public GabaritCreateurLogo()
        {
            InitializeComponent();
            DtgCriteres = dtgCritere;


            foreach (GabaritCritere gabaritCritere in GabaritCreateurController.Gabarits.GabaritCriteres)
                if (gabaritCritere.EstUtilise)
                    LstObCritere.Add(gabaritCritere.Critere);

            DtgCriteres.ItemsSource = LstObCritere;
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
            GabaritCreateurController.Gabarits.TitreGabarit = "Test1";


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
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Sélection d'un logo";
                dlg.Filter = "Images files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lblLogo.Content = dlg.FileName;
                    
                    imgLogo.Source = new BitmapImage(new Uri(dlg.FileName));
                }
            }
        }
        #endregion
    }
}
