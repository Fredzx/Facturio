using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Facturio.GabaritsCriteres
{
    class HibernateCritereService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Critere> RetrieveAll()
        {
            return session.Query<Critere>().OrderBy(x => x.Id).ToList();
        }

        public static List<Critere> Retrieve(int idCritere)
        {
            var critere = session.Query<Critere>().AsQueryable();

            var result = from c in critere
                where c.Id == idCritere
                select c;

            return result.ToList();
        }

        public static void Create(Critere critere)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(critere);
                transaction.Commit();
            }
        }

        public static void Update(Critere critere)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(critere);
                transaction.Commit();
            }
        }

        public static void Delete(Critere critere)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(critere);
                transaction.Commit();
            }
        }
    }
}
