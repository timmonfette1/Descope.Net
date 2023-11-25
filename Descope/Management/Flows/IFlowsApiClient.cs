using Descope.Models;

namespace Descope.Management.Flows
{
    public interface IFlowsApiClient
    {
        Task<IEnumerable<DescopeFlowMetadata>> GetAll(params string[] ids);
        Task<DescopeFlow> Export(string flowId);
        Task<DescopeFlow> Import(DescopeFlow flow);
    }
}
