using Facturio.Rapports.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports.Hibernate
{
    class HibernateRapportFacturationCliente
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<RapportFacturationCliente> RetrieveAll()
        {
            return session.Query<RapportFacturationCliente>().ToList();
        }

        public static List<RapportFacturationCliente> Retrieve(int idRapportFactClient)
        {
            var rapport = session.Query<RapportFacturationCliente>().AsQueryable();

            var result = from r in rapport
                         where r.IdRapportFacturationCliente == idRapportFactClient
                         select r;

            return result.ToList();
        }

        public static void Create(RapportFacturationCliente rapportFacturationCliente)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(rapportFacturationCliente);
                transaction.Commit();
            }
        }

        public static void Update(RapportFacturationCliente rapportFacturationCliente)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(rapportFacturationCliente);
                transaction.Commit();
            }
        }

        public static void Delete(RapportFacturationCliente rapportFacturationCliente)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(rapportFacturationCliente);
                transaction.Commit();
            }
        }
    }
}
