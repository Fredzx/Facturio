using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Facturio.Produits
{
    public static class HibernateProduitService
    {
        private static ISession session = NHibernateConnexion.OpenSession();

        public static List<Produit> RetrieveAll()
        {
            return session.Query<Produit>().ToList();
        }

        public static List<Produit> Retrieve(int idProduit)
        {
            var produit = session.Query<Produit>().AsQueryable();

            var result = from p in produit
                         where p.Id == idProduit
                         select p;

            return result.ToList();
        }

        public static void Create(ProduitMap produit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(produit);
                transaction.Commit();
            }

        }

        public static void Update(Produit produit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(produit);
                transaction.Commit();
            }
        }

        public static void Delete(Produit produit)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(produit);
                transaction.Commit();
            }
        }


    }
}
