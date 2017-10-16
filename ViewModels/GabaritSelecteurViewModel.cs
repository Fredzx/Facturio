using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;
using Facturio.Models;

namespace Facturio.ViewModels
{
    public class GabaritSelecteurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public ObservableCollection<Gabarit> Gabarits { get; set; }
        public Gabarit SelectionCourante { get; set; }
        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand NouveauGabarit { get; set; }
        public ICommand SupprimerGabarit { get; set; }

        #endregion

        #region Constructeur

        public GabaritSelecteurViewModel()
        {
            Gabarits = new ObservableCollection<Gabarit>
            {
                new Gabarit { Titre = "Titre #1" },
                new Gabarit { Titre = "Titre #2" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #4" },
                new Gabarit { Titre = "Titre #5" }
            };

            Titre = "Gabarits";

            SupprimerGabarit = new RelayCommand(SupprimeGabarit, parameter => SelectionCourante != null);
        }

        #endregion

        #region Méthodes

        private void SupprimeGabarit(object parameter)
        {
            Gabarits.Remove(SelectionCourante);
            SelectionCourante = null;
        }

        #endregion
    }
}
