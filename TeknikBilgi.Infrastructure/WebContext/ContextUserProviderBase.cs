using System;
using System.Security.Principal;
using System.Web;
using TeknikBilgi.Infrastructure.Constraints.Enums;
using TeknikBilgi.Infrastructure.Constraints.Structs;
using TeknikBilgi.Infrastructure.Interface;

namespace TeknikBilgi.Infrastructure.WebContext
{
    public abstract class ContextUserProviderBase
    {
        private HttpContextBase _context;
        private readonly ISessionManager _sessionManager;

        public readonly Guid MallocGuid = Guid.NewGuid();

        protected ContextUserProviderBase(
            //HttpContextBase contextBase,
            ISessionManager sessionManager
            )
        {
            //_context = contextBase;
            _sessionManager = sessionManager;
        }

        public HttpContextBase ContextBase
        {
            get
            {
                _context = new HttpContextWrapper(HttpContext.Current);
                return _context;
            }
        }

        public ISessionManager SessionManager
        {
            get { return _sessionManager; }
        }

        public IIdentity CurrentIdentity
        {
            get { return ContextBase.User.Identity; }
        }

        public IPrincipal CurrentUser
        {
            get { return ContextBase.User; }
        }

        public HttpSessionStateBase CurrentSession
        {
            get { return SessionManager.SessionStateBase; }
        }

        public byte LanguageId
        {
            get
            {
                return SessionManager.Get<byte>(Keys.Session.CurrentLanguageId);
            }
            set
            {
                SessionManager.Set(Keys.Session.CurrentLanguageId, value);
            }
        }

        public Languages Language
        {
            get { return (Languages)LanguageId; }
        }

        public AccountInfo Account
        {
            get
            {
                return SessionManager.Get<AccountInfo>(Keys.Session.CurrentAccountInfo);
            }
            set
            {
                SessionManager.Set(Keys.Session.CurrentAccountInfo, value);
            }
        }

        public bool IsAccountLogin
        {
            get { return Account != null && Account.LoginStatus; }
        }

        public bool IsAuthenticated
        {
            get { return ContextBase.Request.IsAuthenticated; }
        }

    }
}