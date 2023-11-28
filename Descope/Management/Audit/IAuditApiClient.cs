using Descope.Models;

namespace Descope.Management.Audit
{
    public interface IAuditApiClient
    {
        Task<IEnumerable<DescopeAudit>> Search(DescopeAuditSearchRequest request);
    }
}
