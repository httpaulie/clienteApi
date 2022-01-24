using ClienteAPI.Application.DTO;
using ClienteAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Application.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/enderecos")]
    [ApiVersion("1.0")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoServices _service;

        public EnderecoController(IEnderecoServices enderecoService)
        {
            _service = enderecoService;
        }

        /// <summary>
        /// Retorna uma lista com todos os endereços.
        /// </summary>
        /// <remarks>
        /// Descrição:
        ///
        ///     GET /api/v{version}/enderecos
        ///     Retorna uma lista com todos os endereços.
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Retorna uma lista com todos os endereços.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllEnderecoAsync()
        {
            return this.Ok(await _service.GetAllEnderecoAsync());
        }

        /// <summary>
        /// Retorna um endereço correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/v{version}/enderecos/{id}
        ///     Retorna um endereço correspondente ao id passado como parâmetro
        /// 
        /// Id Exemplo:
        ///
        ///     1
        ///
        /// </remarks>
        /// <response code="200">Retorna o endereço correspondente ao id pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEnderecoByIdAsync(int id)
        {
            return this.Ok(await _service.GetEnderecoByIdAsync(id));
        }

        /// <summary>
        /// Retorna um endereço correspondente ao CEP passado como parâmetro, consumindo a API ViaCEP.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/v{version}/enderecos/cep
        ///     Retorna um endereço correspondente ao CEP passado como parâmetro, consumindo a API ViaCEP.
        /// 
        /// Id Exemplo:
        ///
        ///     60355642
        ///
        /// </remarks>
        /// <response code="200">Retorna o endereço correspondente ao CEP pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("cep")]
        [HttpGet]
        public async Task<IActionResult> GetAdress(string cep)
        {
            return this.Ok(await _service.GetAdress(cep));
        }

        /// <summary>
        /// Cadastra um novo endereço.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cadastra um novo endereço.
        ///     POST /api/{version}/enderecos
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "cep": "60355642",
        ///        "logradouro": "Rua Maria Mirian Ferreira de Souza",
        ///        "complemento": "101",
        ///        "bairro": "Presidente Kennedy",
        ///        "cidade": "Fortaleza",
        ///        "uf": "CE",
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        public async Task<IActionResult> PostAsync(EnderecoRequest endereco)
        {
            await _service.PostAsync(endereco);
            return this.Created("enderecos", endereco);
        }

        /// <summary>
        /// Atualiza os dados de um endereço.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza os dados de um endereço.
        ///     PUT /api/{version}/enderecos/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "cep": "60355642",
        ///        "logradouro": "Rua Maria Mirian Ferreira de Souza",
        ///        "complemento": "101",
        ///        "bairro": "Presidente Kennedy",
        ///        "cidade": "Fortaleza",
        ///        "uf": "CE",
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Atualização realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Endereco não existe</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EnderecoRequest endereco)
        {
            await _service.UpdateAsync(id, endereco);
            return this.NoContent();
        }

        /// <summary>
        /// Deleta um endereço.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Deleta um endereço.
        ///     DELETE /api/{version}/enderecos/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Endereço não existe</response> 
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return this.NoContent();
        }

    }
}
