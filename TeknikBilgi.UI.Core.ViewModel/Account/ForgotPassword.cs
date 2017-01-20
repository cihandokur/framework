namespace TeknikBilgi.UI.Core.ViewModel.Account
{
    public class ForgotPassword
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string ResetKey { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}