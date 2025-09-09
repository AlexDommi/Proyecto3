using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Services.Implementations
{
    public class CustomersService : ICustomersService
    {
        private readonly ApplicationDbContext _context;

        public CustomersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomersReadDTO>> GetAllAsync()
        {
            var clientes = await _context.Clientes
                .Where(c => !c.isDeleted)
                .Select(c => new CustomersReadDTO {
                    Id = c.Id,
                    ClienteNombre = c.ClienteNombre,
                    ClienteApellidos = c.ClienteApellidos,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem
            })
                .ToListAsync();

            return clientes;
        }

        public async Task<CustomersReadDTO> GetByIdAsync(int id)
        {
            var clienteid = await _context.Clientes
                .Where(c => c.Id == id && !c.isDeleted)
                .Select(p => new CustomersReadDTO
                {
                    Id = p.Id,
                    ClienteNombre = p.ClienteNombre,
                    ClienteApellidos = p.ClienteApellidos,
                    Activo= p.isActive,
                    HoraAlta = p.HighSystem
                }).FirstOrDefaultAsync();

            if (clienteid == null)
                throw new ApplicationException($"Cliente con Id {id} no encontrado");

            return clienteid;
        }

        public async Task AddAsync(CustomersCreatedDTO AddDTO)
        {
            var cliente = new Customers
            {
                Id = AddDTO.Id,
                ClienteNombre = AddDTO.ClienteNombre,
                ClienteApellidos = AddDTO.ClienteApellidos
            };

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                throw new ApplicationException("No se encontro cliente");

            cliente.isDeleted = true;
            cliente.isActive = false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAsync(int id, CustomersCreatedDTO dto)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            clientes.ClienteNombre= dto.ClienteNombre;
            clientes.ClienteApellidos= dto.ClienteApellidos;
            clientes.isActive = dto.Activo;
            
            _context.Clientes.Update(clientes);
            await _context.SaveChangesAsync();
        }
    }
}
