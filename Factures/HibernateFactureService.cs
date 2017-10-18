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

        public static void Create(FactureMap facture)
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
