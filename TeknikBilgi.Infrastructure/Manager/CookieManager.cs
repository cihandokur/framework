using System;
using System.Web;
using TeknikBilgi.Infrastructure.Interface;

namespace TeknikBilgi.Infrastructure.Manager
{
    public class CookieManager : ICookieManager
    {
        private readonly HttpContext _httpContext;
        public CookieManager(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public string Name { get; set; }

        public int? ExpireMinute { get; set; }

        public bool IsHttpOnly { get; set; }

        /// <summary>
        /// Cookie'ye yazma işlemini yapar.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="isHttpOnly"></param>
        /// <param name="expireMinute">Null set edilirse Session Bazlı set eder</param>
        /// <returns>true  / false </returns>
        public bool Write(object value, string name = "", bool isHttpOnly = true, int? expireMinute = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            if (string.IsNullOrWhiteSpace(Name))
                return false;

            if (expireMinute.HasValue)
                ExpireMinute = expireMinute.Value;

            IsHttpOnly = isHttpOnly;

            var cookie = new HttpCookie(Name, value.ToString()) { HttpOnly = IsHttpOnly };
            if (ExpireMinute.HasValue)
            {
                cookie.Expires = DateTime.Now.AddMinutes(ExpireMinute.Value);
            }

            _httpContext.Response.Cookies.Add(cookie);

            return true;
        }
        public string Read(string name = "")
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            if (string.IsNullOrWhiteSpace(Name))
                return null;

            var cookie = _httpContext.Request.Cookies.Get(Name);
            return cookie != null ? cookie.Value : null;
        }

        public bool Remove(string name = "")
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;

            if (string.IsNullOrWhiteSpace(Name))
                return false;

            var cookie = _httpContext.Request.Cookies.Get(Name);
            cookie.Expires = DateTime.Now.AddDays(-1);

            _httpContext.Response.Cookies.Add(cookie);
            return true;
        }
    }
}