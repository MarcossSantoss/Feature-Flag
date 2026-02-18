using Google.Apis.Auth;

namespace FeatureFlag.Interfaces
{
    public interface IGoogleAuthService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateTokenAsync(string idToken);
    }
}
