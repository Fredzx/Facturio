using NHibernate;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;

namespace Facturio.Criteres
{
    class HibernateTypeCritereService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<TypeCritere> RetrieveAll()
        {
            return session.Query<TypeCritere>().OrderBy(x => x.Id).ToList();
        }

        public static List<TypeCritere> Retrieve(int idTypeCritere)
        {
            var typeCritere = session.Query<TypeCritere>().AsQueryable();

            var result = from g in typeCritere
                where g.Id == idTypeCritere
                select g;

            return result.ToList();
        }

        public static void Create(TypeCritere typeCritere)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(typeCritere);
                transaction.Commit();
            }
        }

        public static void Update(TypeCritere typeCritere)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(typeCritere);
                transaction.Commit();
            }
        }

        public static void Delete(TypeCritere typeCritere)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(typeCritere);
                transaction.Commit();
            }
        }
    }
}
