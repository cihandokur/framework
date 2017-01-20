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
            public const string ApplicationCode = "ApplicationCode";
            public const string ApplicationMode = "ApplicationMode";

            public const string EuroMessage_EuroMsgAuthUser = "EuroMsgAuthUser";
            public const string EuroMessage_EuroMsgAuthPass = "EuroMsgAuthPass";
            public const string EuroMessage_LoginErrorCode = "00";
            public const string EuroMessage_EuroMsgFromAddress = "EuroMsgFromAddress";
            public const string EuroMessage_EuroMsgReplyAddress = "EuroMsgReplyAddress";
            public const string EuroMessage_FromName = "Fanatik.com.tr";


            public const string CssErrorMessage = "errorMessage";
            public const string CssSuccessMessage = "errorMessage";



        }


        public struct TempDataMessage
        {
            public const string General = "TDKey_General";
            public const string PageLayoutHome = "TDKey_PageLayoutHome";
            public const string PageLayoutNewspaperHome = "TDKey_PageLayoutNewspaperHome";
            public const string PageLayoutCategoryGeneric = "TDKey_PageLayoutCategoryGeneric{0}";
            public const string PageLayoutClubCategory = "TDKey_PageLayoutClubCategory{0}";
        }

        public struct SubmitButton
        {
            public const string RemoveContent = "RemoveContent";
            public const string SaveChanges = "SaveChanges";
            public const string SaveChangesAndClose = "SaveChangesAndClose";
            public const string SaveChangesAndReturn = "SaveChangesAndReturn";
            public const string FetchArticle = "FetchArticle";
            public static string PublishPage = "PublishPage";
            public static string RevertPage = "RevertPage";
            public static string ClearPage = "ClearPage";
        }

        public struct LotteryTypeName
        {
            public const string MilliPiyango = "piyango";
            public const string SayisalLoto = "sayisal";
            public const string SansTopu = "sanstopu";
            public const string OnNumara = "onnumara";
            public const string SuperLoto = "superloto";
        }

        public struct LotteryName
        {
            public const string MilliPiyango = "milli-piyango";
            public const string SayisalLoto = "sayisal-loto";
            public const string SansTopu = "sans-topu";
            public const string OnNumara = "on-numara";
            public const string SuperLoto = "super-loto";
            public const string SporToto = "spor-toto";
        }
    }
}
