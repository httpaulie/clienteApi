using AutoMapper;
using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Application.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            this.SetupInbound();
            this.SetupOutbound();
        }

        public void SetupInbound()
        {
            this.CreateMap<ClienteRequest, Cliente>();
        }

        public void SetupOutbound()
        {
            this.CreateMap<Cliente, ClienteResponse>()
            .ForMember(dest => dest.Nascimento, opt => opt.MapFrom(x => x.Nascimento.ToShortDateString()));
            this.CreateMap<Cliente, ClienteDTO>();
        }
    }
}
