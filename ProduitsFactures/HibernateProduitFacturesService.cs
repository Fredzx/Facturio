﻿using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.ProduitsFactures
{
    class HibernateProduitFacturesService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<ProduitsFactures> RetrieveAll()
        {
            return session.Query<ProduitsFactures>().ToList();
        }

        public static List<ProduitsFactures> Retrieve(int idProduitFacture)
        {
            var produitFacture = session.Query<ProduitsFactures>().AsQueryable();

            var result = from pf in produitFacture
                         where pf.IdProduitFactures == idProduitFacture
                         select pf;

            return result.ToList();
        }

        public static void Create(ProduitsFacturesMap produitFacture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(produitFacture);
                transaction.Commit();
            }

        }

        public static void Update(ProduitsFactures produitFacture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(produitFacture);
                transaction.Commit();
            }
        }

        public static void Delete(ProduitsFactures produitFacture)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(produitFacture);
                transaction.Commit();
            }
        }
    }
}