using AccountsFunction;
using AccountsModel;
using AccountsWebAuthentication.Helper;
using System.Web.Mvc;

namespace AccountsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AccountAdministrator"})]
    public class RoleController : BaseController
    {
        private IFRole _iFRole;
        public RoleController(IFRole iFRole)
        {
            _iFRole = iFRole;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()    
        {
            return View(new Role());
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            var createdRole = _iFRole.Create(UserId, role);
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
            return Json(_iFRole.Read("Name"));
        }
        [HttpPost]
        public JsonResult ReadAssignedRole(int id)
        {
            return Json(_iFRole.Read(id, "Name"));
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFRole.Read(id));
        }
        [HttpPost]
        public ActionResult Update(Role role)
        {
            var createdRole = _iFRole.Update(UserId, role);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFRole.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}