using Descope.Configuration;
using Descope.HttpClient;
using Descope.Models;

namespace Descope.Management.Users
{
    internal class UsersApiClient(IDescopeManagementHttpClient httpClient) : IUsersApiClient
    {
        private readonly IDescopeManagementHttpClient _httpClient = httpClient;

        public async Task<DescopeUser> GetByUserId(string userId)
        {
            var response = await _httpClient.GetAsync<DescopeUserResponse>(Endpoints.Management.LoadUser, new { userId });
            return response.User;
        }

        public async Task<DescopeUser> GetByLoginId(string loginId)
        {
            var response = await _httpClient.GetAsync<DescopeUserResponse>(Endpoints.Management.LoadUser, new { loginId });
            return response.User;
        }

        public async Task<DescopeUserOAuthToken> GetProviderToken(string loginId, string provider)
        {
            return await _httpClient.GetAsync<DescopeUserOAuthToken>(Endpoints.Management.LoadUserToken, new { loginId, provider });
        }

        public async Task<IEnumerable<DescopeUser>> Search(DescopeUserSearchRequest search)
        {
            var response = await _httpClient.PostAsync<DescopeUserSearchRequest, DescopeUserListResponse>(Endpoints.Management.SearchUsers, search);
            return response.Users;
        }

        public async Task<DescopeUser> Create(DescopeUserCreateRequest user)
        {
            var response = await _httpClient.PostAsync<DescopeUserCreateRequest, DescopeUserResponse>(Endpoints.Management.CreateUser, user);
            return response.User;
        }

        public async Task<DescopeUserBatchCreateResponse> BatchCreate(DescopeUserBatchCreateRequest users)
        {
            return await _httpClient.PostAsync<DescopeUserBatchCreateRequest, DescopeUserBatchCreateResponse>(Endpoints.Management.BatchCreateUsers, users);
        }

        public async Task<DescopeUser> Update(string loginId, DescopeUser user)
        {
            var request = new DescopeUserUpdateRequest
            {
                LoginId = loginId,
                DisplayName = user.Name,
                GivenName = user.GivenName,
                MiddleName = user.MiddleName,
                FamilyName = user.FamilyName,
                Email = user.Email,
                VerifiedEmail = user.VerifiedEmail,
                Phone = user.Phone,
                VerifiedPhone = user.VerifiedPhone,
                RoleNames = user.RoleNames,
                UserTenants = user.UserTenants,
                Picture = user.Picture,
                CustomAttributes = user.CustomAttributes,
                SsoAppIds = user.SsoAppIds
            };

            var response = await _httpClient.PostAsync<DescopeUserUpdateRequest, DescopeUserResponse>(Endpoints.Management.UpdateUser, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdateStatus(string loginId, string status)
        {
            object request = new
            {
                loginId,
                status
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserStatus, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdateEmail(string loginId, string email, bool verified)
        {
            object request = new
            {
                loginId,
                email,
                verified = !string.IsNullOrWhiteSpace(email) && verified
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserEmail, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdateLoginId(string loginId, string newLoginId)
        {
            object request = new
            {
                loginId,
                newLoginId
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserLoginId, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdatePhone(string loginId, string phone, bool verified)
        {
            object request = new
            {
                loginId,
                phone,
                verified = !string.IsNullOrWhiteSpace(phone) && verified
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserPhone, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdateName(string loginId, string givenName, string middleName, string familyName, string displayName = null)
        {
            string fullName;
            if (string.IsNullOrWhiteSpace(displayName))
            {
                fullName = givenName;
                if (!string.IsNullOrWhiteSpace(middleName))
                {
                    fullName = $"{fullName} {middleName}";
                }

                fullName = $"{fullName} {familyName}";
            }
            else
            {
                fullName = displayName;
            }

            object request = new
            {
                loginId,
                givenName,
                middleName,
                familyName,
                displayName = fullName
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserName, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdatePicture(string loginId, string picture)
        {
            object request = new
            {
                loginId,
                picture
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserPicture, request);
            return response.User;
        }

        public async Task<DescopeUser> UpdateCustomAttribute(string loginId, string key, object value)
        {
            object request = new
            {
                loginId,
                attributeKey = key,
                attributeValue = value
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserCustomAttribute, request);
            return response.User;
        }

        public async Task<DescopeUser> AddTenant(string loginId, string tenantId)
        {
            object request = new
            {
                loginId,
                tenantId
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserTenantsAdd, request);
            return response.User;
        }

        public async Task<DescopeUser> RemoveTenant(string loginId, string tenantId)
        {
            object request = new
            {
                loginId,
                tenantId
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserTenantsRemove, request);
            return response.User;
        }

        public async Task<DescopeUser> AddRoles(string loginId, string tenantId, IEnumerable<string> roleNames)
        {
            object request = new
            {
                loginId,
                tenantId,
                roleNames
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserRolesAdd, request);
            return response.User;
        }

        public async Task<DescopeUser> RemoveRoles(string loginId, string tenantId, IEnumerable<string> roleNames)
        {
            object request = new
            {
                loginId,
                tenantId,
                roleNames
            };

            var response = await _httpClient.PostAsync<object, DescopeUserResponse>(Endpoints.Management.UpdateUserRolesRemove, request);
            return response.User;
        }

        public async Task SetPassword(string loginId, string password)
        {
            var request = new DescopeUserPasswordRequest
            {
                LoginId = loginId,
                Password = password
            };

            await _httpClient.PostAsync(Endpoints.Management.SetUserPassword, request);
        }

        public async Task ExpirePassword(string loginId)
        {
            var request = new DescopeUserLoginIdRequest
            {
                LoginId = loginId
            };

            await _httpClient.PostAsync(Endpoints.Management.ExpireUserPassword, request);
        }

        public async Task LogoutByUserId(string userId)
        {
            await _httpClient.PostAsync<object>(Endpoints.Management.LogoutUser, new { userId });
        }

        public async Task LogoutByLoginId(string loginId)
        {
            var request = new DescopeUserLoginIdRequest
            {
                LoginId = loginId
            };

            await _httpClient.PostAsync(Endpoints.Management.LogoutUser, request);
        }

        public async Task Delete(string loginId)
        {
            var request = new DescopeUserLoginIdRequest
            {
                LoginId = loginId
            };

            await _httpClient.PostAsync(Endpoints.Management.DeleteUser, request);
        }
    }
}
