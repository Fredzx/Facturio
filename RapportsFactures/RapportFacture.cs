using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturio.Rapports;
using Facturio.Factures;
using Facturio.Rapports.Entities;

namespace Facturio.RapportsFactures
{
    public class RapportFacture
    {
        public virtual int? IdRapportFacture { get; set; } = null;
        public virtual Rapport Rapport { get; set; } = new Rapport();
        public virtual Facture Facture { get; set; } = new Facture();

        public RapportFacture() { }

        public RapportFacture(Rapport rapport, Facture facture)
        {
            Rapport = rapport;
            Facture = facture;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            RapportFacture r = obj as RapportFacture;

            if (r == null)
            {
                return false;
            }

            return this.IdRapportFacture == r.IdRapportFacture;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
