using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Facturio.Base;
using Facturio.GabaritsCriteres;
using Facturio.Gabarits;
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
        // À la place d'une liste de DataGridTextColumn j'aurais une liste de GabaritCritereViewModels
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
            // TODO: Vérifier si le critère à ajouter existe déjà dans la liste
            // Comparer le nom de tous les critères avec le nom du critère à ajouter
            // Si pareil, afficher message d'erreur
            // Sinon, ajouter le critère

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
            var chb = (CheckBox)parameter;
            var dtgTxtCol = new DataGridTextColumn { Header = chb.Content.ToString() };

            if (chb.IsChecked == true)
            {
                // Vérifier si les deux checkboxes sont bien remplies (> 0)...
                // Doit faire un GabaritCritereViewModel, pour pouvoir binder TwoWay Position, Largeur, EstUtilise
                // Chaque fois que la liste de GabaritCritereViewModel sera modifié, je vais faire:
                // GabaritCriteres.Clear();
                // foreach (var gabaritCritereViewModel in GabaritCritereViewModels)
                // {
                //     var gabaritCritere = new GabaritCritere
                //     {
                //         Gabarit = gabaritCritereViewModel.Gabarit,
                //         Critere = gabaritCritereViewModel.Critere,
                //         Largeur = gabaritCritereViewModel.Largeur,
                //         Position = gabaritCritereViewModel.Position,
                //         EstUtilise = gabaritCritereViewModel.EstUtilise
                //     };
                //
                //     GabaritCriteres.Add(gabaritCritere);
                // }

                Colonnes.Add(dtgTxtCol);
                return;
            }

            EnleverColonne(chb.Content.ToString());
        }

        private void EnleverColonne(string titre)
        {
            for (int i = 0; i < Colonnes.Count; ++i)
            {
                if (Colonnes[i].Header.ToString() == titre)
                {
                    Colonnes.RemoveAt(i);
                    return;
                }
            }
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
