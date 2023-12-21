using Application.Features.Orders.Dtos;
using Application.Features.Orders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Command
{
    public class CreateOrderCommand : IRequest<CreateOrderDto>
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public decimal SubTotal { get; set; }//Ara Toplam
        public double DisCount { get; set; }//Indirim
        public double Tax { get; set; } //Vergi
        public decimal Total { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsShippingDifferent { get; set; }//default false Nakliye Farklı mı?
        public DateTime CanceledDate { get; set; }//Iptal Tarihi.
        public DateTime DeliveredDate { get; set; }//Teslim Tarihi

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly OrderBusinessRules _businessRules;

            public CreateOrderCommandHandler(IOrderRepository orderRepository,
                IMapper mapper, OrderBusinessRules businessRules)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {

                Order? mappedOrder = _mapper.Map<Order>(request);
                Order addedOrder = await _orderRepository.AddAsync(mappedOrder);
                CreateOrderDto createOrderDto = _mapper.Map<CreateOrderDto>(addedOrder);
                return createOrderDto;

            }
        }

    }
}
