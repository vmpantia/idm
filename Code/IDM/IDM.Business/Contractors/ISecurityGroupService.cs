using IDM.Business.Models.DTOs;
using IDM.Business.Models.Request;

namespace IDM.Business.Contractors
{
    public interface ISecurityGroupService
    {
        Task<SecurityGroupDTO> GetSGByIDAsync(Guid internalID);
        Task<IEnumerable<SecurityGroupDTO>> GetSGsAsync();
        Task<IEnumerable<SecurityGroupDTO>> GetSGsByStatusAsync(int status);
        Task SaveSGAsync(SaveSecurityGroupRequest request);
    }
}