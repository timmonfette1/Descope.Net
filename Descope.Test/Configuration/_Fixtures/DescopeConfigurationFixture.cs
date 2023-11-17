using Descope.Configuration;

namespace Descope.Test.Configuration
{
    public class DescopeConfigurationFixture
    {
        private readonly DescopeConfiguration _config;

        public DescopeConfigurationFixture()
        {
            _config = new DescopeConfiguration("myProjectId", "myManagementKey");
        }

        internal DescopeConfiguration Config => _config;
    }
}
