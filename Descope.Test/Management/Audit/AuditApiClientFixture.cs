using Descope.Management.Audit;

namespace Descope.Test.Management.Audit
{
    public class AuditApiClientFixture(ClientServerFixture fixture)
    {
        private readonly AuditApiClient _auditApiClient = new(fixture.ManagementHttpClient);

        internal AuditApiClient Audit => _auditApiClient;
    }
}
