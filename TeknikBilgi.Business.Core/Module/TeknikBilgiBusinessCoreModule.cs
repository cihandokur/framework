using Autofac;
using TeknikBilgi.Business.Core.Builder;
using TeknikBilgi.Business.Core.Implement;
using TeknikBilgi.Business.Core.Interface;
using TeknikBilgi.Infrastructure.WebContext;

namespace TeknikBilgi.Business.Core.Module
{
    public class TeknikBilgiBusinessCoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IAdminBusiness).Assembly)
                .Where(t => t.Name.EndsWith("Business"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<AppConfigBuilder>().As<AppConfigBuilder>().SingleInstance();
            builder.RegisterType<ContextUserProvider>().As<ContextUserProviderBase>().InstancePerLifetimeScope();
        }
    }
}