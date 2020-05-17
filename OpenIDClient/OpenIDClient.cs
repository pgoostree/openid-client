using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using OpenIDClient.Models;

namespace OpenIDClient
{
    /// <summary>
    ///     Provides the base functionality for the OpenIDClient
    /// </summary>
    public class OpenIDClient
    {
        private readonly Context _context;

        public OpenIDClient(Context uemContext)
        {
            _context = uemContext;
        }

        /// <summary>
        ///     Retrieves an OpenID Client access token from the IDP Access Token Url
        /// </summary>
        /// <returns></returns>
        public async Task<AccessTokenResponse> GetAccessToken()
        {
            var data = new Dictionary<string, object>
            {
                {"grant_type", "client_credentials"},
                {"scope", $"{_context.Scope}"}
            };

            return await _context.AccessTokenUrl
                .WithBasicAuth(_context.ClientId, _context.ClientSecret)
                .PostUrlEncodedAsync(data)
                .ReceiveJson<AccessTokenResponse>();
        }
    }
}