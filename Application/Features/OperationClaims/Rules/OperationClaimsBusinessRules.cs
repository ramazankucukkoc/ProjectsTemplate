using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimsBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        public OperationClaimsBusinessRules(IOperationClaimRepository operationClaimRepository)
        => (_operationClaimRepository) = (operationClaimRepository);

        public async Task OperationClaimShouldNotDuplicatedWhenInserted(string role)
        {
            var result = await _operationClaimRepository.GetAsync(o => o.Name.ToLower() == role.ToLower());
            if (result is not null) throw new BusinessException("");
        }



    }
}
