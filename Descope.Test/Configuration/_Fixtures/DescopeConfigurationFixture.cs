/* <copyright file="DescopeConfigurationFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/27/2023 22:20:34</date>
 */

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
