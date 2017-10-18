using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;
using Facturio.Creation;
using Facturio.Gabarits;
using Facturio.Clients;
using Facturio.Produits;

namespace Facturio
{
    public class FacturioViewModel : BaseViewModel
    {
        #region Propriétés

        public ObservableCollection<IOngletViewModel> Onglets { get; set; }

        private IOngletViewModel _ongletSelectionne;
        public IOngletViewModel OngletSelectionne
        {
            get => _ongletSelectionne;
            set
            {
                if (value == _ongletSelectionne)
                    return;

                _ongletSelectionne = value;
                RaisePropertyChanged(nameof(OngletSelectionne));
            }
        }

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
                new GabaritCreateurViewModel(),
                new ClientsController(),
                new ProduitsController()
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
