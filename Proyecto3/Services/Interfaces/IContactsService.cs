using Proyecto3.DTOs;

namespace Proyecto3.Services.Interfaces
{
    public interface IContactsService : IGenericService<ContactsCreateDTO, ContactsReadDTO, ContactsCreateDTO>
    {
    }
}
