using Proyecto3.Data;
using Proyecto3.DTOs;
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
            throw new NotImplementedException();
        }

        public Task<AgreementsReadDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(AgreementsCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, AgreementsCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
