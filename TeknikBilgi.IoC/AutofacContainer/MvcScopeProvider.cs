using System;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using System.Web;

namespace TeknikBilgi.IoC.AutofacContainer
{
    public class MvcScopeProvider : IScopeProvider
    {
        public ILifetimeScope Scope()
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    return AutofacDependencyResolver.Current.RequestLifetimeScope;
                }

                return Bootstrapper.Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch (Exception)
            {
                return Bootstrapper.Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}