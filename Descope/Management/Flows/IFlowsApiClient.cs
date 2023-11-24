using Descope.Models;

namespace Descope.Management.Flows
{
    public interface IFlowsApiClient
    {
        Task<DescopeFlowListResponse> GetAll(params string[] ids);
        Task<DescopeFlow> Export(string flowId);
        Task<DescopeFlow> Import(DescopeFlow flow);
    }
}
