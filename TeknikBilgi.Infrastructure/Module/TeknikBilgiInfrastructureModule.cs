using Autofac;
using Autofac.Core;
using System.Web;
using TeknikBilgi.Infrastructure.Interface;
using TeknikBilgi.Infrastructure.Manager;
using TeknikBilgi.Infrastructure.Security;

namespace TeknikBilgi.Infrastructure.Module
{
    public class TeknikBilgiInfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SaltedHash>().As<IHashProvider>().InstancePerLifetimeScope();
            builder.RegisterType<SessionManager>().As<ISessionManager>().InstancePerLifetimeScope();

            builder.RegisterType<CookieManager>().As<ICookieManager>()
                .WithParameter(new ResolvedParameter((info, context) => info.ParameterType == typeof(HttpContext), (info, context) => HttpContext.Current))
                .InstancePerLifetimeScope();
        }
    }
}