﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikBilgi.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Account {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Account() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TeknikBilgi.Localization.Account", typeof(Account).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-posta adresi kullanılıyor...
        /// </summary>
        public static string EmailExists {
            get {
                return ResourceManager.GetString("EmailExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifrenizi unuttunuz ?.
        /// </summary>
        public static string ForgotPassword {
            get {
                return ResourceManager.GetString("ForgotPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Giriş.
        /// </summary>
        public static string Login {
            get {
                return ResourceManager.GetString("Login", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-posta adresiniz ve şifrenizi girmeniz gerekli..
        /// </summary>
        public static string LoginRequired {
            get {
                return ResourceManager.GetString("LoginRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kullanıcı Bulunamadı..
        /// </summary>
        public static string NotFound {
            get {
                return ResourceManager.GetString("NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifre.
        /// </summary>
        public static string Password {
            get {
                return ResourceManager.GetString("Password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-posta adresiniz veya şifreniz hatalı.
        /// </summary>
        public static string PasswordDoesNotMatch {
            get {
                return ResourceManager.GetString("PasswordDoesNotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifreler aynı değil..
        /// </summary>
        public static string PasswordDoesNotMatch_ {
            get {
                return ResourceManager.GetString("PasswordDoesNotMatch_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifre hatalı..
        /// </summary>
        public static string PasswordInvalid {
            get {
                return ResourceManager.GetString("PasswordInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Eski şifre ile yeni şifre aynı olamaz..
        /// </summary>
        public static string PasswordSameOld {
            get {
                return ResourceManager.GetString("PasswordSameOld", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Beni Hatırla.
        /// </summary>
        public static string RememberMe {
            get {
                return ResourceManager.GetString("RememberMe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifrenizi sıfırlamak için e-posta adresinizi yazınız..
        /// </summary>
        public static string ResetPasswordText {
            get {
                return ResourceManager.GetString("ResetPasswordText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Oturum Aç.
        /// </summary>
        public static string SignIn {
            get {
                return ResourceManager.GetString("SignIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Kullanıcı Adı.
        /// </summary>
        public static string Username {
            get {
                return ResourceManager.GetString("Username", resourceCulture);
            }
        }
    }
}