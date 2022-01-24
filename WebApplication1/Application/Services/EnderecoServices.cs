using AutoMapper;
using ClienteAPI.Application.DTO;
using ClienteAPI.Application.Services.Interfaces;
using ClienteAPI.Domain.Models;
using ClienteAPI.Infra.Repositories.Interfaces;
using ClienteAPI.Infra.External_Services.Interfaces;

namespace ClienteAPI.Application.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        IEnderecoRepository _enderecoRepository;
        IMapper _mapper;
        IAdressProvider _adressProvider;
        public EnderecoServices(IEnderecoRepository enderecoRepository, IMapper mapper, IAdressProvider adressProvider)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _adressProvider = adressProvider;
        }

        public async Task<EnderecoDTO> GetEnderecoByIdAsync(int id)
        {
            var endereco = await _enderecoRepository.GetEnderecoByIdAsync(id);
            return _mapper.Map<EnderecoDTO>(endereco);
        }

        public async Task<List<EnderecoDTO>> GetAllEnderecoAsync()
        {
            var enderecos = await _enderecoRepository.GetAllEnderecoAsync();
            return _mapper.Map<List<EnderecoDTO>>(enderecos);
        }

        public async Task PostAsync(EnderecoRequest endereco)
        {
            await _enderecoRepository.PostAsync(_mapper.Map<Endereco>(endereco));
        }

        public async Task UpdateAsync(int id, EnderecoRequest endereco)
        {
            await _enderecoRepository.UpdateAsync(id, endereco);
        }

        public async Task DeleteAsync(int id)
        {
            await _enderecoRepository.DeleteAsync(id);
        }

        public async Task<object> GetAdress(string cep)
        {
            object endereco = await _adressProvider.GetAdress(cep);
            return _mapper.Map<EnderecoViaCepDTO>(endereco);
        }
    }
}
