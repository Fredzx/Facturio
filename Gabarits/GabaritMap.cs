using System;
using FluentNHibernate.Mapping;

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

            Map(x => x.DateCreation)
                .Column("dateCreation")
                .CustomType<DateTime>()
                .Access.Property()
                .CustomSqlType("DATETIME")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.CodeProduit)
                .Column("codeProduit")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.NomProduit)
                .Column("nomProduit")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.Description)
                .Column("description")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.Prix)
                .Column("prix")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.Quantite)
                .Column("quantite")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.PrenomClient)
                .Column("prenomClient")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.NomClient)
                .Column("nomClient")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.AdresseClient)
                .Column("adresseClient")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.CodePostalClient)
                .Column("codePostalClient")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.Escompte)
                .Column("escompte")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.CritereLibre)
                .Column("critereLibre")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.NombreHeures)
                .Column("nbHeure")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();

            Map(x => x.TauxHoraire)
                .Column("tauxHoraire")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Generated.Never();
        }
    }
}
