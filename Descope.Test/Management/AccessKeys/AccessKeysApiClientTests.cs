﻿using Descope.Models;

namespace Descope.Test.Management.AccessKeys
{
    [Collection("ClientServer")]
    public class AccessKeysApiClientTests : IClassFixture<AccessKeysApiClientFixture>
    {
        private readonly AccessKeysApiClientFixture _fixture;

        public AccessKeysApiClientTests(AccessKeysApiClientFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task ShouldGetAccessKey()
        {
            var accessKey = await _fixture.AccessKeysApiClient.Get("TEST");

            Assert.NotNull(accessKey);
            AccessKeyAssertations(accessKey);
        }

        [Fact]
        public async Task ShouldNotGetAccessKey()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.AccessKeysApiClient.Get("TESTBAD"));

            Assert.NotNull(exception);
            AccessKeyCantFindAssertations(exception);
        }

        [Fact]
        public async Task ShouldNotGetAccessKey_IdTooShort()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.AccessKeysApiClient.Get("X"));

            Assert.NotNull(exception);
            Assert.Equal("E011003", exception.ErrorCode);
            Assert.Equal("Request is invalid", exception.ErrorDescription);
            Assert.Equal("The id field must be at least 27 characters", exception.ErrorMessage);
        }

        [Fact]
        public async Task ShouldSearchAccessKeys()
        {
            var accessKeys = await _fixture.AccessKeysApiClient.Search(new DescopeAccessKeySearchRequest
            {
                TenantIds = new string[1] { "TEST" }
            });

            Assert.NotNull(accessKeys);
            Assert.Single(accessKeys.Keys);
            AccessKeyAssertations(accessKeys.Keys.ElementAt(0));
        }

        [Fact]
        public async Task ShouldNotGetAnyAccessKeysBySearch()
        {
            var accessKeys = await _fixture.AccessKeysApiClient.Search(new DescopeAccessKeySearchRequest
            {
                TenantIds = new string[1] { "TESTBAD" }
            });

            Assert.NotNull(accessKeys);
            Assert.Empty(accessKeys.Keys);
        }

        [Fact]
        public async Task ShouldCreateAccessKey()
        {
            var accessKey = await _fixture.AccessKeysApiClient.Create(new DescopeAccessKeyCreateRequest());

            Assert.NotNull(accessKey);
            Assert.Equal("Secret", accessKey.ClearText);
            AccessKeyAssertations(accessKey.Key);
        }

        [Fact]
        public async Task ShouldUpdateAccessKey()
        {
            var accessKey = await _fixture.AccessKeysApiClient.Update(new DescopeAccessKeyUpdateRequest
            {
                Id = "TEST",
                Name = "Updated Testing"
            });

            Assert.NotNull(accessKey);
            AccessKeyAssertations(accessKey, "Updated Testing");
        }

        [Fact]
        public async Task ShouldNotUpdateAccessKey()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.AccessKeysApiClient.Update(new DescopeAccessKeyUpdateRequest
            {
                Id = "TESTBAD",
                Name = "Updated Testing"
            }));

            Assert.NotNull(exception);
            AccessKeyCantFindAssertations(exception);
        }

        [Fact]
        public async Task ShouldActivateAccessKey()
        {
            var delete = await Record.ExceptionAsync(async () => await _fixture.AccessKeysApiClient.Activate(new DescopeAccessKeyStatusChangeRequest
            {
                Id = "TEST"
            }));

            Assert.Null(delete);
        }

        [Fact]
        public async Task ShouldNotActivateAccessKey()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.AccessKeysApiClient.Activate(new DescopeAccessKeyStatusChangeRequest
            {
                Id = "TESTBAD"
            }));

            Assert.NotNull(exception);
            AccessKeyUnableToUpdateAssertations(exception);
        }

        [Fact]
        public async Task ShouldDeactivateAccessKey()
        {
            var delete = await Record.ExceptionAsync(async () => await _fixture.AccessKeysApiClient.Deactivate(new DescopeAccessKeyStatusChangeRequest
            {
                Id = "TEST"
            }));

            Assert.Null(delete);
        }

        [Fact]
        public async Task ShouldNotDeactivateAccessKey()
        {
            var exception = await Assert.ThrowsAsync<DescopeException>(async () => await _fixture.AccessKeysApiClient.Deactivate(new DescopeAccessKeyStatusChangeRequest
            {
                Id = "TESTBAD"
            }));

            Assert.NotNull(exception);
            AccessKeyUnableToUpdateAssertations(exception);
        }

        [Fact]
        public async Task ShouldDeleteAccessKey()
        {
            var delete = await Record.ExceptionAsync(async () => await _fixture.AccessKeysApiClient.Delete(new DescopeAccessKeyStatusChangeRequest
            {
                Id = "TEST"
            }));

            Assert.Null(delete);
        }

        #region Private Methods

        private static void AccessKeyAssertations(DescopeAccessKey accessKey, string expectedName = "Testing")
        {
            Assert.Equal("TEST", accessKey.Id);
            Assert.Equal(expectedName, accessKey.Name);
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

        private static void AccessKeyCantFindAssertations(DescopeException exception)
        {
            Assert.Equal("E111502", exception.ErrorCode);
            Assert.Equal("Access key not found", exception.ErrorDescription);
            Assert.Equal("Can't find access key", exception.ErrorMessage);
        }

        private static void AccessKeyUnableToUpdateAssertations(DescopeException exception)
        {
            Assert.Equal("E111502", exception.ErrorCode);
            Assert.Equal("Access key not found", exception.ErrorDescription);
            Assert.Equal("Unable to update access key because it's not found", exception.ErrorMessage);
        }

        #endregion Private Methods
    }
}