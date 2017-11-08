﻿using Facturio.Rapports.Entities;
using Facturio.Rapports.Hibernate;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facturio.Rapports.Vues
{
    /// <summary>
    /// Logique d'interaction pour ListeRapport.xaml
    /// </summary>
    public partial class ListeRapportUserControl : UserControl
    {
        public static DataGrid DtgRapports { get; set; }

        public List<Rapport> LstRapport { get; set; } = new List<Rapport>();
        public string TypeRapport { get; set; }

        public ListeRapportUserControl()
        {
            InitializeComponent();
            DtgRapports = dtgAfficherRapport;
            LstRapport = HibernateRapportService.RetrieveAll();

            DtgRapports.ItemsSource = LstRapport;
            
        }

        private void dtgAfficherRapport_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = ((e.Row.GetIndex()) + 1).ToString();
        }

        private void dtgAfficherRapport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
