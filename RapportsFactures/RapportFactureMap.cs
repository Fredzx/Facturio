using Facturio.Factures;
using Facturio.Rapports;
using Facturio.Rapports.Entities;
using FluentNHibernate.Mapping;


namespace Facturio.RapportsFactures
{
    public class RapportFactureMap : ClassMap<RapportFacture>
    {
        public RapportFactureMap()
        {
            Table("RapportFacture");

            LazyLoad();

            Id(x => x.IdRapportFacture)
                .Column("idRapportFacture")
                .CustomType<int?>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            References(x => x.Facture)
                .Class<Facture>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idFacture");

            References(x => x.Rapport)
                .Class<Rapport>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idRapport");
        }
    }
}
