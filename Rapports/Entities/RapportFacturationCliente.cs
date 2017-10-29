using Facturio.Factures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports.Entities
{
    public class RapportFacturationCliente : Rapport
    {
        public virtual int? IdRapportFacturationCliente { get { return base.IdRapport; } set { base.IdRapport = value; }}

        
        RapportFacturationCliente() { }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            RapportFacturationCliente r = obj as RapportFacturationCliente;

            if (r == null)
            {
                return false;
            }

            return this.IdRapportFacturationCliente == r.IdRapportFacturationCliente;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void RetriveFactureClient()
        {
            LstFacture = new HashSet<Facture>(HibernateFactureService.RetrieveFacturationCliente(new DateTime(2017, 10, 03, 0, 0, 0), new DateTime(2017, 11, 04, 0, 0, 0), 1));
        }

    }
}
