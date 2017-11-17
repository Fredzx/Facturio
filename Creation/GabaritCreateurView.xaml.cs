using Facturio.Gabarits;
using Facturio.GabaritsCriteres;
using System.Windows;
using System.Windows.Controls;

namespace Facturio.Creation
{
    /// <summary>
    /// Interaction logic for GabaritCreateurView.xaml
    /// </summary>
    public partial class GabaritCreateurView : UserControl
    {
        //public Gabarit Gabarit { get; set; }
        //public List<GabaritCritere> GabaritCriteres { get; set; }
        //public List<ListBoxItem> ListeBoxItems { get; set; }

        public GabaritCreateurView(Gabarit gabarit)
        {
            InitializeComponent();

            /*
            Gabarit = gabarit;

            GabaritCriteres = new List<GabaritCritere>(Gabarit.GabaritCriteres);
            foreach (var gabaritCritere in GabaritCriteres)
            {
                ListBoxItem listBoxItem = new ListBoxItem() { Content = new CheckBox() };

                ((CheckBox)listBoxItem.Content).IsChecked = gabaritCritere.EstUtilise;
                ((CheckBox)listBoxItem.Content).Checked += GabaritCreateurView_Checked;
                ((CheckBox)listBoxItem.Content).Unchecked += GabaritCreateurView_Unchecked;

                ListeBoxItems.Add(listBoxItem);
                ItcCriteres.Items.Add(gabaritCritere);
            }
            */
        }

        /*
        private void GabaritCreateurView_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{e.ToString()} a été coché!");
            ((GabaritCritere)sender).EstUtilise = true;
        }

        private void GabaritCreateurView_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{e.ToString()} a été décoché!");
            ((GabaritCritere)sender).EstUtilise = false;
        }
        */

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            // Dire au controleur de changer de fenêtre
            GabaritCreateurController.AfficherInterfaceCreationSuivante();
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GabaritCritere gabaritCritere = (GabaritCritere)sender;

            DataGridTextColumn colonne = new DataGridTextColumn();
            colonne.Header = gabaritCritere.Critere.Titre;
            colonne.Width = gabaritCritere.Largeur;
            colonne.DisplayIndex = gabaritCritere.Position;
            DtgGabarit.Columns.Add(colonne);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GabaritCritere gabaritCritere = (GabaritCritere)sender;

            DtgGabarit.Columns.RemoveAt(gabaritCritere.Position);
        }
    }
}
