using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturio.Clients;
using Facturio.Gabarits;
using Facturio.Rapports;
using Facturio.Produits;

namespace Facturio.Factures
{
    public class Facture
    {
        public virtual int? IdFacture { get; set; } = null;

        public virtual Client LeClient { get; set; } = new Client();

        public virtual DateTime? Date { get; set; } = null;

        public virtual ISet<Produit> LstProduit { get; set; } = new HashSet<Produit>();
        public Facture() { }


        public Facture(Client client, DateTime date)
        {
            LeClient = client;
            Date = date;
            LstProduit = new HashSet<Produit>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Facture r = obj as Facture;

            if (r == null)
            {
                return false;
            }

            return this.IdFacture == r.IdFacture;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
