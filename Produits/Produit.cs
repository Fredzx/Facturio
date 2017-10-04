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
        public Produit(int id, string nom, string code, string description, double prix, double quantite)
        {
            Id = id;
            Nom = nom;
            Code = code;
            Description = description;
            Prix = prix;
            Quantite = quantite;
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public double Quantite { get; set; }

    }
}
    
