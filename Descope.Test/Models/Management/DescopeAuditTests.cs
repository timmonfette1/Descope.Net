using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeAuditTests
    {
        [Fact]
        public void ShouldCreateObject_Request()
        {
            var request = new DescopeAuditSearchRequest
            {
                From = 12345,
                To = 99999,
                UserIds =
               [
                   "UTEST"
               ],
                Actions =
               [
                   "Action"
               ],
                Devices =
               [
                   "Desktop"
               ],
                Methods =
               [
                   "Delete"
               ],
                Geos =
               [
                   "USA"
               ],
                RemoteAddresses =
               [
                   "0.0.0.0"
               ],
                ExternalIds =
               [
                   "ExTEST"
               ],
                Tenants =
               [
                   "TEST"
               ],
                NoTenants = false,
                Text = "Text",
                ExcludedActions =
               [
                   "ExcludedAction"
               ]
            };

            Assert.NotNull(request);
            Assert.Equal(12345, request.From);
            Assert.Equal(99999, request.To);
            Assert.Single(request.UserIds);
            Assert.Equal("UTEST", request.UserIds[0]);
            Assert.Single(request.Actions);
            Assert.Equal("Action", request.Actions[0]);
            Assert.Single(request.Devices);
            Assert.Equal("Desktop", request.Devices[0]);
            Assert.Single(request.Methods);
            Assert.Equal("Delete", request.Methods[0]);
            Assert.Single(request.Geos);
            Assert.Equal("USA", request.Geos[0]);
            Assert.Single(request.RemoteAddresses);
            Assert.Equal("0.0.0.0", request.RemoteAddresses[0]);
            Assert.Single(request.ExternalIds);
            Assert.Equal("ExTEST", request.ExternalIds[0]);
            Assert.Single(request.Tenants);
            Assert.Equal("TEST", request.Tenants[0]);
            Assert.False(request.NoTenants);
            Assert.Equal("Text", request.Text);
            Assert.Single(request.ExcludedActions);
            Assert.Equal("ExcludedAction", request.ExcludedActions[0]);
        }

        [Fact]
        public void ShouldCreateObject_Resposne()
        {
            var response = new DescopeAuditListResponse
            {
                Audits =
                [
                    new()
                    {
                        Id = "AID",
                        ProjectId = "PTEST",
                        UserId = "UTEST",
                        Action = "Action",
                        Occurred = 34567,
                        Device = "Desktop",
                        Method = "Delete",
                        Geo = "USA",
                        RemoteAddress = "0.0.0.0",
                        ExternalIds =
                        [
                            "ExTEST"
                        ],
                        Tenants =
                        [
                            "TEST"
                        ],
                        Data = new
                        {
                            Inner = "Inner"
                        },
                        Type = "Info",
                    }
                ]
            };

            Assert.NotNull(response);
            Assert.Single(response.Audits);

            string dataInner = response.Audits.ElementAt(0).Data.GetType().GetProperty("Inner")?.GetValue(response.Audits.ElementAt(0).Data, null)?.ToString();

            Assert.Equal("AID", response.Audits.ElementAt(0).Id);
            Assert.Equal("PTEST", response.Audits.ElementAt(0).ProjectId);
            Assert.Equal("UTEST", response.Audits.ElementAt(0).UserId);
            Assert.Equal("Action", response.Audits.ElementAt(0).Action);
            Assert.Equal(34567, response.Audits.ElementAt(0).Occurred);
            Assert.Equal("Desktop", response.Audits.ElementAt(0).Device);
            Assert.Equal("Delete", response.Audits.ElementAt(0).Method);
            Assert.Equal("USA", response.Audits.ElementAt(0).Geo);
            Assert.Equal("0.0.0.0", response.Audits.ElementAt(0).RemoteAddress);
            Assert.Single(response.Audits.ElementAt(0).ExternalIds);
            Assert.Equal("ExTEST", response.Audits.ElementAt(0).ExternalIds[0]);
            Assert.Single(response.Audits.ElementAt(0).Tenants);
            Assert.Equal("TEST", response.Audits.ElementAt(0).Tenants[0]);
            Assert.Equal("Inner", dataInner);
            Assert.Equal("Info", response.Audits.ElementAt(0).Type);
        }
    }
}
