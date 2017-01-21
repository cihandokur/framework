using System;
using Autofac;
using Autofac.Core.Lifetime;

namespace TeknikBilgi.IoC.AutofacContainer
{
    public class WebApiScopeProvider : IScopeProvider
    {
        public ILifetimeScope Scope()
        {
            try
            {
                return Bootstrapper.Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch (Exception)
            {
                return Bootstrapper.Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}