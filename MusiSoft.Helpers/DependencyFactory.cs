using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Base;
using MusiSoft.Repositories.Contract.Contract;
using MusiSoft.Repositories.Impl;
using MusiSoft.Services.Contract.Contract;
using MusiSoft.Services.Impl;
using Unity;
using Unity.Injection;

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
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<ICampaignService, CampaignService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IPQRService, PQRService>();
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IEFBaseRepository, EFBaseRepository>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<ICampaignRepository, CampaignRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IPQRRepository, PQRRepository>();
        }

        private static void RegisterApplicationDBContext(IUnityContainer container)
        {
            container.RegisterType<MusiSoftBDEntities>(new InjectionFactory(x => new MusiSoftBDEntities()));
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