using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeFlowTests
    {
        [Fact]
        public void ShouldCreateObjec()
        {
            var flow = new DescopeFlow
            {
                Flow = new DescopeFlowMetadata
                {
                    Id = "TEST",
                    Version = 1,
                    Name = "Test",
                    Description = "Testing",
                    Dsl = new
                    {
                        Inner = "Inner"
                    },
                    ModifiedTime = 12345,
                    ETag = "Tagged",
                    Disabled = false,
                    Translate = true,
                    TranslateConnectorId = "TID",
                    TranslateSourceLang = "ENG",
                    TranslateTargetLangs = ["JP"],
                    Fingerprint = true,
                },
                Screens = []
            };

            string dslInner = flow.Flow.Dsl.GetType().GetProperty("Inner")?.GetValue(flow.Flow.Dsl, null)?.ToString();

            Assert.Equal("TEST", flow.Flow.Id);
            Assert.Equal(1, flow.Flow.Version);
            Assert.Equal("Test", flow.Flow.Name);
            Assert.Equal("Testing", flow.Flow.Description);
            Assert.Equal("Inner", dslInner);
            Assert.Equal(12345, flow.Flow.ModifiedTime);
            Assert.Equal("Tagged", flow.Flow.ETag);
            Assert.False(flow.Flow.Disabled);
            Assert.True(flow.Flow.Translate);
            Assert.Equal("TID", flow.Flow.TranslateConnectorId);
            Assert.Equal("ENG", flow.Flow.TranslateSourceLang);
            Assert.Single(flow.Flow.TranslateTargetLangs);
            Assert.Equal("JP", flow.Flow.TranslateTargetLangs[0]);
            Assert.True(flow.Flow.Fingerprint);
            Assert.Empty(flow.Screens);
        }

        [Fact]
        public void ShouldCreateObject_ListResponse()
        {
            var list = new DescopeFlowListResponse
            {
                Flows = [],
                Total = 0,
            };

            Assert.Empty(list.Flows);
            Assert.Equal(0, list.Total);
        }

        [Fact]
        public void ShouldCreateObject_ExportRequest()
        {
            var request = new DescopeFlowExportRequest
            {
                FlowId = "FTEST"
            };

            Assert.Equal("FTEST", request.FlowId);
        }

        [Fact]
        public void ShouldCreateObject_SearchRequest()
        {
            var request = new DescopeFlowSearchRequest
            {
                Ids = ["FTEST", "FTEST2"]
            };

            Assert.Equal(2, request.Ids.Length);
            Assert.Equal("FTEST", request.Ids[0]);
            Assert.Equal("FTEST2", request.Ids[1]);
        }

        [Fact]
        public void ShouldCreateObject_ImportRequest()
        {
            var request = new DescopeFlowImportRequest
            {
                FlowId = "FTEST",
                Flow = new DescopeFlowMetadata
                {
                    Id = "FTEST"
                },
                Screens = [],
            };

            Assert.Equal("FTEST", request.FlowId);
            Assert.Equal("FTEST", request.Flow.Id);
            Assert.Empty(request.Screens);
        }
    }
}
