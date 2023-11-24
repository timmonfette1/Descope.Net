using Descope.Management.Flows;

namespace Descope.Test.Management.Flows
{
    public class FlowsApiClientFixture
    {
        private readonly FlowsApiClient _flowsApiClient;

        public FlowsApiClientFixture(ClientServerFixture fixture)
        {
            _flowsApiClient = new FlowsApiClient(fixture.HttpClient);
        }

        internal FlowsApiClient FlowsApiClient => _flowsApiClient;
    }
}
