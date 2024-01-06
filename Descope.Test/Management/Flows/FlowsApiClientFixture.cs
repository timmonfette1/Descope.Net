using Descope.Management.Flows;

namespace Descope.Test.Management.Flows
{
    public class FlowsApiClientFixture(ClientServerFixture fixture)
    {
        private readonly FlowsApiClient _flowsApiClient = new(fixture.ManagementHttpClient);

        internal FlowsApiClient FlowsApiClient => _flowsApiClient;
    }
}
