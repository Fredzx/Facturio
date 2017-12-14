using Facturio.Clients;
using Facturio.Produits;
using Facturio.Factures;
using Facturio.ProduitsFactures;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.MappingModel.Collections;
using Facturio.Rapports;
using Facturio.Rapports.Entities;
using Facturio.RapportsFactures;
using Facturio.Gabarits;

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
                .CustomType<int?>()
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

            References(x => x.LeGabarit)
                .Class<Gabarit>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idGabarit");

            Map(x => x.Date)
                .Column("dateFacture ")
                .CustomType<DateTime?>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("DATETIME");

            //HasManyToMany<Rapport>(x => x.LstRapport)
            //   .Access.Property()
            //   .AsSet()
            //   .Cascade.All()
            //   .LazyLoad()
            //   .Generic()
            //   .Table("facturesrapports")
            //   .FetchType.Join()
            //   .ChildKeyColumns.Add("idFacture", mapping => mapping.Name("idFacture")
            //                                                        .SqlType("INTEGER")
            //                                                        .Not.Nullable())
            //   .ParentKeyColumns.Add("idRapport", mapping => mapping.Name("idRapport")
            //                                                        .SqlType("INTEGER")
            //                                                        .Not.Nullable());

            //HasManyToMany<Rapport>(x => x.LstRapport)
            //    .Cascade.All()
            //    .Table("FacturesRapports");

            HasMany<ProduitFacture>(x => x.LstProduitFacture)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .KeyColumns.Add("idFacture", map => map.Name("idFacture")
                                                       .SqlType("INTEGER")
                                                       .Nullable());

        }
    }
}
