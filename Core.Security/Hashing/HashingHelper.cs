using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);
            byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
        public static void CreateCreditCartHash(string cardNumber, out byte[] crediCartHash, out byte[] creditCardSalt)
        {
            using HMACSHA256 hmac = new();
            creditCardSalt = hmac.Key;
            crediCartHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(cardNumber));
        }
        public static bool VerifyCreditCardHash(string cardNumber,  byte[] crediCartHash,  byte[] creditCardSalt)
        {
            using HMACSHA256 hmac= new(creditCardSalt);
            byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(cardNumber));
            return computeHash.SequenceEqual(crediCartHash);
        }

    }
}
