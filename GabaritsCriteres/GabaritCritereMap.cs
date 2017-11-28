using Facturio.GabaritsCriteres;
using Facturio.Gabarits;
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

            References(x => x.Gabarit)
                .Class<Gabarit>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idGabarit");

            References(x => x.Critere)
                 .Class<Critere>()
                 .Access.Property()
                 .LazyLoad(Laziness.False)
                 .Cascade.None()
                 .Columns("idCritere");

            Map(x => x.Position)
                .Column("positionCritere")
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
                .CustomSqlType("BOOLEAN")
                .Not.Nullable()
                .Generated.Never();
        }
    }
}
