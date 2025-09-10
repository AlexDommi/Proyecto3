using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;

namespace Proyecto3.Services.Implementations
{
    public class ContactsService
    {
        private readonly ApplicationDbContext _context;
        public ContactsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactsReadDTO>> GetAllAsync()
        {
            var contacts = await _context.Contactos
                .Where(c => !c.isDeleted)
                .Select(c => new ContactsReadDTO
                {
                    Id = c.Id,
                    ContactoTelefono = c.ContactoTelefono,
                    ClientesId = c.ClientesId,
                    Activo = c.isActive,
                    HoraAlta = c.HighSystem
                })
                .ToListAsync();

            return contacts;
        }

        public async Task<ContactsReadDTO> GetByIdAsync(int id)
        {
            var contacts = await _context.Contactos
                .Where(c => c.Id == id && !c.isDeleted)
                .Select(p => new ContactsReadDTO
                {
                    ClientesId = p.ClientesId,
                    ContactoTelefono = p.ContactoTelefono,
                    Activo = p.isActive,
                    HoraAlta = p.HighSystem
                }).FirstOrDefaultAsync();

            if (contacts == null)
                throw new ApplicationException($"Registro con Id {id} no encontrado");

            return contacts;
        }

        public async Task AddAsync(ContactsCreateDTO AddDTO)
        {
            var contacts = new Contacts
            {
                ContactoTelefono = AddDTO.ContactoTelefono,
                ClientesId = AddDTO.ClientesId,
                isActive = AddDTO.Activo,
                HighSystem = AddDTO.HoraAlta

            };

            await _context.Contactos.AddAsync(contacts);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var contacts = await _context.Contactos.FindAsync(id);

            if (contacts == null)
                throw new ApplicationException("No se encontro el registro");

            contacts.isDeleted = true;
            contacts.isActive = false;

            _context.Contactos.Remove(contacts);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAsync(int id, ContactsCreateDTO dto)
        {
            var contacts = await _context.Contactos.FindAsync(id);
            contacts.ContactoTelefono = dto.ContactoTelefono;
            contacts.ClientesId = dto.ClientesId;
            contacts.isActive = dto.Activo;

            _context.Contactos.Update(contacts);
            await _context.SaveChangesAsync();
        }
    }
}
