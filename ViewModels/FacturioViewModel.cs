using System.Collections.ObjectModel;

namespace Facturio.ViewModels
{
    public class FacturioViewModel : BaseViewModel
    {
        #region Propriétés

        public ObservableCollection<IOngletViewModel> Onglets { get; set; }
        public IOngletViewModel SelectionCourante { get; set; }

        #endregion

        #region Constructeur

        public FacturioViewModel()
        {
            Onglets = new ObservableCollection<IOngletViewModel>
            {
                new GabaritSelecteurViewModel(),
                new GabaritSelecteurViewModel()
            };
        }

        #endregion
    }
}
