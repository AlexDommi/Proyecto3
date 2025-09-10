using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.DTOs;
using Proyecto3.Services.Implementations;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService _ContactsService;
        private readonly ICustomersService _customersService;

        public ContactsController(
            IContactsService contactsService,
            ICustomersService customersServices
            )
        {
            _ContactsService = contactsService;
            _customersService = customersServices;
        }

        //Accion para obtener todos losclientes
        public async Task<IActionResult> Index()
        {
            var contacts = await _ContactsService.GetAllAsync();
            return View(contacts);
        }

        //Mostrar Cliente por ID
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var contacts = await _ContactsService.GetByIdAsync(id);
                return View(contacts);

            }
            catch (ApplicationException ex)
            {
                TempData["ErrorMessage"] = "No se encontro el detalle";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var directionsDTO = await _ContactsService.GetByIdAsync(id);
                var clientes = await _customersService.GetAllAsync();

                var directionsCreateDto = directionsDTO.Adapt<DirectionsCreateDTO>();

                // Pasamos la lista completa
                directionsCreateDto.Clientes = clientes;

                return View(directionsCreateDto);
            }
            catch (ApplicationException)
            {
                TempData["ErrorMessage"] = "No se pudo cargar el registro";
                return RedirectToAction("Index");
            }
        }

        // Acción para mostrar el formulario de agregar producto
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clientes = await _ContactsService.GetAllAsync();
            ViewBag.Clientes = new SelectList(clientes, "Id", "ClienteNombre");

            return View();
        }

        // Acción para procesar el formulario de agregar producto
        [HttpPost]
        public async Task<IActionResult> Create(ContactsCreateDTO directionsCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //throw new ApplicationException("Ejemplo");
                    await _ContactsService.AddAsync(directionsCreateDTO);
                    TempData["SuccessMessage"] = "Registro exitoso";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Error al registrar";
            }

            var clientes = await _ContactsService.GetAllAsync();
            ViewBag.Clientes = new SelectList(clientes, "Id", "ClienteNombre");

            return View(directionsCreateDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(ContactsCreateDTO contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _ContactsService.UpdateAsync(contacts.Id, contacts);
                    TempData["SuccessMessage"] = "Registro actualizado existosamente";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
            }

            return View(contacts);
        }

        // Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var contacts = await _ContactsService.GetByIdAsync(id);
                return View(contacts); // Muestra la vista de confirmación
            }
            catch (ApplicationException e)
            {
                TempData["ErrorMessage"] = "Error al eliminar el registro";
                return RedirectToAction("Index");
            }
        }


        // Acción para eliminar un producto
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ContactsService.DeleteAsync(id);
                TempData["SuccessMessage"] = "Registro eliminado";
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Error al eliminar el registro";
            }

            return RedirectToAction("Index");
        }
    }
}
