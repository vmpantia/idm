using IDM.Api.Models;
using IDM.Api.Models.Request;

namespace IDM.Api.Contractors
{
    public interface ISecurityGroupService
    {
        Task<SecurityGroupDTO> GetSGByIDAsync(Guid internalID);
        Task<IEnumerable<SecurityGroupDTO>> GetSGsAsync();
        Task<IEnumerable<SecurityGroupDTO>> GetSGsByStatusAsync(int status);
        Task SaveSGAsync(SaveSecurityGroupRequest request);
    }
}