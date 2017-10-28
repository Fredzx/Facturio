using FluentNHibernate.Mapping;

namespace Facturio.Criteres
{
    public class TypeCritereMap : ClassMap<TypeCritere>
    {
        public TypeCritereMap()
        {
            Table("TypesCriteres");
            LazyLoad();

            Id(x => x.Id)
                .Column("idTypeCritere")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.TypeDuCritere)
                .Column("typeDuCritere")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Not.Nullable()
                .Generated.Never();

            Map(x => x.Nom)
                .Column("nom")
                .CustomType<string>()
                .Access.Property()
                .CustomSqlType("VARCHAR")
                .Not.Nullable()
                .Generated.Never();
        }
    }
}