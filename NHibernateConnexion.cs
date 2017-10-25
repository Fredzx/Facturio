using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;

namespace Facturio
{
    public class NHibernateConnexion
    {
        private static ISessionFactory _sessionFactory;
        private static readonly bool IS_FLUENT = true;

        static NHibernateConnexion()
        {
            if (IS_FLUENT)
            {
                _sessionFactory = Fluently.Configure().Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConnexion>()).BuildSessionFactory();
            }
            else
            {
                _sessionFactory = new Configuration().AddAssembly(typeof(NHibernateConnexion).Assembly).BuildSessionFactory();
            }
        }

        private static ISessionFactory SessionFactory => _sessionFactory;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
