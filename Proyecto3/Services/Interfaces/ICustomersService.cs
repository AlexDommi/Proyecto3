using Microsoft.AspNetCore.Mvc;
using Proyecto3.DTOs;

namespace Proyecto3.Services.Interfaces
{
    public interface ICustomersService : IGenericService<CustomersCreatedDTO,CustomersReadDTO,CustomersCreatedDTO>
    {
    }
}
