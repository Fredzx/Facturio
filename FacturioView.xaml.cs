﻿using System.Windows;

namespace Facturio
{
    /// <summary>
    /// Interaction logic for Facturio.xaml
    /// </summary>
    public partial class FacturioView : Window
    {
        public FacturioView()
        {
            DataContext = new FacturioViewModel();
            InitializeComponent();
        }
    }
}
