using FluentNHibernate.Mapping;
using Facturio.Gabarits;
using Facturio.GabaritsCriteres;

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

            HasManyToMany<GabaritCritere>(x => x.Gabarits)
                .Access.Property()
                .AsSet()
                .Cascade.None()
                .LazyLoad()
                .Inverse()
                .Generic()
                .Component(c =>
                {
                    c.Map(x => x.Position)
                        .Column("positionCritere")
                        .CustomType<int>()
                        .Access.Property()
                        .Generated.Never()
                        .CustomSqlType("INTEGER");
                    c.Map(x => x.Largeur)
                        .Column("largeur")
                        .CustomType<int>()
                        .Access.Property()
                        .Generated.Never()
                        .CustomSqlType("INTEGER");
                    c.Map(x => x.EstUtilise)
                        .Column("estUtilise")
                        .CustomType<bool>()
                        .Access.Property()
                        .Generated.Never()
                        .CustomSqlType("BOOLEAN");
                    c.References<Gabarit>(r => r.Gabarit, "idGabarit");
                })
                .Table("GabaritsCriteres")
                .FetchType.Join()
                .ChildKeyColumns.Add("idGabarit", mapping => mapping.Name("idGabarit")
                                                                    .SqlType("INTEGER")
                                                                    .Not.Nullable())
                .ParentKeyColumns.Add("idCritere", mapping => mapping.Name("idCritere")
                                                                     .SqlType("INTEGER")
                                                                     .Not.Nullable());
        }
    }
}
