using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using System;
using Facturio.Clients;
using Facturio.Produits;
using Facturio.ProduitsFactures;
using Facturio.Factures;

namespace Facturio.RapportsFactures
{
    public static class HibernateRapportFactureService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<RapportFacture> RetrieveAll()
        {
            return session.Query<RapportFacture>().ToList();
        }

        public static List<RapportFacture> Retrieve(int idRapportFacture)
        {
            var rapportFacture = session.Query<RapportFacture>().AsQueryable();

            var result = from rf in rapportFacture
                         where rf.IdRapportFacture == idRapportFacture
                         select rf;

            return result.ToList();
        }

        public static List<RapportFacture> RetrieveFacturationCliente(DateTime dateDebut, DateTime dateFin, Client client)
        {
            var rapportFacture = session.Query<RapportFacture>().AsQueryable();

            var result = from rf in rapportFacture
                         where rf.Facture.LeClient.IdClient == client.IdClient
                                && (rf.Facture.Date >= dateDebut
                                && rf.Facture.Date <= dateFin)
                         select rf;

            return result.ToList();
        }

        public static List<RapportFacture> RetrieveVenteProduit(DateTime dateDebut, DateTime dateFin)
        {
            var rappportfacture = session.Query<RapportFacture>();

            var result = from rf in rappportfacture
                             where (rf.Facture.Date >= dateDebut
                                   && rf.Facture.Date <= dateFin)
                             select rf;
            return result.ToList();
        }

        public static void Create(RapportFactureMap rapportFacture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(rapportFacture);
                transaction.Commit();
            }

        }

        public static void Update(RapportFacture rapportFacture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(rapportFacture);
                transaction.Commit();
            }
        }

        public static void Delete(RapportFacture rapportFacture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(rapportFacture);
                transaction.Commit();
            }
        }

    }
}
