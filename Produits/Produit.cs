using Facturio.Factures;
using Facturio.ProduitsFactures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Produits
{
    public class Produit
    {
        public Produit()
        {

        }
        public Produit(string nom, string code, string description, decimal? prix, double quantite, bool estActif)
        {
            Nom = nom;
            Code = code;
            Description = description;
            Prix = prix;
            Quantite = quantite;
            EstActif = estActif;
        }

        public virtual int? Id { get; set; } = null;
        public virtual string Nom { get; set; } = string.Empty;
        public virtual string Code { get; set; } = string.Empty;
        public virtual string Description { get; set; } = string.Empty;
        public virtual decimal? Prix { get; set; } = null;
        public virtual double? Quantite { get; set; } = null;
        public virtual bool EstActif { get; set; } = true;

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Produit p = obj as Produit;

            if (p == null)
            {
                return false;
            }

            return this.Id == p.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }





    //// INTERGERUPDOWN -> PACKAGE NUGET
}
    
