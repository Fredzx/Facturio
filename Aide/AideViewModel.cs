using Facturio.Base;
using System.Windows.Input;

namespace Facturio.Aide
{
    public class AideViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public string Titre { get; set; }
        public string PageCourante { get; set; }

        #endregion

        #region Commandes

        public ICommand AideGabarit { get; set; }
        public ICommand AideCreation { get; set; }
        public ICommand AideProduit { get; set; }
        public ICommand AideClient { get; set; }
        public ICommand AideRapport { get; set; }

        #endregion

        #region Constructeurs

        public AideViewModel()
        {
            Titre = "Aide";

            PageCourante = "Pages/AideGabaritPage.xaml";

            AideGabarit = new RelayCommand(AfficherAideGabarit);
            AideCreation = new RelayCommand(AfficherAideCreation);
            AideProduit = new RelayCommand(AfficherAideProduit);
            AideClient = new RelayCommand(AfficherAideClient);
            AideRapport = new RelayCommand(AfficherAideRapport);
        }

        #endregion

        #region Méthodes

        private void AfficherAideGabarit(object obj)
        {
            PageCourante = "Pages/AideGabaritPage.xaml";
        }

        private void AfficherAideCreation(object obj)
        {
            PageCourante = "Pages/AideCreationPage.xaml";
        }

        private void AfficherAideProduit(object obj)
        {
            PageCourante = "Pages/AideProduitPage.xaml";
        }

        private void AfficherAideClient(object obj)
        {
            PageCourante = "Pages/AideClientPage.xaml";
        }

        private void AfficherAideRapport(object obj)
        {
            PageCourante = "Pages/AideRapportPage.xaml";
        }

        #endregion
    }
}