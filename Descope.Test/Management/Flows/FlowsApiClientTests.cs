using System.Text.Json;
using Descope.Models;

namespace Descope.Test.Management.Flows
{
    [Collection("ClientServer")]
    public class FlowsApiClientTests(FlowsApiClientFixture fixture) : IClassFixture<FlowsApiClientFixture>
    {
        private readonly FlowsApiClientFixture _fixture = fixture;

        [Fact]
        public async Task ShouldListFlows()
        {
            var flows = await _fixture.FlowsApiClient.GetAll();

            Assert.NotNull(flows);
            Assert.Single(flows.Flows);
            Assert.Equal(1, flows.Total);
            FlowMetadataAssertations(flows.Flows[0]);
        }

        [Fact]
        public async Task ShouldListFlowsById()
        {
            var flows = await _fixture.FlowsApiClient.GetAll("TEST");

            Assert.NotNull(flows);
            Assert.Single(flows.Flows);
            Assert.Equal(1, flows.Total);
            FlowMetadataAssertations(flows.Flows[0]);
        }

        [Fact]
        public async Task ShouldNotListFlows()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.FlowsApiClient.GetAll("TESTBAD"));

            Assert.NotNull(exception);
            Assert.Equal("E103009", exception.ErrorCode);
            Assert.Equal("Failed Finding any flows", exception.ErrorDescription);
        }

        [Fact]
        public async Task ShouldExportFlow()
        {
            var flow = await _fixture.FlowsApiClient.Export("TEST");

            Assert.NotNull(flow);
            Assert.NotNull(flow.Flow);
            Assert.Single(flow.Screens);
            FlowMetadataAssertations(flow.Flow);
            ScreenAssertations(flow.Screens[0]);
        }

        [Fact]
        public async Task ShouldNotExportFlow()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.FlowsApiClient.Export("TESTBAD"));

            Assert.NotNull(exception);
            Assert.Equal("E103003", exception.ErrorCode);
            Assert.Equal("Failed getting flow", exception.ErrorDescription);
            Assert.Equal("Failed loading flow by ID", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldImportFlow()
        {
            var flow = await _fixture.FlowsApiClient.Import(new DescopeFlow
            {
                Flow = new DescopeFlowMetadata
                {
                    Id = "TEST"
                },
                Screens = []
            });

            Assert.NotNull(flow);
            Assert.NotNull(flow.Flow);
            Assert.Single(flow.Screens);
            FlowMetadataAssertations(flow.Flow, 2);
            ScreenAssertations(flow.Screens[0]);
        }

        #region Private Methods

        private static void FlowMetadataAssertations(DescopeFlowMetadata flow, int version = 1)
        {
            string dslInner = ((JsonElement)flow.Dsl).GetProperty("Inner").GetString();

            Assert.Equal("TEST", flow.Id);
            Assert.Equal(version, flow.Version);
            Assert.Equal("Test", flow.Name);
            Assert.Equal("Testing", flow.Description);
            Assert.Equal("Inner", dslInner);
            Assert.Equal(12345, flow.ModifiedTime);
            Assert.Equal("Tagged", flow.ETag);
            Assert.False(flow.Disabled);
            Assert.True(flow.Translate);
            Assert.Equal("TID", flow.TranslateConnectorId);
            Assert.Equal("ENG", flow.TranslateSourceLang);
            Assert.Single(flow.TranslateTargetLangs);
            Assert.Equal("JP", flow.TranslateTargetLangs[0]);
            Assert.True(flow.Fingerprint);
        }

        private static void ScreenAssertations(DescopeScreen screen)
        {
            string htmlTemplateInner = ((JsonElement)screen.HtmlTemplate).GetProperty("Inner").GetString();

            Assert.Equal("TEST", screen.Id);
            Assert.Equal(1, screen.Version);
            Assert.Equal("FTEST", screen.FlowId);
            Assert.Single(screen.Inputs);
            Assert.Equal("TEST", screen.Inputs[0].Type);
            Assert.Equal("Tester", screen.Inputs[0].Name);
            Assert.False(screen.Inputs[0].Required);
            Assert.True(screen.Inputs[0].Visible);
            Assert.Equal("Testing", screen.Inputs[0].DisplayName);
            Assert.Equal("Test", screen.Inputs[0].DisplayType);
            Assert.Single(screen.Inputs[0].DependsOn);
            Assert.Equal("Dependency", screen.Inputs[0].DependsOn[0]);
            Assert.Null(screen.Inputs[0].NameValueMap);
            Assert.True(screen.Inputs[0].ContextAware);
            Assert.Single(screen.Inputs[0].Options);
            Assert.Equal("Label", screen.Inputs[0].Options[0].Label);
            Assert.Equal("Value", screen.Inputs[0].Options[0].Value);
            Assert.Single(screen.Interactions);
            Assert.Equal("TEST", screen.Interactions[0].Id);
            Assert.Equal("Tester", screen.Interactions[0].Type);
            Assert.Equal("Testing", screen.Interactions[0].Label);
            Assert.Equal("Smile", screen.Interactions[0].Icon);
            Assert.Equal("Tester Jr.", screen.Interactions[0].SubType);
            Assert.Equal("Inner", htmlTemplateInner);
            Assert.Equal("1.0.0", screen.ComponentsVersion);
        }

        #endregion Private Methods
    }
}
