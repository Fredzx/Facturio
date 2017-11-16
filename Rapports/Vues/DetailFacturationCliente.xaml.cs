﻿using Facturio.Clients;
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
using System.Windows.Shapes;

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Logique d'interaction pour DetailFacturationCliente.xaml
    /// </summary>
    public partial class DetailFacturationCliente : Window
    {
        const double TPS = 0.09975;
        const double TVQ = 0.05000;

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int? IdClient { get; set; }
       public Produit Produit { get; set; }
        public ObservableCollection<Facture> LstFacture { get; set; }
        public ObservableCollection<ProduitFacture> LstProduitFacture { get; set; }
        public int compteur = 0;
        public DataGrid DtgProduit { get; set; }
        public decimal Total { get; set; }

        public DetailFacturationCliente(DateTime dateDebut, DateTime dateFin, Client leClient)
        {
            InitializeComponent();

            DtgProduit = dtgProduits;
            DateDebut = dateDebut;
            DateFin = dateFin;
            LstFacture = new ObservableCollection<Facture>(HibernateFactureService.RetrieveFacturationCliente(dateDebut, DateFin, leClient.IdClient));
            AjouterColonneTotal();

            RafraichirData(true);
        }

        public DetailFacturationCliente(DateTime dateDebut, DateTime dateFin, Produit leProduit)
        {
            InitializeComponent();

            DtgProduit = dtgProduits;
            DateDebut = dateDebut;
            DateFin = dateFin;
            LstProduitFacture = new ObservableCollection<ProduitFacture>(HibernateProduitFacturesService.RetrieveProduit(leProduit.Id));
            LstFacture = new ObservableCollection<Facture>(ConstruireFactures());
            AjouterColonneTotal();
            RafraichirData(true);
        }

        private void AjouterColonneTotal()
        {
            var col = new DataGridTextColumn();
            col.Header = "Total";
            col.Binding = new Binding("Total");
            col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            DtgProduit.Columns.Add(col);
        }

        private void Button_Click_Precedent(object sender, RoutedEventArgs e)
        {
            if (compteur <= 0)
                compteur = LstFacture.Count - 1;
            else
                compteur--;

            RafraichirData(false);
        }

        private void Button_Click_Suivant(object sender, RoutedEventArgs e)
        {
            if (compteur >= LstFacture.Count - 1)
                compteur = 0;
            else
                compteur++;

            RafraichirData(false);
        }
        private decimal CalculerSousTotalLigne(IList<ProduitFacture> lstPF)
        {
            if (lstPF.Count > 0)
                return lstPF[0].CalculerTotalLigne();
            else
                return 0;
        }

        public decimal CalculerSousTotal()
        {
            decimal total = 0;

            foreach (ProduitFacture p in LstFacture[compteur].LstProduitFacture)
                {
                    total += ((decimal)p.Quantite* (decimal)p.Produit.Prix);
                }

            return total;
        }

        public decimal CalculerTaxes(double taxe)
        {
            return (CalculerSousTotal() * (decimal)taxe);
        }   

        public decimal CalculerTotal()
        {
            return (CalculerSousTotal() + CalculerTaxes(TPS) + CalculerTaxes(TVQ));
        }

        public void RafraichirData(bool estPremiereOuverture)
        {
            if (LstFacture != null || LstFacture.Count != 0)
            {
                DtgProduit.ItemsSource = LstFacture[compteur].LstProduitFacture;
                lblNoFacture.Content = (compteur + 1).ToString() + "/" + LstFacture.Count;
                Total = 0;

                if(!estPremiereOuverture)
                    DtgProduit.Items.Refresh();

                txtSousTotal.Text = Math.Round(CalculerSousTotal(), 2).ToString() + "$";
                txtTPS.Text = Math.Round(CalculerTaxes(TPS), 2).ToString() + "$";
                txtTVQ.Text = Math.Round(CalculerTaxes(TVQ), 2).ToString() + "$";
                txtTotal.Text = Math.Round(CalculerTotal(), 2).ToString() + "$";
            }
            else
            {
                lblInfo.Foreground = Brushes.Red;
                lblInfo.Content = "Aucune facture pour la date du " + DateDebut + " au " + DateFin;
            }
        }

        public List<Facture> ConstruireFactures()
        {
            List<Facture> lstFacture = new List<Facture>();

            foreach (ProduitFacture pf in LstProduitFacture)
            {
                lstFacture.Add(pf.Facture);
            }
            return lstFacture;
        }
    }
}
