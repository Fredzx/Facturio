using Facturio.GabaritsCriteres;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;

namespace Facturio.Factures
{
    /// <summary>
    /// Interaction logic for OpererFactureUserControl.xaml
    /// </summary>
    public partial class OpererFactureUserControl : System.Windows.Controls.UserControl
    {
        public OpererFactureUserControl()
        {
            InitializeComponent();
            CreerFacture();
        }

        private void CreerFacture()
        {
            bool contientCritereLibre = false;
            foreach (var gc in OpererFacture.Gabarit.GabaritCriteres)
            {
                if (gc.EstUtilise)
                {
                    var titre = GenererNomBinding(gc);
                    if (titre != "")
                    {
                        var dtgTxtCol = new DataGridTextColumn { Header = gc.Critere.Titre };
                        dtgTxtCol.Binding = new System.Windows.Data.Binding(titre);
                        dtgTxtCol.IsReadOnly = true;
                        dtgFacture.Columns.Add(dtgTxtCol);
                    }
                    else
                    {
                        contientCritereLibre = true;
                        var col = new DataGridTemplateColumn();
                        switch (gc.Critere.TypeCritere.TypeDuCritere)
                        {
                            case "string":
                                //var col = new DataGridTextBoxColumn();
                                FrameworkElementFactory textFactory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                                DataTemplate textTemplate = new DataTemplate();
                                textTemplate.VisualTree = textFactory;
                                col.Header = gc.Critere.Titre;
                                col.IsReadOnly = false;
                                col.CellTemplate = textTemplate;
                                col.CellEditingTemplate = textTemplate;
                                dtgFacture.Columns.Add(col);
                                break;
                            case "bool":
                                var col1 = new DataGridCheckBoxColumn();
                                col1.Header = gc.Critere.Titre;
                                col1.IsReadOnly = false;
                                dtgFacture.Columns.Add(col1);
                                break;
                            case "float":
                                // TODO: Validation de float (REGEX)
                                break;
                            case "int":
                                // TODO: Validation de int (REGEX)
                                break;

                            default:
                                break;
                        }

                    }
                }
            }
            if(contientCritereLibre)
                System.Windows.MessageBox.Show("Ce gabarit contient un critère libre\nVeuillez entrer les informations par vous-même");
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

        private string GenererNomBinding(GabaritCritere gc)
        {
            string critere = "";
            switch (gc.Critere.Titre)
            {
                case "Quantité":
                    critere = "Quantite";
                    break;
                case "Prix":
                    critere = "Produit.Prix";
                    break;
                case "Nom produit":
                    critere = "Produit.Nom";
                    break;
                case "Description":
                    critere = "Produit.Description";
                    break;
                case "":
                    critere = "";
                    break;
                default:
                    critere = "";
                    break;
            }
            return critere;
        }

        private IEnumerable DeterminerCritereLibre(GabaritCritere gc)
        {
            //System.Console.WriteLine(gc.Critere.TypeCritere.TypeDuCritere);
            switch (gc.Critere.TypeCritere.TypeDuCritere)
            {
                case "string":
                    yield return new DataGridTextColumn();
                    break;
                case "bool":
                    yield return new DataGridCheckBoxColumn();
                    break;
                case "float":
                    // TODO: Validation de float (REGEX)
                    break;
                case "int":
                    // TODO: Validation de int (REGEX)
                    break;

                default:
                    break;
            }
        }

        private void BtnConvertirPdf_Click(object sender, RoutedEventArgs e)
        {
            OpererFactureController.GenererPdf("Facture_Test", "");
        }
    }
}
