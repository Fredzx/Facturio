using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Facturio.Clients
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Table("clients");

            LazyLoad();

            Id(x => x.IdClient)
                .Column("idClient")
                .CustomType<int>()
                .Access.Property()
                .CustomSqlType("INTEGER")
                .NotNullable()
                .GeneratedBy.Identity();

            Map(x)

        }


    }
}
