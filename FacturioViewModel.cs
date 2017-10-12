using System.Collections.ObjectModel;
using System.Windows.Controls;
using Facturio.Base;

namespace Facturio
{
    public class FacturioViewModel : BaseViewModel
    {
        public ObservableCollection<TabItem> LstTabItems { get; set; }

        public FacturioViewModel()
        {
            LstTabItems = new ObservableCollection<TabItem>()
            {
                new TabItem() { Header = "Gabarits" },
                new TabItem() { Header = "Création" },
                new TabItem() { Header = "Clients" },
                new TabItem() { Header = "Produits" },
                new TabItem() { Header = "Rapports" }
            };
        }
    }
}
