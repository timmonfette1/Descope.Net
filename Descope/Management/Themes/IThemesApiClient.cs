using Descope.Models;

namespace Descope.Management.Themes
{
    public interface IThemesApiClient
    {
        Task<DescopeTheme> Export();
        Task<DescopeTheme> Import(DescopeTheme theme);
    }
}
