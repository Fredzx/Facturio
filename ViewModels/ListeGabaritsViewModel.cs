using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;
using Facturio.Models;

namespace Facturio.ViewModels
{
    public class ListeGabaritsViewModel : BaseViewModel, IOngletViewModel
    {
        public ObservableCollection<Gabarit> Gabarits { get; set; }
        public Gabarit SelectionCourante { get; set; }

        public string Titre { get; set; } = "Gabarits";

        public ICommand NouveauGabarit { get; set; }
        public ICommand SupprimerGabarit { get; set; }

        public ListeGabaritsViewModel(/* ICommand command */)
        {
            Gabarits = new ObservableCollection<Gabarit>
            {
                new Gabarit { Titre = "Titre #1" },
                new Gabarit { Titre = "Titre #2" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" },
                new Gabarit { Titre = "Titre #3" }
            };

            // NouveauGabarit = command;
            SupprimerGabarit = new RelayCommand(SupprimeGabarit, parameter => SelectionCourante != null);
        }

        private void SupprimeGabarit(object parameter)
        {
            Gabarits.Remove(SelectionCourante);
            SelectionCourante = null;
        }
    }
}
