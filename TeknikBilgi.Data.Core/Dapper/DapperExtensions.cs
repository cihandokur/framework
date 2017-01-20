using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace TeknikBilgi.Data.Core.Dapper
{
    public static class DapperExtensions
    {

        public static List<T> Where<T>(this IDbConnection connection,Expression<Func<T, object>> expression, object value) where T : class
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var predicate = Predicates.Field<T>(expression, Operator.Eq, value);
            return connection.GetList<T>(predicate).ToList();
        }

        public static T FirstOrDefault<T>(this IDbConnection connection, Expression<Func<T, object>> expression, object value) where T : class
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var predicate = Predicates.Field<T>(expression, Operator.Eq, value);
            return connection.GetList<T>(predicate).FirstOrDefault();
        }

        public static bool Update<T>(this IDbConnection connection, T obj) where T : class
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection.Update<T>(obj);
        }
    }
}
