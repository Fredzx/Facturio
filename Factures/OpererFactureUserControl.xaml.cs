using Facturio.GabaritsCriteres;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using Xceed.Wpf.Toolkit;

namespace Facturio.Factures
{
    /// <summary>
    /// Interaction logic for OpererFactureUserControl.xaml
    /// </summary>
    public partial class OpererFactureUserControl : System.Windows.Controls.UserControl
    {
        public static System.Windows.Controls.DataGrid DtgFacture;
        public static TextBlock TxtPrenom { get; set; }
        public OpererFactureUserControl()
        {
            InitializeComponent();
            DtgFacture = dtgFacture;
            TxtPrenom = txtPrenom;
            //txtPrenom.DataContext = OpererFactureController.LeClient;
            //txtNom.DataContext = OpererFactureController.LeClient;
            //txtEscompte.DataContext = OpererFactureController.LeClient.Rang;
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
                        dtgTxtCol.IsReadOnly = true;
                        dtgTxtCol.Binding = new System.Windows.Data.Binding(titre);
                        if(titre == "Produit.Prix")
                        {
                            dtgTxtCol.Binding.StringFormat = "C";
                        }
                        dtgFacture.Columns.Add(dtgTxtCol);
                    }
                    else
                    {
                        contientCritereLibre = true;
                        var col = new DataGridTemplateColumn();
                        DataTemplate textTemplate = new DataTemplate();
                        FrameworkElementFactory textFactory;
                        switch (gc.Critere.TypeCritere.TypeDuCritere)
                        {
                            case "string":
                                //var col = new DataGridTextBoxColumn();
                                textFactory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                                textTemplate.VisualTree = textFactory;
                                col.Header = gc.Critere.Titre;
                                col.IsReadOnly = false;
                                col.CellTemplate = textTemplate;
                                col.CellEditingTemplate = textTemplate;
                                dtgFacture.Columns.Add(col);
                                break;
                            case "bool":
                                textFactory = new FrameworkElementFactory(typeof(System.Windows.Controls.CheckBox));
                                textTemplate.VisualTree = textFactory;
                                col.Header = gc.Critere.Titre;
                                col.IsReadOnly = false;
                                col.CellTemplate = textTemplate;
                                col.CellEditingTemplate = textTemplate;
                                dtgFacture.Columns.Add(col);
                                //var col1 = new DataGridCheckBoxColumn();
                                break;
                            case "float":
                                // TODO: Validation de float (REGEX)
                                break;
                            case "int":
                                //textFactory = new FrameworkElementFactory(typeof(IntegerUpDown));
                                //textTemplate.VisualTree = textFactory;
                                //col.CellTemplate = textTemplate;
                                //col.CellEditingTemplate = textTemplate;
                                //col.SetValue(IntegerUpDown.WatermarkProperty, 10);
                                IntegerUpDown i = new IntegerUpDown();
                                i.Increment = 10;
                                i.Watermark = "Entrez " + titre;
                                col.Header = gc.Critere.Titre;
                                col.IsReadOnly = false;
                                //dtgFacture.Columns.Add(col);
                                //IntegerUpDown.
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

        private void btn_AssocierClient_Click(object sender, RoutedEventArgs e)
        {
            AssignerClientFacture a = new AssignerClientFacture();
            a.ShowDialog();
        }

        private void ViderFacture(object sender, RoutedEventArgs e)
        {
            OpererFactureController.LaFacture.LstProduitFacture.Clear();
            dtgFacture.Items.Refresh();
        }
    }
}
