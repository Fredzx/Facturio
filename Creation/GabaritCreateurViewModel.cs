using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Facturio.Base;
using Facturio.Criteres;
using Facturio.Gabarits;
using Facturio.GabaritsCriteres;

namespace Facturio.Creation
{
    public class GabaritCreateurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public static string Mode = "Nouveau";

        public static Gabarit Gabarit { get; set; }

        public ObservableCollection<Critere> Criteres { get; set; }

        public ObservableCollection<GabaritCritere> GabaritCriteres { get; set; }
        public ObservableCollection<TypeCritere> TypesCriteres { get; set; }

        public string TitreCritereLibre { get; set; }
        public TypeCritere TypeCritereSelectionne { get; set; }

        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand AjouteCritere { get; set; }
        public ICommand SupprimeCritere { get; set; }

        #endregion

        #region Constructeurs

        public GabaritCreateurViewModel()
        {
            if (Mode == "Nouveau")
                Gabarit = new Gabarit { GabaritCriteres = CreerNouveauGabarit() };


            GabaritCriteres = new ObservableCollection<GabaritCritere>(Gabarit.GabaritCriteres);

            TypesCriteres = new ObservableCollection<TypeCritere>(HibernateTypeCritereService.RetrieveAll());
            TypeCritereSelectionne = TypesCriteres[0];

            Titre = "Création";

            AjouteCritere = new RelayCommand(AjouterCritere, parameter => !string.IsNullOrWhiteSpace(TitreCritereLibre));
            SupprimeCritere = new RelayCommand(SupprimerCritere, parameter => true);
        }

        public GabaritCreateurViewModel(Gabarit gabarit) : this()
        {
            Gabarit = gabarit;
        }

        #endregion

        #region Méthodes

        private void AjouterCritere(object parameter)
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
            GabaritCriteres = new ObservableCollection<GabaritCritere>(Gabarit.GabaritCriteres);

            TitreCritereLibre = string.Empty;
        }

        private void SupprimerCritere(object parameter)
        {
            Gabarit.GabaritCriteres.Remove((GabaritCritere)parameter);
            GabaritCriteres = new ObservableCollection<GabaritCritere>(Gabarit.GabaritCriteres);
        }

        private ISet<GabaritCritere> CreerNouveauGabarit()
        {
            const int POSITION = 0;
            const int LARGEUR = 50;

            ISet<GabaritCritere> gabaritCriteres = new HashSet<GabaritCritere>();
            for (int i = 0; i < 12; ++i)
            {
                GabaritCritere gabaritCritere = new GabaritCritere
                {
                    Gabarit = null,
                    Critere = HibernateCritereService.Retrieve(i + 1).First(),
                    Position = POSITION,
                    Largeur = LARGEUR,
                    EstUtilise = false
                };
                
                gabaritCriteres.Add(gabaritCritere);
            }

            return gabaritCriteres;
        }

        #endregion
    }
}
