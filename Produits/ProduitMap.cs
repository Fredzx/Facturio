using FluentNHibernate.Mapping;

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
                .CustomType<float?>()
                .Access.Property()
                .CustomSqlType("DECIMAL")
                .Generated.Never();

            Map(x => x.Quantite)
                .Column("quantite")
                .CustomType<float?>()
                .Access.Property()
                .CustomSqlType("DECIMAL")
                .Generated.Never();
        }
    }
}
