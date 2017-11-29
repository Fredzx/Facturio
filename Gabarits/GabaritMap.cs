using System;
using FluentNHibernate.Mapping;
using Facturio.GabaritsCriteres;

namespace Facturio.Gabarits
{
    class GabaritMap : ClassMap<Gabarit>
    {
        public GabaritMap()
        {
            Table("Gabarits");
            LazyLoad();

            Id(x => x.Id)
                .Column("idGabarit")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.TitreGabarit)
                .Column("titreGabarit")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.Logo)
               .Column("logo")
               .CustomType<string>()
               .Access.Property()
               .CustomSqlType("VARCHAR")
               .Generated.Never();

            Map(x => x.DateCreation)
                .Column("dateCreation")
                .CustomType<DateTime>()
                .Access.Property()
                .CustomSqlType("DATETIME")
                .Not.Nullable()
                .Generated.Never();

            HasManyToMany<GabaritCritere>(x => x.GabaritCriteres)
                .Access.Property()
                .AsSet()
                .Cascade.None()
                .LazyLoad()
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
                    c.References<Critere>(r => r.Critere, "idCritere");
                })
                .Table("GabaritsCriteres")
                .FetchType.Join()
                .ChildKeyColumns.Add("idCritere", mapping => mapping.Name("idCritere")
                                                                    .SqlType("INTEGER")
                                                                    .Not.Nullable())
                .ParentKeyColumns.Add("idGabarit", mapping => mapping.Name("idGabarit")
                                                                     .SqlType("INTEGER")
                                                                     .Not.Nullable());
        }
    }
}
