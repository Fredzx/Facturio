﻿using Facturio.Clients;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturio.Factures
{
    public class FactureMap : ClassMap<Facture>
    {
        public FactureMap()
        {
            Table("Factures");

            LazyLoad();

            Id(x => x.IdFacture)
                .Column("idFacture")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            References(x => x.LeClient)
                .Class<Client>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idClient");

            Map(x => x.Date)
                .Column("dateFacture ")
                .CustomType<DateTime?>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("DATETIME");

            //HasManyToMany(x => x.LstRapport)
            //    .Access.Property()
            //    .AsSet()
            //    .Cascade.None()
            //    .LazyLoad()
            //    .Inverse()
            //    .Generic()
            //    .Table("RapportFacture")
            //    .FetchType.Join()
            //    .ChildKeyColumns.Add("idRapport", mapping => mapping.Name("idRapport")
            //                                                        .SqlType("INTEGER")
            //                                                        .Not.Nullable())
            //    .ParentKeyColumns.Add("idFacture", mapping => mapping.Name("idFacture")
            //                                                         .SqlType("INTEGER")
            //                                                         .Not.Nullable());



        }
    }
}