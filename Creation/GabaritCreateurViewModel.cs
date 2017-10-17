using Facturio.Base;

namespace Facturio.Gabarits
{
    public class GabaritCreateurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public Gabarit GabaritModification { get; set; }
        public string Titre { get; set; }

        #endregion

        #region Constructeurs

        public GabaritCreateurViewModel()
        {
            Titre = "Création";
        }

        public GabaritCreateurViewModel(Gabarit gabarit) : this()
        {
            GabaritModification = gabarit;
        }

        #endregion
    }
}
