using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;
using ClienteAPI.Infra.External_Services.Interfaces;
using System.Text.Json;

namespace ClienteAPI.Infra.External_Services
{
    public class AdressProvider : IAdressProvider
    {
        private HttpClient _httpClient;

        public AdressProvider()
        {
            _httpClient = new HttpClient();
        }

        public async Task<object> GetAdress(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);
            var objectResponse = response.Content.ReadAsStringAsync().Result;
            var adress = JsonSerializer.Deserialize<EnderecoViaCep>(objectResponse);

            EnderecoViaCepDTO endereco = new EnderecoViaCepDTO()
            {
                cep = adress.cep,
                logradouro = adress.logradouro,
                bairro = adress.bairro,
                localidade = adress.localidade,
                uf = adress.uf
            };

            return endereco;
        }
    }
}

