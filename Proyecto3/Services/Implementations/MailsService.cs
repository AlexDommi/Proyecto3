using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;

namespace Proyecto3.Services.Implementations
{
    public class MailsService
    {
        private readonly ApplicationDbContext _context;
        public MailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MailsReadDTO>> GetAllAsync()
        {
            var result = await _context.Correos
                .Where(c => !c.isDeleted)
                .Select(c => new MailsReadDTO
                {
                    Id = c.Id,
                    CorreoDireccion = c.CorreoDireccion,
                    ClientesId  = c.ClientesId,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem

                })
                .ToListAsync();

            return result;
        }

        public async Task<MailsReadDTO> GetByIdAsync(int id)
        {
            var result = await _context.Correos
                .Where(c => c.Id == id && !c.isDeleted)
                .Select(c => new MailsReadDTO
                {
                    Id = c.Id,
                    CorreoDireccion = c.CorreoDireccion,
                    ClientesId = c.ClientesId,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem

                }).FirstOrDefaultAsync();

            if (result == null)
                throw new ApplicationException($"Seguimiento con Id {id} no encontrado");

            return result;
        }

        public async Task AddAsync(MailsCreateDTO dto)
        {
            var result = new Mails
            {
                Id = dto.Id,
                CorreoDireccion = dto.CorreoDireccion,
                ClientesId = dto.ClientesId,
                isActive = dto.Activo,
                HighSystem = dto.HoraAlta
            };

            await _context.Correos.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, MailsCreateDTO dto)
        {
            var result = await _context.Correos.FindAsync(id);
            result.CorreoDireccion = dto.CorreoDireccion;
            result.ClientesId = dto.ClientesId;
            result.isActive = dto.Activo;

            _context.Correos.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Correos.FindAsync(id);

            if (result == null)
                throw new ApplicationException("No se encontro Acuerdo");

            result.isDeleted = true;
            result.isActive = false;

            _context.Correos.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
