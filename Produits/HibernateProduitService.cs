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
            var produits = session.Query<Produit>().OrderBy(p => p.Nom).AsQueryable();

            var result = from p in produits
                         where p.EstActif == true
                         select p;

            return result.ToList();

//            return session.Query<Produit>().OrderBy(p=>p.Nom).ToList();
        }

        public static List<Produit> Retrieve(int idProduit)
        {
            var produit = session.Query<Produit>().AsQueryable();

            var result = from p in produit
                         where p.Id == idProduit
                         select p;

            return result.ToList();
        }
        // TODO: Modif
        //public static List<Produit> Retrieve(string code)
        //{
        //    var produit = session.Query<Produit>().AsQueryable();

        //    var result = from p in produit
        //                 where p.Code.Like(code)
        //                 select p;

        //    return result.ToList();
        //}

            //TODO: Modif
        //public static List<Produit> RetrieveFilter(string filter)
        //{
        //    var produit = session.Query<Produit>().AsQueryable();

        //    // J'utilise contains au lieu de startswith pour s'assurer que l'utilisateur ait toutes les options possibles
        //    // Ex.: Si le user cherche 'porc' pour trouver 'filet de porc' et que j'utilise startswith, la requête n'affichera pas sa recherche.
        //    var result = from p in produit
        //                 where (p.Nom.Contains(filter) || p.Code.Contains(filter)) && p.EstActif == true
        //                 orderby p.Code ascending
        //                 select p;

        //    return result.ToList();
        //}

        public static void Create(Produit produit)
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
                session.Update(produit, produit.Id);
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
