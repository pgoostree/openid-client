using System;
using Flurl;

namespace OpenIDClient
{
    public class Context
    {
        public Context(
            string clientId, 
            string clientSecret, 
            string accessTokenUrl, 
            string scope)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("clientId cannot be null or empty.");

            if (string.IsNullOrEmpty(clientSecret))
                throw new ArgumentException("clientSecret cannot be null or empty.");

            if (string.IsNullOrEmpty(accessTokenUrl))
                throw new ArgumentException("accessTokenUrl cannot be null or empty.");

            if (!Url.IsValid(accessTokenUrl))
                throw new ArgumentException("accessTokenUrl is not a valid format.");

            if (string.IsNullOrEmpty(scope))
                throw new ArgumentException("scope cannot be null or empty.");

            ClientId = clientId;
            ClientSecret = clientSecret;
            AccessTokenUrl = accessTokenUrl;
            Scope = scope;
        }
        
        /// <summary>
        ///     The client identifier issued to the client during the application registration process.
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     The client secret issued to the client during the application registration process.
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        ///     The endpoint for IDP server.
        ///     This is used to exchange the authorization code for an access token
        /// </summary>
        public string AccessTokenUrl { get; }

        /// <summary>
        ///     The scope of the access request.  It may have multiple comma delimited values.
        /// </summary>
        public string Scope { get; }
    }
}