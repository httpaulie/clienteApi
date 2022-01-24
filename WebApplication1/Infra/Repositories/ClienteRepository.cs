using ClienteAPI.Application.DTO;
using ClienteAPI.Domain.Models;
using ClienteAPI.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Infra.Context
{
    public class ClienteRepository : IClienteRepository
    {
        List<Cliente> clientes = new List<Cliente>();

        private readonly Context _context;
        public ClienteRepository(Context context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.Include(x => x.Endereco).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Cliente> GetByCPFAsync(string cpf)
        {
            return await _context.Clientes.Include(x => x.Endereco).Where(a => a.CPF == cpf).FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<List<Cliente>> GetByNameAsync(string name)
        {
            return await _context.Clientes.Where(a => a.Nome.Contains(name)).ToListAsync();
        }
        public async Task<List<Cliente>> GetByEmailAsync(string email)
        {
            return await _context.Clientes.Where(a => a.Email.Contains(email)).ToListAsync();
        } 

        public async Task PostAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ClienteRequest clienteRequest)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            cliente.Nome = clienteRequest.Nome;
            cliente.CPF = clienteRequest.CPF;
            cliente.Email = clienteRequest.Email;
            cliente.Nascimento = clienteRequest.Nascimento;
            cliente.EnderecoId = clienteRequest.EnderecoId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

        }
    }
}
