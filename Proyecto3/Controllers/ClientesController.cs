using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.DTOs;
using Proyecto3.Models;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ICustomersService _clientesService;

        public ClientesController(
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
                CustomersReadDTO clientes = await _clientesService.GetByIdAsync(id);
                var clientesdto = clientes.Adapt<CustomersCreatedDTO>();

                return View(clientesdto);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(CustomersCreatedDTO altaClientesDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientesService.AddAsync(altaClientesDTO);
                    TempData["SuccessMessage"] = "Cliente agregado exitosamente!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Error al crear el cliente";
            }
            return View(altaClientesDTO);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(CustomersCreatedDTO altaClientesDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _clientesService.UpdateAsync(altaClientesDTO.Id, altaClientesDTO);
                    TempData["SuccessMessage"] = "Registro actualizado existosamente";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
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
                await _clientesService.DeleteAsync(id);
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
