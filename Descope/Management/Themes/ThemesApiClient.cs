using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Themes
{
    internal class ThemesApiClient(IDescopeManagementHttpClient httpClient) : IThemesApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<DescopeTheme> Export()
        {
            var response = await _httpClient.PostAsync<object, DescopeThemeRequestResponse>(Endpoints.Management.ExportTheme, new { });
            return response.Theme;
        }

        public async Task<DescopeTheme> Import(DescopeTheme theme)
        {
            var request = new DescopeThemeRequestResponse { Theme = theme };
            var response = await _httpClient.PostAsync<DescopeThemeRequestResponse, DescopeThemeRequestResponse>(Endpoints.Management.ImportTheme, request);
            return response.Theme;
        }
    }
}
