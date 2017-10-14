using System.Collections.ObjectModel;
using Facturio.Base;

namespace Facturio.ViewModels
{
    public class FacturioViewModel : BaseViewModel
    {
        public ObservableCollection<IOngletViewModel> Onglets { get; set; }
        public IOngletViewModel SelectionCourante { get; set; }

        public FacturioViewModel()
        {
            Onglets = new ObservableCollection<IOngletViewModel>
            {
                new ListeGabaritsViewModel(/* new RelayCommand(VaOngletCreation) */),
                new ListeGabaritsViewModel(/* new RelayCommand(VaOngletCreation) */)
            };
        }

        /*
        private void VaOngletCreation(object parameter)
        {
            SelectionCourante = Onglets[1];
        }
        */
    }
}
