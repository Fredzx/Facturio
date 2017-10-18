using System;
using System.Collections.Generic;
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
        public Produit(string nom, string code, string description, float prix, float quantite)
        {
            Nom = nom;
            Code = code;
            Description = description;
            Prix = prix;
            Quantite = quantite;
        }
        public virtual bool EstCache { get; set; }
        public virtual int? Id { get; set; } = null;
        public virtual string Nom { get; set; } = string.Empty;
        public virtual string Code { get; set; } = string.Empty;
        public virtual string Description { get; set; } = string.Empty;
        public virtual float? Prix { get; set; } = null;
        public virtual float? Quantite { get; set; } = null;

    }
}
    
