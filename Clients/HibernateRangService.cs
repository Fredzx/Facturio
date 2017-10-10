using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Facturio.Clients
{
    public static class HibernateRangService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Rang> RetrieveAll()
        {
            return session.Query<Rang>().ToList();
        }

        public static List<Rang> Retrieve(int idRang)
        {
            var rang = session.Query<Rang>().AsQueryable();

            var result = from r in rang
                         where r.IdRang == idRang
                         select r;

            return result.ToList();
        }

        public static void Create(RangMap rang)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(rang);
                transaction.Commit();
            }

        }

        public static void Update(Rang rang)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(rang);
                transaction.Commit();
            }
        }

        public static void Delete(Rang rang)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(rang);
                transaction.Commit();
            }
        }
    }
}
