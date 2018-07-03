using AccountsWebAuthentication.Helper;
using AndersonCRMFunction;
using System.Web.Mvc;

namespace AccountsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AccountAdministrator" })]
    public class EmployeeController : BaseController
    {
        private IFEmployee _iFEmployee;
        public EmployeeController(IFEmployee iFEmployee)
        {
            _iFEmployee = iFEmployee;
        }

        #region Create
        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFEmployee.Read());
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}