namespace TeknikBilgi.Infrastructure.Constraints.Structs
{
    public class Keys
    {
        public struct Session
        {
            public const string CurrentAccountInfo = "CurrentAccountInfo";
            public const string AfterLoginReturnUrl = "AfterLoginReturnUrl";
            public const string CurrentLanguageId = "CurrentLanguageId";
        }

        public struct Security
        {
            public const string CommonScreens = "CommonScreens";
            public const string Admin = "Administrator";
        }

        public struct Request
        {
            public const string ReturnUrl = "returnurl";
        }

        public struct PageUrl
        {
            public const string AccountLogin = "~/account/login";
            public const string AccountLogout = "~/account/logout";
            public const string AccessDenied = "~/account/login";
        }

        public struct Cookie
        {
            public const string UserName = "aun";
            public const string Language = "lang";
        }

        public struct ViewData
        {
            public const string Fail = "Fail";
        }

        public struct System
        {
            public const string ApplicationMode = "ApplicationMode";
            public const string CssErrorMessage = "errorMessage";
            public const string CssSuccessMessage = "errorMessage";
        }

        public struct TempDataMessage
        {
            public const string General = "TdmGeneral";
            public const string PageLayoutHome = "TdmPageLayoutHome";
        }

        public struct SubmitButton
        {
            public const string RemoveContent = "RemoveContent";
            public const string SaveChanges = "SaveChanges";
            public const string SaveChangesAndClose = "SaveChangesAndClose";
            public const string SaveChangesAndReturn = "SaveChangesAndReturn";
        }
    }
}
