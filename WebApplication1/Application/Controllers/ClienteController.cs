using ClienteAPI.Application.DTO;
using ClienteAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Application.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("1.0")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _service;

        public ClienteController(IClienteServices clienteService)
        {
            _service = clienteService;
        }

        /// <summary>
        /// Retorna uma lista com todos os clientes.
        /// </summary>
        /// <remarks>
        /// Descrição:
        ///
        ///     GET /api/v{version}/clientes
        ///     Retorna uma lista com todos os clientes.
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">Retorna uma lista com todos os alunos.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return this.Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna uma lista de clientes correspondentes ao nome passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/v{version}/clientes/nome
        ///     Retorna uma lista de clientes correspondentes ao nome passado como parâmetro.
        /// 
        /// Nome Exemplo:
        ///
        ///     Paulo Guilherme Medeiros Marques
        ///
        /// </remarks>
        /// <response code="200">Retorna a lista correspondente ao nome pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("nome")]
        [HttpGet]
        public async Task<IActionResult> GetByNameAsync(string nome)
        {
            return this.Ok(await _service.GetByNameAsync(nome));
        }

        /// <summary>
        /// Retorna uma lista de clientes correspondentes ao nome passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/v{version}/clientes/email
        ///     Retorna uma lista de clientes correspondentes ao email passado como parâmetro.
        /// 
        /// Email Exemplo:
        ///
        ///     pgmededeiros@gmail.com
        ///
        /// </remarks>
        /// <response code="200">Retorna a lista correspondente ao email pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("email")]
        [HttpGet]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            return this.Ok(await _service.GetByEmailAsync(email));
        }

        /// <summary>
        /// Retorna um cliente correspondente ao id passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/v{version}/clientes/{id}
        ///     Retorna um aluno correspondente ao id passado como parâmetro
        /// 
        /// Id Exemplo:
        ///
        ///     1
        ///
        /// </remarks>
        /// <response code="200">Retorna o cliente correspondente ao id pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return this.Ok(await _service.GetByIdAsync(id));
        }

        /// <summary>
        /// Retorna um cliente correspondente ao CPF passado como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET /api/v{version}/clientes/cpf
        ///     Retorna um aluno correspondente ao CPF passado como parâmetro
        /// 
        /// CPF Exemplo:
        ///
        ///     62237079323
        ///
        /// </remarks>
        /// <response code="200">Retorna o cliente correspondente ao CPF pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [Route("cpf")]
        [HttpGet]
        public async Task<IActionResult> GetByCPFAsync(string cpf)
        {
            return this.Ok(await _service.GetByCPFAsync(cpf));
        }

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Cadastra um novo cliente.
        ///     POST /api/{version}/clientes
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "Maria Silva",
        ///        "cpf": "28745820007",
        ///        "email": "maria.silva@gmail.com",
        ///        "nascimento: "2000-10-01",
        ///        "enderecoId": 1
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        public async Task<IActionResult> PostAsync(ClienteRequest cliente)
        {
            await _service.PostAsync(cliente);
            return this.Created("clientes", cliente);
        }

        /// <summary>
        /// Atualiza os dados de um cliente.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Atualiza os dados de um cliente.
        ///     PUT /api/{version}/clientes/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "Maria Silva",
        ///        "cpf": "28745820007",
        ///        "email": "maria.silva@gmail.com",
        ///        "nascimento: "2000-10-01",
        ///        "enderecoId": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Atualização realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Cliente não existe</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ClienteRequest cliente)
        {
            await _service.UpdateAsync(id, cliente);
            return this.NoContent();
        }

        /// <summary>
        /// Deleta um cliente.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     Deleta um cliente.
        ///     DELETE /api/{version}/clientes/{id}
        ///     
        /// id
        /// 
        ///     1
        ///     
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        /// <response code="404">Cliente não existe</response> 
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return this.NoContent();
        }
    }
}
