using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.DTOs;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Controllers
{
    public class DirectionsController : Controller
    {
        private readonly IDirectionsServices _directionService;
        private readonly ICustomersService _customersService;
        public DirectionsController(
            IDirectionsServices directionsServices,
            ICustomersService customersServices
            )
        {
            _directionService = directionsServices;
            _customersService = customersServices;
        }

        // Acción para obtener todos los productos
        public async Task<IActionResult> Index()
        {
            var direcciones = await _directionService.GetAllAsync();
            return View(direcciones);
        }

        // Acción para ver los detalles de un producto
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _directionService.GetByIdAsync(id);
                return View(result);

            }
            catch (ApplicationException ex)
            {
                TempData["ErrorMessage"] = "Error";
                return RedirectToAction("Index");
            }
        }


        // Acción para mostrar el formulario de agregar producto
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clientes = await _customersService.GetAllAsync();
            ViewBag.Clientes = new SelectList(clientes, "Id", "ClienteNombre");

            return View();
            }

        // Acción para procesar el formulario de agregar producto
        [HttpPost]
        public async Task<IActionResult> Create(DirectionsCreateDTO directionsCreateDTO)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(AgreementsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //throw new ApplicationException("Ejemplo");
                    await _directionService.AddAsync(directionsCreateDTO);
                    TempData["SuccessMessage"] = "Registro exitoso";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Error al registrar";
            }

            var clientes = await _customersService.GetAllAsync();
            ViewBag.Clientes = new SelectList(clientes, "Id", "ClienteNombre");

            return View(directionsCreateDTO);
        }

        // Acción para mostrar el formulario de edición de un producto
        // GET: Edit
        public async Task<IActionResult> Edit(int id)
            {
            try
            {
                var directionsDTO = await _directionService.GetByIdAsync(id);
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

        // POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(DirectionsCreateDTO directionsCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _directionService.UpdateAsync(directionsCreateDTO.Id, directionsCreateDTO);
                    TempData["SuccessMessage"] = "Registro actualizado exitosamente";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Fallo al actualizar";
            }

            // Volvemos a cargar la lista de clientes para el select
            directionsCreateDTO.Clientes = await _customersService.GetAllAsync();

            return View(directionsCreateDTO);
        }


        // Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var product = await _directionService.GetByIdAsync(id);
                return View(product); // Muestra la vista de confirmación
            }
            catch (ApplicationException e)
            {
                TempData["ErrorMessage"] = "No se pudo borrar el registro";
                return RedirectToAction("Index");
            }
        }


        // Acción para eliminar un producto
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _directionService.DeleteAsync(id);
                TempData["SuccessMessage"] = "Registro borrado con exito";
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "No se pudo borrar el registro";
            }

            return RedirectToAction("Index");
        }
    }
}

