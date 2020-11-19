using AutoMapper;
using Travel.Infrastructure.Models;
using Travel.Dtos;

namespace Travel.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Ticket, TicketResponseDto>().ForSourceMember(ticket => ticket.Buyers, expression => expression.DoNotValidate());
            CreateMap<Buyer, BuyerResponseDto>().ForSourceMember(buyer => buyer.Ticket, expression => expression.DoNotValidate());
        }
    }
}