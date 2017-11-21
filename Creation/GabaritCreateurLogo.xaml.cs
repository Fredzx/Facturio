using System;
using System.Drawing;
using System.Windows.Controls;
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
            // Enregistrer le gabarit en BD.

            GabaritCreateurController.Gabarits.TitreGabarit = txtTitreFacture.Text;


           // GabaritCreateurController.Gabarits.

        }

        private void btnOuvrir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Fermer la fenêtre active (celle du look du gabarit)
            GabaritCreateurController.FermerFenetreCreationLook();

            // Ouvrir la fenêtre de gestion de la facture.
            GabaritCreateurController.OuvrirFenetreGestion();


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
