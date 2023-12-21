using Application.Services.Repositories;

namespace Application.Features.CreditCards.Rules
{
    public class CreditCardBusinessRules
    {
        
        private readonly ICreditCartRepository _creditCartRepository;
        public CreditCardBusinessRules(ICreditCartRepository creditCartRepository)
        {
            _creditCartRepository = creditCartRepository;
        }


    }
}
