using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Services.Implementations
{
    public class AgreementsService : IAgreementsService
    {
        private readonly ApplicationDbContext _context;
        public AgreementsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgreementsReadDTO>> GetAllAsync()
        {
            var result = await _context.Acuerdos
                .Where(c => !c.isDeleted)
                .Select(c => new AgreementsReadDTO
                {
                    Id = c.Id,
                    AcuerdoFecha = c.AcuerdoFecha,
                    AcuerdoPago = c.AcuerdoPago,
                    ClientesId = c.ClientesId,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem

                })
                .ToListAsync();

            return result;
        }

        public async Task<AgreementsReadDTO> GetByIdAsync(int id)
        {
            var result = await _context.Acuerdos
                .Where(c => c.Id == id && !c.isDeleted)
                .Select(c => new AgreementsReadDTO
                {
                    Id = c.Id,
                    AcuerdoFecha = c.AcuerdoFecha,
                    AcuerdoPago = c.AcuerdoPago,
                    ClientesId = c.ClientesId,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem

                }).FirstOrDefaultAsync();

            if (result == null)
                throw new ApplicationException($"Acuerdo con Id {id} no encontrado");

            return result;
        }

        public async Task AddAsync(AgreementsCreateDTO dto)
        {
            var result = new Agreements
            {
                AcuerdoFecha = dto.AcuerdoFecha,
                AcuerdoPago = dto.AcuerdoPago,
                ClientesId = dto.ClientesId,
                isActive = dto.Activo,
                HighSystem = dto.HoraAlta
            };

            await _context.Acuerdos.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AgreementsCreateDTO dto)
        {
            var result = await _context.Acuerdos.FindAsync(id);
            result.AcuerdoFecha = dto.AcuerdoFecha;
            result.AcuerdoPago = dto.AcuerdoPago;
            result.ClientesId = dto.ClientesId;
            result.isActive = dto.Activo;

            _context.Acuerdos.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Acuerdos.FindAsync(id);

            if (result == null)
                throw new ApplicationException("No se encontro Acuerdo");

            result.isDeleted = true;
            result.isActive = false;

            _context.Acuerdos.Remove(result);
            await _context.SaveChangesAsync();
        }

        
    }
}
