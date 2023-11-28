using System.Text.Json;
using Descope.Models;

namespace Descope.Test.Management.Audit
{
    [Collection("ClientServer")]
    public class AuditApiClientTests(AuditApiClientFixture fixture) : IClassFixture<AuditApiClientFixture>
    {
        private readonly AuditApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldSearchAudit()
        {
            var audits = await _fixture.Audit.Search(new DescopeAuditSearchRequest
            {
                From = 12345,
                To = 99999,
                UserIds =
                [
                    "TEST"
                ]
            });
            Assert.NotNull(audits);
            Assert.Single(audits);

            string dataInner = ((JsonElement)audits.ElementAt(0).Data).GetProperty("Inner").GetString();

            Assert.Equal("AID", audits.ElementAt(0).Id);
            Assert.Equal("PTEST", audits.ElementAt(0).ProjectId);
            Assert.Equal("UTEST", audits.ElementAt(0).UserId);
            Assert.Equal("Action", audits.ElementAt(0).Action);
            Assert.Equal(34567, audits.ElementAt(0).Occurred);
            Assert.Equal("Desktop", audits.ElementAt(0).Device);
            Assert.Equal("Delete", audits.ElementAt(0).Method);
            Assert.Equal("USA", audits.ElementAt(0).Geo);
            Assert.Equal("0.0.0.0", audits.ElementAt(0).RemoteAddress);
            Assert.Single(audits.ElementAt(0).ExternalIds);
            Assert.Equal("ExTEST", audits.ElementAt(0).ExternalIds[0]);
            Assert.Single(audits.ElementAt(0).Tenants);
            Assert.Equal("TEST", audits.ElementAt(0).Tenants[0]);
            Assert.Equal("Inner", dataInner);
            Assert.Equal("Info", audits.ElementAt(0).Type);
        }

        [Fact]
        public async Task ShouldNotSearchAudit()
        {
            var audits = await _fixture.Audit.Search(new DescopeAuditSearchRequest
            {
                From = 12345,
                To = 99999,
                UserIds =
                [
                    "TESTBAD"
                ]
            });

            Assert.NotNull(audits);
            Assert.Empty(audits);
        }
    }
}
