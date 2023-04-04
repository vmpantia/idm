using IDM.Business.Contractors;
using IDM.Business.Models.DTOs;
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

        public async Task<IActionResult> Index()
        {
            var result = await _sg.GetSGsAsync();

            var model = new SecurityGroupViewModel
            {
                sgList = result.ToList(),
            };

            return View(model);
        }

        public async Task<IActionResult> CreateSG()
        {
            var model = new SecurityGroupViewModel()
            {
                sgInfo = new SecurityGroupDTO()
            };
            return View(model);
        }

        public async Task<IActionResult> EditSG(Guid internalID)
        {
            var model = new SecurityGroupViewModel()
            {
                sgInfo = await _sg.GetSGByIDAsync(internalID),
            };
            return View(model);
        }
    }
}
