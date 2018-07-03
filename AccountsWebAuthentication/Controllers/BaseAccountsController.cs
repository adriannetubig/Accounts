using System.Web.Mvc;
using AccountsFunction;
using AccountsModel;
using AccountsWebAuthentication.Helper;
using AndersonCRMFunction;
using AndersonCRMModel;

namespace AccountsWebAuthentication.Controllers
{
    public class BaseAccountsController : Controller
    {
        private IFUser _iFUser;
        private IFEmployee _iFEmployee;

        public BaseAccountsController()
        {
            _iFUser = new FUser();
            _iFEmployee = new FEmployee();
        }

        protected string Username
        {
            get
            {
                return WindowsUser.Username;
            }
        }
        protected int UserId
        {
            get
            {
                var user = _iFUser.Read(Username);
                int UserID = user?.UserId ?? 0;
                return UserID;
            }
        }
        protected int EmployeeId
        {
            get
            {
                int employeeId = CurrentUser?.EmployeeId ?? 0;
                return employeeId;
            }
        }

        protected User CurrentUser
        {
            get
            {
                var user = _iFUser.Read(Username);
                return user;
            }
        }

        protected int ManagerEmployeeId
        {
            get
            {
                int employeeId = CurrentEmployee?.ManagerEmployeeId ?? 0;
                return employeeId;
            }
        }

        protected Employee CurrentEmployee
        {
            get
            {
                var employee = _iFEmployee.Read(EmployeeId);
                return employee;
            }
        }
    }
}