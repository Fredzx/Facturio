using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using NHibernate;

namespace Facturio.Clients
{
    public static class HibernateClientService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Client> RetrieveAll()
        {
            return session.Query<Client>().ToList();
        }
        public static List<Client> Retrieve(int idClient)
        {
            var client = session.Query<Client>().AsQueryable();

            var result = from c in client
                         where c.IdClient == idClient
                         select c;

            return result.ToList();
        }
        public static void Create(Client client)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(client);
                transaction.Commit();
            }

        }
        public static List<Client> RetrieveInactif()
        {
            var client = session.Query<Client>().AsQueryable();

            var result = from c in client
                         where c.EstActif == false
                         select c;

            return result.ToList();
        }
        public static List<Client> RetrieveActif()
        {
            var client = session.Query<Client>().AsQueryable();

            var result = from c in client
                         where c.EstActif == true
                         select c;

            return result.ToList();
        }
        public static void Update(Client client)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(client);
                transaction.Commit();
            }
        }
        public static void Delete(Client client)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(client);
                transaction.Commit();
            }
        }
        public static List<Client> RetrieveFilter(string filter, int status)
        {
            var client = session.Query<Client>().AsQueryable();

            if (status == 0) // Actif
            {
                var result = from c in client
                where c.EstActif == true && c.Nom.Contains(filter) || c.NoClient.Contains(filter)
                orderby c.NoClient ascending
                select c;

                return result.ToList();
            }
            else if(status == 1) // Inactif
            {
                var result = from c in client
                             where c.EstActif == false && c.Nom.Contains(filter) || c.NoClient.Contains(filter) 
                             orderby c.NoClient ascending
                             select c;

                return result.ToList();
            }
            else // Tous
            {
                var result = from c in client
                             where c.Nom.Contains(filter) || c.NoClient.Contains(filter)
                             orderby c.NoClient ascending
                             select c;

                return result.ToList();
            }
        }
    }
}
