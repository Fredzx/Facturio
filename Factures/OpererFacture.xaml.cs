using Facturio.Gabarits;
using System.Windows;
using System.Windows.Controls;

namespace Facturio.Factures
{
    /// <summary>
    /// Logique d'interaction pour OpererFacture.xaml
    /// </summary>
    public partial class OpererFacture : Window
    {
        public static TabControl TbcProduitPublic { get; set; }
        public static Gabarit Gabarit { get; set; }

        public OpererFacture(Gabarit gabarit)
        {
            Gabarit = gabarit;
            InitializeComponent();
            TbcProduitPublic = tbcOperer;
        }
    }
}
