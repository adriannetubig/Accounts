using AccountsFunction;
using AccountsModel;
using AccountsWebAuthentication.Helper;
using System.Web.Mvc;

namespace AccountsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AccountAdministrator" })]
    public class UserController : BaseController
    {
        private IFUser _iFUser;
        private IFUserRole _iFUserRole;
        public UserController(IFUser iFUser, IFUserRole iFUserRole)
        {
            _iFUser = iFUser;
            _iFUserRole = iFUserRole;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            var createdUser = _iFUser.Create(UserId, user);
            _iFUserRole.Create(UserId, createdUser.UserId, user.UserRoles);
            return RedirectToAction("Index");
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFUser.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFUser.Read(id));
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            var createdUser = _iFUser.Update(UserId, user);
            _iFUserRole.Create(UserId, createdUser.UserId, user.UserRoles);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFUser.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}