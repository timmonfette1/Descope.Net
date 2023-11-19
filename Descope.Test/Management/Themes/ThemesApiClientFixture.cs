using Descope.Management.Themes;

namespace Descope.Test.Management.Themes
{
    public class ThemesApiClientFixture
    {
        private readonly ThemesApiClient _themesApiClient;

        public ThemesApiClientFixture(ClientServerFixture fixture)
        {
            _themesApiClient = new ThemesApiClient(fixture.HttpClient);
        }

        internal ThemesApiClient ThemesApiClient => _themesApiClient;
    }
}
