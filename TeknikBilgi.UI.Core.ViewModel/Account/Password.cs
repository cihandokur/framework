using System.ComponentModel.DataAnnotations;

namespace TeknikBilgi.UI.Core.ViewModel.Account
{
    public class Password
    {
        public int Id { get; set; }

        [DataType(DataType.Password), MinLength(5), MaxLength(10)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), MinLength(5), MaxLength(10)]
        public string NewPasswordConfirm { get; set; }

        [DataType(DataType.Password), MinLength(5), MaxLength(10)]
        public string CurrentPassword { get; set; }
    }
}
