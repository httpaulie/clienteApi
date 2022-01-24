using AutoMapper;
using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Application.Mappers
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            this.SetupInbound();
            this.SetupOutbound();
        }
        public void SetupInbound()
        {
            this.CreateMap<EnderecoRequest, Endereco>();
        }
        public void SetupOutbound()
        {
            this.CreateMap<Endereco, EnderecoResponse>();
            this.CreateMap<Endereco, EnderecoDTO>();
            this.CreateMap<Endereco, EnderecoViaCepDTO>();
        }

    }
}
