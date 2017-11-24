using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Facturio.Base;
using Facturio.Factures;

namespace Facturio.Gabarits
{
    public class GabaritSelecteurViewModel : BaseViewModel, IOngletViewModel
    {
        #region Propriétés

        public ObservableCollection<Gabarit> Gabarits { get; set; }
        public Gabarit GabaritSelectionne { get; set; }

        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand OuvrirFacture { get; set; }
        public ICommand SupprimerGabarit { get; set; }

        #endregion

        #region Constructeurs

        public GabaritSelecteurViewModel()
        {
            try
            {
                Gabarits = new ObservableCollection<Gabarit>(HibernateGabaritService.RetrieveAllOrderedByCreationDateDesc());
            }
            catch (Exception)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'accès à la base de données.");
                Environment.Exit(1);
            }

            Titre = "Gabarits";

            OuvrirFacture = new RelayCommand(OuvrirFenetreFacture, parameter => GabaritSelectionne != null);
            SupprimerGabarit = new RelayCommand(SupprimeGabarit, parameter => GabaritSelectionne != null);
        }

        #endregion

        #region Méthodes

        private void OuvrirFenetreFacture(object parameter)
        {
            // TODO: Ouvrir la fenêtre d'opérations sur la facture en lui passant le gabarit sélectionné (GabaritSelectionne)
            throw new NotImplementedException();
        }

        private void SupprimeGabarit(object parameter)
        {
            // Supprime le gabarit de la BD
            HibernateGabaritService.Delete(GabaritSelectionne);

            // Supprime le gabarit de la mémoire
            Gabarits.Remove(GabaritSelectionne);
            GabaritSelectionne = null;
        }

        #endregion
    }
}
