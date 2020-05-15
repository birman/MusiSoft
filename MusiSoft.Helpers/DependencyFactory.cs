using Unity;

namespace MusiSoft.Helpers
{
    public static class DependencyFactory
    {
        public static IUnityContainer Container { get; set; }

        static DependencyFactory()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            Container = container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            RegisterApplicationDBContext(container);
            RegisterRepositories(container);
            RegisterServices(container);
        }

        private static void RegisterServices(IUnityContainer container)
        {
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            //container.RegisterType<IDeleteRulesRepository, DeleteRulesRepository>();
        }

        private static void RegisterApplicationDBContext(IUnityContainer container)
        {
            //container.RegisterType(typeof(EvaSysDbContext), new InjectionConstructor(MySQLConnectionStringProvider.ConnectionString));
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }
}