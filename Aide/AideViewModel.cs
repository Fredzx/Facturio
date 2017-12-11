using Facturio.Base;
using System.Windows.Input;

namespace Facturio.Aide
{
    public class AideViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public string Titre { get; set; }
        public string TitreParagraphe { get; set; }
        public string Paragraphe { get; set; }

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

            AideGabarit = new RelayCommand(AfficherAideGabarit);
            AideCreation = new RelayCommand(AfficherAideCreation);
            AideProduit = new RelayCommand(AfficherAideProduit);
            AideClient = new RelayCommand(AfficherAideClient);
            AideRapport = new RelayCommand(AfficherAideRapport);

            AideGabarit.Execute(null);
        }

        #endregion

        #region Méthodes

        private void AfficherAideGabarit(object obj)
        {
            // Ça me tentais pas de me casser la tête... So, c'est ici qu'on écrit notre documentation LOL!
            TitreParagraphe = "What's up?!";
            Paragraphe = "Salut, je suis un paragraphe.\nUne deuxième ligne...";
        }

        private void AfficherAideCreation(object obj)
        {
            TitreParagraphe = "Création";
            Paragraphe = "";
        }

        private void AfficherAideProduit(object obj)
        {
            TitreParagraphe = "Produits";
            Paragraphe = "";
        }

        private void AfficherAideClient(object obj)
        {
            TitreParagraphe = "Clients";
            Paragraphe = "";
        }

        private void AfficherAideRapport(object obj)
        {
            TitreParagraphe = "Rapports";
            Paragraphe = "";
        }

        #endregion
    }
}