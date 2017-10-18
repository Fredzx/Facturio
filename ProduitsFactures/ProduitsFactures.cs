using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.ProduitsFactures
{
    class ProduitsFactures
    {
        public virtual int? IdProduitFactures { get; set; } = null;
        public virtual int? IdProduit { get; set; } = null;
        public virtual int? IdFacture { get; set; } = null;
        public virtual int? Quantite { get; set; } = 0;

        ProduitsFactures() { }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ProduitsFactures pf = obj as ProduitsFactures;

            if (pf == null)
            {
                return false;
            }

            return this.IdProduitFactures == pf.IdProduit;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
