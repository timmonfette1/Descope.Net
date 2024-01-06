using Descope.Management.Themes;

namespace Descope.Test.Management.Themes
{
    public class ThemesApiClientFixture(ClientServerFixture fixture)
    {
        private readonly ThemesApiClient _themesApiClient = new(fixture.ManagementHttpClient);

        internal ThemesApiClient ThemesApiClient => _themesApiClient;
    }
}
