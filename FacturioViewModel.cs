using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;
using Facturio.Gabarits;

namespace Facturio.ViewModels
{
    public class FacturioViewModel : BaseViewModel
    {
        #region Propriétés

        public ObservableCollection<IOngletViewModel> Onglets { get; set; }
        public IOngletViewModel OngletSelectionne { get; set; }

        #endregion

        #region Commandes

        public ICommand VaOngletCreation { get; set; }
        public ICommand VaOngletCreationModifier { get; set; }

        #endregion

        #region Constructeur

        public FacturioViewModel()
        {
            Onglets = new ObservableCollection<IOngletViewModel>
            {
                new GabaritSelecteurViewModel(),
                new GabaritCreateurViewModel()
            };

            VaOngletCreation = new RelayCommand(SelectionneOngletCreation, parameter => true);
            VaOngletCreationModifier = new RelayCommand(SelectionneOngletCreationModifier, parameter => parameter != null);
        }

        #endregion

        #region Méthodes

        private void SelectionneOngletCreation(object parameter)
        {
            OngletSelectionne = Onglets[(int)Enums.Onglets.Creation];
        }

        private void SelectionneOngletCreationModifier(object parameter)
        {
            Onglets[(int)Enums.Onglets.Creation] = new GabaritCreateurViewModel((Gabarit)parameter);
            OngletSelectionne = Onglets[(int)Enums.Onglets.Creation];
        }

        #endregion
    }
}
