using System.Collections.ObjectModel;
using System.Windows.Input;
using Facturio.Base;

namespace Facturio.Gabarits.ViewModel
{
    public class ListeGabaritsViewModel : BaseViewModel
    {
        public ObservableCollection<Gabarit> LstGabarits { get; set; }
        public Gabarit SelectionCourante { get; set; }

        public ICommand NouveauGabarit { get; set; }

        public ListeGabaritsViewModel()
        {
            LstGabarits = new ObservableCollection<Gabarit>()
            {
                new Gabarit() { Titre = "Titre #1" },
                new Gabarit() { Titre = "Titre #2" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #3" }
            };

            NouveauGabarit = new RelayCommand(VaOngletCreation);
        }

        private void VaOngletCreation(object parameter)
        {
            
        }
    }
}
