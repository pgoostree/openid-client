using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using OpenIDClient.Models;
using Xunit;

namespace OpenIDClient.UnitTests
{
    public class AuthenticationTests
    {
        private const string _accessTokenUrl = "https://idp-rel.eval.test.com/op/tenant/XYZ123456/token";
        private const string _clientId = "65442a84-c8f4-4dad-9a86-d14dae3954d9";
        private const string _clientSecret = "cmo9lyU2qsy4STD6MojwlphIRcnRn3shC9DhCxGJ6eAfHXh86lWfr5pv6YZ8rsnG";
        private const string _scope = "All";

        private static Context OIDCUemContext => new Context(
            _clientId,
            _clientSecret,
            _accessTokenUrl,
            _scope);

        [Fact(DisplayName = "OpenIDClient POST request with the Authorization header to Basic Authorization values provided in Context.")]
        public async Task Fact()
        {
            var client = new OpenIDClient(OIDCUemContext);

            var accessTokenResponse = new AccessTokenResponse
            {
                TokenType = "Bearer",
                AccessToken = "test_access_token"
            };

            var applicationId = Guid.NewGuid();

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(accessTokenResponse);

                await client.GetAccessToken();

                httpTest.ShouldHaveCalled(_accessTokenUrl)
                    .WithVerb(HttpMethod.Post)
                    .WithBasicAuth(_clientId, _clientSecret);
            }
        }
    }
}