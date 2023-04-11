using IDM.Business.Contractors;
using IDM.Business.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace IDM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityGroupController : ControllerBase
    {
        private readonly ISecurityGroupService _sg;
        public SecurityGroupController(ISecurityGroupService sg)
        {
            _sg = sg;
        }

        [HttpGet("GetSGs")]
        public async Task<IActionResult> GetSGsAsync()
        {
            try
            {
                var result = await _sg.GetSGsAsync();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("GetSGsByStatus")]
        public async Task<IActionResult> GetSGsByStatusAsync(int status)
        {
            try
            {
                var result = await _sg.GetSGsByStatusAsync(status);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("GetSGByID")]
        public async Task<IActionResult> GetSGByIDAsync(Guid internalID)
        {
            try
            {
                var result = await _sg.GetSGByIDAsync(internalID);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("SaveSG")]
        public async Task<IActionResult> SaveSGAsync(SaveSecurityGroupRequest request)
        {
            try
            {
                await _sg.SaveSGAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}