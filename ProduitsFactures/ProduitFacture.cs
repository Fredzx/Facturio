using Facturio.Factures;
using Facturio.Produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.ProduitsFactures
{
    public class ProduitFacture
    {
        public virtual int? IdProduitFactures { get; set; } = null;
        public virtual Produit Produit { get; set; } = new Produit();
        public virtual Facture Facture { get; set; } = new Facture();
        public virtual float Quantite { get; set; } = 0;
        public virtual decimal SousTotal { get { return (decimal)(Quantite * Produit.Prix); } set { SousTotal = value; } }

        public ProduitFacture() { }

        public ProduitFacture(Produit produit, Facture facture, float quantite)
        {
            Produit = produit;
            Facture = facture;
            Quantite = quantite;
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ProduitFacture pf = obj as ProduitFacture;

            if (pf == null)
            {
                return false;
            }

            return this.IdProduitFactures == pf.IdProduitFactures;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual decimal CalculerTotalLigne()
        {
            return (decimal)((float)Produit.Prix * Quantite);
        }

    }
}
