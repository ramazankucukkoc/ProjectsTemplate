using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;

namespace Core.Security.GoogleAuth
{
    public class GoogleAuthAdapter : IGoogleAuthAdapter
    {
        private readonly IConfiguration _config;

        public GoogleAuthAdapter(IConfiguration config)
        {
            _config = config;
        }

        public async Task<GoogleUserDetails> GetGoogleUserDetails(string googleAccessToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {

                Audience = new List<string> { _config["Google:Client_ID"] }
            };
            GoogleJsonWebSignature.Payload? googleAuthTokenInfo =
                await GoogleJsonWebSignature.ValidateAsync(googleAccessToken, settings);

            return new GoogleUserDetails
            {
                Email = googleAuthTokenInfo.Email,
                EmailVerified = googleAuthTokenInfo.EmailVerified,
                FirstName = googleAuthTokenInfo.GivenName,
                LastName = googleAuthTokenInfo.FamilyName
            };
        }
    }
}
