using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Facturio.Base;
using Facturio.Criteres;
using Facturio.Gabarits;
using Facturio.GabaritsCriteres;

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

                _gabarit = value;
                RaisePropertyChanged(nameof(Gabarit));
            }
        }

        public ObservableCollection<TypeCritere> TypesCriteres { get; set; }

        private string _titreCritereLibre;
        public string TitreCritereLibre
        {
            get => _titreCritereLibre;
            set
            {
                if (value == _titreCritereLibre)
                    return;

                _titreCritereLibre = value;
                RaisePropertyChanged(nameof(TitreCritereLibre));
            }
        }

        private TypeCritere _typeCritereSelectionne;
        public TypeCritere TypeCritereSelectionne
        {
            get => _typeCritereSelectionne;
            set
            {
                if (Equals(value, _typeCritereSelectionne))
                    return;

                _typeCritereSelectionne = value;
                RaisePropertyChanged(nameof(TypeCritereSelectionne));
            }
        }

        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand AjouterCritere { get; set; }

        #endregion

        #region Constructeurs

        public GabaritCreateurViewModel()
        {
            TypesCriteres = new ObservableCollection<TypeCritere>(HibernateTypeCritereService.RetrieveAll());
            TypeCritereSelectionne = TypesCriteres[0];
            Titre = "Création";

            AjouterCritere = new RelayCommand(AjouteCritere, parameter => !string.IsNullOrWhiteSpace(TitreCritereLibre));
        }

        public GabaritCreateurViewModel(Gabarit gabarit) : this()
        {
            Gabarit = gabarit ?? CreerNouveauGabarit();
        }

        #endregion

        #region Méthodes

        private void AjouteCritere(object parameter)
        {
            GabaritCritere gabaritCritere = new GabaritCritere
            {
                Gabarit = Gabarit,
                Critere = new Critere { Titre = TitreCritereLibre.Trim(), TypeCritere = TypeCritereSelectionne },
                Position = 0,
                Largeur = 50,
                EstUtilise = false
            };

            Gabarit.GabaritCriteres.Add(gabaritCritere);
        }

        private Gabarit CreerNouveauGabarit()
        {
            const int POSITION = 0;
            const int LARGEUR = 50;

            Gabarit gabarit = new Gabarit();

            List<GabaritCritere> gabaritCriteres = new List<GabaritCritere>();
            for (int i = 0; i < 12; ++i)
            {
                GabaritCritere gabaritCritere = new GabaritCritere
                {
                    Gabarit = gabarit,
                    Critere = HibernateCritereService.Retrieve(i + 1).First(),
                    Position = POSITION,
                    Largeur = LARGEUR,
                    EstUtilise = false
                };
                
                gabaritCriteres.Add(gabaritCritere);
            }

            gabarit.GabaritCriteres = gabaritCriteres;

            return gabarit;
        }

        #endregion
    }
}
