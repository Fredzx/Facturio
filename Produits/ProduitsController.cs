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
        public static ObservableCollection<Produit> Produits { get; set; }
        public static Produit Produit { get; set; }
        /*
        public static ObservableCollection<Produit> ocProduits { get; set; } = new ObservableCollection<Produit>();
        public static List<Produit> Produits { get; set; } = new List<Produit>();
        */

        public string Titre { get; set; }

        public ProduitsController()
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveAll());
            Titre = "Produits";
            // ChargerListeProduits();
        }

        public static void ChargerListeProduits()
        {
            //Produits = HibernateProduitService.RetrieveAll();

            //foreach (Produit produit in Produits)
            //    ocProduits.Add(produit);
        }

        public static void UpdateProduit()
        {

            Produit ProduitModifie = new Produit("updateNom", "updateCode", "updateDescription", 10, 11);
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (Produit == null)
                return;
            // TODO: UPDATE en BD
            // TEST
            DeleteProduit(Produit);
            AjoutProduit();

            //Produits.Remove(p);
            //Produits.Add(ProduitModifie);
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

        public static void AjoutProduit()
        {
            // TODO: Si le produit est null, retourner à la page d'avant
            // Et afficher un message
            if (Produit == null)
                return;

            // TODO: Ajouter en BD
            // TEST
            HibernateProduitService.Create(Produit);
            
            //Produits.Add(Produit);
        }

        public static void LiveFiltering(string filter)
        {
            Produits = new ObservableCollection<Produit>(HibernateProduitService.RetrieveFilter(filter));
        }

        public static void ConstruireModifUserControl()
        {
            //AjoutModifUserControl m = new AjoutModifUserControl(Produit);
            //AjoutModifUserControl.
        }
    }
}
