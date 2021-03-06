﻿using FluentNHibernate.Mapping;

namespace Facturio.Clients
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Table("Clients");

            LazyLoad();            
            
            Id(x => x.IdClient)
                .Column("idClient")        // Colonne en BD
                .CustomType<int?>()         // Type dans le code
                .Access.Property()         // Accès par propriété
                .CustomSqlType("INTEGER")  // Type en BD
                .Not.Nullable()            // Est pas nullable
                .GeneratedBy.Identity();   // Est généré par la BD

            Map(x => x.NoClient)
                .Column("codeClient")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Generated.Never();

            Map(x => x.Prenom)
                .Column("prenom")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Generated.Never();

            Map(x => x.Nom)
               .Column("nom")
               .CustomType<string>()
               .Access.Property()
               .CustomSqlType("VARCHAR")
               .Generated.Never();         // N'est pas généré par la BD

            Map(x => x.Description)
                .Column("description")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            References(x => x.Sexe)
                .Class<Sexe>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idSexe");        // Colonne qui fait référence à la table Sexes dans Clients

            Map(x => x.Adresse)
                .Column("adresse ")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            Map(x => x.CodePostal)
                .Column("codePostal")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            Map(x => x.Telephone)
                .Column("telephone")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            Map(x => x.EstActif)
                .Column("estActif")
                .CustomType<bool>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("BOOLEAN");

            References(x => x.Rang)
               .Class<Rang>()
               .Access.Property()
               .LazyLoad(Laziness.False)
               .Cascade.None()
               .Columns("idRang");

            References(x => x.Province)
               .Class<Province>()
               .Access.Property()
               .LazyLoad(Laziness.False)
               .Cascade.None()
               .Columns("idProvince");
        }
    }
}
