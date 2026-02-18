using FeatureFlag.Interfaces;
using Google.Apis.Auth;

namespace FeatureFlag.Application.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly string _clientId;

        public GoogleAuthService(IConfiguration configuration)
        {
            _clientId = configuration["Google:ClientId"] ?? throw new ArgumentNullException("Google:ClientId not configured");
        }

        public async Task<GoogleJsonWebSignature.Payload> ValidateTokenAsync(string idToken)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new[] { _clientId }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
                return payload;
            }
            catch (InvalidJwtException ex)
            {
                throw new UnauthorizedAccessException("Invalid Google token", ex);
            }
        }
    }
}