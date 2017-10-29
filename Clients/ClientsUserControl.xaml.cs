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
   /// Logique d'interaction pour ClientsUserControl.xaml
   /// </summary>
   public partial class ClientsUserControl : System.Windows.Controls.UserControl
   {
        public static TabControl TbcClientPublic { get; set; } = new TabControl();
        public ClientsUserControl()
        {
            InitializeComponent();
            TbcClientPublic = tbcClient;
            
        }

        private void tbcClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tbcClient.SelectedItem == tbiRechercher)
            {
                AjoutModifUserControl.LblFormTitle.Content = "Ajouter un client";
                AjoutModifUserControl.LblTxtNoClient.Content = "En cours de génération...";
                AjoutModifUserControl.ViderChamps();
                AjoutModifUserControl.LblInfo.Content = "";
                
            }
        }
    }
}
