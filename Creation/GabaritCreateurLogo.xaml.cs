using System;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Facturio.Creation
{
    /// <summary>
    /// Logique d'interaction pour GabaritCreateurLogo.xaml
    /// </summary>
    public partial class GabaritCreateurLogo : System.Windows.Controls.UserControl
    {
        public GabaritCreateurLogo()
        {
            InitializeComponent();
            
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
    }
}
