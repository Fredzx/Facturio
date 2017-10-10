using FluentNHibernate.Mapping;
using System;
using Facturio.Factures;

namespace Facturio.Rapport
{
    public class RapportMap : ClassMap<Rapport>
    {
        public RapportMap()
        {
            Table("Rapports");

            LazyLoad();

            Id(x => x.IdRapport)
                .Column("idRapport")
                .CustomType<int?>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.Date)
                .Column("dateRapport")
                .CustomType<DateTime?>()
                .Access.Property()
                .CustomSqlType("DATETIME")
                .Generated.Never();

            // Avec HasMany, on dit que le rapport a plusieurs factures
            //HasMany(x => x.LstFacture)
            //    .Not.LazyLoad()
            //    .Access.Property()
            //    .Cascade.All()
            //    .KeyColumns.Add("idRapport", map => map.Name("idRapport")
            //                                            .SqlType("INTEGER")
            //                                            .Nullable());

        }
    }
}
