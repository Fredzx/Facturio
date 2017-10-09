using System.Collections.ObjectModel;
using Facturio.Base;
using System.Windows.Input;
using System.Windows;

namespace Facturio.Gabarits.ViewModel
{
    public class ListeGabaritsViewModel : BaseViewModel
    {
        public ObservableCollection<Gabarit> LstGabarits { get; set; }
        public Gabarit SelectionCourante { get; set; }

        public ICommand Selection { get; set; }

        public ListeGabaritsViewModel()
        {
            LstGabarits = new ObservableCollection<Gabarit>()
            {
                new Gabarit() { Titre = "Titre #1" },
                new Gabarit() { Titre = "Titre #2" },
                new Gabarit() { Titre = "Titre #3" },
                new Gabarit() { Titre = "Titre #4" },
                new Gabarit() { Titre = "Titre #5" }
            };

            Selection = new RelayCommand(PeutSelectionner, Selectionne);

            SelectionCourante = LstGabarits[1];
        }

        public bool PeutSelectionner(object parameter) => true;

        public void Selectionne(object parameter)
        {
            if (parameter == null)
                return;

            SelectionCourante = parameter as Gabarit;
            MessageBox.Show(SelectionCourante.Titre);
        }
    }
}
