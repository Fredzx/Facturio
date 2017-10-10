using FluentNHibernate.Mapping;

namespace Facturio.Clients
{
    public class ProvinceMap : ClassMap<Province>
    {
        public ProvinceMap()
        {
            Table("Provinces");

            LazyLoad();

            Id(x => x.IdProvince)
               .Column("idProvince")
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

        }
    }
}
