using Facturio.Clients;
using Facturio.Factures;
using Facturio.RapportsFactures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports.Entities
{
    public class RapportFacturationCliente : Rapport
    {
        public virtual int? IdRapportFacturationCliente { get { return base.IdRapport; } set { base.IdRapport = value; }}

        public virtual Client LeClient { get{ return TrouverClient(); } set { LeClient = value; } } 
        
        public RapportFacturationCliente() { }
        public RapportFacturationCliente(DateTime date, List<RapportFacture> lstFacture, Client client)
        {
            Date = date;
            LstRapportFacture = lstFacture;
            LeClient = client; 
        } 


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

        public override string GetTypeRapport()
        {
            return "Facturation cliente";
        }

        public override string GetObject()
        {
            return LeClient.Prenom + " " + LeClient.Nom;
        }

        public virtual Client TrouverClient()
        {
            ObservableCollection<RapportFacture> obcFacture = new ObservableCollection<RapportFacture>(LstRapportFacture);
            Client client = new Client();

            return obcFacture[0].Facture.LeClient;
        }

    }
}
