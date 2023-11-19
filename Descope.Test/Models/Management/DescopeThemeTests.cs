using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeThemeTests
    {
        private static readonly DescopeTheme _theme = new()
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
        };

        [Fact]
        public static void ShouldCreateObject_Theme()
        {
            var theme = _theme;

            Assert.NotNull(theme);
            ThemeAssertations(theme);
        }

        [Fact]
        public static void ShouldCreateObject_ThemeRequestResponse()
        {
            var theme = new DescopeThemeRequestResponse
            {
                Theme = _theme
            };

            Assert.NotNull(theme);
            ThemeAssertations(theme.Theme);
        }

        #region Private Methods

        private static void ThemeAssertations(DescopeTheme theme)
        {
            Assert.Equal("TEST", theme.Id);
            Assert.Equal(1, theme.Version);
            Assert.NotNull(theme.CssTemplate);

            object dark = theme.CssTemplate.GetType().GetProperty("Dark")?.GetValue(theme.CssTemplate, null);
            object light = theme.CssTemplate.GetType().GetProperty("Light")?.GetValue(theme.CssTemplate, null);

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

            Assert.Equal("1.0.0", theme.ComponentsVersion);
        }

        #endregion Private Methods
    }
}
