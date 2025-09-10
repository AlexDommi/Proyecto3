using EcommerceMVC.Constants;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.DTOs;
using Proyecto3.Models;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _clientesService;

        public CustomersController(
            ICustomersService clientesService
            )
        {
            _clientesService = clientesService;
        }

        //Accion para obtener todos losclientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _clientesService.GetAllAsync();
            return View(clientes);
        }

        //Mostrar Cliente por ID
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var cliente = await _clientesService.GetByIdAsync(id);
                return View(cliente);
                return PartialView("_Details", cliente);

            }
            catch (ApplicationException ex)
            {
                TempData["ErrorMessage"] = Messages.Error.DetailNotFound;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                CustomersReadDTO clientes = await _clientesService.GetByIdAsync(id);
                var clientesdto = clientes.Adapt<CustomersCreateDTO>();

                return View(clientesdto);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordUpdateError;
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(CustomersCreateDTO altaClientesDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientesService.AddAsync(altaClientesDTO);
                    TempData["SuccessMessage"] = Messages.Success.CustomersCreated;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = Messages.Error.CustomersCreateError;
            }
            return View(altaClientesDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(CustomersCreateDTO altaClientesDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientesService.UpdateAsync(altaClientesDTO.Id, altaClientesDTO);
                    TempData["SuccessMessage"] = Messages.Success.RecordUpdated;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.CustomersCreateError;
            }

            return View(altaClientesDTO);
        }

        // Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var product = await _clientesService.GetByIdAsync(id);
                return View(product); // Muestra la vista de confirmación
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
                await _clientesService.DeleteAsync(id);
                TempData["SuccessMessage"] = Messages.Error.RecordDeleteError;
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordDeleteError;
            }

            return RedirectToAction("Index");
        }
    }
}
