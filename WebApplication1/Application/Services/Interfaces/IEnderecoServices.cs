using ClienteAPI.Application.DTO;

namespace ClienteAPI.Application.Services.Interfaces
{
    public interface IEnderecoServices
    {
        Task<EnderecoDTO> GetEnderecoByIdAsync(int id);
        Task<List<EnderecoDTO>> GetAllEnderecoAsync();
        Task PostAsync(EnderecoRequest endereco);
        Task UpdateAsync(int id, EnderecoRequest endereco);
        Task DeleteAsync(int id);
        Task<object> GetAdress(string cep);
    }
}
