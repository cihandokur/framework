using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DapperExtensions;
using TeknikBilgi.Data.Core.Dapper;
using TeknikBilgi.Data.Core.Entity.Admin;
using TeknikBilgi.Data.Core.Interface;

namespace TeknikBilgi.Data.Core.Implement
{
    public class AdminRepository : IAdminRepository
    {
        public IDbConnection Connection;
        public AdminRepository(IDbConnection connection)
        {
            Connection = connection;
        }
        public List<Permission> GetAdminPermissionsById(int id)
        {
            return Connection.Query<Permission>("GetAdminPermissionsInfoById", new
            {
                AdminId = id
            }, commandType: CommandType.StoredProcedure).ToList();
        }

        public Admin GetAdminByEmail(string email)
        {
            return Connection.FirstOrDefault<Admin>(a => a.Email, email);
        }

        public Admin GetAdminById(int id)
        {
            return Connection.FirstOrDefault<Admin>(a => a.Id, id);
        }

        public bool Update(Admin obj)
        {
            return Connection.Update<Admin>(obj);
        }
    }
}
