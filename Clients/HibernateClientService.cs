using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;


namespace Facturio.Clients
{
    public static class HibernateClientService
    {
        
        private static ISession session = NHibernateConnexion.OpenSession();


        // Avant modification : 29 Oct. 12h37
        //public static List<Client> RetrieveAll()
        //{
        //    return session.Query<Client>().ToList();
        //}


        public static List<Client> RetrieveAll()
        {
            var client = session.Query<Client>().AsQueryable();

            var result = from c in client
                         where c.EstActif == true
                         select c;

            return result.ToList();
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

        public static List<Client> RetrieveFilter(string filter)
        {
            var client = session.Query<Client>().AsQueryable();
            
            var result = from c in client
                         where c.Nom.Contains(filter) || c.NoClient.Contains(filter)
                         orderby c.NoClient ascending
                         select c;

            return result.ToList();
        }
    }
}
