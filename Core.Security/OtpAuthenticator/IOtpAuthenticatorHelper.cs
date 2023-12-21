namespace Core.Security.OtpAuthenticator
{
    public interface IOtpAuthenticatorHelper
    {
        Task<byte[]> GenerateSecretKey();
        Task<string> ConvertSecretKeyToString(byte[] secretKey);
        Task<bool> VerifyCode(byte[] secretKey, string code);
    }
}
