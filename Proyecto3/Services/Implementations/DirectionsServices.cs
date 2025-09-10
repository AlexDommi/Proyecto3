using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Services.Implementations
{
    public class DirectionsServices : IDirectionsServices
    {
        private readonly ApplicationDbContext _context;

        public DirectionsServices(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public async Task<IEnumerable<DirectionsReadDTO>> GetAllAsync()
        {
            var result = await _context.Direcciones
                .Where(c => !c.isDeleted)
                .Select(c => new DirectionsReadDTO
                {
                    Id = c.Id,
                    ClientesId = c.ClientesId,
                    DireccionCalle = c.DireccionCalle,
                    DireccionColonia = c.DireccionColonia,
                    DireccionCodigoPostal = c.DireccionCodigoPostal,
                    DireccionEntreCalle1  = c.DireccionEntreCalle1,
                    DireccionEntreCalle2 = c.DireccionEntreCalle2,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem
                    
                })
                .ToListAsync();

            return result;
        }

        public async Task<DirectionsReadDTO> GetByIdAsync(int id)
        {
            var result = await _context.Direcciones
                .Where(c => c.Id == id && !c.isDeleted)
                .Select(p => new DirectionsReadDTO
                {
                    Id = p.Id,
                    DireccionCalle = p.DireccionCalle,
                    DireccionColonia = p.DireccionColonia,
                    DireccionCodigoPostal = p.DireccionCodigoPostal,
                    DireccionEntreCalle1 = p.DireccionEntreCalle1,
                    DireccionEntreCalle2 = p.DireccionEntreCalle2,
                    Activo = p.isActive,
                    HoraAlta = p.HighSystem,
                    ClientesId = p.ClientesId

                }).FirstOrDefaultAsync();

            if (result == null)
                throw new ApplicationException($"Cliente con Id {id} no encontrado");

            return result;
        }

        public async Task AddAsync(DirectionsCreateDTO AddDTO)
        {
            var result = new Directions
            {
                ClientesId = AddDTO.ClientesId,
                DireccionCalle = AddDTO.DireccionCalle,
                DireccionColonia = AddDTO.DireccionColonia,
                DireccionEntreCalle1 = AddDTO.DireccionEntreCalle1,
                DireccionEntreCalle2 = AddDTO.DireccionEntreCalle2,
                DireccionCodigoPostal = AddDTO.DireccionCodigoPostal,
                Id = AddDTO.Id,
                HighSystem = AddDTO.HoraAlta,
                isActive = AddDTO.Activo,
            };

            await _context.Direcciones.AddAsync(result);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Direcciones.FindAsync(id);

            if (result == null)
                throw new ApplicationException("No se encontro cliente");

            result.isDeleted = true;
            result.isActive = false;

            _context.Direcciones.Remove(result);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAsync(int id, DirectionsCreateDTO dto)
        {
            var result = await _context.Direcciones.FindAsync(id);
            result.DireccionCalle = dto.DireccionCalle;
            result.DireccionEntreCalle1 = dto.DireccionEntreCalle1;
            result.DireccionEntreCalle2 = dto.DireccionEntreCalle2;
            result.DireccionCodigoPostal = dto.DireccionCodigoPostal;
            result.DireccionColonia = dto.DireccionColonia;
            result.ClientesId = dto.ClientesId;
            result.isActive = dto.Activo;
            result.HighSystem = dto.HoraAlta;

            _context.Direcciones.Update(result);
            await _context.SaveChangesAsync();
        }
    }
}
