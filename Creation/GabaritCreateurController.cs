using Facturio.Factures;
using Facturio.Gabarits;
using Facturio.GabaritsCriteres;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Facturio.Creation
{
    public class GabaritCreateurController
    {
        #region Propriétés
        public static Gabarits.Gabarit Gabarit { get; set; } = GabaritCreateurViewModel.Gabarit;
        public static GabaritCreationWindow FntGabCreation { get; set; }
        public static OpererFacture FntOperationFacture { get; set; }
        
        

        #endregion

        public GabaritCreateurController()
        {
            

            
        }

        

        #region Méthodes
        public static void AfficherInterfaceCreationSuivante()
        {
            Gabarit = GabaritCreateurViewModel.Gabarit;
            FntGabCreation = new GabaritCreationWindow();
            FntGabCreation.Show();
        }
        public static void EnregistrerGabarit()
        {
            HibernateGabaritService.Create(Gabarit);
        }
        public static void FermerFenetreCreationLook()
        {
            FntGabCreation.Close();
        }
        public static void AfficherInterfaceOperationFacture()
        {
            FntGabCreation.Close();
            FntOperationFacture = new OpererFacture(Gabarit);
            FntOperationFacture.ShowDialog();

        }
        #endregion
    }
}
