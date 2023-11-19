using System.Text.Json;
using Descope.Models;

namespace Descope.Test.Management.Themes
{
    [Collection("ClientServer")]
    public class ThemesApiClientTests : IClassFixture<ThemesApiClientFixture>
    {
        private readonly ThemesApiClientFixture _fixture;

        public ThemesApiClientTests(ThemesApiClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldExportTheme()
        {
            var theme = await _fixture.ThemesApiClient.Export();

            Assert.NotNull(theme);
            ThemeAssertations(theme);
        }

        [Fact]
        public async Task ShouldImportTheme()
        {
            var theme = await _fixture.ThemesApiClient.Import(new DescopeTheme { });

            Assert.NotNull(theme);
            ThemeAssertations(theme, 2);
        }

        #region Private Methods

        private static void ThemeAssertations(DescopeTheme theme, int version = 1)
        {
            Assert.Equal("TEST", theme.Id);
            Assert.Equal(version, theme.Version);
            Assert.NotNull(theme.CssTemplate);

            object dark = ((JsonElement)theme.CssTemplate).GetProperty("Dark");
            object light = ((JsonElement)theme.CssTemplate).GetProperty("Light");

            Assert.NotNull(dark);
            Assert.NotNull(light);

            string darkFont = ((JsonElement)dark).GetProperty("Font").GetString();
            string darkColor = ((JsonElement)dark).GetProperty("Color").GetString();

            Assert.NotNull(darkFont);
            Assert.NotNull(darkColor);
            Assert.Equal("Fun Font", darkFont);
            Assert.Equal("Black", darkColor);

            string lightFont = ((JsonElement)light).GetProperty("Font").GetString();
            string lightColor = ((JsonElement)light).GetProperty("Color").GetString();

            Assert.NotNull(lightFont);
            Assert.NotNull(lightColor);
            Assert.Equal("Less Fun Font", lightFont);
            Assert.Equal("White", lightColor);

            Assert.Equal("1.0.0", theme.ComponentsVersion);
        }

        #endregion Private Methods
    }
}
