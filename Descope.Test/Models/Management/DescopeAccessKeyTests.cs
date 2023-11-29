using Descope.Models;

namespace Descope.Test.Models.Management
{
    public class DescopeAccessKeyTests
    {
        [Fact]
        public void ShouldCreateObject_AccessKeyResponse()
        {
            var accessKey = new DescopeAccessKeyResponse
            {
                Key = null
            };

            Assert.NotNull(accessKey);
            Assert.Null(accessKey.Key);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyListResponse()
        {
            var accessKeys = new DescopeAccessKeyListResponse
            {
                Keys =
                [
                    new()
                    {
                        Id = "TEST",
                        Name = "Testing",
                        RoleNames = ["Role1"],
                        KeyTenants =
                        [
                            new()
                            {
                                TenantId = "Tenant1",
                                RoleNames = ["TenantRole1"]
                            },
                            new()
                            {
                                TenantId = "Tenant2",
                                RoleNames = ["TenantRole2"]
                            }
                        ],
                        Status = "Active",
                        CreatedTime = 12345,
                        ExpireTime = 99999,
                        CreatedBy = "Mr. Tester"
                    }
                ]
            };

            Assert.Single(accessKeys.Keys);
            Assert.Equal("TEST", accessKeys.Keys.ElementAt(0).Id);
            Assert.Equal("Testing", accessKeys.Keys.ElementAt(0).Name);
            Assert.Single(accessKeys.Keys.ElementAt(0).RoleNames);
            Assert.Equal("Role1", accessKeys.Keys.ElementAt(0).RoleNames.ElementAt(0));
            Assert.Equal(2, accessKeys.Keys.ElementAt(0).KeyTenants.Count());
            Assert.Equal("Active", accessKeys.Keys.ElementAt(0).Status);
            Assert.Equal(12345, accessKeys.Keys.ElementAt(0).CreatedTime);
            Assert.Equal(99999, accessKeys.Keys.ElementAt(0).ExpireTime);
            Assert.Equal("Mr. Tester", accessKeys.Keys.ElementAt(0).CreatedBy);

            var keyTenant1 = accessKeys.Keys.ElementAt(0).KeyTenants.ElementAt(0);
            var keyTenant2 = accessKeys.Keys.ElementAt(0).KeyTenants.ElementAt(1);

            Assert.Equal("Tenant1", keyTenant1.TenantId);
            Assert.Single(keyTenant1.RoleNames);
            Assert.Equal("TenantRole1", keyTenant1.RoleNames.ElementAt(0));
            Assert.Equal("Tenant2", keyTenant2.TenantId);
            Assert.Single(keyTenant2.RoleNames);
            Assert.Equal("TenantRole2", keyTenant2.RoleNames.ElementAt(0));
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyCreateRequest()
        {
            var accessKey = new DescopeAccessKeyCreateRequest
            {
                Name = "Testing",
                ExpireTime = 12345,
                RoleNames = ["Role1"],
                KeyTenants =
                [
                    new()
                    {
                        TenantId = "Tenant1",
                        RoleNames = ["TenantRole1"]
                    },
                    new()
                    {
                        TenantId = "Tenant2",
                        RoleNames = ["TenantRole2"]
                    }
                ]
            };

            Assert.Equal("Testing", accessKey.Name);
            Assert.Equal(12345, accessKey.ExpireTime);
            Assert.Single(accessKey.RoleNames);
            Assert.Equal("Role1", accessKey.RoleNames.ElementAt(0));
            Assert.Equal(2, accessKey.KeyTenants.Count());

            var keyTenant1 = accessKey.KeyTenants.ElementAt(0);
            var keyTenant2 = accessKey.KeyTenants.ElementAt(1);

            Assert.Equal("Tenant1", keyTenant1.TenantId);
            Assert.Single(keyTenant1.RoleNames);
            Assert.Equal("TenantRole1", keyTenant1.RoleNames.ElementAt(0));
            Assert.Equal("Tenant2", keyTenant2.TenantId);
            Assert.Single(keyTenant2.RoleNames);
            Assert.Equal("TenantRole2", keyTenant2.RoleNames.ElementAt(0));
        }

        [Fact]
        public void ShouldCreteObject_AccessKeyCreateResponse()
        {
            var created = new DescopeAccessKeyCreateResponse
            {
                ClearText = "Password",
                Key = null
            };

            Assert.Equal("Password", created.ClearText);
            Assert.Null(created.Key);
        }

        [Fact]
        public void ShouldCreateObject_AccessKeyTenant()
        {
            var accessKeyTenant = new DescopeAccessKeyTenant
            {
                TenantId = "TEST",
                RoleNames = ["Role1", "Role2"]
            };

            Assert.Equal("TEST", accessKeyTenant.TenantId);
            Assert.Equal(2, accessKeyTenant.RoleNames.Count());
            Assert.Equal("Role1", accessKeyTenant.RoleNames.ElementAt(0));
            Assert.Equal("Role2", accessKeyTenant.RoleNames.ElementAt(1));
        }

        [Fact]
        public void ShouldCreateObject_AccessKeySearchRequest()
        {
            var search = new DescopeAccessKeySearchRequest
            {
                TenantIds = ["1", "2"],
            };

            Assert.Equal(2, search.TenantIds.Count());
            Assert.Equal("1", search.TenantIds.ElementAt(0));
            Assert.Equal("2", search.TenantIds.ElementAt(1));
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
    }
}
