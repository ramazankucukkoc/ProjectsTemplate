using Core.Domain.Entities;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos
{
    public class RegisteredDto : RefreshedTokensDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
