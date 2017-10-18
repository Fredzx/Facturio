using Facturio.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Produits
{
    // CRUD
    public class ProduitsController : BaseViewModel, IOngletViewModel
    {
        public static List<Produit> Produits { get; set; } = new List<Produit>();

        public string Titre { get; set; }

        public ProduitsController()
        {
            Titre = "Produits";
            ChargerListeProduits();
        }

        public static void ChargerListeProduits()
        {
            Produits = HibernateProduitService.RetrieveAll();
        }

        public static void UpdateProduit(Produit produitAModifier)
        {

            Produit ProduitModifie = new Produit("updateNom", "updateCode", "updateDescription", 10, 11);
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
            HibernateProduitService.Delete(produitADeleter);
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

        public static void LiveFiltering(string filter)
        {
            Produits = HibernateProduitService.RetrieveFilter(filter);

        }

        public static void ToutVisible()
        {
         //   Produits.ForEach(i => i.EstCache = false);
        }
    }
}
