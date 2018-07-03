using BaseModel;
using System.Collections.Generic;

namespace AccountsModel
{
    public class Role: Base
    {
        public int RoleId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
