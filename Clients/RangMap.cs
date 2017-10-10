using FluentNHibernate.Mapping;

namespace Facturio.Clients
{
    public class RangMap : ClassMap<Rang>
    {
        public RangMap()
        {

            Table("Rangs");

            LazyLoad();

            Id(x => x.IdRang)
               .Column("idRang")
               .CustomType<int?>()
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

            // Procédure différente pour mapper un image voir le lien :
            /*http://blog.calyptus.eu/seb/2009/03/large-object-storage-for-nhibernate-and-ddd-part-1-blobs-clobs-and-xlobs/ */
            //Map(x => x.Image)
            //   .Column("image")
            //   .CustomType<BinaryBlob>()
            //   .Access.Property()
            //   .CustomSqlType("VARCHAR")
            //   .Generated.Never()
            //   .Length(2147483647);

            Map(x => x.Escompte)
               .Column("escompte")
               .CustomType<float?>()
               .Access.Property()
               .CustomSqlType("DECIMAL")
               .Generated.Never();
        }
    }
}
