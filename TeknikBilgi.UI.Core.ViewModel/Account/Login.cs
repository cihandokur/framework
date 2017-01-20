using System.ComponentModel.DataAnnotations;

namespace TeknikBilgi.UI.Core.ViewModel.Account
{
    public class Login
    {
        //[DataType(DataType.EmailAddress), MinLength(1), Display(ResourceType = typeof(Localization.Common), Name ="Email")]
        public string Email { get; set; }

        //[DataType(DataType.Password), MinLength(5), MaxLength(10), Display(ResourceType = typeof(Localization.Account), Name = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }   
    }
}
