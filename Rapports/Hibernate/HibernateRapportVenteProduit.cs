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
    class HibernateRapportVenteProduit
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<RapportVenteProduit> RetrieveAll()
        {
            return session.Query<RapportVenteProduit>().ToList();
        }

        public static List<RapportVenteProduit> Retrieve(int idRapportVenteProduit)
        {
            var rapportVP = session.Query<RapportVenteProduit>().AsQueryable();

            var result = from r in rapportVP
                         where r.IdRapportVenteProduit == idRapportVenteProduit
                         select r;

            return result.ToList();
        }

        public static void Create(RapportVenteProduit rapportVenteProduit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(rapportVenteProduit);
                transaction.Commit();
            }
        }

        public static void Update(RapportVenteProduit rapportVenteProduit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(rapportVenteProduit);
                transaction.Commit();
            }
        }

        public static void Delete(RapportVenteProduit rapportVenteProduit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(rapportVenteProduit);
                transaction.Commit();
            }
        }
    }
}
