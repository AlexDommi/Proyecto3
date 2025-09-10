using EcommerceMVC.Constants;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proyecto3.DTOs;
using Proyecto3.Services.Interfaces;

namespace Proyecto3.Controllers
{
    public class AgreementsController : Controller
    {
        private readonly IAgreementsService _agreementsService;

        public AgreementsController(
            IAgreementsService agreementsService
            )
        {
            _agreementsService = agreementsService;
        }

        public async Task<IActionResult> Index()
        {
            var agreements = await _agreementsService.GetAllAsync();
            return View(agreements);
        }


        //Mostrar Cliente por ID
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _agreementsService.GetByIdAsync(id);
                return View(result);

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
                AgreementsReadDTO result = await _agreementsService.GetByIdAsync(id);
                var result2 = result.Adapt<AgreementsCreateDTO>();

                return View(result2);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordUpdateError;
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(AgreementsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _agreementsService.AddAsync(result);
                    TempData["SuccessMessage"] = Messages.Error.RecordUpdateError;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = Messages.Error.RecordCreatedError;
            }
            return View(result);
        }

        // Acción para procesar el formulario de edición de producto
        [HttpPost]
        public async Task<IActionResult> Edit(AgreementsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _agreementsService.UpdateAsync(result.Id, result);
                    TempData["SuccessMessage"] = Messages.Success.RecordCreated;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = Messages.Error.RecordUpdateError;
            }

            return View(result);
        }

        // Acción para mostrar la confirmación de eliminación
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                var result = await _agreementsService.GetByIdAsync(id);
                return View(result); 
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
                await _agreementsService.DeleteAsync(id);
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
