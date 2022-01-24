using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Infra.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> GetByCPFAsync(string cpf);
        Task<List<Cliente>> GetAllAsync();
        Task<List<Cliente>> GetByNameAsync(string name);
        Task<List<Cliente>> GetByEmailAsync(string email);
        Task PostAsync(Cliente cliente);
        Task UpdateAsync(int id, ClienteRequest cliente);
        Task DeleteAsync(int id);
    }
}
