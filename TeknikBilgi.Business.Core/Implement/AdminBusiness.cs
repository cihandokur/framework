using System;
using TeknikBilgi.Business.Core.ServiceResult;
using TeknikBilgi.Infrastructure.Constraints.Structs;
using TeknikBilgi.Infrastructure.WebContext;
using TeknikBilgi.Business.Core.Interface;
using TeknikBilgi.UI.Core.ViewModel.Account;
using System.Web;
using TeknikBilgi.Infrastructure.Interface;
using TeknikBilgi.Infrastructure.Constraints.Enums.Status;
using TeknikBilgi.Data.Core.Entity.Admin;
using TeknikBilgi.Data.Core.Interface;
using System.Linq;
using TeknikBilgi.Infrastructure.Util;
using Erp.UI.Admin.ViewModel.Account;

namespace TeknikBilgi.Business.Core.Implement
{
    public class AdminBusiness : IAdminBusiness
    {
        public ContextUserProviderBase ContextUserProviderBase;
        public IAdminRepository AdminRepository;
        public IHashProvider HashProvider;
        public AdminBusiness(ContextUserProviderBase contextUserProviderBase, IAdminRepository adminRepository, IHashProvider hashProvider)
        {
            ContextUserProviderBase = contextUserProviderBase;
            AdminRepository = adminRepository;
            HashProvider = hashProvider;
        }
        public ResultSet<ForgotPassword> ForgotPassword(string email)
        {
            var result = new ResultSet<ForgotPassword> { Message = Localization.Common.OperationFailed };

            var admin = AdminRepository.GetAdminByEmail(email);

            if (admin == null)
            {
                result.Success = false;
                result.Message = Localization.Account.NotFound;
                return result;
            }

            // is Active
            if (admin.StatusId != (int)AdminStatus.Active)
            {
                result.Message = Localization.Account.NotFound;
                return result;
            }

            string passHash, passSalt;
            var password = Utility.RandomString(8);
            HashProvider.GetHashAndSaltString(password, out passHash, out passSalt);

            admin.PasswordHash = passHash;
            admin.PasswordSalt = passSalt;

            try
            {
                AdminRepository.Update(admin);

                result.Object = new ForgotPassword
                {
                    Id = admin.Id,
                    Email = admin.Email,
                    Name = admin.Name,
                    Password = password,
                    Surname = admin.Surname
                };

                result.Success = true;
                result.Message = Localization.Common.OperationSuccess;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ResultSet ForgotPasswordSendMail(string html, ForgotPassword admin)
        {
            ResultSet result = new ResultSet();

            //var mail = new MailMessage
            //{
            //    IsBodyHtml = true,
            //    Subject = _localizationBusiness.GetResource("NP.UI.Admin.Account.ForgotPassword.Subject"),
            //    From = new MailAddress("console@dogangazetecilik.com.tr", "Console App"),
            //    Body = html
            //};

            //mail.To.Add(admin.Email);

            //try
            //{

            //    //var sendMail = new SendMail();
            //    //sendMail.SendMailFromWebService(mail,
            //    //    _applicationBusiness.GetApplicationConfigValueBy("EuroMsgAuthUser"),
            //    //    _applicationBusiness.GetApplicationConfigValueBy("EuroMsgAuthPass"),
            //    //    _applicationBusiness.GetApplicationConfigValueBy("EuroMsgFromAddress"),
            //    //    _applicationBusiness.GetApplicationConfigValueBy("EuroMsgReplyAddress"),
            //    //    _applicationBusiness.GetApplicationConfigValueBy("EuroMsgFromName"));
            //    result.Success = true;

            //}
            //catch (Exception ex)
            //{
            //    result.Message = ex.Message;
            //}

            return result;
        }

        public ResultSet VerifyAdmin(string email, string password)
        {
            var result = new ResultSet<AccountInfo>();
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                result.Success = false;
                result.Message = Localization.Account.LoginRequired;
                return result;
            }

            var checkAdmin = AdminRepository.GetAdminByEmail(email);
            if (checkAdmin == null)
            {
                result.Success = false;
                result.Message = Localization.Account.PasswordDoesNotMatch;
                return result;
            }


            var isAuthenticated = HashProvider.VerifyHashString(password, checkAdmin.PasswordHash, checkAdmin.PasswordSalt);

            if (!isAuthenticated)
            {
                result.Success = false;
                result.Message = Localization.Account.PasswordDoesNotMatch;
                return result;
            }

            result = SetData(checkAdmin);
            return result;
        }

        public void LogoutAdmin()
        {
            if (ContextUserProviderBase.ContextBase.Session != null)
            {
                ContextUserProviderBase.CurrentSession.Abandon();
                ContextUserProviderBase.CurrentSession.RemoveAll();
                ContextUserProviderBase.CurrentSession.Clear();
                ContextUserProviderBase.ContextBase.Request.Cookies.Remove(Keys.Cookie.UserName);

                var cookieUserName = new HttpCookie(Keys.Cookie.UserName)
                {
                    Value = string.Empty,
                    Expires = DateTime.Now.AddDays(-1)
                };
                ContextUserProviderBase.ContextBase.Response.Cookies.Add(cookieUserName);
            }
            if (ContextUserProviderBase.IsAccountLogin)
            {
                ContextUserProviderBase.Account = null;
            }
        }

        public ResultSet<My> GetMyById(int id)
        {
            var result = new ResultSet<My>();

            var admin = AdminRepository.GetAdminById(id);
            if (admin != null)
            {
                result.Success = true;
                result.Object = new My
                {
                    PersonalInfo = new Info
                    {
                        Name = admin.Name,
                        Surname = admin.Surname,
                        Email = admin.Email,
                    },

                    Password = new Password()
                };
            }

            return result;
        }

        public ResultSet Update(Info obj)
        {
            var result = new ResultSet();

            var admin = AdminRepository.GetAdminById(obj.Id);
            if (admin == null)
            {
                result.Message = Localization.Account.NotFound;
                return result;
            }

            if (admin.StatusId != (int)AdminStatus.Active)
            {
                result.Success = false;
                result.Message = Localization.Common.OperationFailed;
                return result;
            }

            if (!admin.Email.Equals(obj.Email))
            {
                var checkEmail = AdminRepository.GetAdminByEmail(obj.Email);
                if (checkEmail != null && checkEmail.Id != admin.Id) // E-posta değişecekse, Yeni e-posta adresinin baka bir kullanıcıda kullanılmadığının kontrolü 
                {
                    result.Message = Localization.Account.EmailExists;
                    return result;
                }
            }

            admin.Name = obj.Name;
            admin.Surname = obj.Surname;
            admin.Email = obj.Email;

            try
            {
                AdminRepository.Update(admin);
                result.Success = true;
                result.Message = Localization.Common.OperationSuccess;

                ContextUserProviderBase.Account.FullName = string.Format("{0} {1}",admin.Name, admin.Surname);
                ContextUserProviderBase.Account.Email = admin.Email;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public ResultSet PasswordChange(Password pass)
        {
            var result = new ResultSet();

            var admin = AdminRepository.GetAdminById(pass.Id);

            if (admin == null)
            {
                result.Success = false;
                result.Message = Localization.Account.NotFound;
                return result;
            }

            // is Active
            if (admin.StatusId != (int)AdminStatus.Active)
            {
                result.Success = false;
                result.Message = Localization.Common.OperationFailed;
                return result;
            }

            // Current password verify
            if (!HashProvider.VerifyHashString(pass.CurrentPassword, admin.PasswordHash, admin.PasswordSalt))
            {
                result.Success = false;
                result.Message = Localization.Account.PasswordInvalid;

                return result;
            }

            // password confirm
            if (pass.NewPassword != pass.NewPasswordConfirm)
            {
                result.Success = false;
                result.Message = Localization.Account.PasswordDoesNotMatch_;
                return result;
            }

            string passHash, passSalt;
            var password = pass.NewPassword;
            HashProvider.GetHashAndSaltString(password, out passHash, out passSalt);


            // old password check
            if (passHash == admin.PasswordHash)
            {
                result.Success = false;
                result.Message = Localization.Account.PasswordSameOld;
                return result;
            }

            admin.PasswordSalt = passSalt;
            admin.PasswordHash = passHash;

            try
            {
                AdminRepository.Update(admin);
                result.Success = true;
                result.Message = Localization.Common.OperationSuccess;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        #region Private Methods
        private ResultSet<AccountInfo> SetData(Admin admin)
        {
            var result = new ResultSet<AccountInfo>();
            if (admin == null)
                return result;

            var userStatus = (AdminStatus)admin.StatusId;

            switch (userStatus)
            {
                case AdminStatus.Active:
                    var accountUser = new AccountInfo
                    {
                        LoginStatus = true,
                        Message = "",
                        Id = admin.Id,
                        FullName = $"{admin.Name} {admin.Surname}",
                        Email = admin.Email,
                        Status = userStatus,
                        Rights = AdminRepository.GetAdminPermissionsById(admin.Id).Select(o => o.Key).ToList()
                    };
                    result.Success = true;
                    result.Message = Localization.Common.OperationSuccess;
                    result.Object = accountUser;
                    ContextUserProviderBase.Account = accountUser;

                    break;
            }
            return result;
        }
        #endregion
    }
}