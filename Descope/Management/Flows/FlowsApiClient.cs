using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Flows
{
    internal class FlowsApiClient(IDescopeManagementHttpClient httpClient) : IFlowsApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<IEnumerable<DescopeFlowMetadata>> GetAll(params string[] ids)
        {
            var request = new DescopeFlowSearchRequest
            {
                Ids = ids
            };

            var response = await _httpClient.PostAsync<DescopeFlowSearchRequest, DescopeFlowListResponse>(Endpoints.Management.LoadAllFlows, request);
            return response.Flows;
        }

        public async Task<DescopeFlow> Export(string flowId)
        {
            var request = new DescopeFlowExportRequest
            {
                FlowId = flowId
            };

            return await _httpClient.PostAsync<DescopeFlowExportRequest, DescopeFlow>(Endpoints.Management.ExportFlow, request);
        }

        public async Task<DescopeFlow> Import(DescopeFlow flow)
        {
            var request = new DescopeFlowImportRequest
            {
                FlowId = flow.Flow.Id,
                Flow = flow.Flow,
                Screens = flow.Screens
            };

            return await _httpClient.PostAsync<DescopeFlowImportRequest, DescopeFlow>(Endpoints.Management.ImportFlow, request);
        }
    }
}
