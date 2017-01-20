using Autofac;

namespace TeknikBilgi.IoC.AutofacContainer
{
    public interface IScopeProvider
    {
        ILifetimeScope Scope();
    }
}