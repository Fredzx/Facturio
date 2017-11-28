using NHibernate;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;

namespace Facturio.Gabarits
{
    public static class HibernateGabaritService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Gabarit> RetrieveAll()
        {
            return session.Query<Gabarit>().ToList();
        }

        public static List<Gabarit> RetrieveAllOrderedByCreationDateDesc()
        {
            return session.Query<Gabarit>()
                .OrderByDescending(x => x.DateCreation)
                .ToList();
        }

        public static List<Gabarit> Retrieve(int idGabarit)
        {
            var gabarit = session.Query<Gabarit>().AsQueryable();

            var result = from g in gabarit
                         where g.Id == idGabarit
                         select g;

            return result.ToList();
        }

        public static void Create(Gabarit gabarit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(gabarit);
                transaction.Commit();
            }
        }

        public static void Update(Gabarit gabarit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(gabarit);
                transaction.Commit();
            }
        }

        public static void Delete(Gabarit gabarit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(gabarit);
                transaction.Commit();
            }
        }
    }
}
