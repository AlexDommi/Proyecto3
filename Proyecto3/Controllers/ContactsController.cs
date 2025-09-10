using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proyecto3.DTOs;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService _ContactsService;

        public ContactsController(
            IContactsService contactsService
            )
        {
            _ContactsService = contactsService;
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
                TempData["ErrorMessage"] = Messages.Error.DetailNotFound;
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ContactsReadDTO contacts = await _ContactsService.GetByIdAsync(id);
                var contactsdto = contacts.Adapt<ContactsCreateDTO>();

                return View(contactsdto);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(ContactsCreateDTO contacts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _ContactsService.AddAsync(contacts);
                    TempData["SuccessMessage"] = Messages.Success.RecordCreated;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = Messages.Error.CustomersCreateError;
            }
            return View(contacts);
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
                    TempData["SuccessMessage"] = Messages.Success.RecordUpdated;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordUpdateError;
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
                TempData["ErrorMessage"] = Messages.Error.RecordDeleteError;
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
                TempData["SuccessMessage"] = Messages.Success.RecordDeleted;
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordDeleteError;
            }

            return RedirectToAction("Index");
        }
    }
}
