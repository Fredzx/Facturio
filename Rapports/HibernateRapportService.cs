using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using System.Collections;
using System.ComponentModel;

namespace Facturio.Rapports
{

    public static class HibernateRapportService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Rapport> RetrieveAll()
        {
            return session.Query<Rapport>().ToList();
        }

        public static List<Rapport> Retrieve(int idRapport)
        {
            var rapport = session.Query<Rapport>().AsQueryable();

            var result = from r in rapport
                         where r.IdRapport == idRapport
                         select r;

            return result.ToList();
        }

        public static void Create(RapportMap rapport)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(rapport);
                transaction.Commit();
            }

        }

        public static void Update(Rapport rapport)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(rapport);
                transaction.Commit();
            }
        }

        public static void Delete(Rapport rapport)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(rapport);
                transaction.Commit();
            }
        }


    }
}
