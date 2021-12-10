using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Boss
        : User
    {
        public Boss(int userId, string name, int cityID)
            : base(userId, name, cityID, nameof(Boss))
        {
        }
    }
}
