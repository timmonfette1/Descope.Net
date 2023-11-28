using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Audit
{
    internal class AuditApiClient(IDescopeManagementHttpClient httpClient) : IAuditApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<IEnumerable<DescopeAudit>> Search(DescopeAuditSearchRequest request)
        {
            var response = await _httpClient.PostAsync<DescopeAuditSearchRequest, DescopeAuditListResponse>(Endpoints.Management.SearchAudit, request);
            return response.Audits;
        }
    }
}
