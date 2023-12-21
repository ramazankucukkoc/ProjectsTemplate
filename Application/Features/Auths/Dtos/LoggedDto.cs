using Core.Application.DTOs;
using Core.Domain.Entities;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos
{
    public class LoggedDto : IDto
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }

    }
}
