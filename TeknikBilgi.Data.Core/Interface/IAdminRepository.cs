using System.Collections.Generic;
using TeknikBilgi.Data.Core.Entity.Admin;

namespace TeknikBilgi.Data.Core.Interface
{
    public interface IAdminRepository
    {
        List<Permission> GetAdminPermissionsById(int id);
        Admin GetAdminByEmail(string email);
        Admin GetAdminById(int id);
        bool Update(Admin obj);
    }
}