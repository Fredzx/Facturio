using Facturio.Factures;
using Facturio.Produits;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.ProduitsFactures
{
    class ProduitsFacturesMap : ClassMap<ProduitFacture>
    {
        public ProduitsFacturesMap()
        {
            Table("ProduitsFactures");
            LazyLoad();

            Id(x => x.IdProduitFactures)
                .Column("idProduitFacture")
                .CustomType<int?>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.Quantite)
                .Column("quantite")
                .CustomType<float>()
                .Access.Property()
                .CustomSqlType("DECIMAL")
                .Not.Nullable()
                .Generated.Never();




            //References(x => x.Facture)
            //    .Class<Facture>()
            //    .Access.Property()
            //    .LazyLoad(Laziness.False)
            //    .Cascade.None()
            //    .Columns("idFacture");

            //References(x => x.Produit)
            //    .Class<Produit>()
            //    .Access.Property()
            //    .LazyLoad(Laziness.False)
            //    .Cascade.None()
            //    .Columns("idProduit");
        }
    }
}
