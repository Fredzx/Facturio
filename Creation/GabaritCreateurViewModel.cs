using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Facturio.Base;
using Facturio.Criteres;
using Facturio.Gabarits;
using Facturio.GabaritsCriteres;
using System.Windows.Controls;

namespace Facturio.Creation
{
    public class GabaritCreateurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public static string Mode = "Nouveau";

        public static Gabarit Gabarit { get; set; }

        // TODO: Si j'ai le temps, essayer de trouver une façon qui permet d'enlever le DataGridTextColumn du ViewModel,
        //       car là je mets du code de la View dans le ViewModel.
        public ObservableCollection<DataGridTextColumn> Colonnes { get; set; }
        public ObservableCollection<string> TitresDesColonnes { get; set; }

        public ObservableCollection<GabaritCritere> GabaritCriteres { get; set; }
        public ObservableCollection<TypeCritere> TypesCriteres { get; set; }

        public string TitreCritereLibre { get; set; }
        public TypeCritere TypeCritereSelectionne { get; set; }

        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand AjouteCritere { get; set; }
        public ICommand SupprimeCritere { get; set; }
        public ICommand AfficheColonne { get; set; }

        #endregion

        #region Constructeurs

        public GabaritCreateurViewModel()
        {
            if (Mode == "Nouveau")
                Gabarit = new Gabarit { GabaritCriteres = CreerNouveauGabarit() };

            GabaritCriteres = new ObservableCollection<GabaritCritere>(Gabarit.GabaritCriteres);

            TitresDesColonnes = new ObservableCollection<string>();
            foreach (GabaritCritere gabaritCritere in Gabarit.GabaritCriteres)
                if (gabaritCritere.EstUtilise)
                    TitresDesColonnes.Add(gabaritCritere.Critere.Titre);

            Colonnes = new ObservableCollection<DataGridTextColumn>();
            foreach (string titreColonne in TitresDesColonnes)
                Colonnes.Add(new DataGridTextColumn { Header = titreColonne });

            TypesCriteres = new ObservableCollection<TypeCritere>(HibernateTypeCritereService.RetrieveAll());
            TypeCritereSelectionne = TypesCriteres[0];

            Titre = "Création";

            AjouteCritere = new RelayCommand(AjouterCritere, param => !string.IsNullOrWhiteSpace(TitreCritereLibre));
            SupprimeCritere = new RelayCommand(SupprimerCritere, param => true);
            AfficheColonne = new RelayCommand(AfficherColonne, param => true);
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
            var gabaritCritere = (GabaritCritere)parameter;

            if (gabaritCritere.EstUtilise)
                AfficherColonne(new CheckBox { Content = gabaritCritere.Critere.Titre });

            Gabarit.GabaritCriteres.Remove((GabaritCritere)parameter);
            GabaritCriteres = new ObservableCollection<GabaritCritere>(Gabarit.GabaritCriteres);
        }

        private void AfficherColonne(object parameter)
        {
            CheckBox chb = (CheckBox)parameter;
            var dtgTxtCol = new DataGridTextColumn { Header = chb.Content.ToString() };

            if (chb.IsChecked == true)
            {
                Colonnes.Add(dtgTxtCol);
                return;
            }

            for (int i = 0; i < Colonnes.Count; ++i)
                if (Colonnes[i].Header.ToString() == chb.Content.ToString())
                    Colonnes.RemoveAt(i);
        }

        private ISet<GabaritCritere> CreerNouveauGabarit()
        {
            const int NB_GABARITCRITERE = 12;
            const int POSITION = 0;
            const int LARGEUR = 50;

            ISet<GabaritCritere> gabaritCriteres = new HashSet<GabaritCritere>();
            for (int i = 0; i < NB_GABARITCRITERE; ++i)
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
