using AutoMapper;
using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;
using ClienteAPI.Infra.Repositories.Interfaces;

namespace ClienteAPI.Application.Services.Interfaces
{
    public class ClienteServices : IClienteServices
    {
        IClienteRepository _clienteRepository;
        IMapper _mapper;
        
        public ClienteServices(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteResponse> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteResponse>(cliente);
        }
        public async Task<ClienteResponse> GetByCPFAsync(string cpf)
        {
            var cliente = await _clienteRepository.GetByCPFAsync(cpf);
            return _mapper.Map<ClienteResponse>(cliente);
        }

        public async Task<List<ClienteDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }
        public async Task<List<ClienteDTO>> GetByNameAsync(string name)
        {
            var clientes = await _clienteRepository.GetByNameAsync(name);
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }
        public async Task<List<ClienteDTO>> GetByEmailAsync(string email)
        {
            var clientes = await _clienteRepository.GetByEmailAsync(email);
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public async Task PostAsync(ClienteRequest cliente)
        {
            await _clienteRepository.PostAsync(_mapper.Map<Cliente>(cliente));
        }

        public async Task UpdateAsync(int id, ClienteRequest cliente)
        {
            await _clienteRepository.UpdateAsync(id, cliente);
        }

        public async Task DeleteAsync(int id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}
