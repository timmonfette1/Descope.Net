using Descope.Management.Audit;

namespace Descope.Test.Management.Audit
{
    public class AuditApiClientFixture(ClientServerFixture fixture)
    {
        private readonly AuditApiClient _auditApiClient = new(fixture.HttpClient);

        internal AuditApiClient Audit => _auditApiClient;
    }
}
