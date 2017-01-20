using System;
using System.Collections.Generic;
using System.Linq;
using TeknikBilgi.Infrastructure.Constraints.Enums.Status;
using TeknikBilgi.Infrastructure.Constraints.Structs;

namespace TeknikBilgi.Infrastructure.WebContext
{
    [Serializable]
    public class AccountInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool LoginStatus { get; set; }
        public string Message { get; set; }
        public List<string> Rights { get; set; }

        public AdminStatus Status { get; set; }

        /// <summary>
        /// Determines the current user has right for selected object name(key).
        /// </summary>
        /// <param name="objectName">Object key name that need to be validated to has right.</param>
        /// <returns>Returns true if user has right for selected object, otherwise false.</returns>
        public bool HasPermissionFor(string objectName)
        {
            if (string.IsNullOrWhiteSpace(objectName))
                return false;

            if (objectName.Equals(Keys.Security.CommonScreens))
                return true;

            return !string.IsNullOrWhiteSpace(Rights.FirstOrDefault(r => r.Equals(objectName)));
        }
    }
}