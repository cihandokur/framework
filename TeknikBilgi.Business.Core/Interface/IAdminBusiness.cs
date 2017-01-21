using TeknikBilgi.Business.Core.ServiceResult;
using TeknikBilgi.UI.Core.ViewModel.Account;

namespace TeknikBilgi.Business.Core.Interface
{
    public interface IAdminBusiness
    {
        /// <summary>
        /// VerifyAdmin -> Admin'i kontrol eder sistemi kullanıp kullanamayacağına karar verir.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ResultSet VerifyAdmin(string username, string password);

        /// <summary>
        /// Şifre unutma işlemlerinde kullanılır.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        ResultSet<ForgotPassword> ForgotPassword(string email);

        /// <summary>
        /// Şifre unuttumdaki sıfırlama e-postasını gönderir.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        ResultSet ForgotPasswordSendMail(string html, ForgotPassword admin);

        void LogoutAdmin();
        ResultSet<My> GetMyById(int id);

        ResultSet Update(Info obj);

        ResultSet PasswordChange(Password pass);
    }
}