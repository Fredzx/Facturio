using Facturio.Produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports.Entities
{
    public class RapportVenteProduit : Rapport
    {
        public virtual int? IdRapportVenteProduit { get { return base.IdRapport; } set { base.IdRapport = value; } }
        public virtual Produit Produit { get; set; }
        public RapportVenteProduit() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            RapportVenteProduit r = obj as RapportVenteProduit;

            if (r == null)
            {
                return false;
            }

            return this.IdRapportVenteProduit == r.IdRapportVenteProduit;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string GetTypeRapport()
        {
            return "Vente produit";
        }

        //public override string GetObject()
        //{
        //    return Produit.Nom;
        //}

    }
}
