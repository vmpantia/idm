using IDM.Business.Contractors;
using IDM.Web_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IDM.Web_MVC.Controllers
{
    public class SecurityGroupController : Controller
    {
        private readonly ISecurityGroupService _sg;
        public SecurityGroupController(ISecurityGroupService sg)
        {
            _sg = sg;
        }

        public async Task<IActionResult> SGList()
        {
            var result = await _sg.GetSGsAsync();

            var model = new SecurityGroupViewModel
            {
                sgList = result.ToList(),
            };

            return View(model);
        }

        public IActionResult EditSG()
        {
            var model = new SecurityGroupViewModel();
            return View(model);
        }
    }
}
