using HcodeR.Domain.Contracts.Repositories;
using HcodeR.Domain.Entities;
using HcodeR.Infrastructure.Context;
using HcodeR.Infrastructure.Pagination.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HcodeR.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly HcodeRContext _context;

        public ClienteRepository(HcodeRContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Cliente>> ListarClientesAsync(PaginationFilter paginationFilter)
        {
            var clientes = _context.Clientes.AsNoTracking();

            if (!string.IsNullOrEmpty(paginationFilter.Filter))
            {
                clientes = clientes.Where(c => c.Nome.ToLower().Contains(paginationFilter.Filter));
            }

            clientes = clientes.OrderByDescending(c => c.UpdatedAt);

            return await PaginatedList<Cliente>.CreateAsync(clientes, paginationFilter.PageNumber, paginationFilter.PageSize);
        }     

        public async Task<Cliente> ObterClientePorIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
        }

        public void ExcluirCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }       
    }
}
