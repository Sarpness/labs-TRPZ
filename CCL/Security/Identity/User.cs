using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class User
    {
        public User(int userId, string name, int cityID, string userType)
        {
            UserId = userId;
            Name = name;
            CityID = cityID;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int CityID { get; }
        protected string UserType { get; }
    }
}
