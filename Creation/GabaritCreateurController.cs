using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Facturio.Creation
{
    public class GabaritCreateurController
    {
        public static Gabarits.Gabarit Gabarits { get; set; } = GabaritCreateurViewModel.Gabarit;
        public static GabaritCreationWindow FntGabCreation { get; set; } = new GabaritCreationWindow();

        public GabaritCreateurController()
        {
            



        }

        public static void AfficherInterfaceCreationSuivante()
        {
            FntGabCreation.Show();
        }
    }
}
