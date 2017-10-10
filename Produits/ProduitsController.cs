using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Produits
{
    // CRUD
    public static class ProduitsController
    {
        public static List<Produit> Produits { get; set; } = new List<Produit>();

        public static void ChargerListeProduits()
        {
            Produits = HibernateProduitService.RetrieveAll();

            // TODO: Modifier pour retrieve en BD
            //Produits.Add(new Produit(1, "nom1", "code1", "description1", 19.23, 2));
            //Produits.Add(new Produit(2, "nom2", "code2", "description2", 19, 2.54));
            //Produits.Add(new Produit(3, "nom3", "code3", "description3", 24.24, 12));
            //Produits.Add(new Produit(4, "nom4", "code4", "description4", 11111, 27.5));
            //Produits.Add(new Produit(5, "nom5", "code5", "description5", 1234.5, 45));
        }

        public static void UpdateProduit(Produit produitAModifier)
        {
            Produit ProduitModifie = new Produit(produitAModifier.Id, "updateNom", "updateCode", "updateDescription", 10, 11);
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (produitAModifier == null)
                return;
            // TODO: UPDATE en BD

            // TEST
            Produits.Remove(produitAModifier);
            Produits.Add(ProduitModifie);
        }

        public static void DeleteProduit(Produit produitADeleter)
        {
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (produitADeleter == null)
                return;

            // TODO: DELETE en BD

            // TEST
            Produits.Remove(produitADeleter);
        }

        public static void AjoutProduit(Produit produitAAjouter)
        {
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (produitAAjouter == null)
                return;

            // TODO: Ajouter en BD

            // TEST
            Produits.Add(produitAAjouter);
        }
    }
}
