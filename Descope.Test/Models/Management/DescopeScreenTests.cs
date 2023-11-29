using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeScreenTests
    {
        [Fact]
        public void ShouldCreateObject_Screen()
        {
            var screen = new DescopeScreen
            {
                Id = "TEST",
                Version = 1,
                FlowId = "FTEST",
                Inputs =
               [
                   new()
                   {
                       Type = "TEST",
                       Name = "Tester",
                       Required = false,
                       Visible = true,
                       DisplayName = "Testing",
                       DisplayType = "Test",
                       DependsOn = ["Dependency"],
                       NameValueMap = null,
                       ContextAware = true,
                       Options =
                        [
                            new()
                            {
                                Label = "Label",
                                Value = "Value"
                            }
                        ]
                   }
               ],
                Interactions =
               [
                   new()
                   {
                       Id = "TEST",
                       Type = "Tester",
                       Label = "Testing",
                       Icon = "Smile",
                       SubType = "Tester Jr."
                   }
               ],
                HtmlTemplate = new
                {
                    Inner = "Inner"
                },
                ComponentsVersion = "1.0.0",
            };

            string htmlTemplateInner = screen.HtmlTemplate.GetType().GetProperty("Inner")?.GetValue(screen.HtmlTemplate, null)?.ToString();

            Assert.Equal("TEST", screen.Id);
            Assert.Equal(1, screen.Version);
            Assert.Equal("FTEST", screen.FlowId);
            Assert.Single(screen.Inputs);
            Assert.Equal("TEST", screen.Inputs.ElementAt(0).Type);
            Assert.Equal("Tester", screen.Inputs.ElementAt(0).Name);
            Assert.False(screen.Inputs.ElementAt(0).Required);
            Assert.True(screen.Inputs.ElementAt(0).Visible);
            Assert.Equal("Testing", screen.Inputs.ElementAt(0).DisplayName);
            Assert.Equal("Test", screen.Inputs.ElementAt(0).DisplayType);
            Assert.Single(screen.Inputs.ElementAt(0).DependsOn);
            Assert.Equal("Dependency", screen.Inputs.ElementAt(0).DependsOn.ElementAt(0));
            Assert.Null(screen.Inputs.ElementAt(0).NameValueMap);
            Assert.True(screen.Inputs.ElementAt(0).ContextAware);
            Assert.Single(screen.Inputs.ElementAt(0).Options);
            Assert.Equal("Label", screen.Inputs.ElementAt(0).Options.ElementAt(0).Label);
            Assert.Equal("Value", screen.Inputs.ElementAt(0).Options.ElementAt(0).Value);
            Assert.Single(screen.Interactions);
            Assert.Equal("TEST", screen.Interactions.ElementAt(0).Id);
            Assert.Equal("Tester", screen.Interactions.ElementAt(0).Type);
            Assert.Equal("Testing", screen.Interactions.ElementAt(0).Label);
            Assert.Equal("Smile", screen.Interactions.ElementAt(0).Icon);
            Assert.Equal("Tester Jr.", screen.Interactions.ElementAt(0).SubType);
            Assert.Equal("Inner", htmlTemplateInner);
            Assert.Equal("1.0.0", screen.ComponentsVersion);
        }
    }
}
