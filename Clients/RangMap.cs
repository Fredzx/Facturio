using FluentNHibernate.Mapping;
using System.Windows.Controls;

namespace Facturio.Clients
{
    public class RangMap : ClassMap<Rang>
    {
        public RangMap()
        {

            Table("Rangs");

            LazyLoad();

            Id(x => x.IdRang)
               .Column("idRang")
               .CustomType<int?>()
               .Access.Property()
               .CustomSqlType("INTEGER")
               .Not.Nullable()
               .GeneratedBy.Identity();

            Map(x => x.Nom)
               .Column("nom")
               .CustomType<string>()
               .Access.Property()
               .CustomSqlType("VARCHAR")
               .Generated.Never();

            //Map(x => x.Image)
            //   .Column("image")
            //   .CustomType<Image>()
            //   .Access.Property()
            //   .CustomSqlType("VARCHAR")
            //   .Generated.Never();

            Map(x => x.Escompte)
               .Column("escompte")
               .CustomType<float?>()
               .Access.Property()
               .CustomSqlType("DECIMAL")
               .Generated.Never();
        }
    }
}
