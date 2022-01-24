using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;
using ClienteAPI.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Infra.Context
{
    public class EnderecoRepository : IEnderecoRepository
    {
        List<Endereco> enderecos = new List<Endereco>();

        private readonly Context _context;
        public EnderecoRepository(Context context)
        {
            _context = context;
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int id)
        {
            return await _context.Enderecos.Include(x => x.Clientes).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Endereco>> GetAllEnderecoAsync()
        {
            return await _context.Enderecos.Include(x => x.Clientes).ToListAsync();
        }

        public async Task PostAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EnderecoRequest enderecoRequest)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            endereco.CEP = enderecoRequest.CEP;
            endereco.Logradouro = enderecoRequest.Logradouro;
            endereco.Complemento = enderecoRequest.Complemento;
            endereco.Bairro = enderecoRequest.Bairro;
            endereco.UF = enderecoRequest.UF;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
        }

        /*public EnderecoRequest PostViaCep(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json";

            using (HttpClient client = new HttpClient())

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var response = client.Send(request);
                string result = response.Content.ReadAsStringAsync().Result;

                var enderecoViaCep = JsonSerializer.Deserialize<EnderecoViaCepDTO>(result);

                EnderecoRequest endereco = new EnderecoRequest()
                {
                    CEP = enderecoViaCep.cep,
                    Logradouro = enderecoViaCep.logradouro,
                    Bairro = enderecoViaCep.bairro,
                    Complemento = enderecoViaCep.complemento,
                    UF = enderecoViaCep.uf
                };

                return endereco;
            }*/
        
    }
}
