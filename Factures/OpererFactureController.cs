using Facturio.Produits;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Factures
{
    class OpererFactureController
    {
        public static ObservableCollection<Produit> Produits { get; set; }
    }
}
