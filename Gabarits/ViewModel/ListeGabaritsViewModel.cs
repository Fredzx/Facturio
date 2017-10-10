using System.Collections.ObjectModel;
using Facturio.Base;

namespace Facturio.Gabarits.ViewModel
{
    public class ListeGabaritsViewModel : BaseViewModel
    {
        public ObservableCollection<Gabarit> LstGabarits { get; set; }
        public Gabarit SelectionCourante { get; set; }

        public ListeGabaritsViewModel()
        {
            LstGabarits = new ObservableCollection<Gabarit>()
            {
                new Gabarit() { Titre = "Titre #1" },
                new Gabarit() { Titre = "Titre #2" },
                new Gabarit() { Titre = "Titre #3" }
            };

            SelectionCourante = LstGabarits[1];
        }
    }
}
