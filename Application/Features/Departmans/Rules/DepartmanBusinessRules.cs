using Application.Features.Departmans.Constants;
using Application.Services.Repositories;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Departmans.Rules
{
    public class DepartmanBusinessRules : ITransactionableOperation
    {
        private readonly IDepartmanRepository _departmanRepository;

        public DepartmanBusinessRules(IDepartmanRepository departmanRepository)
        {
            _departmanRepository = departmanRepository;
        }
        public async Task DepartmanNameListCanNotBeDuplicatedWhenInserted(List<string> departmanList)
        {
            IPaginate<Departman> result = await _departmanRepository.GetListAsync(d => departmanList.Contains(d.FullName.Trim()));
            if (result.Items.Any()) throw new BusinessException(DepartmanBusinessExceptionMessages.DepartmanNameExists);

        }

    }
}
