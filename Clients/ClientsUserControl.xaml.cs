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
      public Control ControlSelectionne { get; set; }
      public ClientsUserControl()
      {
         InitializeComponent();



         txtRecherche.Text = "Rechercher un client";

         
         
      }
   

     

      private void TxtRecherche_Selectionne(object sender, EventArgs e)
      {
         txtRecherche.Text = "";
      }
   }
}
