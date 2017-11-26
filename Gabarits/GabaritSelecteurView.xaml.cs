using System.Collections.Generic;
using System.Windows.Controls;

namespace Facturio.Gabarits
{
    /// <summary>
    /// Logique d'interaction pour GabaritsTabUserControl.xaml
    /// </summary>
    public partial class GabaritSelecteurView
    {
        public GabaritSelecteurView()
        {
            InitializeComponent();
            DataContext = new GabaritSelecteurViewModel();

            LsbGabarits.SelectionChanged += VideListe;
        }

        private void VideListe(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var dernierItemSelectionne = e.AddedItems[0];
                List<object> itemsSelectionnes = new List<object>((IEnumerable<object>)LsbGabarits.SelectedItems);

                foreach (var item in itemsSelectionnes)
                {
                    if (dernierItemSelectionne != item)
                        LsbGabarits.SelectedItems.Remove(item);
                }
            }
        }
    }
}
