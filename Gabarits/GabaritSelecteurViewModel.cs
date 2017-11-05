using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Facturio.Base;

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

        #region Constructeur

        public GabaritSelecteurViewModel()
        {
            try
            {
                Gabarits = new ObservableCollection<Gabarit>(
                    HibernateGabaritService.RetrieveAllOrderedByCreationDateDesc()
                );
            }
            catch (Exception)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'accès à la base de données.");
                Environment.Exit(1);
            }

            Titre = "Gabarits";

            OuvrirFacture = new RelayCommand(parameter =>
            {
                try
                {
                    OuvrirFenetreFacture();
                }
                catch (NotImplementedException)
                {
                    MessageBox.Show("Cette fonctionalité n'est pas encore implémentée.", "Oups!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }, parameter => GabaritSelectionne != null);

            SupprimerGabarit = new RelayCommand(SupprimeGabarit, parameter => GabaritSelectionne != null);
        }

        #endregion

        #region Méthodes

        private void OuvrirFenetreFacture()
        {
            // TODO: Ouvrir la fenêtre de la création de facture
            // TODO: Faire un petit gestionnaire pour ouvrir/fermer des fenêtres
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
