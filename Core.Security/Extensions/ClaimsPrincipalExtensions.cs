using System.Security.Claims;

namespace Core.Security.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
        // FirstOrDefault dememizin sebebi kullanıcının sadece bir adı bir emaili bir UserId'si olamsıdır.
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
        }
        public static string? GetName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindFirstValue(ClaimTypes.Name);
        }
        public static string? GetLastName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Surname)?.FirstOrDefault();
        }
        public static string? GetEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindFirst(ClaimTypes.Email)?.Value ?? "<Anonymous>";
        }
        public static string? FindFirstValue(this ClaimsPrincipal claimsPrincipal, string claimTypes)
        {
            if (claimsPrincipal == null) throw new ArgumentNullException(nameof(claimsPrincipal));

            var claim = claimsPrincipal.FindFirst(claimTypes);
            return claim?.Value;
        }
        public static bool HasClaimType(this ClaimsPrincipal principal, string claimType)
       => principal.HasClaim(c => c.Type == claimType);
    }
}
