using Autofac;
using System;

namespace TeknikBilgi.IoC.AutofacContainer
{
    public class Bootstrapper
    {
        public static ContainerBuilder Builder { get; private set; }
        public static IContainer Container { get; private set; }
        public static IScopeProvider ScopeProvider { get; set; }
        public static void InitializeBuilder()
        {
            Builder = new ContainerBuilder();
        }

        public static bool IsBuilded { get; set; }

        public static void SetAutofacContainer()
        {
            if (!IsBuilded)
            {
                Container = Builder.Build();
                IsBuilded = true;
            }
            else
            {
                Builder.Update(Container);
            }
        }

        public static T GetService<T>() where T : class
        {
            return Resolve<T>();
        }

        public static object GetService(string typeName)
        {
            return Resolve(Type.GetType(typeName));
        }

        private static T Resolve<T>(string key = "", ILifetimeScope scope = null) where T : class
        {
            if (scope == null)
            {
                //no scope specified
                scope = ScopeProvider.Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<T>();
            }
            return scope.ResolveKeyed<T>(key);
        }

        private static object Resolve(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                //no scope specified
                scope = ScopeProvider.Scope();
            }
            return scope.Resolve(type);
        }
    }
}