using Application.Features.CreditCards.Dtos;
using Application.Features.CreditCards.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreditCards.Command.CreateCreditCard
{
    public class CreateCreditCardCommand:IRequest<CreateCreditCardDto>
    {
        public int UserId { get; set; }
        public string NameOnTheCard { get; set; }//Kart üzerindeki isim
        public string CardNumber { get; set; }//Kart Numarası
        public string CardCvv { get; set; }//Güvenlik Kodu
        public string ExpirationDate { get; set; }//Son kullanma tarihi
        public decimal MoneyInTheCard { get; set; }//Karttaki Para

        public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, CreateCreditCardDto>
        {
            private readonly ICreditCartRepository _creditCartRepository;
            private readonly CreditCardBusinessRules _creditCardBusinessRules;
            private readonly IMapper _mapper;

            public CreateCreditCardCommandHandler(ICreditCartRepository creditCartRepository, 
                CreditCardBusinessRules creditCardBusinessRules, IMapper mapper)
            {
                _creditCartRepository = creditCartRepository;
                _creditCardBusinessRules = creditCardBusinessRules;
                _mapper = mapper;
            }

            public Task<CreateCreditCardDto> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
