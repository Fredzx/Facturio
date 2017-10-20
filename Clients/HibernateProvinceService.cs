using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Facturio.Clients
{
    public static class HibernateProvinceClient
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Province> RetrieveAll()
        {
            return session.Query<Province>().ToList();
        }

        public static List<Province> RetrieveByName(string nomProvince)
        {
            var province = session.Query<Province>().AsQueryable();

            var result = from p in province
                         where p.Nom == nomProvince
                         select p;

            return result.ToList();
        }

        public static void Create(Province province)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(province);
                transaction.Commit();
            }

        }

        public static void Update(Province province)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(province);
                transaction.Commit();
            }
        }

        public static void Delete(Province province)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(province);
                transaction.Commit();
            }
        }


    }
}
