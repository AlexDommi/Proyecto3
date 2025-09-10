using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proyecto3.DTOs;
using Proyecto3.Services.Implementations;
using Proyecto3.Services.Interfaces;
using System.Threading.Tasks;

namespace Proyecto3.Controllers
{
    public class FollowupsController : Controller
    {
        private readonly IFollowupsService _followupsService;

        public FollowupsController(IFollowupsService followupsService)
        {
            _followupsService = followupsService;
        }

        public async Task<IActionResult> Index()
        {
            var followups = await _followupsService.GetAllAsync();
            return View(followups);
        }

        //Mostrar Cliente por ID
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _followupsService.GetByIdAsync(id);
                return View(result);

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
                FolloupsReadDTO result = await _followupsService.GetByIdAsync(id);
                var result2 = result.Adapt<FollowupsCreateDTO>();

                return View(result2);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(FollowupsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _followupsService.AddAsync(result);
                    TempData["SuccessMessage"] = "Registro agregado exitosamente!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Error al crear el registro";
            }
            return View(result);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(FollowupsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _followupsService.UpdateAsync(result.Id, result);
                    TempData["SuccessMessage"] = "Registro actualizado existosamente";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
            }

            return View(result);
        }

        // Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var result = await _followupsService.GetByIdAsync(id);
                return View(result); // Muestra la vista de confirmación
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
                await _followupsService.DeleteAsync(id);
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
