using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;
using Facturio.Creation;
using Facturio.Gabarits;
using Facturio.Clients;
using Facturio.Produits;
using Facturio.Rapports;
using Facturio.Aide;

namespace Facturio
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

        #region Constructeurs

        public FacturioViewModel()
        {
            Onglets = new ObservableCollection<IOngletViewModel>
            {
                new GabaritSelecteurViewModel(),
                new GabaritCreateurViewModel(),
                new ClientsController(),
                new ProduitsController(),
                new RapportController(),
                new AideViewModel()
            };

            VaOngletCreation = new RelayCommand(SelectionneOngletCreation, parameter => true);
            VaOngletCreationModifier = new RelayCommand(SelectionneOngletCreationModifier, parameter => parameter != null);
        }

        #endregion

        #region Méthodes

        private void SelectionneOngletCreation(object parameter)
        {
            GabaritCreateurViewModel.Mode = "Nouveau";
            Onglets[(int)Enums.Onglets.Creation] = new GabaritCreateurViewModel();
            OngletSelectionne = Onglets[(int)Enums.Onglets.Creation];
        }

        private void SelectionneOngletCreationModifier(object parameter)
        {
            GabaritCreateurViewModel.Mode = "Modification";
            Onglets[(int)Enums.Onglets.Creation] = new GabaritCreateurViewModel((Gabarit)parameter);
            OngletSelectionne = Onglets[(int)Enums.Onglets.Creation];
        }

        #endregion
    }
}
