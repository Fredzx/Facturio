using Facturio.Enums;
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
    /// Logique d'interaction pour FormClientUserControl.xaml
    /// </summary>
    public partial class AjoutModifUserControl : UserControl
    {
        public bool Ajout { get; set; } = true;
        public static Label LblFormTitle { get; set; } = new Label();
        public AjoutModifUserControl()
        {
            InitializeComponent();
            LblFormTitle = lblFormTitle;

     

        }
       

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            // L'utilisateur veut enregistrer les informations du client.
            // Vérifier si on est en ajout ou en modification.
            if (Ajout)
            {
                // TODO : Validation des informations entrées.

                
                // TODO : Ajouter le client à la liste.
                ClientsController.AjouterClient(new Client(txtPrenom.Text.ToString(), txtNom.Text.ToString()
                                                         , txtDescription.Text.ToString(), new Sexe(Sexes.Masculin) 
                                                         , txtAdresse.Text.ToString(), txtCodePostal.Text.ToString()
                                                         , "4506665555", new Rang(), new Province(Provinces.Quebec)));

                // TODO : Ajouter le client en BD.

            }    
        }
    }
}
