﻿using System;
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

        private Gabarit _gabaritSelectionne;
        public Gabarit GabaritSelectionne
        {
            get => _gabaritSelectionne;
            set
            {
                if (Equals(value, _gabaritSelectionne))
                    return;

                _gabaritSelectionne = value;
                RaisePropertyChanged(nameof(GabaritSelectionne));
            }
        }

        public string Titre { get; set; }

        #endregion

        #region Commandes

        public ICommand OuvrirFacture { get; set; }
        public ICommand SupprimerGabarit { get; set; }

        #endregion

        #region Constructeur

        public GabaritSelecteurViewModel()
        {
            Gabarits = new ObservableCollection<Gabarit>(
                HibernateGabaritService.RetrieveAllOrderedByCreationDateDesc()
            );

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
