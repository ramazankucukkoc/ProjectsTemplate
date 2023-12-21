namespace Core.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; }//izleyici
        public string Issuer { get; set; }//Yayıncı
        public int AccessTokenExpiration { get; set; }//Son accesstoken süresi
        public string SecurityKey { get; set; }
        public int RefreshTokenTTL { get; set; }
    }
}
