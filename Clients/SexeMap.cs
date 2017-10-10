using FluentNHibernate.Mapping;

namespace Facturio.Clients
{
    public class SexeMap : ClassMap<Sexe>
    {
        public SexeMap()
        {
            Table("Sexes");

            LazyLoad();

            Id(x => x.IdSexe)
               .Column("idSexe")
               .CustomType<int?>()
               .Access.Property()
               .CustomSqlType("INTEGER")
               .Not.Nullable()
               .GeneratedBy.Identity();

            Map(x => x.Nom)
               .Column("sexe")
               .CustomType<string>()
               .Access.Property()
               .CustomSqlType("VARCHAR")
               .Generated.Never();
        }
    }
}
