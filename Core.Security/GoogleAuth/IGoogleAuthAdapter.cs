namespace Core.Security.GoogleAuth
{
    public interface IGoogleAuthAdapter
    {
        Task<GoogleUserDetails> GetGoogleUserDetails(string googleAccessToken);
    }
}
