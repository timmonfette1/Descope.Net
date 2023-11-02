/* <copyright file="RequestsTests" company="Solidus">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author>Solidus</author>
 * <date>10/27/2023 22:28:29</date>
 */

using Descope.Utilities;
using RestSharp;

namespace Descope.Test.Utilities
{
    public class RequestsTests
    {
        private class Dummy
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [Fact]
        public void ShouldGetGetRequest()
        {
            var request = Requests.GetRequest("my/fake/resource");

            Assert.Equal(Method.Get, request.Method);
            Assert.Equal("my/fake/resource", request.Resource);
        }

        [Fact]
        public void ShouldGetJsonPostRequest()
        {
            var dummy = new Dummy()
            {
                Id = 1,
                FirstName = "hello",
                LastName = "world"
            };

            var request = Requests.JsonPostRequest("my/fake/resource/create", dummy);

            Assert.Equal(Method.Post, request.Method);
            Assert.Equal("my/fake/resource/create", request.Resource);
            Assert.Single(request.Parameters);

            var requestParams = request.Parameters.GetParameters(ParameterType.RequestBody);

            Assert.Single(requestParams);

            var param = requestParams.Single();

            Assert.Equal(ParameterType.RequestBody, param.Type);
            Assert.Equal("application/json", param.ContentType.Value);
            Assert.Equivalent(param.Value, dummy, true);
        }
    }
}
