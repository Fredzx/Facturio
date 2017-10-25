using Facturio.Base;
using Facturio.Gabarits;

namespace Facturio.Creation
{
    public class GabaritCreateurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        private static Gabarit _gabarit;
        public Gabarit Gabarit
        {
            get => _gabarit;
            set
            {
                if (Equals(value, _gabarit))
                    return;

                // TODO: M'arranger pour pogner un "default" gabarit... avec les critères de base.
                if (_gabarit == null)
                    _gabarit = new Gabarit();

                _gabarit = value;
                RaisePropertyChanged(nameof(Gabarit));
            }
        }

        public string Titre { get; set; }

        #endregion

        #region Constructeurs

        public GabaritCreateurViewModel()
        {
            Titre = "Création";
        }

        public GabaritCreateurViewModel(Gabarit gabarit) : this()
        {
            Gabarit = gabarit;
        }

        #endregion
    }
}
