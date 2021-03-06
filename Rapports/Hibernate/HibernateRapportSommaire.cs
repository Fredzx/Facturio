﻿using Facturio.Rapports.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Rapports.Hibernate
{
    class HibernateRapportSommaire
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<RapportSommaire> RetrieveAll()
        {
            return session.Query<RapportSommaire>().ToList();
        }

        public static List<RapportSommaire> Retrieve(int idRapportSommaire)
        {
            var rapport = session.Query<RapportSommaire>().AsQueryable();

            var result = from r in rapport
                         where r.IdRapportSommaire == idRapportSommaire
                         select r;

            return result.ToList();
        }

        public static void Create(RapportSommaire rapportSommaire)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(rapportSommaire);
                transaction.Commit();
            }
        }

        public static void Update(RapportSommaire rapportSommaire)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(rapportSommaire);
                transaction.Commit();
            }
        }

        public static void Delete(RapportSommaire rapportSommaire)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(rapportSommaire);
                transaction.Commit();
            }
        }
    }
}
