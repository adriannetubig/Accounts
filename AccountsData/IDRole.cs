using AccountsEntity;
using BaseData;
using System.Collections.Generic;

namespace AccountsData
{
    public interface IDRole : IDBase
    {
        #region Read
        List<ERole> Read();
        #endregion
    }
}
