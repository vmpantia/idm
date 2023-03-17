using IDM.Web.Data;
using IDM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using static IDM.Web.Models.GroupViewModel;

namespace IDM.Web.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult GetInternalSGList()
        {
            var view = new GroupViewModel();
            view.groupList = Stub.groupList;
            return View(view);
        }

        public IActionResult EditInternalSG(Guid internalID)
        {
            var view = new GroupViewModel();
            return View(view);
        }
    }
}
