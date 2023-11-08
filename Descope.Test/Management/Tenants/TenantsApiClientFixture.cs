/* <copyright file="TenantsApiClientFixture" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/31/2023 20:53:26</date>
 */

using Descope.Management.Tenants;

namespace Descope.Test.Management.Tenants
{
    public class TenantsApiClientFixture
    {
        private readonly TenantsApiClient _tenantsApiClient;

        public TenantsApiClientFixture(ClientServerFixture fixture)
        {
            _tenantsApiClient = new TenantsApiClient(fixture.HttpClient);
        }

        internal TenantsApiClient TenantsApiClient => _tenantsApiClient;
    }
}
