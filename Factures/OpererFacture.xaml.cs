using Facturio.Gabarits;
using Facturio.GabaritsCriteres;
using System.Collections.ObjectModel;
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

        public static ObservableCollection<Critere> Criteres { get; set; }

        public OpererFacture(Gabarit gabarit)
        {
            Gabarit = gabarit;
            InitializeComponent();
            TbcProduitPublic = tbcOperer;
        }

        public OpererFacture(ObservableCollection<Critere> criteres)
        {
            Criteres = criteres;
            InitializeComponent();
            TbcProduitPublic = tbcOperer;
        }
    }
}
