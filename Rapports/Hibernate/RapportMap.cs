using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.Collections;
using System;
using Facturio.Factures;
using System.Collections;
using System.ComponentModel;
using Facturio.Rapports.Entities;
using Facturio.RapportsFactures;

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

            /*HasMany<RapportFacture>(x => x.LstFacture)
               .Not.LazyLoad()
               .Access.Property()
               .Cascade.All()
               .KeyColumns.Add("idRapport", map => map.Name("idRapport")
                                                           .SqlType("INTEGER")
                                                           .Nullable());*/

            //HasManyToMany<Facture>(x => x.LstFacture)
            //   .Access.Property()
            //   .AsSet()
            //   .Cascade.None()
            //   .LazyLoad()
            //   .Inverse()
            //   .Generic()
            //   .Table("FacturesRapports")
            //   .FetchType.Join()
            //   .ChildKeyColumns.Add("idFacture", mapping => mapping.Name("idFacture")
            //                                                        .SqlType("INTEGER")
            //                                                        .Not.Nullable())
            //   .ParentKeyColumns.Add("idRapport", mapping => mapping.Name("idRapport")
            //                                                        .SqlType("INTEGER")
            //                                                        .Not.Nullable());

            HasManyToMany<Facture>(x => x.LstFacture)
                .Cascade.All()
                .Inverse()
                .Table("FacturesRapports");

        }
    }

    public class RapportFacturationClienteMap : SubclassMap<RapportFacturationCliente>
    {
        public RapportFacturationClienteMap()
        {
            Table("RapportsFacturationCliente");
            LazyLoad();
            KeyColumn("idRapportFacturationCliente");
        }
    }

    public class RapportSommaireMap : SubclassMap<RapportSommaire>
    {
        public RapportSommaireMap()
        {
            Table("RapportsSommaires");
            LazyLoad();
            KeyColumn("idRapportSommaire");
        }
    }

    public class RapportVenteProduitMap : SubclassMap<RapportVenteProduit>
    {
        public RapportVenteProduitMap()
        {
            Table("RapportsVentesProduit");
            LazyLoad();
            KeyColumn("idRapportVenteProduit");
        }
    }

}
