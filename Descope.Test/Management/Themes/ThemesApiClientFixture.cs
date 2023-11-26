using Descope.Management.Themes;

namespace Descope.Test.Management.Themes
{
    public class ThemesApiClientFixture(ClientServerFixture fixture)
    {
        private readonly ThemesApiClient _themesApiClient = new(fixture.HttpClient);

        internal ThemesApiClient ThemesApiClient => _themesApiClient;
    }
}
