using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TeknikBilgi.Infrastructure.Extension
{
    public static class ExpressionMethods
    {
        public static MemberExpression GetMemberExpression<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression memberExpression;
            if (expression.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)expression.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)expression.Body;
            }
            return memberExpression;
        }
        public static string GetMemberName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var memberExpression = GetMemberExpression(expression);
            return memberExpression.Member.Name;
        }

        public static string GetMemberName<TModel>(Expression<Func<TModel, object>> expression)
        {
            MemberExpression memberExpression = GetMemberExpression(expression);
            return memberExpression.Member.Name;
        }

        public static string GetMemberFullName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            string fullName = null;
            MemberExpression me;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expression.Body as UnaryExpression;
                    me = ((ue != null) ? ue.Operand : null) as MemberExpression;
                    break;
                default:
                    me = expression.Body as MemberExpression;
                    break;
            }

            while (me != null)
            {
                fullName = fullName == null ? me.Member.Name : string.Format("{0}.{1}", me.Member.Name, fullName);
//                Type propertyType = me.Type;
                me = me.Expression as MemberExpression;
            }
            return fullName;
        }
        public static string GetMemberFullName<TModel>(Expression<Func<TModel, object>> expression)
        {
            return GetMemberFullName<TModel, object>(expression);
        }

        public static void SetPropertyValue<T>(this T target, Expression<Func<T, object>> memberLamda,
            object value)
        {
            var memberSelectorExpression = memberLamda.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }

        public static void SetPropertyValue<TModel, TProperty>(TModel target,
            Expression<Func<TModel, TProperty>> expression,
            TProperty value)
        {
            var memberSelectorExpression = expression.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }


        public static T GetAttributeGeneric<T>(this ICustomAttributeProvider provider)
            where T : Attribute
        {
            var attributes = provider.GetCustomAttributes(typeof(T), true);
            return attributes.Length > 0 ? attributes[0] as T : null;
        }

        public static string GetAliasName<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            var memberExpression = GetMemberExpression(expression);
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return GetMemberFullName(expression);
        }

        public static string GetAliasName<TModel>(Expression<Func<TModel, object>> expression)
        {
            return GetAliasName<TModel, object>(expression);
        }
    }
}