using FluentNHibernate.Mapping;

namespace Facturio.Criteres
{
    public class CritereMap : ClassMap<Critere>
    {
        public CritereMap()
        {
            Table("Criteres");
            LazyLoad();

            Id(x => x.Id)
                .Column("idCritere")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.Titre)
                .Column("titre")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Not.Nullable()
                .Generated.Never();
        }
    }
}
