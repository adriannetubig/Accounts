using AccountsContext;
using AccountsEntity;
using BaseData;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace AccountsData
{
    public class DRole : DBase, IDRole
    {
        public DRole() : base(new Context())
        {
        }

        #region Create
        #endregion

        #region Read 
        public List<ERole> Read()
        {
            using (var context = new Context())
            {
                return context.Roles
                    .Include(a => a.UserRoles)
                    .Include(a => a.UserRoles.Select(b => b.Role))
                    .OrderBy(a => a.Name)
                    .ToList();
            }
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region Other Function
        #endregion

    }
}
