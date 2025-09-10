using Mapster;
using Microsoft.AspNetCore.Mvc;
using Proyecto3.DTOs;
using Proyecto3.Services.Implementations;
using Proyecto3.Services.Interfaces;
using System.Threading.Tasks;

namespace Proyecto3.Controllers
{
    public class MailsController : Controller
    {
        private readonly IMailsService _mailsController;

        public MailsController(IMailsService mailsController)
        {
            _mailsController = mailsController;
        }

        public async Task<IActionResult> Index()
        {
            var mails = await _mailsController.GetAllAsync();
            return View(mails);
        }

        //Mostrar Cliente por ID
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _mailsController.GetByIdAsync(id);
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
                MailsReadDTO result = await _mailsController.GetByIdAsync(id);
                var result2 = result.Adapt < MailsCreateDTO>();

                return View(result2);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error al modificar registro";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Create(MailsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mailsController.AddAsync(result);
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
        public async Task<IActionResult> Edit(MailsCreateDTO result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mailsController.UpdateAsync(result.Id, result);
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
                var result = await _mailsController.GetByIdAsync(id);
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
                await _mailsController.DeleteAsync(id);
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
