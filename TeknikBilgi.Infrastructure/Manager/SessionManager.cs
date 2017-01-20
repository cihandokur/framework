using System.Web;
using TeknikBilgi.Infrastructure.Interface;

namespace TeknikBilgi.Infrastructure.Manager
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionStateBase _httpSession;
        public SessionManager(/*HttpSessionStateBase httpSession*/)
        {
            //_httpSession = httpSession;
        }

        public HttpSessionStateBase SessionStateBase
        {
            get
            {
                if (_httpSession == null)
                    _httpSession = new HttpSessionStateWrapper(HttpContext.Current.Session).Contents;
                return _httpSession;
            }
        }

        public object Get(string sessionName)
        {
            if (SessionStateBase == null)
                return null;
            return SessionStateBase[sessionName];
        }

        public T Get<T>(string sessionName)
        {
            var obj = Get(sessionName);
            if (obj != null)
                return (T)obj;

            return default(T);
        }

        public T? Get<T>(string sessionName, bool isValue) where T : struct
        {
            var obj = Get(sessionName);
            if (obj is T?)
                return (T?)obj;
            if (obj != null)
                return (T?)obj;
            return new T?();
        }

        public bool Check(string sessionName)
        {
            return Get(sessionName) != null;
        }

        public void Set(string sessionName, object obj)
        {
            SessionStateBase[sessionName] = obj;
        }

        public void Remove(string sessionName)
        {
            SessionStateBase.Remove(sessionName);
        }
    }
}