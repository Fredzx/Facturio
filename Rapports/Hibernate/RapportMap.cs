using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;
using System;
using Facturio.Factures;
using System.Collections;
using System.ComponentModel;
using Facturio.Rapports.Entities;

namespace Facturio.Rapports.Hibernate
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

            HasManyToMany<Facture>(x => x.LstFacture)
                .Access.Property()
                .AsSet()
                .Cascade.None()
                .LazyLoad()
                .Generic()
                .Table("FacturesRapports")
                .FetchType.Join()
                .ChildKeyColumns.Add("idFacture", mapping => mapping.Name("idFacture")
                                                                    .SqlType("INTEGER")
                                                                    .Not.Nullable())
                .ParentKeyColumns.Add("idRapport", mapping => mapping.Name("idRapport")
                                                                     .SqlType("INTEGER")
                                                                     .Not.Nullable());

        }
    }

    public class RapportFacturationClienteMap : SubclassMap<Rapport>
    {
        public RapportFacturationClienteMap()
        {
            Table("RapportsFacturationCliente");
            LazyLoad();
            KeyColumn("idRapportFacturationCliente");
        }
    }

    public class RapportSommaireMap : SubclassMap<Rapport>
    {
        public RapportSommaireMap()
        {
            Table("RapportsSommaires");
            LazyLoad();
            KeyColumn("idRapportSommaire");
        }
    }

    public class RapportVenteProduitMap : SubclassMap<Rapport>
    {
        public RapportVenteProduitMap()
        {
            Table("RapportsVentesProduit");
            LazyLoad();
            KeyColumn("idRapportVenteProduit");
        }
    }

}
