using FluentNHibernate.Mapping;
using Facturio.ProduitsFactures;
using Facturio.Factures;

namespace Facturio.Produits
{
    public class ProduitMap : ClassMap<Produit>
    {
        public ProduitMap()
        {
            Table("Produits");

            LazyLoad();

            Id(x => x.Id)
               .Column("idProduit")        
               .CustomType<int>()         
               .Access.Property()         
               .CustomSqlType("INTEGER")  
               .Not.Nullable()            
               .GeneratedBy.Identity();

            Map(x => x.Nom)
                .Column("nom")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Generated.Never();

            Map(x => x.Code)
                .Column("codeProduit")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Generated.Never();

            Map(x => x.Description)
                .Column("description")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Generated.Never();

            Map(x => x.Prix)
                .Column("prix")
                .CustomType<double?>()
                .Access.Property()
                .CustomSqlType("DECIMAL")
                .Generated.Never();

            Map(x => x.Quantite)
                .Column("quantite")
                .CustomType<double?>()
                .Access.Property()
                .CustomSqlType("DECIMAL")
                .Generated.Never();
<<<<<<< HEAD
=======

            Map(x => x.EstActif)
                .Column("estActif")
                .CustomType<bool>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("BOOLEAN");

            HasManyToMany<ProduitFacture>(x => x.LstFacture)
                .Access.Property()
                .AsSet()
                .Cascade.AllDeleteOrphan()
                .LazyLoad()
                .Inverse()
                .Generic()
                .Component(p =>
                {
                    p.Map(x => x.Quantite)
                        .Column("quantite")
                        .CustomType<float>()
                        .Access.Property()
                        .Generated.Never()
                        .CustomSqlType("DECIMAL");
                    p.References<Facture>(r => r.Facture, "idFacture");
                })
                .Table("ProduitsFactures")
                .FetchType.Join()
                .ChildKeyColumns.Add("idFacture", mapping => mapping.Name("idFacture")
                                                                    .SqlType("INTEGER")
                                                                    .Not.Nullable())
                .ParentKeyColumns.Add("idProduit", mapping => mapping.Name("idProduit")
                                                                     .SqlType("INTEGER")
                                                                     .Not.Nullable());


>>>>>>> d77ef1cd087a3953959e30e3bc109348d437aa3c
        }
    }
}
