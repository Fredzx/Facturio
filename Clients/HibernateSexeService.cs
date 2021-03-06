﻿using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;


namespace Facturio.Clients
{
    public static class HibernateSexeService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Sexe> RetrieveAll()
        {
            return session.Query<Sexe>().ToList();
        }

        public static List<Sexe> RetrieveByName(string nomSexe)
        {
            var sexe = session.Query<Sexe>().AsQueryable(); 


            var result = from s in sexe
                         where s.Nom == nomSexe[0].ToString()
                         select s;

            return result.ToList();
        }

        public static void Create(Sexe sexe)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(sexe);
                transaction.Commit();
            }

        }

        public static void Update(Sexe sexe)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(sexe);
                transaction.Commit();
            }
        }

        public static void Delete(Sexe sexe)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(sexe);
                transaction.Commit();
            }
        }

    }
}
