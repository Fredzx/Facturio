using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Produits
{
    class Produit
    {
        public Produit(int v1, string v2)
        {
            this.id = v1;
            this.nom = v2;
        }

        public int id { get; set; }
        public string nom { get; set; }
    }
}
