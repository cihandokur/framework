using Autofac;
using Autofac.Builder;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TeknikBilgi.IoC.AutofacContainer
{
    //public static class CacheServiceIoCExtensions
    //{
    //    public static BootstrapperExtensions Extensions(this ContainerBuilder builder)
    //    {
    //        return new BootstrapperExtensions(builder);
    //    }
    //}

    public static class BootstrapperExtensions
    {
        //private readonly ContainerBuilder _builder;

        //public BootstrapperExtensions(ContainerBuilder builder)
        //{
        //    _builder = builder;
        //}

        //public IRegistrationBuilder<IRedisClientsManager, SimpleActivatorData, SingleRegistrationStyle> RedisPooledConnection(string readWriteHosts, string readOnlyHosts, int? defaultDb = 0)
        //{
        //    var locReadWriteHosts = readWriteHosts.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
        //    var locReadOnlyHosts = readOnlyHosts.Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

        //    var config = new RedisClientManagerConfig
        //    {
        //        MaxWritePoolSize = locReadWriteHosts.Length,
        //        MaxReadPoolSize = locReadOnlyHosts.Length,
        //        AutoStart = true,
        //        DefaultDb = defaultDb ?? 0
        //    };
        //    //return _builder.Register<IRedisClientsManager>(c => new PooledRedisClientManager(locReadWriteHosts, locReadOnlyHosts)).SingleInstance();
        //    return _builder.Register<IRedisClientsManager>(c => new PooledRedisClientManager(locReadWriteHosts, locReadOnlyHosts)).SingleInstance();
        //}


        //public IRegistrationBuilder<IRedisClientsManager, SimpleActivatorData, SingleRegistrationStyle> RedisConnection(string redisConnectionString, int? defaultDb = 0)
        //{
        //    return _builder.Register<IRedisClientsManager>(c => new RedisManagerPool(redisConnectionString)).SingleInstance();
        //}


        //public IRegistrationBuilder<ICacheService, SimpleActivatorData, SingleRegistrationStyle> CacheService()
        //{
        //    return
        //        _builder.Register<ICacheService>(
        //            context =>
        //                new CacheService(context.Resolve<IRedisClientsManager>(), context.Resolve<IBinarySerializer>())).InstancePerLifetimeScope();
        //}

        public static IRegistrationBuilder<IDbConnection, SimpleActivatorData, SingleRegistrationStyle> SqlConnection(this ContainerBuilder builder, string conStrConfigName, object key = null)
        {
            var result =  key == null
                ? builder.Register<IDbConnection>(c => new SqlConnection(ConfigurationManager.ConnectionStrings[conStrConfigName].ConnectionString))
                : builder.Register<IDbConnection>(c => new SqlConnection(ConfigurationManager.ConnectionStrings[conStrConfigName].ConnectionString)).Keyed(key, typeof(IDbConnection));
            return result;
        }
    }
}