using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;

namespace ClienteAPI.Infra.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetEnderecoByIdAsync(int id);
        Task<List<Endereco>> GetAllEnderecoAsync();
        Task PostAsync(Endereco endereco);
        Task UpdateAsync(int id, EnderecoRequest endereco);
        Task DeleteAsync(int id);
    }
}
