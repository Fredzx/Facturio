using FluentNHibernate.Mapping;

namespace Facturio.GabaritsCriteres
{
    public class GabaritCritereMap : ClassMap<GabaritCritere>
    {
        public GabaritCritereMap()
        {
            Table("GabaritsCriteres");
            LazyLoad();

            Id(x => x.Id)
                .Column("idGabaritCritere")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.IdGabarit)
                .Column("idCritere")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.IdCritere)
                .Column("idCritere")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.Position)
                .Column("position")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.Largeur)
                .Column("largeur")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.EstUtilise)
                .Column("estUtilise")
                .CustomType<bool>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();
        }
    }
}
