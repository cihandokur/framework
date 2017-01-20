using Autofac;
using System.Linq;
using TeknikBilgi.Data.Core.Interface;

namespace TeknikBilgi.Data.Core.Module
{
    public class TeknikBilgiDataCoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IAdminRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}