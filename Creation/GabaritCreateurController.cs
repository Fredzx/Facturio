using Facturio.Factures;
using Facturio.Gabarits;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Facturio.Creation
{
    public class GabaritCreateurController
    {
        #region Propriétés
        public static Gabarits.Gabarit Gabarits { get; set; } = GabaritCreateurViewModel.Gabarit;
        public static GabaritCreationWindow FntGabCreation { get; set; }
        public static OpererFacture FntOperationFacture { get; set; }
        
        #endregion

        public GabaritCreateurController()
        {
            
        }

        #region Méthodes
        public static void AfficherInterfaceCreationSuivante()
        {
            FntGabCreation = new GabaritCreationWindow();
            FntGabCreation.Show();
        }
        public static void EnregistrerGabarit()
        {
            HibernateGabaritService.Create(Gabarits);
        }
        public static void FermerFenetreCreationLook()
        {
            FntGabCreation.Close();
        }
        public static void AfficherInterfaceOperationFacture()
        {
            FntGabCreation.Close();
            FntOperationFacture = new OpererFacture(Gabarits);
            FntOperationFacture.ShowDialog();

        }
        #endregion
    }
}
