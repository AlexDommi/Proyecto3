using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto3.DTOs;
using Proyecto3.Services.Implementations;
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
                TempData["ErrorMessage"] = Messages.Error.DetailNotFound;
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
            try
            {
                if (ModelState.IsValid)
                {
                    await _directionService.AddAsync(directionsCreateDTO);
                    TempData["SuccessMessage"] = Messages.Success.DirectionsCreated;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordCreatedError;
            }

            var clientes = await _customersService.GetAllAsync();
            ViewBag.Clientes = new SelectList(clientes, "Id", "ClienteNombre");

            return View(directionsCreateDTO);
        }

        // Acción para mostrar el formulario de edición de un producto
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var directionsDTO = await _directionService.GetByIdAsync(id);
            var clientes = await _customersService.GetAllAsync();

            var directionsCreateDto = directionsDTO.Adapt<DirectionsCreateDTO>();
            // asigna la lista de clientes al DTO
            directionsCreateDto.Clientes = clientes;

            return View(directionsCreateDto);
        }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DirectionsCreateDTO directionsCreateDTO)
        {
            if (ModelState.IsValid)
            {
                await _directionService.UpdateAsync(directionsCreateDTO.Id, directionsCreateDTO);
                return RedirectToAction("Index");
            }

            // recarga lista para el select antes de retornar la vista
            directionsCreateDTO.Clientes = await _customersService.GetAllAsync();
            return View(directionsCreateDTO);
        }


        // Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var product = await _directionService.GetByIdAsync(id);
                return View(product); 
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
                await _directionService.DeleteAsync(id);
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

