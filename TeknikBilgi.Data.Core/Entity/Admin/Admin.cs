using System;

namespace TeknikBilgi.Data.Core.Entity.Admin
{
    public class Admin
    {
        public int Id { get; set; }
        public int ParentAdminId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
