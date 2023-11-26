using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeThemeTests
    {
        [Fact]
        public static void ShouldCreateObject_ThemeRequestResponse()
        {
            var theme = new DescopeThemeRequestResponse
            {
                Theme = new DescopeTheme
                {
                    Id = "TEST",
                    Version = 1,
                    CssTemplate = new
                    {
                        Dark = new
                        {
                            Font = "Fun Font",
                            Color = "Black"
                        },
                        Light = new
                        {
                            Font = "Less Fun Font",
                            Color = "White"
                        }
                    },
                    ComponentsVersion = "1.0.0"
                }
            };

            Assert.NotNull(theme);
            Assert.NotNull(theme.Theme);
            Assert.Equal("TEST", theme.Theme.Id);
            Assert.Equal(1, theme.Theme.Version);
            Assert.NotNull(theme.Theme.CssTemplate);

            object dark = theme.Theme.CssTemplate.GetType().GetProperty("Dark")?.GetValue(theme.Theme.CssTemplate, null);
            object light = theme.Theme.CssTemplate.GetType().GetProperty("Light")?.GetValue(theme.Theme.CssTemplate, null);

            Assert.NotNull(dark);
            Assert.NotNull(light);

            string darkFont = dark.GetType().GetProperty("Font")?.GetValue(dark, null)?.ToString();
            string darkColor = dark.GetType().GetProperty("Color")?.GetValue(dark, null)?.ToString();

            Assert.NotNull(darkFont);
            Assert.NotNull(darkColor);
            Assert.Equal("Fun Font", darkFont);
            Assert.Equal("Black", darkColor);

            string lightFont = light.GetType().GetProperty("Font")?.GetValue(light, null)?.ToString();
            string lightColor = light.GetType().GetProperty("Color")?.GetValue(light, null)?.ToString();

            Assert.NotNull(lightFont);
            Assert.NotNull(lightColor);
            Assert.Equal("Less Fun Font", lightFont);
            Assert.Equal("White", lightColor);

            Assert.Equal("1.0.0", theme.Theme.ComponentsVersion);
        }
    }
}
