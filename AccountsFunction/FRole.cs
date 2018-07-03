using AccountsData;
using AccountsEntity;
using AccountsModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsFunction
{
    public class FRole : IFRole
    {
        private IDRole _iDRole;

        public FRole(IDRole iDRoles)
        {
            _iDRole = iDRoles;
        }

        public FRole()
        {
            _iDRole = new DRole();

        }
        #region Create
        public Role Create(int createdBy, Role role)
        {
            var eRole = ERole(role);
            eRole.CreatedDate = DateTime.Now;
            eRole.CreatedBy = createdBy;
            eRole = _iDRole.Insert(eRole);
            return Role(eRole);
        }
        #endregion

        #region Read
        public Role Read(int roleId)
        {
            var eRole = _iDRole.Read<ERole>(a => a.RoleId == roleId);
            return Role(eRole);
        }
        public List<Role> Read(string sortBy)
        {
            var eRoles = _iDRole.Read<ERole>(a => true, sortBy);
            return Roles(eRoles);
        }
        public List<Role> Read(int userId, string sortBy)
        {
            var eRoles = _iDRole.Read<ERole>(a => a.UserRoles.Any(b => b.User.UserId == userId), sortBy);
            return Roles(eRoles);
        }
        public List<Role> Read()
        {
            var eRole = _iDRole.Read();
            return Roles(eRole);
        }
        #endregion

        #region Update
        public Role Update(int updatedBy, Role role)
        {
            var eRole = ERole(role);
            eRole.UpdatedDate = DateTime.Now;
            eRole.UpdatedBy = updatedBy;
            eRole = _iDRole.Update(eRole);
            return Role(eRole);
        }
        #endregion

        #region Delete
        public void Delete(int roleId)
        {
            _iDRole.Delete<ERole>(a => a.RoleId == roleId);
        }
        #endregion

        #region Other Function
        private ERole ERole(Role role)
        {
            return new ERole
            {
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate,

                CreatedBy = role.CreatedBy,
                UpdatedBy = role.UpdatedBy,
                RoleId = role.RoleId,
                Name = role.Name,
                Description = role.Description
            };
        }

        private Role Role(ERole eRole)
        {
            return new Role
            {
                CreatedDate = eRole.CreatedDate,
                UpdatedDate = eRole.UpdatedDate,

                CreatedBy = eRole.CreatedBy,
                UpdatedBy = eRole.UpdatedBy,
                RoleId = eRole.RoleId,
                Name = eRole.Name,
                Description = eRole.Description
            };
        }
        private List<Role> Roles(List<ERole> eRoles)
        {
            return eRoles.Select(a => new Role
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                RoleId = a.RoleId,
                UpdatedBy = a.UpdatedBy,

                Name = a.Name,
                Description = a.Description
            }).ToList();
        }
        #endregion

    }
}
