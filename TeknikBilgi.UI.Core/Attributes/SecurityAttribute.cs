using System.Web;
using System.Web.Mvc;
using TeknikBilgi.Infrastructure.Constraints.Structs;
using TeknikBilgi.Infrastructure.WebContext;
using TeknikBilgi.IoC.AutofacContainer;

namespace TeknikBilgi.UI.Core.Attributes
{
    public class SecurityAttribute : AuthorizeAttribute
    {
        private readonly ContextUserProviderBase _contextUserProviderBase;

        public string Key { get; private set; }
        public string ReturnUrl { get; private set; }

        public bool IsAuthorize { get; private set; }

        public SecurityAttribute(string key = "", string returnUrl = "")
        {
            Key = string.IsNullOrWhiteSpace(key) ? Keys.Security.CommonScreens : key;
            ReturnUrl = returnUrl;
            _contextUserProviderBase = Bootstrapper.GetService<ContextUserProviderBase>();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            IsAuthorize = base.AuthorizeCore(_contextUserProviderBase.ContextBase);
            if (_contextUserProviderBase.IsAccountLogin)
            {
                IsAuthorize = _contextUserProviderBase.Account.HasPermissionFor(Key);
            }
            return IsAuthorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var contextReturnUrl = "";
            if (_contextUserProviderBase.ContextBase.Request.Url != null)
            {
                contextReturnUrl = _contextUserProviderBase.ContextBase.Request.Url.ToString();
            }
            var retUrl = string.IsNullOrWhiteSpace(ReturnUrl) ? contextReturnUrl : ReturnUrl.Replace("~/", "/");
            _contextUserProviderBase.SessionManager.Set(Keys.Session.AfterLoginReturnUrl, retUrl);
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Result = new RedirectResult(Keys.PageUrl.AccountLogin);
        }
    }
}