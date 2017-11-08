﻿using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Facturio.Rapports.Entities;
using NHibernate.Transform;

namespace Facturio.Rapports.Hibernate
{

    public static class HibernateRapportService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Rapport> RetrieveAll()
        {
            return session.Query<Rapport>().ToList();
        }

        //public static List<Rapport> RetrieveSommaire()
        //{
        //    var rapport = session.CreateSQLQuery("SELECT c.nom as Nom, c.prenom as Prenom, Date " +
        //                                         "FROM Rapports r" +
        //                                         "INNER JOIN FacturesRapports fr ON r.idRapport = fr.idRapport" +
        //                                         "INNER JOIN Factures f ON f.idFacture = fr.idFactures" +
        //                                         "INNER JOIN Clients c On c.idClient = f.idClient");

        //    rapport.SetResultTransformer(Transformers.AliasToBean<Rapport>());

        //    return rapport.List();
            
        //}

        public static List<Rapport> Retrieve(int idRapport)
        {
            var rapport = session.Query<Rapport>().AsQueryable();

            var result = from r in rapport
                         where r.IdRapport == idRapport
                         select r;

            return result.ToList();
        }

        public static void Create(Rapport rapport)
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
