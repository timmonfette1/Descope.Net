using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeAccessKeyTests
    {
        private readonly DescopeAccessKey _accessKey = new()
        {
            Id = "TEST",
            Name = "Testing",
            RoleNames = new string[1] { "Role1" },
            KeyTenants = new DescopeAccessKeyTenant[2]
                {
                    new()
                    {
                        TenantId = "Tenant1",
                        RoleNames = new string[1] { "TenantRole1" }
                    },
                    new()
                    {
                        TenantId = "Tenant2",
                        RoleNames = new string[1] { "TenantRole2" }
                    }
                },
            Status = "Active",
            CreatedTime = 12345,
            ExpireTime = 99999,
            CreatedBy = "Mr. Tester"
        };

        [Fact]
        public void ShouldCreateObject_AccessKey()
        {
            var accessKey = _accessKey;

            AccessKeyAssertations(accessKey);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyResponse()
        {
            var accessKey = new DescopeAccessKeyResponse
            {
                Key = _accessKey
            };

            AccessKeyAssertations(accessKey.Key);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyListResponse()
        {
            var accessKeys = new DescopeAccessKeyListResponse
            {
                Keys = new DescopeAccessKey[1] { _accessKey }
            };

            Assert.Single(accessKeys.Keys);
            AccessKeyAssertations(accessKeys.Keys.ElementAt(0));
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyCreateRequest()
        {
            var accessKey = new DescopeAccessKeyCreateRequest
            {
                Name = "Testing",
                ExpireTime = 12345,
                RoleNames = new string[1] { "Role1" },
                KeyTenants = new DescopeAccessKeyTenant[2]
                {
                    new()
                    {
                        TenantId = "Tenant1",
                        RoleNames = new string[1] { "TenantRole1" }
                    },
                    new()
                    {
                        TenantId = "Tenant2",
                        RoleNames = new string[1] { "TenantRole2" }
                    }
                }
            };

            Assert.Equal("Testing", accessKey.Name);
            Assert.Equal(12345, accessKey.ExpireTime);
            Assert.Single(accessKey.RoleNames);
            Assert.Equal("Role1", accessKey.RoleNames[0]);
            Assert.Equal(2, accessKey.KeyTenants.Length);

            var keyTenant1 = accessKey.KeyTenants[0];
            var keyTenant2 = accessKey.KeyTenants[1];

            Assert.Equal("Tenant1", keyTenant1.TenantId);
            Assert.Single(keyTenant1.RoleNames);
            Assert.Equal("TenantRole1", keyTenant1.RoleNames[0]);
            Assert.Equal("Tenant2", keyTenant2.TenantId);
            Assert.Single(keyTenant2.RoleNames);
            Assert.Equal("TenantRole2", keyTenant2.RoleNames[0]);
        }

        [Fact]
        public void ShouldCreteObject_AccessKeyCreateResponse()
        {
            var created = new DescopeAccessKeyCreateResponse
            {
                ClearText = "Password",
                Key = _accessKey
            };

            Assert.Equal("Password", created.ClearText);
            AccessKeyAssertations(created.Key);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyTenant()
        {
            var accessKeyTenant = new DescopeAccessKeyTenant
            {
                TenantId = "TEST",
                RoleNames = new string[2] { "Role1", "Role2" }
            };

            Assert.Equal("TEST", accessKeyTenant.TenantId);
            Assert.Equal(2, accessKeyTenant.RoleNames.Length);
            Assert.Equal("Role1", accessKeyTenant.RoleNames[0]);
            Assert.Equal("Role2", accessKeyTenant.RoleNames[1]);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeySearchRequest()
        {
            var search = new DescopeAccessKeySearchRequest
            {
                TenantIds = new string[2] { "1", "2" },
            };

            Assert.Equal(2, search.TenantIds.Length);
            Assert.Equal("1", search.TenantIds[0]);
            Assert.Equal("2", search.TenantIds[1]);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyUpdateRequest()
        {
            var acessKey = new DescopeAccessKeyUpdateRequest
            {
                Id = "TEST",
                Name = "Testing"
            };

            Assert.Equal("TEST", acessKey.Id);
            Assert.Equal("Testing", acessKey.Name);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyStatusChangeRequest()
        {
            var accessKey = new DescopeAccessKeyStatusChangeRequest
            {
                Id = "TEST"
            };

            Assert.Equal("TEST", accessKey.Id);
        }

        #region Private Methods

        private static void AccessKeyAssertations(DescopeAccessKey accessKey)
        {
            Assert.Equal("TEST", accessKey.Id);
            Assert.Equal("Testing", accessKey.Name);
            Assert.Single(accessKey.RoleNames);
            Assert.Equal("Role1", accessKey.RoleNames[0]);
            Assert.Equal(2, accessKey.KeyTenants.Length);
            Assert.Equal("Active", accessKey.Status);
            Assert.Equal(12345, accessKey.CreatedTime);
            Assert.Equal(99999, accessKey.ExpireTime);
            Assert.Equal("Mr. Tester", accessKey.CreatedBy);

            var keyTenant1 = accessKey.KeyTenants[0];
            var keyTenant2 = accessKey.KeyTenants[1];

            Assert.Equal("Tenant1", keyTenant1.TenantId);
            Assert.Single(keyTenant1.RoleNames);
            Assert.Equal("TenantRole1", keyTenant1.RoleNames[0]);
            Assert.Equal("Tenant2", keyTenant2.TenantId);
            Assert.Single(keyTenant2.RoleNames);
            Assert.Equal("TenantRole2", keyTenant2.RoleNames[0]);
        }

        #endregion Private Methods
    }
}
