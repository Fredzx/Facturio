using Facturio.ProduitsFactures;
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
using System.Windows.Shapes;

namespace Facturio.Factures
{
    /// <summary>
    /// Logique d'interaction pour OpererFacture.xaml
    /// </summary>
    public partial class OpererFacture : Window
    {
        public static TabControl TbcProduitPublic { get; set; }
        
        public OpererFacture()
        {
            InitializeComponent();
            TbcProduitPublic = tbcOperer;
            
        }
    }
}
