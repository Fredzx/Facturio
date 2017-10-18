﻿using Facturio.Clients;
using Facturio.Produits;
using Facturio.Factures;
using Facturio.ProduitsFactures;
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

            HasManyToMany<ProduitFacture>(x => x.LstProduit)
                .Access.Property()
                .AsSet()
                .Cascade.None()
                .LazyLoad()
                .Inverse()
                .Generic()
                .Component(p =>
                {
                    p.Map(x => x.Quantite)
                        .Column("quantite")
                        .CustomType<string>()
                        .Access.Property()
                        .Generated.Never()
                        .CustomSqlType("DECIMAL");
                    p.References<Produit>(r => r.Produit, "idProduit");                        
                })
                .Table("ProduitsFactures")
                .FetchType.Join()
                .ChildKeyColumns.Add("idProduit", mapping => mapping.Name("idProduit")
                                                                    .SqlType("INTEGER")
                                                                    .Not.Nullable())
                .ParentKeyColumns.Add("idFacture", mapping => mapping.Name("idFacture")
                                                                     .SqlType("INTEGER")
                                                                     .Not.Nullable());



        }
    }
}
