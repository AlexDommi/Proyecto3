using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;

namespace Proyecto3.Services.Implementations
{
    public class FollowupsService
    {
        private readonly ApplicationDbContext _context;
        public FollowupsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FolloupsReadDTO>> GetAllAsync()
        {
            var result = await _context.Seguimientos
                .Where(c => !c.isDeleted)
                .Select(c => new FolloupsReadDTO
                {
                    Id = c.Id,
                    SeguimientoDescripcion = c.SeguimientoDescripcion,
                    SeguimientoFecha = c.SeguimientoFecha,
                    ClientesId = c.Id,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem

                })
                .ToListAsync();

            return result;
        }

        public async Task<FolloupsReadDTO> GetByIdAsync(int id)
        {
            var result = await _context.Seguimientos
                .Where(c => c.Id == id && !c.isDeleted)
                .Select(c => new FolloupsReadDTO
                {
                    Id = c.Id,
                    SeguimientoDescripcion = c.SeguimientoDescripcion,
                    SeguimientoFecha = c.SeguimientoFecha,
                    ClientesId = c.Id,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem

                }).FirstOrDefaultAsync();

            if (result == null)
                throw new ApplicationException($"Seguimiento con Id {id} no encontrado");

            return result;
        }

        public async Task AddAsync(FollowupsCreateDTO dto)
        {
            var result = new Followups
            {
                Id = dto.Id,
                SeguimientoDescripcion = dto.SeguimientoDescripcion,
                SeguimientoFecha = dto.SeguimientoFecha,
                ClientesId = dto.Id,
                isActive = dto.Activo,
                HighSystem = dto.HoraAlta
            };

            await _context.Seguimientos.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, FollowupsCreateDTO dto)
        {
            var result = await _context.Seguimientos.FindAsync(id);
            result.SeguimientoDescripcion = dto.SeguimientoDescripcion;
            result.SeguimientoFecha = dto.SeguimientoFecha;
            result.ClientesId = dto.ClientesId;
            result.isActive = dto.Activo;

            _context.Seguimientos.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Seguimientos.FindAsync(id);

            if (result == null)
                throw new ApplicationException("No se encontro Acuerdo");

            result.isDeleted = true;
            result.isActive = false;

            _context.Seguimientos.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
