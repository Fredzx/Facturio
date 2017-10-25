using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;

namespace Facturio.Gabarits
{
    public class GabaritSelecteurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public ObservableCollection<Gabarit> Gabarits { get; set; }

        private Gabarit _gabaritSelectionne;
        public Gabarit GabaritSelectionne
        {
            get => _gabaritSelectionne;
            set
            {
                if (Equals(value, _gabaritSelectionne))
                    return;

                _gabaritSelectionne = value;
                RaisePropertyChanged(nameof(GabaritSelectionne));
            }
        }

        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand SupprimerGabarit { get; set; }

        #endregion

        #region Constructeur

        public GabaritSelecteurViewModel()
        {
            Gabarits = new ObservableCollection<Gabarit>(
                HibernateGabaritService.RetrieveAllOrderedByCreationDateDesc()
            );

            Titre = "Gabarits";

            SupprimerGabarit = new RelayCommand(SupprimeGabarit, parameter => GabaritSelectionne != null);
        }

        #endregion

        #region Méthodes

        private void SupprimeGabarit(object parameter)
        {
            // Supprime le gabarit de la BD
            HibernateGabaritService.Delete(GabaritSelectionne);

            // Supprime le gabarit de la mémoire
            Gabarits.Remove(GabaritSelectionne);
            GabaritSelectionne = null;
        }

        #endregion
    }
}
