using System.ComponentModel.DataAnnotations;

namespace TeknikBilgi.UI.Core.ViewModel.Account
{
    public class Info
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }


        [DataType(DataType.EmailAddress), MinLength(1)]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
