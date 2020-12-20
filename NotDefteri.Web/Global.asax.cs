using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using NotDefteri.Data.Context;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NotDefteri.Data.Utilities;
using NotDefteri.Service.Repository;
using NotDefteri.Abstraction.IRepository;

namespace NotDefteri.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DataContext>();

            builder.RegisterType<UserService>().As<IUserService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Mapping Initialized
            Mapper.Initialize(cfg =>
            {
                MapUtility.ConfigureMapping(cfg);
            });
        }
    }
}
