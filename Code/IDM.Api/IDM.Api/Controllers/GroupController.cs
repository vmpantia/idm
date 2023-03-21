using IDM.Api.Contractors;
using Microsoft.AspNetCore.Mvc;

namespace IDM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly ISecurityGroupService _sg;
        public GroupController(ISecurityGroupService sg)
        {
            _sg = sg;
        }

        [HttpGet("GetSGs")]
        public async Task<IActionResult> GetSGsAsync()
        {
            try
            {
                var result = await _sg.GetSGsAsync();
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
