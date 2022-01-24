using ClienteAPI.Application.DTO;

namespace ClienteAPI.Application.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<ClienteResponse> GetByIdAsync(int id);
        Task<ClienteResponse> GetByCPFAsync(string cpf);
        Task<List<ClienteDTO>> GetAllAsync();
        Task<List<ClienteDTO>> GetByNameAsync(string name);
        Task<List<ClienteDTO>> GetByEmailAsync(string email);
        Task PostAsync(ClienteRequest cliente);
        Task UpdateAsync(int id, ClienteRequest cliente);
        Task DeleteAsync(int id);
    }
}
