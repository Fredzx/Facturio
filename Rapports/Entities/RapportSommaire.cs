using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports.Entities
{
    public class RapportSommaire : Rapport
    {
        public virtual int? IdRapportSommaire { get { return base.IdRapport; } set { base.IdRapport = value; } }

        public RapportSommaire() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            RapportSommaire r = obj as RapportSommaire;

            if (r == null)
            {
                return false;
            }

            return this.IdRapportSommaire == r.IdRapportSommaire;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
