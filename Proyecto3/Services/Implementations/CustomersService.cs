using Proyecto3.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proyecto3.Data;
using Proyecto3.DTOs;
using Proyecto3.Models;
using Proyecto3.Services.Interfaces;
using Proyecto3.Settings;

namespace Proyecto3.Services.Implementations
{
    public class CustomersService : ICustomersService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UploadSettings _uploadSettings;
        public CustomersService(ApplicationDbContext context, IWebHostEnvironment env, IOptions<UploadSettings> uploadSettings)
        {
            _context = context;
            _env = env;
            _uploadSettings = uploadSettings.Value;
        }

        public async Task<IEnumerable<CustomersReadDTO>> GetAllAsync()
        {
            var clientes = await _context.Clientes
                .Where(c => !c.isDeleted)
                .Select(c => new CustomersReadDTO {
                    Id = c.Id,
                    ClienteNombre = c.ClienteNombre,
                    ClienteApellidos = c.ClienteApellidos,
                    LogoUrl = c.LogoUrl,
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
                    LogoUrl = p.LogoUrl,
                    Activo = p.isActive,
                    HoraAlta = p.HighSystem
                }).FirstOrDefaultAsync();

            if (clienteid == null)
                throw new ApplicationException($"Cliente con Id {id} no encontrado");

            return clienteid;
        }

        public async Task AddAsync(CustomersCreateDTO AddDTO)
        {
            var urlImagen = await UploadImage(AddDTO.File);

            var cliente = new Customers
            {
                Id = AddDTO.Id,
                ClienteNombre = AddDTO.ClienteNombre,
                ClienteApellidos = AddDTO.ClienteApellidos,
                LogoUrl = urlImagen
            };

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

        }
        private async Task<string> UploadImage(IFormFile file)
        {
            ValidateFile(file);

            string _customPath = Path.Combine(_env.WebRootPath, _uploadSettings.UploadDirectory);

            if (!Directory.Exists(_customPath))   // Crear el directorio si no existe
            {
                Directory.CreateDirectory(_customPath);
            }

            // Generar el nombre único del archivo
            var fileName = Path.GetFileNameWithoutExtension(file.FileName)
                            + Guid.NewGuid().ToString()
                            + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_customPath, fileName);

            // Guardar el archivo
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retornar la ruta relativa o completa, según sea necesario
            return $"/{_uploadSettings.UploadDirectory}/{fileName}";
        }
        private void ValidateFile(IFormFile file)
        {
            var permittedExtensions = _uploadSettings.AllowedExtensions
                                 .Split(',')
                                 .Select(e => e.Trim().ToLowerInvariant())
                                 .ToArray();

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            Console.WriteLine($"Archivo subido: {file.FileName}");
            Console.WriteLine($"Extensión detectada: {extension}");
            Console.WriteLine($"Extensiones permitidas: {string.Join(", ", permittedExtensions)}");
            if (!permittedExtensions.Contains(extension))
            {
                throw new NotSupportedException(Messages.Validation.UnSupportedFileType);
            }
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
        public async Task UpdateAsync(int id, CustomersCreateDTO dto)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            clientes.ClienteNombre= dto.ClienteNombre;
            clientes.ClienteApellidos= dto.ClienteApellidos;

            if (dto.File != null && dto.File.Length > 0)
            {
                var urlImagen = await UploadImage(dto.File); // reutiliza tu método existente
                clientes.LogoUrl = urlImagen;
            }

            clientes.isActive = dto.Activo;
            
            _context.Clientes.Update(clientes);
            await _context.SaveChangesAsync();
        }
    }
}
