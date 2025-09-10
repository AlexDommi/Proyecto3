namespace Proyecto3.Services.Interfaces
{
    public interface IGenericService<TCreateDTO, TReadDTO, TUpdateDTO>
        where TCreateDTO : class
        where TReadDTO : class, new()
        where TUpdateDTO : class
    {

        Task<IEnumerable<TReadDTO>> GetAllAsync();
        Task<TReadDTO> GetByIdAsync(int id);
        Task AddAsync(TCreateDTO dto);
        Task UpdateAsync(int id, TUpdateDTO dto);
        Task DeleteAsync(int id);


    }
}
