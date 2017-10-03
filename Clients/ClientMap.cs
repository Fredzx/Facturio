using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel;

namespace Facturio.Clients
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            /*
            Table("clients");

            LazyLoad();

            Id(x => x.IdClient)
                .Column("idClient")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.Nom)
               .Column("nom")
               .CustomType<string>
               .Access.Property()
               .CustomSqlType("VARCHAR")
               .Generated.Never();

            Map(x => x.Prenom)
                .Column("prenom")
                .CustomType<string>
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Generated.Never();

            Map(x => x.Adresse)
                .Column("adresse ")
                .CustomType<string>
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            Map(x => x.CodePostal)
                .Column("codePostal")
                .CustomType<string>
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            Map(x => x.Description)
                .Column("description")
                .CustomType<string>
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            References(x => x.LeSexe)
                .Class<Sexe>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idSexe");

            References(x => x.LeRang)
               .Class<Rang>()
               .Access.Property()
               .LazyLoad(Laziness.False)
               .Cascade.None()
               .Columns("idRang");

            References(x => x.NomProvince)
               .Class<Province>()
               .Access.Property()
               .LazyLoad(Laziness.False)
               .Cascade.None()
               .Columns("idProvince");
               */
        }

        protected ClientMap(AttributeStore attributes, MappingProviderStore providers) : base(attributes, providers)
        {
        }
    }
}
