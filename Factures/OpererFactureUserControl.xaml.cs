using System.Windows.Controls;

namespace Facturio.Factures
{
    /// <summary>
    /// Interaction logic for OpererFactureUserControl.xaml
    /// </summary>
    public partial class OpererFactureUserControl : UserControl
    {
        public OpererFactureUserControl()
        {
            InitializeComponent();
            CreerFacture();
        }

        private void CreerFacture()
        {
            foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
            {
                if (gc.EstUtilise)
                {
                    var dtgTxtCol = new DataGridTextColumn { Header = gc.Critere.Titre };
                    dtgFacture.Columns.Add(dtgTxtCol);
                }
            }
        }
    }
}
