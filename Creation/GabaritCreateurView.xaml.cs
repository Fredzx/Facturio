using System;
using System.Windows;
using System.Windows.Controls;

namespace Facturio.Creation
{
    /// <summary>
    /// Interaction logic for GabaritCreateurView.xaml
    /// </summary>
    public partial class GabaritCreateurView : UserControl
    {
        public GabaritCreateurView()
        {
            InitializeComponent();
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            // Dire au controleur de changer de fenêtre
            GabaritCreateurController.AfficherInterfaceCreationSuivante();
        }

        // Pour l'ordre des colonnes
        // ----------------------------
        // ColumnHeaderDragCompleted
        // ColumnHeaderDragStarted

        // ColumnReordering
        // ColumnReordered

        // ColumnDisplayIndexChanged

        // ColumnHeaderDragDelta -> Occurs every time the mouse position changes while the user drags a column header.
    }
}
