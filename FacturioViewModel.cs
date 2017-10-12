using System.Collections.ObjectModel;
using System.Windows.Controls;
using Facturio.Base;
using Facturio.Gabarits.ViewModel;

namespace Facturio
{
    public class FacturioViewModel : BaseViewModel
    {
        public ObservableCollection<TabItem> LstTabItems { get; set; }
        public TabItem SelectionCourante { get; set; }

        public FacturioViewModel()
        {
            LstTabItems = new ObservableCollection<TabItem>()
            {

            };
        }
    }
}
