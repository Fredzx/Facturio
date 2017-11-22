using System.Windows;
using System.Windows.Controls;

namespace Facturio.Factures
{
    /// <summary>
    /// Logique d'interaction pour OpererFactureUC.xaml
    /// </summary>
    public partial class OpererFactureUC : UserControl
    {
        public static DataGrid DtgListeProduitsFacture { get; set; } = new DataGrid();
        
        public OpererFactureUC()
        {
            InitializeComponent();
            DtgListeProduitsFacture = dtgListeProduitsFacture;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AssignerClientFacture ac = new AssignerClientFacture();
            ac.ShowDialog();
        }

        private void dtgListeProduitsFacture_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }
    }
}
