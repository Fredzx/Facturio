using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

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
                    var dtgTxtCol = new DataGridTextColumn { Header = gc.Critere.Titre};
                    var titre = RemoveDiacritics(gc.Critere.Titre);
                    dtgTxtCol.Binding = new Binding(titre);
                    dtgFacture.Columns.Add(dtgTxtCol);

                }
            }
        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
