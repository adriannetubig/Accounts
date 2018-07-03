using AccountsModel;
using System.Collections.Generic;

namespace AccountsFunction
{
    public interface IFRole
    {
        #region Create
        Role Create(int createdBy, Role role);
        #endregion

        #region Read
        Role Read(int roleId);
        List<Role> Read(string sortBy);
        List<Role> Read(int userId, string sortBy);
        List<Role> Read();

        #endregion

        #region Update
        Role Update(int updatedBy, Role role);
        #endregion

        #region Delete
        void Delete(int roleId);
        #endregion

        #region Other Function

        #endregion
    }
}
