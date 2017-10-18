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

namespace Facturio.Produits
{
    /// <summary>
    /// Logique d'interaction pour Ajouter_ModifierUserControl.xaml
    /// </summary>
    public partial class AjoutModifUserControl : UserControl
    {
        public static Label LblFormTitle { get; set; } = new Label();
        public AjoutModifUserControl()
        {
            InitializeComponent();
            LblFormTitle = lblFormTitle;
        }

        private void btnEnregister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            // Lorsqu'il clique sur Retour on veut : 
            // Que le usercontrol Produit change d'onglet > direction : onglet rechercher.
            ProduitUserControl.TbcProduitPublic.SelectedIndex = 0;
        }
    }
}
