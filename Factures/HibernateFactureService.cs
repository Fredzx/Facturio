﻿using Facturio.Clients;
using Facturio.ProduitsFactures;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Factures
{
    public static class HibernateFactureService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Facture> RetrieveAll()
        {
            return session.Query<Facture>().ToList();
        }

        public static List<Facture> Retrieve(int idFacture)
        {
            var facture = session.Query<Facture>().AsQueryable();

            var result = from f in facture
                         where f.IdFacture == idFacture
                         select f;

            return result.ToList();
        }

        public static List<Facture> RetrieveFacturationCliente(DateTime dateDebut, DateTime dateFin, Client client)
        {
            var facture = session.Query<Facture>().AsQueryable();

            var result = from f in facture
                         where f.LeClient.IdClient == client.IdClient
                                && (f.Date >= dateDebut
                                && f.Date <= dateFin)
                         select f;

            return result.ToList();
        }


        public static List<Facture> RetrieveBetweenDates(DateTime dateDebut, DateTime dateFin)
        {
            var facture = session.Query<Facture>().AsQueryable();

            var result = from f in facture
                         where (f.Date >= dateDebut
                               && f.Date <= dateFin)
                         select f;

            return result.ToList();
        }

        public static void Create(Facture facture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(facture);
                transaction.Commit();
            }

        }

        public static void Update(Facture facture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(facture);
                transaction.Commit();
            }
        }

        public static void Delete(Facture facture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(facture);
                transaction.Commit();
            }
        }
    }
}
