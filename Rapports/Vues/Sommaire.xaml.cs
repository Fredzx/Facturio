using Facturio.Factures;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Interaction logic for Sommaire.xaml
    /// </summary>
    public partial class Sommaire : UserControl
    {
        public DataGrid DtgSommaire { get; set; }

        public Produit MonProduit { get; set; }        
        ProduitFacture LigneFacture { get; set; }
        public ObservableCollection<ProduitFacture> LstProduitSommaire { get; set; }
        public ObservableCollection<ProduitFacture> LstProduitFacture { get; set; }

        public Sommaire()
        {
            InitializeComponent();

            DtgSommaire = dtgSommaire;
            btnObtenirRapport.IsEnabled = false;
            btnRapportPDF.IsEnabled = false;
            cldDateFin.SelectedDate = DateTime.Now;
        }

        public decimal CalculerTotalLigne(ProduitFacture pf)
        {
            return (decimal)(pf.Quantite * pf.Produit.Prix);
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void ListerSommaire()
        {
            LstProduitFacture = TrierProduitFacture(cldDateDebut.SelectedDate.Value, cldDateFin.SelectedDate.Value);
            LstProduitSommaire = new ObservableCollection<ProduitFacture>();

            for (int i = 0; i < LstProduitFacture.Count - 1; i++)
            {
                // Si le produit est déjà la, j'ajuste le nombre de fois qu'il est vendu.
                if (ExisteDeja(LstProduitFacture[i].Produit.Id, LstProduitSommaire))
                {
                    LstProduitSommaire[TrouverIndex(LstProduitSommaire, LstProduitFacture[i].Produit.Id)].NbFoisVendu += LstProduitFacture[i].Quantite;
                }
                // si le produit n'existe pas, j'ajoute le produit dans la liste sommaire
                if (LstProduitSommaire.Count == 0 || !ExisteDeja(LstProduitFacture[i].Produit.Id, LstProduitSommaire))
                {
                    LstProduitSommaire.Add(LstProduitFacture[i]);
                    LstProduitSommaire[LstProduitSommaire.Count - 1].NbFoisVendu = LstProduitFacture[i].Quantite;
                }
            }
            DtgSommaire.ItemsSource = LstProduitSommaire;
        }

        public ObservableCollection<ProduitFacture> TrierProduitFacture(DateTime dateDebut, DateTime dateFin)
        {
            LstProduitFacture = new ObservableCollection<ProduitFacture>(HibernateProduitFacturesService.RetrieveAll());
            ObservableCollection<ProduitFacture> lstTemp = new ObservableCollection<ProduitFacture>();

            foreach (ProduitFacture pf in LstProduitFacture)
            {
                if(pf.Facture.Date >= dateDebut && pf.Facture.Date <= dateFin)
                {
                    lstTemp.Add(pf);
                }
            }
            return lstTemp;
        }

        public void InsertRapportSommaire()
        {
            RapportSommaire RS = new RapportSommaire();
            List<Facture> lstFacture = new List<Facture>(HibernateFactureService.RetrieveBetweenDates(cldDateDebut.SelectedDate.Value,
                                                                                           cldDateFin.SelectedDate.Value));
            RS.Date = DateTime.Now;

            HibernateRapportSommaire.Create(RS);
            RS.LstRapportFacture = RapportController.ConstruireRapportFacture(lstFacture, RS);
            RapportController.InsertRapportFacture(RS.LstRapportFacture.ToList());
            RapportController.LstRapport.Add(RS);
        }

        public int TrouverIndex(ObservableCollection<ProduitFacture> obcProduitFacture, int? idProduit)
        {
            int index = 0;
            foreach (var pf in obcProduitFacture)
            {
                if (pf.Produit.Id == idProduit)
                    return index;

                index++;
            }

            return -1;
        }

        private void btnObtenirRapport_Click(object sender, RoutedEventArgs e)
        {
            ListerSommaire();
            InsertRapportSommaire();
        }

        private void ReInitialiserCalcul()
        {

        }

        private void btnRapportPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool ExisteDeja(int? id, ObservableCollection<ProduitFacture> lstPF)
        {
            foreach (var pf in lstPF)
            {
                if (pf.Produit.Id == id)
                    return true;
            }
            return false;
        }
    }
}
